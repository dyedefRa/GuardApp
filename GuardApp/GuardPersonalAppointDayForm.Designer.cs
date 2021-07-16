
namespace GuardApp
{
    partial class GuardPersonalAppointDayForm
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
            this.lstPersonal = new System.Windows.Forms.ListBox();
            this.lblGuard = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnAppoint = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstPersonal
            // 
            this.lstPersonal.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstPersonal.FormattingEnabled = true;
            this.lstPersonal.ItemHeight = 25;
            this.lstPersonal.Location = new System.Drawing.Point(65, 110);
            this.lstPersonal.Name = "lstPersonal";
            this.lstPersonal.Size = new System.Drawing.Size(430, 329);
            this.lstPersonal.TabIndex = 0;
            this.lstPersonal.Click += new System.EventHandler(this.lstPersonal_Click);
            // 
            // lblGuard
            // 
            this.lblGuard.AutoSize = true;
            this.lblGuard.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblGuard.Location = new System.Drawing.Point(297, 38);
            this.lblGuard.Name = "lblGuard";
            this.lblGuard.Size = new System.Drawing.Size(57, 21);
            this.lblGuard.TabIndex = 1;
            this.lblGuard.Text = "label1";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDate.Location = new System.Drawing.Point(297, 69);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(57, 21);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "label1";
            // 
            // btnAppoint
            // 
            this.btnAppoint.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnAppoint.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAppoint.Location = new System.Drawing.Point(185, 471);
            this.btnAppoint.Name = "btnAppoint";
            this.btnAppoint.Size = new System.Drawing.Size(189, 37);
            this.btnAppoint.TabIndex = 3;
            this.btnAppoint.Text = "Nöbeti Kişiye Ata";
            this.btnAppoint.UseVisualStyleBackColor = false;
            this.btnAppoint.Click += new System.EventHandler(this.btnAppoint_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(196, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nöbet Adı :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(228, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tarih :";
            // 
            // btnBack
            // 
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnBack.Location = new System.Drawing.Point(12, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(120, 28);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "Geriye Git";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // GuardPersonalAppointDayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(578, 586);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAppoint);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblGuard);
            this.Controls.Add(this.lstPersonal);
            this.Name = "GuardPersonalAppointDayForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GuardPersonalAppointDayForm";
            this.Load += new System.EventHandler(this.GuardPersonalAppointDayForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstPersonal;
        private System.Windows.Forms.Label lblGuard;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btnAppoint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBack;
    }
}