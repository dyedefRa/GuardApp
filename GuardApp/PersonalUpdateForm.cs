using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GuardApp.Model;
using GuardApp.Repository;

namespace GuardApp
{
    public partial class PersonalUpdateForm : Form
    {
        Repository<Personal> personalRepository = new Repository<Personal>();
        Repository<Rank> rankRepository = new Repository<Rank>();
        Personal selectedPersonal;

        public PersonalUpdateForm(int personalId)
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(237, 247, 210);
            this.FormClosing += PersonalUpdateForm_FormClosing;
            selectedPersonal = personalRepository.GetById(personalId);
            FillComboBox();
            txtName.Text = selectedPersonal.Name;
            txtTerm.Text = selectedPersonal.Term;
            if (selectedPersonal.IsActive)
                radioButtonActive.Checked = true;
            else
                radioButtonPassive.Checked = true;
            comboBox1.SelectedValue = selectedPersonal.RankId;
        }

        private void PersonalUpdateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            PersonalForm personalForm = new PersonalForm();
            personalForm.Show();
        }

        private void btnUpdatePersonal_Click(object sender, EventArgs e)
        {
            if (CreatedValid())
            {
                selectedPersonal.Name = txtName.Text;
                selectedPersonal.Term = txtTerm.Text;
                selectedPersonal.IsActive = radioButtonActive.Checked;
                selectedPersonal.Rank =(Rank) comboBox1.SelectedItem;
                if (personalRepository.Update(selectedPersonal))
                {                    
                    MessageBox.Show("Personel Güncellendi");
                    PersonalForm personalForm = new PersonalForm();
                    personalForm.Show();
                    this.Hide();
                }
                else                
                    MessageBox.Show("Sistemde hata oluştu.");               
            }
            else
                MessageBox.Show("Lütfen personel bilgilerini eksiksiz doldurun.");
        }

        public bool CreatedValid()
        {
            return !(string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtTerm.Text) || comboBox1.SelectedItem == null);
        }

        public void FillComboBox()
        {
            comboBox1.DataSource = rankRepository.List();
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Name";
        }
      
    }
}
