using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.InteropServices;

namespace Enka_IT_Management
{
    public partial class CallItForm : Form
    {
        public string UserName { get; set; }
        
        public CallItForm()
        {
            InitializeComponent();
        }

        private void CallItForm_Load(object sender, EventArgs e)
        {
            lbl_db_name.Text = UserName;
        }

        public Task ShowTimedMessageBox(string text, string caption, int timeout)
        {
            return Task.Run(() =>
            {
                var form = new Form()
                {
                    Width = 300,
                    Height = 100,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen,
                    FormBorderStyle = FormBorderStyle.FixedDialog
                };

                Label messageLabel = new Label()
                {
                    Text = text,
                    Dock = DockStyle.Fill,
                    TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                };

                form.Controls.Add(messageLabel);

                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = timeout;
                timer.Tick += (sender, e) =>
                {
                    timer.Stop();
                    form.Close();
                };

                timer.Start();
                form.ShowDialog();
            });
        }

        private void InsertCallItRecord(string name, string reason, bool read, string imagePath = null)
        {
            string connectionString = "Server=192.168.10.8;Database=test;User Id=test;Password=test;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO dbo.callit (name, reason, date, [read], image) VALUES (@name, @reason, @date, @read, @image)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@reason", reason);
                        command.Parameters.AddWithValue("@date", DateTime.Now);
                        command.Parameters.AddWithValue("@read", read);

                        command.Parameters.AddWithValue("@image", (object)imagePath ?? DBNull.Value);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Yardım talebiniz alındı. Geri dönüş sağlanacaktır.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanına kayıt eklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private bool CanSubmitNewCall(string name)
        {
            string connectionString = "Server=192.168.10.8;Database=test;User Id=test;Password=test;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT MAX(date) FROM dbo.callit WHERE name = @name";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);

                        var lastCallTime = command.ExecuteScalar();

                        if (lastCallTime != DBNull.Value)
                        {
                            DateTime lastCall = Convert.ToDateTime(lastCallTime);
                            TimeSpan timeSinceLastCall = DateTime.Now - lastCall;

                            if (timeSinceLastCall.TotalMinutes < 1)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Zaman kontrolü yapılırken bir hata oluştu: " + ex.Message);
            }

            return true;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (txt_reason.Text.Trim().Length < 12)
            {
                ShowTimedMessageBox("Lütfen 12 karakterden daha uzun bir sebep giriniz.", "Karakter Hatası", 3000);
            }
            else
            {
                if (!CanSubmitNewCall(lbl_db_name.Text))
                {
                    ShowTimedMessageBox("Son çağrıdan sonra 10 dakika geçmedi. Lütfen daha sonra tekrar deneyin.", "Zaman Kısıtlaması", 3000);
                    return;
                }

                try
                {
                    if (!string.IsNullOrEmpty(selectedImagePath))
                    {
                        string serverFilePath = UploadImageToServer(selectedImagePath);

                        InsertCallItRecord(lbl_db_name.Text, txt_reason.Text, false, serverFilePath);
                    }
                    else
                    {
                        InsertCallItRecord(lbl_db_name.Text, txt_reason.Text, false);
                    }

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }
        }

        private string selectedImagePath = "";

        private void btn_upload_image_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Bir resim seçin";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = openFileDialog.FileName;
                    lbl_image_name.Text = Path.GetFileName(selectedImagePath);
                }
            }
        }

        [DllImport("mpr.dll")]
        private static extern int WNetAddConnection2(ref NETRESOURCE lpNetResource, string lpPassword, string lpUsername, int dwFlags);

        [DllImport("mpr.dll")]
        private static extern int WNetCancelConnection2(string lpName, uint dwFlags, bool fForce);

        [StructLayout(LayoutKind.Sequential)]
        private struct NETRESOURCE
        {
            public int dwScope;
            public int dwType;
            public int dwDisplayType;
            public int dwUsage;
            public string lpLocalName;
            public string lpRemoteName;
            public string lpComment;
            public string lpProvider;
        }

        private void ConnectToNetworkDrive(string networkPath, string username, string password)
        {
            NETRESOURCE nr = new NETRESOURCE
            {
                dwType = 1,
                lpLocalName = null,
                lpRemoteName = networkPath,
                lpProvider = null
            };

            WNetCancelConnection2(networkPath, 0, true);

            int result = WNetAddConnection2(ref nr, password, username, 0);

            if (result != 0)
            {
                throw new Exception("Ağ bağlantısı başarısız oldu. Hata kodu: " + result);
            }
        }

        private string UploadImageToServer(string localImagePath)
        {
            string serverDirectory = @"\\192.168.10.8\C$\Users\administrator.ENKA\Desktop\qs_image\";
            string username = @"test";
            string password = "test";

            string fileName = Path.GetFileName(localImagePath);
            string serverFilePath = Path.Combine(serverDirectory, fileName);

            ConnectToNetworkDrive(serverDirectory, username, password);

            File.Copy(localImagePath, serverFilePath, true);

            return serverFilePath;
        }

        private void SaveImageToDatabase(string serverFilePath)
        {
            string connectionString = "Server=192.168.10.8;Database=test;User Id=test;Password=test;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE dbo.callit SET image = @imagePath WHERE name = @name";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@imagePath", serverFilePath);
                    command.Parameters.AddWithValue("@id", lbl_db_name.Text);

                    command.ExecuteNonQuery();
                }
            }
        }

        private void lbl_resmi_sil_Click(object sender, EventArgs e)
        {
            selectedImagePath = null;
            lbl_image_name.Text = string.Empty;
        }
    }
}
