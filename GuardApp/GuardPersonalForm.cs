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
    public partial class GuardPersonalForm : Form
    {
        public GuardPersonalForm()
        {
            InitializeComponent();
        }

        Repository<GuardPersonal> guardPersonalRepository = new Repository<GuardPersonal>();
        Repository<Personal> personalRepository = new Repository<Personal>();
        Repository<Guard> guardRepository = new Repository<Guard>();

        private void GuardPersonalForm_Load(object sender, EventArgs e)
        {
            FillGuardListBox();
            FillAllPersonalListBox();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormMain formMain = new FormMain();
            formMain.Show();
            this.Hide();
        }

        private void FillGuardListBox()
        {
            lstGuard.DataSource = guardRepository.List();
            lstGuard.ValueMember = "Id";
            lstGuard.DisplayMember = "Name";
        }

        private void FillRelatedPersonalListBox()
        {

        }

        private void FillAllPersonalListBox()
        {
            lstAllPersonal.DataSource = personalRepository.List();
            lstAllPersonal.ValueMember = "Id";
            lstAllPersonal.DisplayMember = "Name";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var searchBox = (TextBox)sender;

            if (searchBox.Text == "")
                FillAllPersonalListBox();
            else
            {
                lstAllPersonal.DataSource = null;
                lstAllPersonal.Items.Clear();
                foreach (var personal in personalRepository.List())
                {
                    if (personal.Name.ToUpper().Contains(searchBox.Text.ToUpper()))
                        lstAllPersonal.Items.Add(personal);
                }
            }
        }

        private void btnAddPersonalToGuard_Click(object sender, EventArgs e)
        {
            var relatedPersonal = (Personal)lstAllPersonal.SelectedItem;
            //HATA
            lstAllPersonal.Items.Remove(relatedPersonal);
            lstGuardPersonal.Items.Add(relatedPersonal);
        }

        private void lstGuard_MouseClick(object sender, MouseEventArgs e)
        {

            lstGuardPersonal.DataSource = null;
            lstGuardPersonal.Items.Clear();
            var selectedGuard = (Guard)lstGuard.SelectedItem;
            var guardPersonals = guardPersonalRepository.List().Where(x => x.GuardId == selectedGuard.Id);
            var personals = personalRepository.List().Where(x => guardPersonals.Any(y => y.PersonalId == x.Id)).ToList();
            lstGuardPersonal.DataSource = personals;
            lstGuardPersonal.ValueMember = "Id";
            lstGuardPersonal.DisplayMember = "Name";
        }
    }
}
