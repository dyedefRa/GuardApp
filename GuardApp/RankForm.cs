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
        int dataGridViewSelectedRow = 0;

        private void RankForm_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(237, 247, 210);
            UpdateGrid();
            dataGridView1.MouseClick += DataGridView1_MouseClick;
        }

        private void DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menuStrip = new ContextMenuStrip();
                dataGridViewSelectedRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                if (dataGridViewSelectedRow >= 0)
                {
                    dataGridView1.Rows[dataGridViewSelectedRow].Selected = true;

                    menuStrip.Items.Add("Güncelle").Name = "Guncelle";
                    menuStrip.Items.Add("Vazgeç").Name = "Vazgec";
                }
                menuStrip.Show(dataGridView1, new Point(e.X, e.Y));
                menuStrip.ItemClicked += MenuStrip_ItemClicked; ;
            }
        }

        private void MenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var selectedRankId = Convert.ToInt32(dataGridView1.Rows[dataGridViewSelectedRow].Cells["Id"].Value);

            switch (e.ClickedItem.Name.ToString())
            {
                case "Vazgec":
                    break;
                case "Guncelle":
                    {
                        RankUpdateForm guardUpdateForm = new RankUpdateForm(selectedRankId);
                        guardUpdateForm.Show();
                        this.Hide();
                    }
                    break;             
            }
        }

        private void btnCreatePersonal_Click(object sender, EventArgs e)
        {
            if (CreatedValid())
            {
                Rank rank = new Rank() { Name = txtRankName.Text };

                if (rankRepository.Insert(rank))
                {
                    ClearAll();
                    UpdateGrid();
                    MessageBox.Show("Rütbe Eklendi");
                }
                else
                    MessageBox.Show("Sistemde bir hata oluştu.");
            }
            else
                MessageBox.Show("Lütfen rütbe bilgilerini eksiksiz doldurun.");
        }

        public void UpdateGrid()
        {
            dataGridView1.DataSource = rankRepository.List().OrderByDescending(x => x.Id).ToList();
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

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nöbet listesi alanındaki nöbetleri güncellemek için farenin sağ tuşunu kullanınız.");
        }
    }
}
