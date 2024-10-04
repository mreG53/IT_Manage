using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;

namespace Enka_IT_Management
{
    public partial class Start : Form
    {
        private PerformanceCounter cpuCounter;

        [DllImport("psapi.dll", SetLastError = true)]
        private static extern bool EmptyWorkingSet(IntPtr hProcess);

        public Start()
        {
            InitializeComponent();
            //CheckNetworkAndExitIfNotEnka();
            InitializePerformanceCounters();
            LoadCDiskInfo();
            UpdateRamUsage();
            UpdateCpuUsage();

            progressBar1.Visible = false;
            lbl_status.Visible = false;

            string computerName = GetComputerName();
            string localIPAddress = GetEnkaNetworkIPAddress();

            lbl_desktop_name.Text = computerName;
            lbl_local_ip_address.Text = localIPAddress;

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // 1 saniye
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Start_Load(object sender, EventArgs e)
        {
            lbl_what_is_issue.Text = "Aşağıdaki butonlara tıklayarak, sorununuzu çözebilirsiniz. " +
                "\nEğer sorununuz çözülmediyse \"BT Bildir\" butonuyla IT ekibine ticket açabilirsiniz.";

            UpdateCpuUsage();
            Thread.Sleep(2000);

            bool isValidUser = CheckLogin(lbl_desktop_name.Text);

            if (!isValidUser)
            {
                MessageBox.Show("Bilgisayar adı uyuşmadı, program kapatılıyor.");
                Application.Exit();
            }
            else
            {
                ChangeStatusOnline();

                Thread.Sleep(2000);
                DatabaseHelper.InsertLogToDatabase(lbl_desktop_name.Text, lbl_local_ip_address.Text, "Kullanıcı giriş yaptı.", lbl_db_name.Text, lbl_cpu_for_db.Text, lbl_ram_for_db.Text, lbl_disk_for_db.Text, lbl_adisk_for_db.Text);
            }

            string userName = lbl_db_name.Text;
            var buttonsPermissions = new Dictionary<Button, string>
    {
        { btn_connect_printers, "Yazicilara_Baglan" },
        { btn_disk_connect, "Disklere_Baglan" },
        { btn_reset_terminal_service, "Terminal_Servisi_Baslat" },
        { btn_sql_execute, "Tiger_Netlock" },
        { btn_wifi_connect, "Baglanti_Wifi" },
        { btn_wired_connect, "Baglanti_Ethernet" },
        { btn_rt_delete, "Temp_Sil" },
        { btn_reset_printer_queue, "Yazici_Sifirla" },
        { btn_system_repair, "Sistem_Onarim" }
    };
            foreach (var entry in buttonsPermissions)
            {
                Button button = entry.Key;
                string permission = entry.Value;
                if (!CheckPermission(userName, permission))
                {
                    button.Enabled = false;
                }
            }
        }

        private void Start_FormClosed(object sender, FormClosedEventArgs e)
        {
            ChangeStatusOffline();
            DatabaseHelper.InsertLogToDatabase(lbl_desktop_name.Text, lbl_local_ip_address.Text, "Kullanıcı çıkış yaptı.", lbl_db_name.Text, lbl_cpu_for_db.Text, lbl_ram_for_db.Text, lbl_disk_for_db.Text, lbl_disk_available_storage.Text);
        }

        private bool CheckLogin(string desktopName)
        {
            string connectionString = "Server=192.168.10.8;Database=Enka_QS;User Id=emba;Password=manageit41;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT name FROM dbo.users WHERE desktopname = @desktopname";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@desktopname", desktopName);
                        var result = command.ExecuteScalar();

                        if (result != null)
                        {
                            lbl_db_name.Text = result.ToString();
                            return true;
                        }
                        else
                        {
                            lbl_db_name.Text = string.Empty;
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                    return false;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void  ChangeStatusOnline()
        {
            string connectionString = "Server=192.168.10.8;Database=Enka_QS;User Id=emba;Password=manageit41;";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = "UPDATE dbo.users SET status = @status WHERE desktopname = @desktopname";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@status", true);
                cmd.Parameters.AddWithValue("@desktopname", lbl_desktop_name.Text);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ShowTimedMessageBox("Hata:" + ex.Message + "\n" + ex.ToString(), "Hata", 5000);
            }
            finally
            {
                connection.Close();
            }
        }

        public void  ChangeStatusOffline()
        {
            string connectionString = "Server=192.168.10.8;Database=Enka_QS;User Id=emba;Password=manageit41;";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = "UPDATE dbo.users SET status = @status WHERE desktopname = @desktopname";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@status", false);
                cmd.Parameters.AddWithValue("@desktopname", lbl_desktop_name.Text);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ShowTimedMessageBox("Hata:" + ex.Message + "\n" + ex.ToString(), "Hata", 5000);
            }
            finally
            {
                connection.Close();
            }
        }

        private bool CheckPermission(string username, string permissionName)
        {
            bool hasPermission = false;
            string connectionString = "Server=192.168.10.8;Database=Enka_QS;User Id=emba;Password=manageit41;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT COUNT(1) 
            FROM dbo.user_permissions up
            JOIN dbo.users u ON u.id = up.user_id
            JOIN dbo.permissions p ON p.permission_id = up.permission_id
            WHERE u.name = @username AND p.permission_name = @permissionName";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@permissionName", permissionName);

                connection.Open();
                int result = (int)command.ExecuteScalar();
                hasPermission = result > 0;
            }

