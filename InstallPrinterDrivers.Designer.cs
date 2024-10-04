namespace Enka_IT_Management
{
    partial class InstallPrinterDrivers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstallPrinterDrivers));
            this.btn_muhasebe_printer_driver_install = new System.Windows.Forms.Button();
            this.lbl_desktop_name = new System.Windows.Forms.Label();
            this.lbl_local_ip_address = new System.Windows.Forms.Label();
            this.lbl_db_name = new System.Windows.Forms.Label();
            this.btn_satis_printer_driver_install = new System.Windows.Forms.Button();
            this.lbl_printer_ips = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_muhasebe_printer_driver_install
            // 
            this.btn_muhasebe_printer_driver_install.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btn_muhasebe_printer_driver_install.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_muhasebe_printer_driver_install.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_muhasebe_printer_driver_install.ForeColor = System.Drawing.Color.White;
            this.btn_muhasebe_printer_driver_install.Location = new System.Drawing.Point(24, 12);
            this.btn_muhasebe_printer_driver_install.Name = "btn_muhasebe_printer_driver_install";
            this.btn_muhasebe_printer_driver_install.Size = new System.Drawing.Size(181, 64);
            this.btn_muhasebe_printer_driver_install.TabIndex = 0;
            this.btn_muhasebe_printer_driver_install.Text = "4050i (Muhasebe)";
            this.btn_muhasebe_printer_driver_install.UseVisualStyleBackColor = false;
            this.btn_muhasebe_printer_driver_install.Click += new System.EventHandler(this.btn_muhasebe_printer_driver_install_Click);
            // 
            // lbl_desktop_name
            // 
            this.lbl_desktop_name.AutoSize = true;
            this.lbl_desktop_name.Location = new System.Drawing.Point(459, 12);
            this.lbl_desktop_name.Name = "lbl_desktop_name";
            this.lbl_desktop_name.Size = new System.Drawing.Size(71, 13);
            this.lbl_desktop_name.TabIndex = 1;
            this.lbl_desktop_name.Text = "desktopname";
            this.lbl_desktop_name.Visible = false;
            // 
            // lbl_local_ip_address
            // 
            this.lbl_local_ip_address.AutoSize = true;
            this.lbl_local_ip_address.Location = new System.Drawing.Point(459, 25);
            this.lbl_local_ip_address.Name = "lbl_local_ip_address";
            this.lbl_local_ip_address.Size = new System.Drawing.Size(37, 13);
            this.lbl_local_ip_address.TabIndex = 2;
            this.lbl_local_ip_address.Text = "localip";
            this.lbl_local_ip_address.Visible = false;
            // 
            // lbl_db_name
            // 
            this.lbl_db_name.AutoSize = true;
            this.lbl_db_name.Location = new System.Drawing.Point(459, 38);
            this.lbl_db_name.Name = "lbl_db_name";
            this.lbl_db_name.Size = new System.Drawing.Size(51, 13);
            this.lbl_db_name.TabIndex = 3;
            this.lbl_db_name.Text = "db_name";
            this.lbl_db_name.Visible = false;
            // 
            // btn_satis_printer_driver_install
            // 
            this.btn_satis_printer_driver_install.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btn_satis_printer_driver_install.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_satis_printer_driver_install.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_satis_printer_driver_install.ForeColor = System.Drawing.Color.White;
            this.btn_satis_printer_driver_install.Location = new System.Drawing.Point(255, 12);
            this.btn_satis_printer_driver_install.Name = "btn_satis_printer_driver_install";
            this.btn_satis_printer_driver_install.Size = new System.Drawing.Size(181, 64);
            this.btn_satis_printer_driver_install.TabIndex = 4;
            this.btn_satis_printer_driver_install.Text = "5020i (Satış ve Satınalma)";
            this.btn_satis_printer_driver_install.UseVisualStyleBackColor = false;
            this.btn_satis_printer_driver_install.Click += new System.EventHandler(this.btn_satis_printer_driver_install_Click);
            // 
            // lbl_printer_ips
            // 
            this.lbl_printer_ips.AutoSize = true;
            this.lbl_printer_ips.Location = new System.Drawing.Point(21, 79);
            this.lbl_printer_ips.Name = "lbl_printer_ips";
            this.lbl_printer_ips.Size = new System.Drawing.Size(129, 13);
            this.lbl_printer_ips.TabIndex = 5;
            this.lbl_printer_ips.Text = "Yazıcı IP: 192.168.10.104";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(252, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Yazıcı IP: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(252, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Satınalma: 192.168.10.89 / Satış : 192.168.10.99";
            // 
            // InstallPrinterDrivers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 131);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_printer_ips);
            this.Controls.Add(this.btn_satis_printer_driver_install);
            this.Controls.Add(this.lbl_db_name);
            this.Controls.Add(this.lbl_local_ip_address);
            this.Controls.Add(this.lbl_desktop_name);
            this.Controls.Add(this.btn_muhasebe_printer_driver_install);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InstallPrinterDrivers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yazıcı Sürücülerini Yükle";
            this.Load += new System.EventHandler(this.InstallPrinterDrivers_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_muhasebe_printer_driver_install;
        private System.Windows.Forms.Label lbl_desktop_name;
        private System.Windows.Forms.Label lbl_local_ip_address;
        private System.Windows.Forms.Label lbl_db_name;
        private System.Windows.Forms.Button btn_satis_printer_driver_install;
        private System.Windows.Forms.Label lbl_printer_ips;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}