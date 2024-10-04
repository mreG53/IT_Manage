﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;

namespace Enka_IT_Management
{
    public partial class ResetPrinters : Form
    {
        public ResetPrinters()
        {
            InitializeComponent();

            try
            {
                string query = "SELECT * FROM Win32_Printer";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                ManagementObjectCollection printers = searcher.Get();

                foreach (ManagementObject printer in printers)
                {
                    // Yazıcının adı ve port adı
                    string printerName = printer["Name"].ToString();
                    string portName = printer["PortName"].ToString();

                    Console.WriteLine($"Yazıcı Adı: {printerName}, Port: {portName}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bir hata oluştu: " + ex.Message);
            }
        }


        public void ResetPrinterQueueByIP(string printerIP)
        {
            try
            {
                // IP adresine göre yazıcıları bulmak için WMI sorgusu
                string query = $"SELECT * FROM Win32_Printer WHERE PortName = 'IP_{printerIP}'";

                // WMI sorgusunu çalıştır
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                ManagementObjectCollection printers = searcher.Get();

                // Yazıcı bulunduysa kuyruğu sıfırla
                if (printers.Count > 0)
                {
                    foreach (ManagementObject printer in printers)
                    {
                        // Yazıcı kuyruğundaki tüm işleri iptal et
                        printer.InvokeMethod("CancelAllJobs", null);
                        Console.WriteLine($"Yazıcının ({printerIP}) kuyruğu başarıyla temizlendi.");
                    }
                }
                else
                {
                    Console.WriteLine($"IP adresine sahip yazıcı ({printerIP}) bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bir hata oluştu: " + ex.Message);
            }
        }

        private void btn_muhasebe_printer_reset_Click(object sender, EventArgs e)
        {
            // Kullanıcının girdiği veya önceden belirlenen IP adresi
            string printerIP = "192.168.10.104";  // Yazıcının IP adresi

            // Yazıcı kuyruğunu IP adresine göre sıfırlama işlemi
            ResetPrinterQueueByIP(printerIP);
        }
    }
}