            return hasPermission;
        }

        private double ConvertBytesToGigabytes(long bytes)
        {
            return (double)bytes / (1024 * 1024 * 1024);
        }

        private async Task<bool> RunCmdCommand(string command)
        {
            return await Task.Run(() =>
            {
                try
                {
                    Process process = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = "cmd.exe",
                            Arguments = "/c " + command,
                            UseShellExecute = true,          // Yönetici izni alabilmek için true
                            CreateNoWindow = false,          // CMD penceresini göster
                            Verb = "runas",                  // Yönetici olarak çalıştır
                            WindowStyle = ProcessWindowStyle.Normal
                        }
                    };

                    process.Start();
                    process.WaitForExit();

                    return process.ExitCode == 0;  // Başarıyla çalıştıysa true döner
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                    return false;  // Hata varsa false döner
                }
            });
        }

        private void LoadCDiskInfo()
        {
            // C sürücüsü için DriveInfo nesnesi
            DriveInfo cDrive = new DriveInfo("C");

            if (cDrive.IsReady)
            {
                // Toplam boyut ve kullanılabilir alan
                long totalSize = cDrive.TotalSize; // Toplam boyut (byte cinsinden)
                long availableSpace = cDrive.AvailableFreeSpace; // Kullanılabilir alan (byte cinsinden)

                // Kullanılan alanı hesapla
                long usedSpace = totalSize - availableSpace;
                double usedPercentage = (double)usedSpace / totalSize * 100; // Yüzde hesaplama

                // Byte'tan GB'ye çevirme
                double totalSizeGB = ConvertBytesToGigabytes(totalSize);
                double availableSpaceGB = ConvertBytesToGigabytes(availableSpace);

                // Label ve ProgressBar'ı güncelle
                progressBarDisk.Value = (int)usedPercentage;
                lblDiskUsage.Text = $"DISK : {usedPercentage:F2}%";
                lbl_disk_available_storage.Text = $"Boş Alan: {availableSpaceGB:F2} GB / {totalSizeGB:F2} GB";
                lbl_disk_for_db.Text = $"{usedPercentage:F2}";
                lbl_adisk_for_db.Text = $"{availableSpaceGB:F2}";
            }
            else
            {
                // Eğer C sürücüsü erişilebilir değilse hata mesajı göster
                lblDiskUsage.Text = "C diski hazır değil veya mevcut değil.";
            }
        }

        private void InitializePerformanceCounters()
        {
            // CPU kullanımı için Performance Counter
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // CPU kullanımını güncelle
            UpdateCpuUsage();

            // RAM kullanımını güncelle
            UpdateRamUsage();
        }

        private void UpdateRamUsage()
        {
            ComputerInfo computerInfo = new ComputerInfo();

            ulong totalPhysicalMemory = computerInfo.TotalPhysicalMemory;
            ulong availablePhysicalMemory = computerInfo.AvailablePhysicalMemory;
            ulong usedMemory = totalPhysicalMemory - availablePhysicalMemory;

            float ramUsagePercentage = (float)usedMemory / totalPhysicalMemory * 100;

            progressBarRAM.Value = (int)ramUsagePercentage;
            lblRamUsage.Text = $"RAM : {ramUsagePercentage:F2}%";
            lbl_ram_for_db.Text = $"{ramUsagePercentage}";

        }

        private void UpdateCpuUsage()
        {
            // CPU kullanımını PerformanceCounter ile alıyoruz
            float cpuUsage = cpuCounter.NextValue();

            // Label ve ProgressBar'ı güncelliyoruz
            progressBarCPU.Value = (int)cpuUsage;
            lblCpuUsage.Text = $"CPU : {cpuUsage:F2}%";
            lbl_cpu_for_db.Text = $"{cpuUsage:F2}";
        }

        private void OptimizeMemory()
        {
            Process[] processes = Process.GetProcesses();

            foreach (Process process in processes)
            {
                try
                {
                    if (!process.HasExited && process.WorkingSet64 > 0)
                    {
                        // İşlem boş çalışma setini serbest bırakır
                        EmptyWorkingSet(process.Handle);
                    }
                }
                catch
                {
                    // Bazı sistem işlemleri üzerinde bu işlemi yapamayabiliriz, bu yüzden hatayı yoksayıyoruz
                }
            }
        }

        private void CleanTemporaryFiles()
        {
            string tempPath = Path.GetTempPath();
            DirectoryInfo tempDirectory = new DirectoryInfo(tempPath);

            foreach (FileInfo file in tempDirectory.GetFiles())
            {
                try
                {
                    file.Delete();
                }
                catch
                {
                    // Silinemeyen dosyaları görmezden geliyoruz
                }
            }

            foreach (DirectoryInfo dir in tempDirectory.GetDirectories())
            {
                try
                {
                    dir.Delete(true); // Alt klasörlerle birlikte sil
                }
                catch
                {
                    // Silinemeyen klasörleri görmezden geliyoruz
                }
            }
        }

        private void CreateShortcut(string targetPath, string shortcutName)
        {
            // Masaüstü yolunu alıyoruz
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string shortcutPath = Path.Combine(desktopPath, $"{shortcutName}.lnk");

            // Windows Script Host aracılığıyla kısayol oluşturma
            Type shellType = Type.GetTypeFromProgID("WScript.Shell");
            dynamic shell = Activator.CreateInstance(shellType);
            dynamic shortcut = shell.CreateShortcut(shortcutPath);

            shortcut.TargetPath = targetPath;
            shortcut.WorkingDirectory = Path.GetDirectoryName(targetPath);
            shortcut.WindowStyle = 1;
            shortcut.Description = $"{shortcutName} kısayolu";

            // Kısayolu kaydediyoruz
            shortcut.Save();
        }

        // clicks

        private void btn_call_it_Click(object sender, EventArgs e)
        {
            CallItForm callItForm = new CallItForm();
            callItForm.UserName = lbl_db_name.Text;
            callItForm.ShowDialog();
        }

        private void btn_reset_printer_queue_Click(object sender, EventArgs e)
        {
            ResetPrinters resetPrinters = new ResetPrinters();
            resetPrinters.ShowDialog();
        }

        private void btn_connect_printers_Click(object sender, EventArgs e)
        {
            InstallPrinterDrivers installPrinterDrivers = new InstallPrinterDrivers();
            installPrinterDrivers.UserName = lbl_db_name.Text;
            installPrinterDrivers.LocalIP = lbl_local_ip_address.Text;
            installPrinterDrivers.DesktopName = lbl_desktop_name.Text;
            installPrinterDrivers.ShowDialog();
        }

        private void btn_reset_terminal_service_Click(object sender, EventArgs e)
        {
            string serviceName = "WMSPlatformTerminalService";
            string machineName = "192.168.10.9";
            string username = $@"enka\administrator";
            string password = "Enk1987VHT.!";


            try
            {
                string managementScope = $@"\\{machineName}\root\cimv2";
                ConnectionOptions options = new ConnectionOptions
                {
                    Username = username,
                    Password = password,
                    Impersonation = ImpersonationLevel.Impersonate,
                    Authentication = AuthenticationLevel.PacketPrivacy,
                };

                ManagementScope scope = new ManagementScope(managementScope, options);
                scope.Connect();

                ObjectQuery query = new ObjectQuery($"SELECT * FROM Win32_Service WHERE Name = '{serviceName}'");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
                ManagementObjectCollection services = searcher.Get();

                foreach (ManagementObject service in services)
                {
                    string currentState = service["State"].ToString();
                    ShowTimedMessageBox($"Servisin mevcut durumu: {currentState}", "Terminal Service", 2000);

                    if (currentState == "Running")
                    {
                        ShowTimedMessageBox("Servis Durduruluyor...", "Terminal Service", 2000);
                        Thread.Sleep(700);
                        service.InvokeMethod("StopService", null);
                    }

                    ShowTimedMessageBox("Servis Başlatılıyor...", "Terminal Service", 2000);
                    Thread.Sleep(700);
                    service.InvokeMethod("StartService", null);
                }
                ShowTimedMessageBox("İşlem başarıyla tamamlandı.", "Terminal Service", 2000);
            }
            catch (Exception ex)
            {
                ShowTimedMessageBox("Hata: " + ex.Message + "\n" + ex.ToString(), "İşlem başarısız", 3000);
            }
            Thread.Sleep(500);
        }

        private void btn_rt_delete_Click(object sender, EventArgs e)
        {
            try
            {
                string exePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DWTFD.exe");

                ProcessStartInfo processInfo = new ProcessStartInfo();
                processInfo.FileName = exePath;
                processInfo.UseShellExecute = true;
                processInfo.Verb = "runas";
                processInfo.WindowStyle = ProcessWindowStyle.Normal;
                Process process = Process.Start(processInfo);
                process.WaitForExit();

                if (process.ExitCode == 0)
                {
                    ShowTimedMessageBox("Programdan çıkılıyor...", "DWTFD", 2000);
                }
                else
                {
                    MessageBox.Show("DWTFD.exe çalıştırılırken bir hata oluştu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void btn_create_shortcut_Click(object sender, EventArgs e)
        {
            CreateShortcut(@"L:\TIGER3ENT\Tiger3Enterprise.exe", "LogoTiger");
            CreateShortcut(@"W:\WMSPlatform.Backoffice.exe", "WMSPlatform.Backoffice");
            CreateShortcut(@"L:\TIGER3ENT\LOGOConnect\PRG\LogoConnect.exe", "LogoConnect");
        }

        private void btn_ram_opt_Click(object sender, EventArgs e)
        {
            try
            {
                ShowTimedMessageBox("RAM Optimize ediliyor...", "RAM", 3000);
                CleanTemporaryFiles();
                OptimizeMemory();

                MessageBox.Show("RAM başarıyla optimize edildi.", "RAM Optimizasyonu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("RAM optimizasyonu sırasında bir hata oluştu: " + ex.Message);
            }
        }

        private async void btn_system_repair_Click(object sender, EventArgs e)
        {
            bool dismSuccess = await RunCmdCommand("DISM /Online /Cleanup-Image /RestoreHealth");
            if (!dismSuccess)
            {
                MessageBox.Show("DISM komutu başarısız oldu, işlem iptal ediliyor.");
                return;
            }
            bool sfcSuccess = await RunCmdCommand("sfc /scannow");
            if (!sfcSuccess)
            {
                MessageBox.Show("SFC komutu başarısız oldu, işlem iptal ediliyor.");
                return;
            }
            DialogResult result = MessageBox.Show("Sistem onarımı tamamlandı, sistemi yeniden başlatmak istiyor musunuz?", "Sistem Onarımı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                await RunCmdCommand("shutdown /r /t 0");
            }
        }



        #region Check Enka Connection
        private void CheckNetworkAndExitIfNotEnka()
        {
            try
            {
                string wifiSSID = GetConnectedWifiSSID();
                if (wifiSSID == "EnkaCivata")
                {
                    return;
                }

                if (IsConnectedToWiredNetwork("enkacivata.local"))
                {
                    return;
                }

                MessageBox.Show("Program sadece EnkaCivata Wi-Fi ağı ya da enkacivata.local kablolu ağı üzerinde çalıştırılabilir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ağ kontrolü sırasında bir hata oluştu: " + ex.Message);
                Environment.Exit(0);
            }
        }

        private bool IsConnectedToWiredNetwork(string dnsSuffix)
        {
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet &&
                    ni.OperationalStatus == OperationalStatus.Up)
                {
                    var ipProperties = ni.GetIPProperties();
                    if (ipProperties.DnsSuffix == dnsSuffix)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion

        #region Timer MessageBox
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
        #endregion

        #region Initialize WNet Add Connection2 API
        [DllImport("mpr.dll")]
        private static extern int WNetAddConnection2(ref NETRESOURCE netResource, string password, string username, int flags);

        [DllImport("mpr.dll")]
        private static extern int WNetCancelConnection2(string lpName, uint dwFlags, bool fForce);

        [StructLayout(LayoutKind.Sequential)]
        public struct NETRESOURCE
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
        #endregion

        #region RunCommand
        private string RunCommand(string command)
        {
            ProcessStartInfo processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.RedirectStandardOutput = true;
            processInfo.UseShellExecute = false;
            processInfo.CreateNoWindow = true;

            Process process = Process.Start(processInfo);
            process.WaitForExit();

            string output = process.StandardOutput.ReadToEnd();
            return output;
        }

        private void RunCommandAsAdmin(string command)
        {
            try
            {
                ProcessStartInfo processInfo = new ProcessStartInfo("cmd.exe", "/c " + command)
                {
                    UseShellExecute = true,
                    Verb = "runas",        
                    CreateNoWindow = true
                };

                Process process = Process.Start(processInfo);
                process.WaitForExit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Komut çalıştırılırken bir hata oluştu: " + ex.Message);
            }
        }
        #endregion

        #region Get LocalIP and ComputerName

        private string GetComputerName()
        {
            return Environment.MachineName;
        }

        private string GetEnkaNetworkIPAddress()
        {
            string localIP = "Bilinmiyor";

            string wifiSSID = GetConnectedWifiSSID();
            if (wifiSSID == "EnkaCivata")
            {
                localIP = GetLocalIPv4Address();
                return localIP;
            }

            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet && ni.OperationalStatus == OperationalStatus.Up)
                {
                    var ipProperties = ni.GetIPProperties();
                    if (ipProperties.DnsSuffix == "enkacivata.local")
                    {
                        foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                            {
                                localIP = ip.Address.ToString();
                                return localIP;
                            }
                        }
                    }
                }
            }

            return localIP;
        }

        private string GetConnectedWifiSSID()
        {
            string ssid = null;
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "netsh",
                    Arguments = "wlan show interfaces",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            process.Start();
            var output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            var lines = output.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            foreach (var line in lines)
            {
                if (line.Trim().StartsWith("SSID"))
                {
                    ssid = line.Split(':')[1].Trim();
                    break;
                }
            }

            return ssid;
        }

        private string GetLocalIPv4Address()
        {
            string localIP = "Bilinmiyor";
            try
            {
                foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (ni.NetworkInterfaceType != NetworkInterfaceType.Loopback && ni.OperationalStatus == OperationalStatus.Up)
                    {
                        foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                            {
                                localIP = ip.Address.ToString();
                                return localIP;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("IP adresi alınırken bir hata oluştu: " + ex.Message);
            }
            return localIP;
        }
        #endregion

        #region Disklere Bağlanma
        private async void btn_disk_connect_Click(object sender, EventArgs e)
        {
            await ConnectToNetworkDrive("L:", @"\\192.168.10.6\logo");
            await ConnectToNetworkDrive("O:", @"\\192.168.10.5\Ortak");
            await ConnectToNetworkDrive("W:", @"\\192.168.10.9\WmsPlatform");

            Thread.Sleep(1000);

            DatabaseHelper.InsertLogToDatabase(lbl_desktop_name.Text, lbl_local_ip_address.Text, "Disklere bağlandı.", lbl_db_name.Text, lbl_cpu_for_db.Text, lbl_ram_for_db.Text, lbl_disk_for_db.Text, lbl_disk_available_storage.Text);
        }

        private async Task ConnectToNetworkDrive(string driveLetter, string networkPath)
        {
            NETRESOURCE nr = new NETRESOURCE
            {
                dwType = 1,
                lpLocalName = driveLetter,
                lpRemoteName = networkPath,
                lpProvider = null
            };

            string username = @"enka\tiger";
            string password = "Enka2019.!@";

            int disconnectResult = WNetCancelConnection2(nr.lpLocalName, 0, true);

            if (disconnectResult == 0 || disconnectResult == 2250)
            {
                await ShowTimedMessageBox($"Bağlantı {driveLetter} kesildi. Tekrar bağlanıyor...", "Bekleme", 1000);
                int result = WNetAddConnection2(ref nr, password, username, 1); // 1: kalıcı bağlantı
                if (result == 0) // Başarılı bağlantı
                {
                    if (Directory.Exists(driveLetter))
                    {
                        await ShowTimedMessageBox($"Bağlantı {driveLetter} başarılı.", "Sürücü", 1000);
                    }
                    else
                    {
                        await ShowTimedMessageBox($"Bağlantı {driveLetter} başarılı. Ancak sürücü haritalanmadı.", "Sürücü", 1000);
                    }
                }
                else
                {
                    string errorMessage = GetNetworkErrorMessage(result);
                    MessageBox.Show($"Bağlantı başarısız. Hata kodu: {result}, Mesaj: {errorMessage}");
                }
            }
            else
            {
                string errorMessage = GetNetworkErrorMessage(disconnectResult);
                MessageBox.Show($"Mevcut {driveLetter} bağlantısı kesilemedi. Hata kodu: {disconnectResult}, Mesaj: {errorMessage}");
            }
        }

        private string GetNetworkErrorMessage(int errorCode)
        {
            switch (errorCode)
            {
                case 53:
                    return "Ağ yolu bulunamadı.";
                case 85:
                    return "Belirtilen yerel aygıt zaten kullanılıyor.";
                case 1219:
                    return "Farklı kimlik bilgileri ile bir bağlantı zaten kurulmuş.";
                case 67:
                    return "Ağ adı bulunamadı.";
                case 5:
                    return "Erişim engellendi.";
                default:
                    return "Bilinmeyen hata.";
            }
        }
        #endregion

        #region TIGER Takılı kalan kullanıcı sorunu
        private void btn_sql_execute_Click(object sender, EventArgs e)
        {
            ExecuteSqlQueries();
            DatabaseHelper.InsertLogToDatabase(lbl_desktop_name.Text, lbl_local_ip_address.Text, "TIGER netlock flush", lbl_db_name.Text, lbl_cpu_for_db.Text, lbl_ram_for_db.Text, lbl_disk_for_db.Text, lbl_disk_available_storage.Text);
        }

        private void ExecuteSqlQueries()
        {
            string connectionString = "Server=192.168.10.8;Database=TIGER2_DB;User Id=emba;Password=manageit41;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query1 = "SELECT * FROM LG_NTLCK_221; TRUNCATE TABLE LG_NTLCK_221;";
                    string query2 = "SELECT * FROM DLG_NETLOCK; TRUNCATE TABLE DLG_NETLOCK;";

                    StringBuilder logBuilder = new StringBuilder();
                    using (SqlCommand command1 = new SqlCommand(query1, connection))
                    {
                        SqlDataReader reader = command1.ExecuteReader();
                        logBuilder.AppendLine("LG_NTLCK_221 Tablosu:");
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                logBuilder.Append(reader.GetName(i) + ": " + reader[i] + " ");
                            }
                            logBuilder.AppendLine();
                        }
                        reader.Close();
                        logBuilder.AppendLine("LG_NTLCK_221 tablosu temizlendi.\n");
                    }
                    using (SqlCommand command2 = new SqlCommand(query2, connection))
                    {
                        SqlDataReader reader = command2.ExecuteReader();
                        logBuilder.AppendLine("DLG_NETLOCK Tablosu:");
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                logBuilder.Append(reader.GetName(i) + ": " + reader[i] + " ");
                            }
                            logBuilder.AppendLine();
                        }
                        reader.Close();
                        logBuilder.AppendLine("DLG_NETLOCK tablosu temizlendi.\n");
                    }
                    MessageBox.Show(logBuilder.ToString(), "SQL Logları");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
        #endregion

        #region Wifi Bağlantı Kontrolü
        private async void btn_wifi_connect_Click(object sender, EventArgs e)
        {
            // ProgressBar ve Label'ı görünür yap
            progressBar1.Visible = true;
            lbl_status.Visible = true;

            DatabaseHelper.InsertLogToDatabase(lbl_desktop_name.Text, lbl_local_ip_address.Text, "Wi-Fi Reconnect.", lbl_db_name.Text, lbl_cpu_for_db.Text, lbl_ram_for_db.Text, lbl_disk_for_db.Text, lbl_disk_available_storage.Text);

            await CheckAndConnectWifi();
        }

        private async Task CheckAndConnectWifi()
        {
            try
            {
                progressBar1.Value = 0;
                lbl_status.Text = "Wi-Fi durumu kontrol ediliyor...";
                await ShowTimedMessageBox($"Bağlantı Kontrol ediliyor. Wi-Fi ağınızın açık olduğundan emin olunuz.", "Wi-Fi", 5000);
                progressBar1.Value = 10;

                RunCommandAsAdmin("netsh interface set interface name=Wi-Fi admin=disable");
                lbl_status.Text = "Wi-Fi adaptörü kapatılıyor.";
                progressBar1.Value = 20;

                Thread.Sleep(5000);

                RunCommandAsAdmin("netsh interface set interface name=Wi-Fi admin=enable");
                lbl_status.Text = "Wi-Fi adaptörü açılıyor.";
                progressBar1.Value = 30;

                string wifiStatus = RunCommand("netsh interface show interface name=Wi-Fi");

                if (wifiStatus.Contains("Connect state:        Disconnected"))
                {
                    await ShowTimedMessageBox($"Bağlantı yok. Enka Ağına bağlanılıyor...", "Wi-Fi", 5000);
                    RunCommand("netsh wlan connect name=\"EnkaCivata\"");
                    lbl_status.Text = "Wi-Fi ağına bağlanılıyor...";
                    Thread.Sleep(2000);
                }

                await Task.Delay(1000);
                progressBar1.Value = 50;
                await Task.Delay(2000);

                lbl_status.Text = "IP yapılandırması yenileniyor...";
                RunCommand("ipconfig /release");
                RunCommand("ipconfig /renew");
                RunCommand("ipconfig /flushdns");
                progressBar1.Value = 70;
                await Task.Delay(1000);

                wifiStatus = RunCommand("netsh interface show interface name=Wi-Fi");
                if (wifiStatus.Contains("Connect state:        Disconnected"))
                {
                    await ShowTimedMessageBox($"Ağ bağlantısı sağlanamadı. Wi-Fi kontrol edin ya da IT çağırın.", "Wi-Fi", 5000);
                    lbl_status.Visible = false;
                    progressBar1.Visible = false;
                    return;
                }


                // 4. İnternet bağlantısını kontrol et
                lbl_status.Text = "İnternet bağlantısı kontrol ediliyor...";
                if (CheckInternetConnection())
                {
                    lbl_status.Text = "İnternet bağlantısı başarılı!";
                }
                else
                {
                    lbl_status.Text = "İnternet bağlantısı yok! Lütfen IT biriminden destek alın.";
                }
                progressBar1.Value = 100;
                await Task.Delay(1000);
                progressBar1.Visible = false;
                lbl_status.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private bool CheckInternetConnection()
        {
            try
            {
                // 1. Yöntem: HTTP Request ile kontrol
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(5);
                    HttpResponseMessage response = client.GetAsync("http://www.google.com").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("HTTP isteği sırasında bir hata oluştu: " + ex.Message);
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("HTTP isteği zaman aşımına uğradı. İnternet bağlantınız yok.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
            string text = GetLocalIPv4Address();
            lbl_local_ip_address.Text = text;

            return false; // Eğer bir hata olursa ya da bağlantı başarısızsa, false döndür


        }
        #endregion

        #region Kablolu Bağlantı Kontrolü
        private void btn_wired_connect_Click(object sender, EventArgs e)
        {
            FixWiredConnection();
            DatabaseHelper.InsertLogToDatabase(lbl_desktop_name.Text, lbl_local_ip_address.Text, "Wired Check", lbl_db_name.Text, lbl_cpu_for_db.Text, lbl_ram_for_db.Text, lbl_disk_for_db.Text, lbl_disk_available_storage.Text);
        }

        private void FixWiredConnection()
        {
            try
            {
                ShowTimedMessageBox("Ağ adaptörü yeniden etkinleştirildi.", "Ethernet", 4000);
                RunCommandAsAdmin("netsh interface set interface name=Ethernet admin=disable");

                System.Threading.Thread.Sleep(5000);

                RunCommandAsAdmin("netsh interface set interface name=Ethernet admin=enable");
                ShowTimedMessageBox("Ağ adaptörü yeniden etkinleştirildi.", "Ethernet", 4000);

                RunCommand("ipconfig /release");
                RunCommand("ipconfig /renew");
                RunCommand("ipconfig /flushdns");

                ShowTimedMessageBox("IP ve DNS ayarları resetlendi.", "Ethernet", 1000);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }
        #endregion
    }
}