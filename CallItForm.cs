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
            // Kullanıcı adını form yüklendiğinde label içine yazdırıyoruz
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
            // SQL bağlantı cümlesi (kendi bilgilerinize göre düzenleyin)
            string connectionString = "Server=192.168.10.8;Database=Enka_QS;User Id=emba;Password=manageit41;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL komutu oluşturuluyor, imagePath varsa ekleniyor
                    string query = "INSERT INTO dbo.callit (name, reason, date, [read], image) VALUES (@name, @reason, @date, @read, @image)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Parametreler ekleniyor
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@reason", reason);
                        command.Parameters.AddWithValue("@date", DateTime.Now);
                        command.Parameters.AddWithValue("@read", read);

                        // imagePath varsa ekleniyor, yoksa null geçiliyor
                        command.Parameters.AddWithValue("@image", (object)imagePath ?? DBNull.Value);

                        // Komut çalıştırılıyor
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
            string connectionString = "Server=192.168.10.8;Database=Enka_QS;User Id=emba;Password=manageit41;";

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
            // Eğer sebep 12 karakterden kısa ise uyarı veriyoruz
            if (txt_reason.Text.Trim().Length < 12)
            {
                ShowTimedMessageBox("Lütfen 12 karakterden daha uzun bir sebep giriniz.", "Karakter Hatası", 3000);
            }
            else
            {
                // Zaman kısıtlamasını kontrol ediyoruz
                if (!CanSubmitNewCall(lbl_db_name.Text))
                {
                    ShowTimedMessageBox("Son çağrıdan sonra 10 dakika geçmedi. Lütfen daha sonra tekrar deneyin.", "Zaman Kısıtlaması", 3000);
                    return;
                }

                try
                {
                    // Eğer resim seçilmişse ve yol boş değilse resmi sunucuya yüklüyoruz
                    if (!string.IsNullOrEmpty(selectedImagePath))
                    {
                        string serverFilePath = UploadImageToServer(selectedImagePath);

                        // Resim ve sebebi veritabanına kaydediyoruz
                        InsertCallItRecord(lbl_db_name.Text, txt_reason.Text, false, serverFilePath);
                    }
                    else
                    {
                        // Resim seçilmemişse sadece sebebi kaydediyoruz
                        InsertCallItRecord(lbl_db_name.Text, txt_reason.Text, false);
                    }

                    // Formu kapatıyoruz
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }
        }

        private string selectedImagePath = ""; // Resmin dosya yolunu tutmak için bir değişken

        private void btn_upload_image_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"; // Sadece resim dosyalarını göster
                openFileDialog.Title = "Bir resim seçin";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = openFileDialog.FileName; // Seçilen dosyanın tam yolu bellekte tutuluyor

                    // Resmin adını lbl_image_name etiketine yazıyoruz
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
                dwType = 1, // Disk tipi
                lpLocalName = null, // Lokal harf kullanmak zorunda değiliz
                lpRemoteName = networkPath, // Bağlanmak istediğimiz ağ yolu
                lpProvider = null
            };

            // Mevcut bağlantıyı kesiyoruz, aynı bağlantı var mı diye kontrol için
            WNetCancelConnection2(networkPath, 0, true);

            int result = WNetAddConnection2(ref nr, password, username, 0);

            if (result != 0) // Eğer 0 değilse hata var demektir
            {
                throw new Exception("Ağ bağlantısı başarısız oldu. Hata kodu: " + result);
            }
        }

        private string UploadImageToServer(string localImagePath)
        {
            string serverDirectory = @"\\192.168.10.8\C$\Users\administrator.ENKA\Desktop\qs_image\";
            string username = @"enka\administrator";
            string password = "Enk1987VHT.!";

            string fileName = Path.GetFileName(localImagePath);
            string serverFilePath = Path.Combine(serverDirectory, fileName);

            ConnectToNetworkDrive(serverDirectory, username, password); // Sunucuya bağlanma

            File.Copy(localImagePath, serverFilePath, true); // Dosyayı sunucuya kopyalama

            return serverFilePath; // Kaydedilen dosya yolunu döndür
        }

        private void SaveImageToDatabase(string serverFilePath)
        {
            string connectionString = "Server=192.168.10.8;Database=Enka_QS;User Id=emba;Password=manageit41;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE dbo.callit SET image = @imagePath WHERE name = @name"; // 'id' yerine doğru bir değer koyun

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@imagePath", serverFilePath);
                    command.Parameters.AddWithValue("@id", lbl_db_name.Text); // Kayıtla eşleşen 'id'yi ekleyin

                    command.ExecuteNonQuery();
                }
            }
        }

        private void lbl_resmi_sil_Click(object sender, EventArgs e)
        {
            // Seçilen resim yolunu ve resmin adını sıfırla
            selectedImagePath = null;
            lbl_image_name.Text = string.Empty; // Resim adı etiketi temizleniyor
        }
    }
}
