using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enka_IT_Management
{

    

    public partial class InstallPrinterDrivers : Form
    {
        public string UserName { get; set; }
        public string LocalIP { get; set; }
        public string DesktopName { get; set; }

        public class NetworkDriveConnector
        {
            // EXE dosyasını yönetici olarak çalıştırma
            public void InstallPrinterDriverAsAdmin(string driverPath)
            {
                try
                {
                    ProcessStartInfo processInfo = new ProcessStartInfo();
                    processInfo.FileName = driverPath;      // Çalıştırılacak dosya
                    processInfo.UseShellExecute = true;     // Shell kullanarak çalıştır
                    processInfo.Verb = "runas";             // Yönetici olarak çalıştır
                    processInfo.WindowStyle = ProcessWindowStyle.Normal; // Pencere normal modda açılır

                    // EXE dosyasını yönetici olarak çalıştır
                    Process process = Process.Start(processInfo);

                    // Yükleme işlemi bitene kadar bekle (isteğe bağlı)
                    process.WaitForExit();

                    if (process.ExitCode == 0)
                    {
                        Console.WriteLine("Sürücü başarıyla yüklendi.");
                    }
                    else
                    {
                        Console.WriteLine("Sürücü yüklemesi sırasında bir hata oluştu.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Bir hata oluştu: " + ex.Message);
                }
            }
        }
        public InstallPrinterDrivers()
        {
            InitializeComponent();

        }

        private void btn_muhasebe_printer_driver_install_Click(object sender, EventArgs e)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = @"4050i Muhasebe\IT6BWDSETWin_31120TR\Setup64.exe";
            string exePath = Path.Combine(baseDirectory, relativePath);

            NetworkDriveConnector connector = new NetworkDriveConnector();
            connector.InstallPrinterDriverAsAdmin(exePath);

            DatabaseHelper.InsertLogToDatabase(lbl_desktop_name.Text, lbl_local_ip_address.Text, "4050i driver kurma işlemi", lbl_db_name.Text, "","","","");
        }

        private void InstallPrinterDrivers_Load(object sender, EventArgs e)
        {
            lbl_desktop_name.Text = DesktopName;
            lbl_local_ip_address.Text = LocalIP;
            lbl_db_name.Text = UserName;
        }

        private void btn_satis_printer_driver_install_Click(object sender, EventArgs e)
        {

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = @"5020\BH5020iDSETWin_1210TR\Setup64.exe";
            string exePath = Path.Combine(baseDirectory, relativePath);

            NetworkDriveConnector connector = new NetworkDriveConnector();
            connector.InstallPrinterDriverAsAdmin(exePath);

            DatabaseHelper.InsertLogToDatabase(lbl_desktop_name.Text, lbl_local_ip_address.Text, "5020i driver kurma işlemi", lbl_db_name.Text, "", "", "", "");
        }
    }
}
