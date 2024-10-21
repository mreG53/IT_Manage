using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Enka_IT_Management
{
    public static class DatabaseHelper
    {
        public static void InsertLogToDatabase(string desktopName, string localIp, string process, string name, string cpu, string ram, string disk, string availableDisk)
        {
            string connectionString = "Server=192.168.10.8;Database=test;User Id=test;Password=test;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO dbo.logs (desktopname, localip, process, name, cpu, ram, disk, available_disk, date) 
                             VALUES (@desktopname, @localip, @process, @name, @cpu, @ram, @disk, @available_disk, @date)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Parametreler ekleniyor
                        command.Parameters.AddWithValue("@desktopname", desktopName);
                        command.Parameters.AddWithValue("@localip", localIp);
                        command.Parameters.AddWithValue("@process", process);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@cpu", cpu);
                        command.Parameters.AddWithValue("@ram", ram);
                        command.Parameters.AddWithValue("@disk", disk);
                        command.Parameters.AddWithValue("@available_disk", availableDisk);
                        command.Parameters.AddWithValue("@date", DateTime.Now);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanına log eklenirken bir hata oluştu: " + ex.Message);
            }
        }
    }
}
