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
        int dataGridViewSelectedRow = 0;
        private void GuardForm_Load(object sender, EventArgs e)
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
                    menuStrip.Items.Add("PasifAktif").Name = "Pasif/Aktif Yap";
                    menuStrip.Items.Add("Vazgeç").Name = "Vazgec";
                }
                menuStrip.Show(dataGridView1, new Point(e.X, e.Y));
                menuStrip.ItemClicked += MenuStrip_ItemClicked;
            }
        }

        private void MenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var selectedGuardId = Convert.ToInt32(dataGridView1.Rows[dataGridViewSelectedRow].Cells["Id"].Value);

            switch (e.ClickedItem.Name.ToString())
            {
                case "Vazgec":
                    break;
                case "Guncelle":
                    {
                        GuardUpdateForm guardUpdateForm = new GuardUpdateForm(selectedGuardId);
                        guardUpdateForm.Show();
                        this.Hide();
                    }
                    break;
                case "Pasif/Aktif Yap":
                    {
                        var guard = guardRepository.GetById(selectedGuardId);
                        guard.IsActive = !guard.IsActive;
                        guardRepository.Update(guard);
                        this.Refresh();
                        break;
                    }
            }
        }

        private void btnCreateGuard_Click(object sender, EventArgs e)
        {
            if (CreatedValid())
            {
                Guard guard = new Guard() { Name = txtGuardName.Text };

                if (guardRepository.Insert(guard))
                {
                    ClearAll();
                    UpdateGrid();
                    MessageBox.Show("Yeni Nöbet Eklendi.");
                }
                else
                    MessageBox.Show("Sistemde bir hata oluştu.");
            }
            else
                MessageBox.Show("Lütfen nöbet bilgilerini eksiksiz doldurun.");
        }

        public void UpdateGrid()
        {
            dataGridView1.DataSource = guardRepository.List().OrderByDescending(x => x.Id).ToList();
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

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nöbet listesi alanındaki nöbetleri güncellemek/silmek için farenin sağ tuşunu kullanınız."
                + Environment.NewLine
                + "Bir nöbeti silmek o nöbeti Pasif yapar.Pasif olan nöbetler sadece bu  sayfada , liste alanında gösterilir.Pasif olan Nöbetleri sistem içerisinde kullanamazsınız.Sistem içerisinde kullanmak için Nöbeti aktif yapınız. ");
        }
    }
}
