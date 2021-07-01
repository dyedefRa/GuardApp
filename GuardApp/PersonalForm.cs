using GuardApp.Helper;
using GuardApp.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GuardApp.Repository;

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
                //SingletonDb.Context.Personals.Add
                if (personalRepository.Insert(personal))
                {
                    ClearAll();
                    UpdateGrid();
                    MessageBox.Show("Personel başarıyla eklendi");
                }
                else
                {
                    MessageBox.Show("Sistemde bir hata oluştu.Açılan pencereden yardım alın.");
                    btnHelp_Click(this,EventArgs.Empty);
                }
            }
            else
            {
                MessageBox.Show("Lütfen personel bilgilerini eksiksiz doldurun.");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void PersonalForm_Load(object sender, EventArgs e)
        {
            UpdateGrid();
            FillComboBox();
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

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }
        private void ClearAll()
        {
            txtName.Text = string.Empty;
            txtTerm.Text = string.Empty;
            comboBox1.SelectedIndex = 0;
        }
    }
}
