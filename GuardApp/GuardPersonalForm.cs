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
        // liste olayını degıstır.
        Repository<GuardPersonal> guardPersonalRepository = new Repository<GuardPersonal>();
        Repository<Personal> personalRepository = new Repository<Personal>();
        Repository<Guard> guardRepository = new Repository<Guard>();

        List<Personal> personOnTheGuard;
        List<Personal> allPersonalExceptRelatedGroup;

        int relatedGuardId = 0;

        private void GuardPersonalForm_Load(object sender, EventArgs e)
        {
            //Apply();
            //FillGuardListBox();
            //FillAllPersonalListBox();
            //FillRelatedPersonalListBox();

            // USTTEK METHODLARI DUZENLE . SAYFA YUKLENDIGINDE OTOMATIK VAR OLAN KAYITLARI GETIR DEGISTIRILDIGINDE ISE GUNCELLE
            var defaultChoosenGuard =(Guard) lstGuard.SelectedItem;
            relatedGuardId = defaultChoosenGuard.Id;

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
            //lstGuardPersonal.DataSource = null;
            //if (personOnTheGuard!=null)
            //{
            //    lstGuardPersonal.DataSource = personOnTheGuard.ToList();
            //    lstGuardPersonal.ValueMember = "Id";
            //    lstGuardPersonal.DisplayMember = "Name";
            //}
            var relatedPersonal = guardPersonalRepository.List().Where(x => x.GuardId == relatedGuardId).Select(y => y.Personal).ToList();
        }

        private void FillAllPersonalListBox()
        {
            lstAllPersonal.DataSource = null;
            if (allPersonalExceptRelatedGroup!=null)
            {
                lstAllPersonal.DataSource = allPersonalExceptRelatedGroup.ToList();
                lstAllPersonal.ValueMember = "Id";
                lstAllPersonal.DisplayMember = "Name";
            }
          
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
                foreach (var personal in allPersonalExceptRelatedGroup)
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

            allPersonalExceptRelatedGroup.Remove(relatedPersonal);
            personOnTheGuard.Add(relatedPersonal);
            FillAllPersonalListBox();
            FillRelatedPersonalListBox();
        }

        private void lstGuard_MouseClick(object sender, MouseEventArgs e)
        {

            Apply();
        }

        private void Apply()
        {
            lstGuardPersonal.DataSource = null;
            lstGuardPersonal.Items.Clear();
            var selectedGuard = (Guard)lstGuard.SelectedItem;
            var guardPersonals = guardPersonalRepository.List().Where(x => x.GuardId == selectedGuard.Id);
            var personals = personalRepository.List().Where(x => guardPersonals.Any(y => y.PersonalId == x.Id)).ToList();
            personOnTheGuard = personals;
            allPersonalExceptRelatedGroup = personalRepository.List().Except(personals).ToList();
            lstGuardPersonal.DataSource = personOnTheGuard.ToList();
            lstGuardPersonal.ValueMember = "Id";
            lstGuardPersonal.DisplayMember = "Name";
        }
    }
}
