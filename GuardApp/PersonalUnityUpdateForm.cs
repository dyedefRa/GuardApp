using GuardApp.Model;
using System;
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
    public partial class PersonalUnityUpdateForm : Form
    {
        Repository<PersonalUnity> personalUnityRepository = new Repository<PersonalUnity>();
        PersonalUnity selectedPersonalUnity;

        public PersonalUnityUpdateForm(int personalUnityId)
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(237, 247, 210);
            this.FormClosing += PersonalUnityUpdateForm_FormClosing1; ;
            selectedPersonalUnity = personalUnityRepository.GetById(personalUnityId);
            txtUnityName.Text = selectedPersonalUnity.Name;
        }

        private void PersonalUnityUpdateForm_FormClosing1(object sender, FormClosingEventArgs e)
        {
            PersonalUnityForm personalUnityForm = new PersonalUnityForm();
            personalUnityForm.Show();
        }
     
        private void btnUpdateUnity_Click(object sender, EventArgs e)
        {
            if (CreatedValid())
            {
                selectedPersonalUnity.Name = txtUnityName.Text;
                if (personalUnityRepository.Update(selectedPersonalUnity))
                {
                    MessageBox.Show("Birlik Güncellendi");
                    PersonalUnityForm personalUnityForm = new PersonalUnityForm();
                    personalUnityForm.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Sistemde hata oluştu.");
            }
            else
                MessageBox.Show("Lütfen birlik bilgilerini eksiksiz doldurun.");
        }

        public bool CreatedValid()
        {
            return !(string.IsNullOrEmpty(txtUnityName.Text));
        }
    }
}
