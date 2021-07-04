using GuardApp.Model;
using GuardApp.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuardApp
{
    public partial class GuardForm : Form
    {
        public GuardForm()
        {
            InitializeComponent();
        }

        Repository<Guard> guardRepository = new Repository<Guard>();

        private void GuardForm_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(237, 247, 210);
            UpdateGrid();
        }

        private void btnCreateGuard_Click(object sender, EventArgs e)
        {
            if (CreatedValid())
            {
                string guardName = txtGuardName.Text;

                Guard guard = new Guard()
                {
                    Name = guardName
                };

                if (guardRepository.Insert(guard))
                {
                    ClearAll();
                    UpdateGrid();
                }
                else
                {
                    MessageBox.Show("Sistemde bir hata oluştu.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen nöbet bilgilerini eksiksiz doldurun.");
            }
        }

        public void UpdateGrid()
        {
            dataGridView1.DataSource = guardRepository.List();
            dataGridView1.Columns["Id"].Visible = false;
        }

        public bool CreatedValid()
        {
            return !(string.IsNullOrEmpty(txtGuardName.Text));
        }

        private void ClearAll()
        {
            txtGuardName.Text = string.Empty;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormMain formMain = new FormMain();
            formMain.Show();
            this.Hide();
        }
    }
}
