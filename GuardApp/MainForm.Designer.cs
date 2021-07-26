
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
            this.btnGuardPersonal = new System.Windows.Forms.Button();
            this.btnUnity = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRank
            // 
            this.btnRank.Location = new System.Drawing.Point(356, 233);
            this.btnRank.Name = "btnRank";
            this.btnRank.Size = new System.Drawing.Size(119, 42);
            this.btnRank.TabIndex = 0;
            this.btnRank.Text = "Rütbe Ekle";
            this.btnRank.UseVisualStyleBackColor = true;
            this.btnRank.Click += new System.EventHandler(this.btnRank_Click);
            // 
            // btnPersonal
            // 
            this.btnPersonal.Location = new System.Drawing.Point(221, 233);
            this.btnPersonal.Name = "btnPersonal";
            this.btnPersonal.Size = new System.Drawing.Size(119, 42);
            this.btnPersonal.TabIndex = 1;
            this.btnPersonal.Text = "Personel Ekle";
            this.btnPersonal.UseVisualStyleBackColor = true;
            this.btnPersonal.Click += new System.EventHandler(this.btnPersonal_Click);
            // 
            // btnGuard
            // 
            this.btnGuard.Location = new System.Drawing.Point(633, 233);
            this.btnGuard.Name = "btnGuard";
            this.btnGuard.Size = new System.Drawing.Size(119, 42);
            this.btnGuard.TabIndex = 2;
            this.btnGuard.Text = "Nöbet Ekle";
            this.btnGuard.UseVisualStyleBackColor = true;
            this.btnGuard.Click += new System.EventHandler(this.btnGuard_Click);
            // 
            // btnMonthly
            // 
            this.btnMonthly.Location = new System.Drawing.Point(221, 146);
            this.btnMonthly.Name = "btnMonthly";
            this.btnMonthly.Size = new System.Drawing.Size(531, 42);
            this.btnMonthly.TabIndex = 3;
            this.btnMonthly.Text = "Aylık Nöbet Oluştur";
            this.btnMonthly.UseVisualStyleBackColor = true;
            this.btnMonthly.Click += new System.EventHandler(this.btnMonthly_Click);
            // 
            // btnGuardPersonal
            // 
            this.btnGuardPersonal.Location = new System.Drawing.Point(221, 317);
            this.btnGuardPersonal.Name = "btnGuardPersonal";
            this.btnGuardPersonal.Size = new System.Drawing.Size(531, 42);
            this.btnGuardPersonal.TabIndex = 5;
            this.btnGuardPersonal.Text = "Nöbet Personel Eşleştir";
            this.btnGuardPersonal.UseVisualStyleBackColor = true;
            this.btnGuardPersonal.Click += new System.EventHandler(this.btnGuardPersonal_Click);
            // 
            // btnUnity
            // 
            this.btnUnity.Location = new System.Drawing.Point(496, 233);
            this.btnUnity.Name = "btnUnity";
            this.btnUnity.Size = new System.Drawing.Size(119, 42);
            this.btnUnity.TabIndex = 6;
            this.btnUnity.Text = "Birlik Ekle";
            this.btnUnity.UseVisualStyleBackColor = true;
            this.btnUnity.Click += new System.EventHandler(this.btnUnity_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(942, 495);
            this.Controls.Add(this.btnUnity);
            this.Controls.Add(this.btnGuardPersonal);
            this.Controls.Add(this.btnMonthly);
            this.Controls.Add(this.btnGuard);
            this.Controls.Add(this.btnPersonal);
            this.Controls.Add(this.btnRank);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[NTP] Nöbet Takip Programı";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRank;
        private System.Windows.Forms.Button btnPersonal;
        private System.Windows.Forms.Button btnGuard;
        private System.Windows.Forms.Button btnMonthly;
        private System.Windows.Forms.Button btnGuardPersonal;
        private System.Windows.Forms.Button btnUnity;
    }
}

