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
    public partial class GuardUpdateForm : Form
    {
        Repository<Guard> guardRepository = new Repository<Guard>();
        Guard selectedGuard;
        public GuardUpdateForm(int guardId)
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(237, 247, 210);
            this.FormClosing += GuardUpdateForm_FormClosing;
            selectedGuard = guardRepository.GetById(guardId);
            txtGuardName.Text = selectedGuard.Name;
            if (selectedGuard.IsActive)
                radioButtonActive.Checked = true;
            else
                radioButtonPassive.Checked = true;
            numericUpDown1.Value = (decimal)selectedGuard.Number;
        }

        private void btnUpdateGuard_Click(object sender, EventArgs e)
        {
            if (CreatedValid())
            {
                selectedGuard.Name = txtGuardName.Text;
                selectedGuard.IsActive = radioButtonActive.Checked;
                selectedGuard.Number = (int)numericUpDown1.Value;
                if (guardRepository.Update(selectedGuard))
                {
                    MessageBox.Show("Nöbet Güncellendi");
                    GuardForm guardForm = new GuardForm();
                    guardForm.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Sistemde hata oluştu.");
            }
            else
                MessageBox.Show("Lütfen nöbet bilgilerini eksiksiz doldurun.");
        }

        private void GuardUpdateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GuardForm guardForm = new GuardForm();
            guardForm.Show();
        }

        public bool CreatedValid()
        {
            return !(string.IsNullOrEmpty(txtGuardName.Text));
        }

    }
}
