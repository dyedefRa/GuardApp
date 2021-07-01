
namespace GuardApp
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRank = new System.Windows.Forms.Button();
            this.btnPersonal = new System.Windows.Forms.Button();
            this.btnGuard = new System.Windows.Forms.Button();
            this.btnMonthly = new System.Windows.Forms.Button();
            this.btnLastGuard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRank
            // 
            this.btnRank.Location = new System.Drawing.Point(252, 137);
            this.btnRank.Name = "btnRank";
            this.btnRank.Size = new System.Drawing.Size(145, 42);
            this.btnRank.TabIndex = 0;
            this.btnRank.Text = "Rütbe Ekle";
            this.btnRank.UseVisualStyleBackColor = true;
            this.btnRank.Click += new System.EventHandler(this.btnRank_Click);
            // 
            // btnPersonal
            // 
            this.btnPersonal.Location = new System.Drawing.Point(63, 137);
            this.btnPersonal.Name = "btnPersonal";
            this.btnPersonal.Size = new System.Drawing.Size(145, 42);
            this.btnPersonal.TabIndex = 1;
            this.btnPersonal.Text = "Personel Ekle";
            this.btnPersonal.UseVisualStyleBackColor = true;
            this.btnPersonal.Click += new System.EventHandler(this.btnPersonal_Click);
            // 
            // btnGuard
            // 
            this.btnGuard.Location = new System.Drawing.Point(449, 137);
            this.btnGuard.Name = "btnGuard";
            this.btnGuard.Size = new System.Drawing.Size(145, 42);
            this.btnGuard.TabIndex = 2;
            this.btnGuard.Text = "Nöbet Ekle";
            this.btnGuard.UseVisualStyleBackColor = true;
            this.btnGuard.Click += new System.EventHandler(this.btnGuard_Click);
            // 
            // btnMonthly
            // 
            this.btnMonthly.Location = new System.Drawing.Point(63, 50);
            this.btnMonthly.Name = "btnMonthly";
            this.btnMonthly.Size = new System.Drawing.Size(531, 42);
            this.btnMonthly.TabIndex = 3;
            this.btnMonthly.Text = "Aylık Nöbet Oluştur";
            this.btnMonthly.UseVisualStyleBackColor = true;
            this.btnMonthly.Click += new System.EventHandler(this.btnMonthly_Click);
            // 
            // btnLastGuard
            // 
            this.btnLastGuard.Location = new System.Drawing.Point(63, 222);
            this.btnLastGuard.Name = "btnLastGuard";
            this.btnLastGuard.Size = new System.Drawing.Size(531, 30);
            this.btnLastGuard.TabIndex = 4;
            this.btnLastGuard.Text = "Geçmiş Nöbetleri Gör";
            this.btnLastGuard.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(659, 330);
            this.Controls.Add(this.btnLastGuard);
            this.Controls.Add(this.btnMonthly);
            this.Controls.Add(this.btnGuard);
            this.Controls.Add(this.btnPersonal);
            this.Controls.Add(this.btnRank);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormMain";
            this.Text = "[NTP] Nöbet Takip Programı";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRank;
        private System.Windows.Forms.Button btnPersonal;
        private System.Windows.Forms.Button btnGuard;
        private System.Windows.Forms.Button btnMonthly;
        private System.Windows.Forms.Button btnLastGuard;
    }
}

