using GuardApp.Model;
using GuardApp.Repository;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GuardApp
{
    public partial class PersonalForm : Form
    {
        public PersonalForm()
        {
            InitializeComponent();
        }

        Repository<Personal> personalRepository = new Repository<Personal>();
        Repository<Rank> rankRepository = new Repository<Rank>();
        Repository<PersonalUnity> personalUnityRepository = new Repository<PersonalUnity>();
        int dataGridViewSelectedRow = 0;

        private void PersonalForm_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(237, 247, 210);
            UpdateGrid();
            FillComboBox();
            FillComboBoxUnity();
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
                    menuStrip.Items.Add("Pasif/Aktif Yap").Name = "Pasif/Aktif Yap";
                    menuStrip.Items.Add("Vazgeç").Name = "Vazgec";
                }
                menuStrip.Show(dataGridView1, new Point(e.X, e.Y));
                menuStrip.ItemClicked += MenuStrip_ItemClicked;
            }
        }

        private void MenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var selectedPersonalId = Convert.ToInt32(dataGridView1.Rows[dataGridViewSelectedRow].Cells["Id"].Value);

            switch (e.ClickedItem.Name.ToString())
            {
                case "Vazgec":
                    break;
                case "Guncelle":
                    {
                        PersonalUpdateForm personalUpdateForm = new PersonalUpdateForm(selectedPersonalId);
                        personalUpdateForm.Show();
                        this.Hide();
                    }
                    break;
                case "Pasif/Aktif Yap":
                    {
                        var personal = personalRepository.GetById(selectedPersonalId);
                        personal.IsActive = !personal.IsActive;
                        personalRepository.Update(personal);
                        this.Refresh();
                        break;
                    }
            }
        }

        private void btnCreatePersonal_Click(object sender, EventArgs e)
        {
            if (CreatedValid())
            {
                Personal personal = new Personal()
                {
                    Name = txtName.Text,
                    Term = txtTerm.Text,
                    RankId = ((Rank)comboBox1.SelectedItem).Id,
                    PersonalUnityId = ((PersonalUnity)comboBox2.SelectedItem).Id
                };
                if (personalRepository.Insert(personal))
                {
                    ClearAll();
                    UpdateGrid();
                    MessageBox.Show("Personel başarıyla eklendi");
                }
                else
                {
                    MessageBox.Show("Sistemde bir hata oluştu.Açılan pencereden yardım alın.");
                    btnHelp_Click(this, EventArgs.Empty);
                }
            }
            else
                MessageBox.Show("Lütfen personel bilgilerini eksiksiz doldurun.");
        }

        public void UpdateGrid()
        {
            dataGridView1.DataSource = personalRepository.List().OrderByDescending(x => x.Id).ToList();
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["RankId"].Visible = false;
            dataGridView1.Columns["PersonalUnityId"].Visible = false;
            dataGridView1.Columns["Rank"].DisplayIndex = 1;
            dataGridView1.Columns["PersonalUnity"].DisplayIndex = 4;
        }

        public void FillComboBox()
        {
            comboBox1.DataSource = rankRepository.List();
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Name";
        }

        public void FillComboBoxUnity()
        {
            comboBox2.DataSource = personalUnityRepository.List();
            comboBox2.ValueMember = "Id";
            comboBox2.DisplayMember = "Name";
        }

        public bool CreatedValid()
        {
            return !(string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtTerm.Text) || comboBox1.SelectedItem == null || comboBox2.SelectedItem == null);
        }

        private void ClearAll()
        {
            txtName.Text = string.Empty;
            txtTerm.Text = string.Empty;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string message = "Aradığınız rütbeyi bulamadıysanız 'Yes'e basınız."
                 + Environment.NewLine
                 + "Sayfa hakkında bilgi almak için 'No'ya basınız."
                 + Environment.NewLine
                 + "İptal etmek için 'Cancel' a basınız.";
            DialogResult result = MessageBox.Show(message, "Yardım", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Rütbe ekleme sayfasına yönlendiriliyorsunuz");
                btnCreateRank_Click(this, EventArgs.Empty);
            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("Personel listesi alanındaki personelleri güncellemek/pasif yapmak için farenin sağ tuşunu kullanınız."
                + Environment.NewLine
                + "Bir personeli pasif yapmak => Pasif olan Personeli sistem içerisinde kullanamazsınız.Sistem içerisinde kullanmak için Personeli aktif yapınız. ");
            }
            else
            {

            }
        }

        private void btnCreateRank_Click(object sender, EventArgs e)
        {
            RankForm rankForm = new RankForm();
            rankForm.Show();
            this.Hide();
        }

        private void btnCreateUnity_Click(object sender, EventArgs e)
        {
            PersonalUnityForm personalUnityForm = new PersonalUnityForm();
            personalUnityForm.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormMain formMain = new FormMain();
            formMain.Show();
            this.Hide();
        }
     
    }
}
