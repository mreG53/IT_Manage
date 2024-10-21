namespace Enka_IT_Management
{
    partial class ResetPrinters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResetPrinters));
            this.btn_muhasebe_printer_reset = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_muhasebe_printer_reset
            // 
            this.btn_muhasebe_printer_reset.Location = new System.Drawing.Point(12, 29);
            this.btn_muhasebe_printer_reset.Name = "btn_muhasebe_printer_reset";
            this.btn_muhasebe_printer_reset.Size = new System.Drawing.Size(172, 79);
            this.btn_muhasebe_printer_reset.TabIndex = 0;
            this.btn_muhasebe_printer_reset.Text = "Muhasebe Yazıcı 4050i";
            this.btn_muhasebe_printer_reset.UseVisualStyleBackColor = true;
            this.btn_muhasebe_printer_reset.Click += new System.EventHandler(this.btn_muhasebe_printer_reset_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(616, 29);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(172, 79);
            this.button2.TabIndex = 1;
            this.button2.Text = "Satın Alma Yazıcı";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(319, 29);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(172, 79);
            this.button3.TabIndex = 2;
            this.button3.Text = "Satış Yazıcı";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 145);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(172, 79);
            this.button4.TabIndex = 3;
            this.button4.Text = "TSC 1";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(319, 145);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(172, 79);
            this.button5.TabIndex = 4;
            this.button5.Text = "TSC 2";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // ResetPrinters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 248);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_muhasebe_printer_reset);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ResetPrinters";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yazıcı Sırasını Sıfırla (Devre Dışı)";
            this.Load += new System.EventHandler(this.ResetPrinters_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_muhasebe_printer_reset;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}