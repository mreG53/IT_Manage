namespace Enka_IT_Management
{
    partial class CallItForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CallItForm));
            this.lbl_db_name = new System.Windows.Forms.Label();
            this.txt_reason = new System.Windows.Forms.TextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.lbl_caption_issue = new System.Windows.Forms.Label();
            this.btn_upload_image = new System.Windows.Forms.Button();
            this.lbl_image_name = new System.Windows.Forms.Label();
            this.lbl_resmi_sil = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_db_name
            // 
            this.lbl_db_name.AutoSize = true;
            this.lbl_db_name.Location = new System.Drawing.Point(-23, 8);
            this.lbl_db_name.Name = "lbl_db_name";
            this.lbl_db_name.Size = new System.Drawing.Size(35, 13);
            this.lbl_db_name.TabIndex = 0;
            this.lbl_db_name.Text = "label1";
            this.lbl_db_name.Visible = false;
            // 
            // txt_reason
            // 
            this.txt_reason.Location = new System.Drawing.Point(12, 37);
            this.txt_reason.Multiline = true;
            this.txt_reason.Name = "txt_reason";
            this.txt_reason.Size = new System.Drawing.Size(434, 95);
            this.txt_reason.TabIndex = 1;
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btn_save.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_save.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Location = new System.Drawing.Point(0, 188);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(458, 41);
            this.btn_save.TabIndex = 2;
            this.btn_save.Text = "Gönder";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // lbl_caption_issue
            // 
            this.lbl_caption_issue.AutoSize = true;
            this.lbl_caption_issue.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_caption_issue.Location = new System.Drawing.Point(82, 8);
            this.lbl_caption_issue.Name = "lbl_caption_issue";
            this.lbl_caption_issue.Size = new System.Drawing.Size(295, 26);
            this.lbl_caption_issue.TabIndex = 3;
            this.lbl_caption_issue.Text = "Sorunun ne olduğunu yazınız.";
            // 
            // btn_upload_image
            // 
            this.btn_upload_image.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_upload_image.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_upload_image.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_upload_image.ForeColor = System.Drawing.Color.White;
            this.btn_upload_image.Location = new System.Drawing.Point(0, 155);
            this.btn_upload_image.Name = "btn_upload_image";
            this.btn_upload_image.Size = new System.Drawing.Size(204, 27);
            this.btn_upload_image.TabIndex = 32;
            this.btn_upload_image.Text = "Ekran Görüntüsü Ekle";
            this.btn_upload_image.UseVisualStyleBackColor = false;
            this.btn_upload_image.Click += new System.EventHandler(this.btn_upload_image_Click);
            // 
            // lbl_image_name
            // 
            this.lbl_image_name.AutoSize = true;
            this.lbl_image_name.Location = new System.Drawing.Point(210, 169);
            this.lbl_image_name.Name = "lbl_image_name";
            this.lbl_image_name.Size = new System.Drawing.Size(16, 13);
            this.lbl_image_name.TabIndex = 33;
            this.lbl_image_name.Text = "...";
            // 
            // lbl_resmi_sil
            // 
            this.lbl_resmi_sil.AutoSize = true;
            this.lbl_resmi_sil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_resmi_sil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_resmi_sil.ForeColor = System.Drawing.Color.Blue;
            this.lbl_resmi_sil.Location = new System.Drawing.Point(387, 169);
            this.lbl_resmi_sil.Name = "lbl_resmi_sil";
            this.lbl_resmi_sil.Size = new System.Drawing.Size(59, 13);
            this.lbl_resmi_sil.TabIndex = 34;
            this.lbl_resmi_sil.Text = "Resmi Sil";
            this.lbl_resmi_sil.Click += new System.EventHandler(this.lbl_resmi_sil_Click);
            // 
            // CallItForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 229);
            this.Controls.Add(this.lbl_resmi_sil);
            this.Controls.Add(this.lbl_image_name);
            this.Controls.Add(this.btn_upload_image);
            this.Controls.Add(this.lbl_caption_issue);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.txt_reason);
            this.Controls.Add(this.lbl_db_name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CallItForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BT Bildir";
            this.Load += new System.EventHandler(this.CallItForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_db_name;
        private System.Windows.Forms.TextBox txt_reason;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label lbl_caption_issue;
        private System.Windows.Forms.Button btn_upload_image;
        private System.Windows.Forms.Label lbl_image_name;
        private System.Windows.Forms.Label lbl_resmi_sil;
    }
}