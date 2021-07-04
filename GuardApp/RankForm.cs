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
    public partial class RankForm : Form
    {
        public RankForm()
        {
            InitializeComponent();
        }

        Repository<Rank> rankRepository = new Repository<Rank>();

        private void RankForm_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(237, 247, 210);
            UpdateGrid();
        }

        private void btnCreatePersonal_Click(object sender, EventArgs e)
        {
            if (CreatedValid())
            {
                string rankName = txtRankName.Text;

                Rank rank = new Rank()
                {
                    Name = rankName
                };
          
                if (rankRepository.Insert(rank))
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
                MessageBox.Show("Lütfen rütbe bilgilerini eksiksiz doldurun.");
            }
        }
       
        public void UpdateGrid()
        {
            dataGridView1.DataSource = rankRepository.List();
            dataGridView1.Columns["Id"].Visible = false;         
        }

        public bool CreatedValid()
        {
            return !(string.IsNullOrEmpty(txtRankName.Text));
        }

        private void ClearAll()
        {
            txtRankName.Text = string.Empty;         
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormMain formMain = new FormMain();
            formMain.Show();
            this.Hide();
        }
    }
}
