
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
            this.SuspendLayout();
            // 
            // lstPersonal
            // 
            this.lstPersonal.FormattingEnabled = true;
            this.lstPersonal.ItemHeight = 15;
            this.lstPersonal.Location = new System.Drawing.Point(149, 103);
            this.lstPersonal.Name = "lstPersonal";
            this.lstPersonal.Size = new System.Drawing.Size(184, 334);
            this.lstPersonal.TabIndex = 0;
            this.lstPersonal.DoubleClick += new System.EventHandler(this.lstPersonal_DoubleClick);
            // 
            // lblGuard
            // 
            this.lblGuard.AutoSize = true;
            this.lblGuard.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblGuard.Location = new System.Drawing.Point(194, 21);
            this.lblGuard.Name = "lblGuard";
            this.lblGuard.Size = new System.Drawing.Size(57, 21);
            this.lblGuard.TabIndex = 1;
            this.lblGuard.Text = "label1";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDate.Location = new System.Drawing.Point(194, 64);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(57, 21);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "label1";
            // 
            // btnAppoint
            // 
            this.btnAppoint.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAppoint.Location = new System.Drawing.Point(144, 465);
            this.btnAppoint.Name = "btnAppoint";
            this.btnAppoint.Size = new System.Drawing.Size(189, 37);
            this.btnAppoint.TabIndex = 3;
            this.btnAppoint.Text = "Nöbeti Kişiye Ata";
            this.btnAppoint.UseVisualStyleBackColor = true;
            this.btnAppoint.Click += new System.EventHandler(this.btnAppoint_Click);
            // 
            // GuardPersonalAppointDayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 571);
            this.Controls.Add(this.btnAppoint);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblGuard);
            this.Controls.Add(this.lstPersonal);
            this.Name = "GuardPersonalAppointDayForm";
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
    }
}