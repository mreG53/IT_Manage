namespace Enka_IT_Management
{
    partial class Start
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Start));
            this.btn_disk_connect = new System.Windows.Forms.Button();
            this.lbl_what_is_issue = new System.Windows.Forms.Label();
            this.btn_call_it = new System.Windows.Forms.Button();
            this.btn_sql_execute = new System.Windows.Forms.Button();
            this.btn_wifi_connect = new System.Windows.Forms.Button();
            this.btn_wired_connect = new System.Windows.Forms.Button();
            this.lbl_desktop_name = new System.Windows.Forms.Label();
            this.lbl_local_ip_address = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lbl_status = new System.Windows.Forms.Label();
            this.lbl_trash = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lbl_db_name = new System.Windows.Forms.Label();
            this.btn_connect_printers = new System.Windows.Forms.Button();
            this.btn_reset_terminal_service = new System.Windows.Forms.Button();
            this.btn_rt_delete = new System.Windows.Forms.Button();
            this.btn_reset_printer_queue = new System.Windows.Forms.Button();
            this.btn_system_repair = new System.Windows.Forms.Button();
            this.progressBarCPU = new System.Windows.Forms.ProgressBar();
            this.progressBarRAM = new System.Windows.Forms.ProgressBar();
            this.lblCpuUsage = new System.Windows.Forms.Label();
            this.lblRamUsage = new System.Windows.Forms.Label();
            this.progressBarDisk = new System.Windows.Forms.ProgressBar();
            this.lblDiskUsage = new System.Windows.Forms.Label();
            this.lbl_disk_available_storage = new System.Windows.Forms.Label();
            this.lbl_disk_for_db = new System.Windows.Forms.Label();
            this.lbl_ram_for_db = new System.Windows.Forms.Label();
            this.lbl_cpu_for_db = new System.Windows.Forms.Label();
            this.lbl_adisk_for_db = new System.Windows.Forms.Label();
            this.versionname = new System.Windows.Forms.Label();
            this.btn_ram_opt = new System.Windows.Forms.Button();
            this.btn_create_shortcut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_disk_connect
            // 
            this.btn_disk_connect.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btn_disk_connect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_disk_connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_disk_connect.ForeColor = System.Drawing.Color.White;
            this.btn_disk_connect.Location = new System.Drawing.Point(508, 70);
            this.btn_disk_connect.Name = "btn_disk_connect";
            this.btn_disk_connect.Size = new System.Drawing.Size(236, 69);
            this.btn_disk_connect.TabIndex = 15;
            this.btn_disk_connect.Text = "TIGER - WMS - ORTAK bağlan";
            this.btn_disk_connect.UseVisualStyleBackColor = false;
            this.btn_disk_connect.Click += new System.EventHandler(this.btn_disk_connect_Click);
            // 
            // lbl_what_is_issue
            // 
            this.lbl_what_is_issue.AutoSize = true;
            this.lbl_what_is_issue.BackColor = System.Drawing.Color.Transparent;
            this.lbl_what_is_issue.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_what_is_issue.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lbl_what_is_issue.Location = new System.Drawing.Point(247, 15);
            this.lbl_what_is_issue.Name = "lbl_what_is_issue";
            this.lbl_what_is_issue.Size = new System.Drawing.Size(51, 17);
            this.lbl_what_is_issue.TabIndex = 2;
            this.lbl_what_is_issue.Text = "caption";
            // 
            // btn_call_it
            // 
            this.btn_call_it.BackColor = System.Drawing.Color.MediumBlue;
            this.btn_call_it.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_call_it.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btn_call_it.FlatAppearance.BorderSize = 3;
            this.btn_call_it.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_call_it.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_call_it.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btn_call_it.Location = new System.Drawing.Point(0, 420);
            this.btn_call_it.Name = "btn_call_it";
            this.btn_call_it.Size = new System.Drawing.Size(1004, 37);
            this.btn_call_it.TabIndex = 22;
            this.btn_call_it.Text = "BT Bildir";
            this.btn_call_it.UseVisualStyleBackColor = false;
            this.btn_call_it.Click += new System.EventHandler(this.btn_call_it_Click);
            // 
            // btn_sql_execute
            // 
            this.btn_sql_execute.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btn_sql_execute.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_sql_execute.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_sql_execute.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_sql_execute.ForeColor = System.Drawing.Color.White;
            this.btn_sql_execute.Location = new System.Drawing.Point(24, 187);
            this.btn_sql_execute.Name = "btn_sql_execute";
            this.btn_sql_execute.Size = new System.Drawing.Size(236, 69);
            this.btn_sql_execute.TabIndex = 16;
            this.btn_sql_execute.Text = "TIGER - Takılı kalan kullanıcı sorununu düzelt.";
            this.btn_sql_execute.UseVisualStyleBackColor = false;
            this.btn_sql_execute.Click += new System.EventHandler(this.btn_sql_execute_Click);
            // 
            // btn_wifi_connect
            // 
            this.btn_wifi_connect.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btn_wifi_connect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_wifi_connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_wifi_connect.ForeColor = System.Drawing.Color.White;
            this.btn_wifi_connect.Location = new System.Drawing.Point(266, 186);
            this.btn_wifi_connect.Name = "btn_wifi_connect";
            this.btn_wifi_connect.Size = new System.Drawing.Size(236, 69);
            this.btn_wifi_connect.TabIndex = 17;
            this.btn_wifi_connect.Text = "Bağlantı problemini çöz - Wi-Fi";
            this.btn_wifi_connect.UseVisualStyleBackColor = false;
            this.btn_wifi_connect.Click += new System.EventHandler(this.btn_wifi_connect_Click);
            // 
            // btn_wired_connect
            // 
            this.btn_wired_connect.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btn_wired_connect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_wired_connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_wired_connect.ForeColor = System.Drawing.Color.White;
            this.btn_wired_connect.Location = new System.Drawing.Point(508, 187);
            this.btn_wired_connect.Name = "btn_wired_connect";
            this.btn_wired_connect.Size = new System.Drawing.Size(236, 69);
            this.btn_wired_connect.TabIndex = 18;
            this.btn_wired_connect.Text = "Bağlantı problemini çöz - Ethernet";
            this.btn_wired_connect.UseVisualStyleBackColor = false;
            this.btn_wired_connect.Click += new System.EventHandler(this.btn_wired_connect_Click);
            // 
            // lbl_desktop_name
            // 
            this.lbl_desktop_name.AutoSize = true;
            this.lbl_desktop_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_desktop_name.ForeColor = System.Drawing.Color.Blue;
            this.lbl_desktop_name.Location = new System.Drawing.Point(65, 19);
            this.lbl_desktop_name.Name = "lbl_desktop_name";
            this.lbl_desktop_name.Size = new System.Drawing.Size(82, 13);
            this.lbl_desktop_name.TabIndex = 3;
            this.lbl_desktop_name.Text = "desktopname";
            // 
            // lbl_local_ip_address
            // 
            this.lbl_local_ip_address.AutoSize = true;
            this.lbl_local_ip_address.ForeColor = System.Drawing.Color.Blue;
            this.lbl_local_ip_address.Location = new System.Drawing.Point(-3, 37);
            this.lbl_local_ip_address.Name = "lbl_local_ip_address";
            this.lbl_local_ip_address.Size = new System.Drawing.Size(37, 13);
            this.lbl_local_ip_address.TabIndex = 4;
            this.lbl_local_ip_address.Text = "localip";
            this.lbl_local_ip_address.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.progressBar1.Enabled = false;
            this.progressBar1.Location = new System.Drawing.Point(267, 262);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.progressBar1.Size = new System.Drawing.Size(235, 23);
            this.progressBar1.TabIndex = 23;
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.BackColor = System.Drawing.Color.Transparent;
            this.lbl_status.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lbl_status.Location = new System.Drawing.Point(263, 288);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(35, 13);
            this.lbl_status.TabIndex = 24;
            this.lbl_status.Text = "status";
            // 
            // lbl_trash
            // 
            this.lbl_trash.AutoSize = true;
            this.lbl_trash.Font = new System.Drawing.Font("Microsoft YaHei", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_trash.Location = new System.Drawing.Point(12, 356);
            this.lbl_trash.Name = "lbl_trash";
            this.lbl_trash.Size = new System.Drawing.Size(0, 42);
            this.lbl_trash.TabIndex = 11;
            // 
            // lbl_db_name
            // 
            this.lbl_db_name.AutoSize = true;
            this.lbl_db_name.ForeColor = System.Drawing.Color.Blue;
            this.lbl_db_name.Location = new System.Drawing.Point(-3, 9);
            this.lbl_db_name.Name = "lbl_db_name";
            this.lbl_db_name.Size = new System.Drawing.Size(51, 13);
            this.lbl_db_name.TabIndex = 1;
            this.lbl_db_name.Text = "db_name";
            this.lbl_db_name.Visible = false;
            // 
            // btn_connect_printers
            // 
            this.btn_connect_printers.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btn_connect_printers.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_connect_printers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_connect_printers.ForeColor = System.Drawing.Color.White;
            this.btn_connect_printers.Location = new System.Drawing.Point(24, 70);
            this.btn_connect_printers.Name = "btn_connect_printers";
            this.btn_connect_printers.Size = new System.Drawing.Size(236, 69);
            this.btn_connect_printers.TabIndex = 13;
            this.btn_connect_printers.Text = "Yazıcılara bağlan";
            this.btn_connect_printers.UseVisualStyleBackColor = false;
            this.btn_connect_printers.Click += new System.EventHandler(this.btn_connect_printers_Click);
            // 
            // btn_reset_terminal_service
            // 
            this.btn_reset_terminal_service.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btn_reset_terminal_service.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_reset_terminal_service.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_reset_terminal_service.ForeColor = System.Drawing.Color.White;
            this.btn_reset_terminal_service.Location = new System.Drawing.Point(266, 70);
            this.btn_reset_terminal_service.Name = "btn_reset_terminal_service";
            this.btn_reset_terminal_service.Size = new System.Drawing.Size(236, 69);
            this.btn_reset_terminal_service.TabIndex = 14;
            this.btn_reset_terminal_service.Text = "Terminal Servisi baştan başlat";
            this.btn_reset_terminal_service.UseVisualStyleBackColor = false;
            this.btn_reset_terminal_service.Click += new System.EventHandler(this.btn_reset_terminal_service_Click);
            // 
            // btn_rt_delete
            // 
            this.btn_rt_delete.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btn_rt_delete.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_rt_delete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_rt_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_rt_delete.ForeColor = System.Drawing.Color.White;
            this.btn_rt_delete.Location = new System.Drawing.Point(24, 307);
            this.btn_rt_delete.Name = "btn_rt_delete";
            this.btn_rt_delete.Size = new System.Drawing.Size(236, 69);
            this.btn_rt_delete.TabIndex = 19;
            this.btn_rt_delete.Text = "Bilgisayarımdaki gereksiz dosyaları sil";
            this.btn_rt_delete.UseVisualStyleBackColor = false;
            this.btn_rt_delete.Click += new System.EventHandler(this.btn_rt_delete_Click);
            // 
            // btn_reset_printer_queue
            // 
            this.btn_reset_printer_queue.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btn_reset_printer_queue.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_reset_printer_queue.Enabled = false;
            this.btn_reset_printer_queue.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_reset_printer_queue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_reset_printer_queue.ForeColor = System.Drawing.Color.White;
            this.btn_reset_printer_queue.Location = new System.Drawing.Point(266, 307);
            this.btn_reset_printer_queue.Name = "btn_reset_printer_queue";
            this.btn_reset_printer_queue.Size = new System.Drawing.Size(236, 69);
            this.btn_reset_printer_queue.TabIndex = 20;
            this.btn_reset_printer_queue.Text = "Yazıcı Sırasını sıfırla (Devre Dışı)";
            this.btn_reset_printer_queue.UseVisualStyleBackColor = false;
            this.btn_reset_printer_queue.Click += new System.EventHandler(this.btn_reset_printer_queue_Click);
            // 
            // btn_system_repair
            // 
            this.btn_system_repair.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btn_system_repair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_system_repair.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_system_repair.ForeColor = System.Drawing.Color.White;
            this.btn_system_repair.Location = new System.Drawing.Point(508, 307);
            this.btn_system_repair.Name = "btn_system_repair";
            this.btn_system_repair.Size = new System.Drawing.Size(236, 69);
            this.btn_system_repair.TabIndex = 21;
            this.btn_system_repair.Text = "Sistem Onarma     (!)";
            this.btn_system_repair.UseVisualStyleBackColor = false;
            this.btn_system_repair.Click += new System.EventHandler(this.btn_system_repair_Click);
            // 
            // progressBarCPU
            // 
            this.progressBarCPU.Location = new System.Drawing.Point(875, 70);
            this.progressBarCPU.Name = "progressBarCPU";
            this.progressBarCPU.Size = new System.Drawing.Size(100, 23);
            this.progressBarCPU.TabIndex = 25;
            // 
            // progressBarRAM
            // 
            this.progressBarRAM.Location = new System.Drawing.Point(875, 99);
            this.progressBarRAM.Name = "progressBarRAM";
            this.progressBarRAM.Size = new System.Drawing.Size(100, 23);
            this.progressBarRAM.TabIndex = 26;
            // 
            // lblCpuUsage
            // 
            this.lblCpuUsage.AutoSize = true;
            this.lblCpuUsage.ForeColor = System.Drawing.Color.Blue;
            this.lblCpuUsage.Location = new System.Drawing.Point(799, 77);
            this.lblCpuUsage.Name = "lblCpuUsage";
            this.lblCpuUsage.Size = new System.Drawing.Size(73, 13);
            this.lblCpuUsage.TabIndex = 5;
            this.lblCpuUsage.Text = "CPU : 00.00%";
            // 
            // lblRamUsage
            // 
            this.lblRamUsage.AutoSize = true;
            this.lblRamUsage.ForeColor = System.Drawing.Color.Blue;
            this.lblRamUsage.Location = new System.Drawing.Point(799, 103);
            this.lblRamUsage.Name = "lblRamUsage";
            this.lblRamUsage.Size = new System.Drawing.Size(75, 13);
            this.lblRamUsage.TabIndex = 7;
            this.lblRamUsage.Text = "RAM : 00.00%";
            // 
            // progressBarDisk
            // 
            this.progressBarDisk.Location = new System.Drawing.Point(875, 128);
            this.progressBarDisk.Name = "progressBarDisk";
            this.progressBarDisk.Size = new System.Drawing.Size(100, 23);
            this.progressBarDisk.TabIndex = 27;
            // 
            // lblDiskUsage
            // 
            this.lblDiskUsage.AutoSize = true;
            this.lblDiskUsage.ForeColor = System.Drawing.Color.Blue;
            this.lblDiskUsage.Location = new System.Drawing.Point(799, 131);
            this.lblDiskUsage.Name = "lblDiskUsage";
            this.lblDiskUsage.Size = new System.Drawing.Size(76, 13);
            this.lblDiskUsage.TabIndex = 9;
            this.lblDiskUsage.Text = "DISK : 00.00%";
            // 
            // lbl_disk_available_storage
            // 
            this.lbl_disk_available_storage.AutoSize = true;
            this.lbl_disk_available_storage.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_disk_available_storage.ForeColor = System.Drawing.Color.Green;
            this.lbl_disk_available_storage.Location = new System.Drawing.Point(799, 161);
            this.lbl_disk_available_storage.Name = "lbl_disk_available_storage";
            this.lbl_disk_available_storage.Size = new System.Drawing.Size(31, 16);
            this.lbl_disk_available_storage.TabIndex = 11;
            this.lbl_disk_available_storage.Text = "text";
            // 
            // lbl_disk_for_db
            // 
            this.lbl_disk_for_db.AutoSize = true;
            this.lbl_disk_for_db.Location = new System.Drawing.Point(872, 131);
            this.lbl_disk_for_db.Name = "lbl_disk_for_db";
            this.lbl_disk_for_db.Size = new System.Drawing.Size(110, 13);
            this.lbl_disk_for_db.TabIndex = 10;
            this.lbl_disk_for_db.Text = "lbl_disk_for_database";
            this.lbl_disk_for_db.Visible = false;
            // 
            // lbl_ram_for_db
            // 
            this.lbl_ram_for_db.AutoSize = true;
            this.lbl_ram_for_db.Location = new System.Drawing.Point(872, 103);
            this.lbl_ram_for_db.Name = "lbl_ram_for_db";
            this.lbl_ram_for_db.Size = new System.Drawing.Size(76, 13);
            this.lbl_ram_for_db.TabIndex = 8;
            this.lbl_ram_for_db.Text = "lbl_ram_for_db";
            this.lbl_ram_for_db.Visible = false;
            // 
            // lbl_cpu_for_db
            // 
            this.lbl_cpu_for_db.AutoSize = true;
            this.lbl_cpu_for_db.Location = new System.Drawing.Point(872, 77);
            this.lbl_cpu_for_db.Name = "lbl_cpu_for_db";
            this.lbl_cpu_for_db.Size = new System.Drawing.Size(77, 13);
            this.lbl_cpu_for_db.TabIndex = 6;
            this.lbl_cpu_for_db.Text = "lbl_cpu_for_db";
            this.lbl_cpu_for_db.Visible = false;
            // 
            // lbl_adisk_for_db
            // 
            this.lbl_adisk_for_db.AutoSize = true;
            this.lbl_adisk_for_db.Location = new System.Drawing.Point(872, 161);
            this.lbl_adisk_for_db.Name = "lbl_adisk_for_db";
            this.lbl_adisk_for_db.Size = new System.Drawing.Size(116, 13);
            this.lbl_adisk_for_db.TabIndex = 12;
            this.lbl_adisk_for_db.Text = "lbl_adisk_for_database";
            this.lbl_adisk_for_db.Visible = false;
            // 
            // versionname
            // 
            this.versionname.AutoSize = true;
            this.versionname.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.versionname.ForeColor = System.Drawing.Color.Blue;
            this.versionname.Location = new System.Drawing.Point(976, -1);
            this.versionname.Name = "versionname";
            this.versionname.Size = new System.Drawing.Size(28, 13);
            this.versionname.TabIndex = 28;
            this.versionname.Text = "v1.0";
            // 
            // btn_ram_opt
            // 
            this.btn_ram_opt.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_ram_opt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_ram_opt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_ram_opt.ForeColor = System.Drawing.Color.White;
            this.btn_ram_opt.Location = new System.Drawing.Point(802, 187);
            this.btn_ram_opt.Name = "btn_ram_opt";
            this.btn_ram_opt.Size = new System.Drawing.Size(173, 31);
            this.btn_ram_opt.TabIndex = 29;
            this.btn_ram_opt.Text = "RAM Optimize Et";
            this.btn_ram_opt.UseVisualStyleBackColor = false;
            this.btn_ram_opt.Click += new System.EventHandler(this.btn_ram_opt_Click);
            // 
            // btn_create_shortcut
            // 
            this.btn_create_shortcut.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btn_create_shortcut.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btn_create_shortcut.FlatAppearance.BorderSize = 3;
            this.btn_create_shortcut.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_create_shortcut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_create_shortcut.ForeColor = System.Drawing.Color.White;
            this.btn_create_shortcut.Location = new System.Drawing.Point(508, 141);
            this.btn_create_shortcut.Name = "btn_create_shortcut";
            this.btn_create_shortcut.Size = new System.Drawing.Size(102, 20);
            this.btn_create_shortcut.TabIndex = 30;
            this.btn_create_shortcut.Text = "Kısayol oluştur.";
            this.btn_create_shortcut.UseVisualStyleBackColor = false;
            this.btn_create_shortcut.Click += new System.EventHandler(this.btn_create_shortcut_Click);
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1004, 457);
            this.Controls.Add(this.btn_create_shortcut);
            this.Controls.Add(this.btn_ram_opt);
            this.Controls.Add(this.versionname);
            this.Controls.Add(this.lbl_adisk_for_db);
            this.Controls.Add(this.lbl_cpu_for_db);
            this.Controls.Add(this.lbl_ram_for_db);
            this.Controls.Add(this.lbl_disk_for_db);
            this.Controls.Add(this.lbl_disk_available_storage);
            this.Controls.Add(this.lblDiskUsage);
            this.Controls.Add(this.progressBarDisk);
            this.Controls.Add(this.lblRamUsage);
            this.Controls.Add(this.lblCpuUsage);
            this.Controls.Add(this.progressBarRAM);
            this.Controls.Add(this.progressBarCPU);
            this.Controls.Add(this.btn_system_repair);
            this.Controls.Add(this.btn_reset_printer_queue);
            this.Controls.Add(this.btn_rt_delete);
            this.Controls.Add(this.btn_reset_terminal_service);
            this.Controls.Add(this.btn_connect_printers);
            this.Controls.Add(this.lbl_db_name);
            this.Controls.Add(this.lbl_trash);
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lbl_local_ip_address);
            this.Controls.Add(this.lbl_desktop_name);
            this.Controls.Add(this.btn_wired_connect);
            this.Controls.Add(this.btn_wifi_connect);
            this.Controls.Add(this.btn_sql_execute);
            this.Controls.Add(this.btn_call_it);
            this.Controls.Add(this.lbl_what_is_issue);
            this.Controls.Add(this.btn_disk_connect);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1024, 500);
            this.MinimumSize = new System.Drawing.Size(1024, 500);
            this.Name = "Start";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enka Civata - Bilgi Teknolojileri Hızlı Çözüm Yazılımı";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Start_FormClosed);
            this.Load += new System.EventHandler(this.Start_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_disk_connect;
        private System.Windows.Forms.Label lbl_what_is_issue;
        private System.Windows.Forms.Button btn_call_it;
        private System.Windows.Forms.Button btn_sql_execute;
        private System.Windows.Forms.Button btn_wifi_connect;
        private System.Windows.Forms.Button btn_wired_connect;
        private System.Windows.Forms.Label lbl_desktop_name;
        private System.Windows.Forms.Label lbl_local_ip_address;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.Label lbl_trash;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lbl_db_name;
        private System.Windows.Forms.Button btn_connect_printers;
        private System.Windows.Forms.Button btn_reset_terminal_service;
        private System.Windows.Forms.Button btn_rt_delete;
        private System.Windows.Forms.Button btn_reset_printer_queue;
        private System.Windows.Forms.Button btn_system_repair;
        private System.Windows.Forms.ProgressBar progressBarCPU;
        private System.Windows.Forms.ProgressBar progressBarRAM;
        private System.Windows.Forms.Label lblCpuUsage;
        private System.Windows.Forms.Label lblRamUsage;
        private System.Windows.Forms.ProgressBar progressBarDisk;
        private System.Windows.Forms.Label lblDiskUsage;
        private System.Windows.Forms.Label lbl_disk_available_storage;
        private System.Windows.Forms.Label lbl_disk_for_db;
        private System.Windows.Forms.Label lbl_ram_for_db;
        private System.Windows.Forms.Label lbl_cpu_for_db;
        private System.Windows.Forms.Label lbl_adisk_for_db;
        private System.Windows.Forms.Label versionname;
        private System.Windows.Forms.Button btn_ram_opt;
        private System.Windows.Forms.Button btn_create_shortcut;
    }
}