using GuardApp.Model;
using GuardApp.Repository;
using System;
using System.Drawing;
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

        private void btnCreatePersonal_Click(object sender, EventArgs e)
        {
            if (CreatedValid())
            {
                string personalName = txtName.Text;
                string personalTerm = txtTerm.Text;
                Rank personalRank = (Rank)comboBox1.SelectedItem;
                Personal personal = new Personal()
                {
                    Name = personalName,
                    Term = personalTerm,
                    Rank = personalRank
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
            {
                MessageBox.Show("Lütfen personel bilgilerini eksiksiz doldurun.");
            }
        }
   
        private void PersonalForm_Load(object sender, EventArgs e)
        {
            UpdateGrid();
            FillComboBox();
            this.BackColor = Color.FromArgb(237, 247, 210);
        }

        public void UpdateGrid()
        {
            dataGridView1.DataSource = personalRepository.List();
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["RankId"].Visible = false;
            dataGridView1.Columns[5].DisplayIndex = 1;          
        }

        public void FillComboBox()
        {
            comboBox1.DataSource = rankRepository.List();
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Name";
        }

        public bool CreatedValid()
        {
            return !(string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtTerm.Text) || comboBox1.SelectedItem == null);
        }

        private void ClearAll()
        {
            txtName.Text = string.Empty;
            txtTerm.Text = string.Empty;
            comboBox1.SelectedIndex = 0;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string message = "Aradığınız rütbeyi bulamadıysanız 'Yes'e basınız."
                 + Environment.NewLine
                 + "Eklemekten sorun yaşıyorsanız 'No' ya basınız."
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
                //BURA
            }
            else
            {
               
            }
        }

        private void btnCreateRank_Click(object sender, EventArgs e)
        {
            RankForm rankForm = new RankForm();
            rankForm.Show();           
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormMain formMain = new FormMain();
            formMain.Show();
            this.Hide();
        }
    }
}
