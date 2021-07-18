
namespace GuardApp
{
    partial class GuardPersonalForm
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
            this.lstGuard = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddPersonalToGuard = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPersonalRemove = new System.Windows.Forms.Button();
            this.lstAllPersonal = new System.Windows.Forms.ListBox();
            this.lstGuardPersonal = new System.Windows.Forms.ListBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstGuard
            // 
            this.lstGuard.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lstGuard.FormattingEnabled = true;
            this.lstGuard.ItemHeight = 17;
            this.lstGuard.Location = new System.Drawing.Point(26, 66);
            this.lstGuard.Name = "lstGuard";
            this.lstGuard.Size = new System.Drawing.Size(211, 378);
            this.lstGuard.TabIndex = 0;
            this.lstGuard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstGuard_MouseClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnAddPersonalToGuard);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnPersonalRemove);
            this.panel1.Controls.Add(this.lstAllPersonal);
            this.panel1.Controls.Add(this.lstGuardPersonal);
            this.panel1.Controls.Add(this.lstGuard);
            this.panel1.Location = new System.Drawing.Point(23, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(975, 523);
            this.panel1.TabIndex = 1;
            // 
            // btnAddPersonalToGuard
            // 
            this.btnAddPersonalToGuard.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddPersonalToGuard.Location = new System.Drawing.Point(772, 476);
            this.btnAddPersonalToGuard.Name = "btnAddPersonalToGuard";
            this.btnAddPersonalToGuard.Size = new System.Drawing.Size(166, 32);
            this.btnAddPersonalToGuard.TabIndex = 9;
            this.btnAddPersonalToGuard.Text = "Nöbete Ekle";
            this.btnAddPersonalToGuard.UseVisualStyleBackColor = true;
            this.btnAddPersonalToGuard.Click += new System.EventHandler(this.btnAddPersonalToGuard_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(808, 37);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Aramak için harf giriniz...";
            this.txtSearch.Size = new System.Drawing.Size(146, 23);
            this.txtSearch.TabIndex = 8;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(780, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tüm Personeller";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(444, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nöbette Olan Personeller";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(55, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nöbet Listesi";
            // 
            // btnPersonalRemove
            // 
            this.btnPersonalRemove.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPersonalRemove.Location = new System.Drawing.Point(472, 476);
            this.btnPersonalRemove.Name = "btnPersonalRemove";
            this.btnPersonalRemove.Size = new System.Drawing.Size(165, 32);
            this.btnPersonalRemove.TabIndex = 3;
            this.btnPersonalRemove.Text = "Nöbetten Çıkar";
            this.btnPersonalRemove.UseVisualStyleBackColor = true;
            this.btnPersonalRemove.Click += new System.EventHandler(this.btnPersonalRemove_Click);
            // 
            // lstAllPersonal
            // 
            this.lstAllPersonal.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lstAllPersonal.FormattingEnabled = true;
            this.lstAllPersonal.ItemHeight = 17;
            this.lstAllPersonal.Location = new System.Drawing.Point(743, 66);
            this.lstAllPersonal.Name = "lstAllPersonal";
            this.lstAllPersonal.Size = new System.Drawing.Size(211, 378);
            this.lstAllPersonal.TabIndex = 2;
            // 
            // lstGuardPersonal
            // 
            this.lstGuardPersonal.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lstGuardPersonal.FormattingEnabled = true;
            this.lstGuardPersonal.ItemHeight = 17;
            this.lstGuardPersonal.Location = new System.Drawing.Point(444, 66);
            this.lstGuardPersonal.Name = "lstGuardPersonal";
            this.lstGuardPersonal.Size = new System.Drawing.Size(211, 378);
            this.lstGuardPersonal.TabIndex = 1;
            // 
            // btnBack
            // 
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBack.Location = new System.Drawing.Point(23, 21);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(136, 28);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "Geriye Git";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // GuardPersonalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 628);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GuardPersonalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nöbetlere Personel Seç";
            this.Load += new System.EventHandler(this.GuardPersonalForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstGuard;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstAllPersonal;
        private System.Windows.Forms.ListBox lstGuardPersonal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnAddPersonalToGuard;
        private System.Windows.Forms.Button btnPersonalRemove;
    }
}