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
using GuardApp.Model.HelperModel;
using GuardApp.Repository;
using GuardApp.Helper;

namespace GuardApp
{
    public partial class GuardPersonalForm : Form
    {
        public GuardPersonalForm()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.tr;
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        Repository<GuardPersonal> guardPersonalRepository = new Repository<GuardPersonal>();
        Repository<Personal> personalRepository = new Repository<Personal>();
        Repository<Guard> guardRepository = new Repository<Guard>();

        int relatedGuardId = 0;
        List<Personal> relatedPersonals = new List<Personal>();
        List<Personal> otherPersonals = new List<Personal>();
        List<PersonalViewModal> otherChangedList = new List<PersonalViewModal>();
        private void GuardPersonalForm_Load(object sender, EventArgs e)
        {
            FillGuardListBox();
            FillPersonalListBoxes();
            // USTTEK METHODLARI DUZENLE . SAYFA YUKLENDIGINDE OTOMATIK VAR OLAN KAYITLARI GETIR DEGISTIRILDIGINDE ISE GUNCELLE
            ShowGuardNameOnLabel();
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
            try
            {
                var relatedPersonalId = guardPersonalRepository.List().Where(x => x.GuardId == relatedGuardId && x.Personal.IsActive == true).ToList().Select(x => x.PersonalId).ToList();
                relatedPersonals = personalRepository.List().Where(x => relatedPersonalId.Contains(x.Id) && x.IsActive == true).ToList();

                List<PersonalViewModal> personalViewModals = relatedPersonals.PersonalDisplayerFormatList();

                lstGuardPersonal.DataSource = null;
                if (personalViewModals != null)
                {
                    lstGuardPersonal.DataSource = personalViewModals.ToList();
                    lstGuardPersonal.ValueMember = "PersonalId";
                    lstGuardPersonal.DisplayMember = "Name";
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void FillAllPersonalListBox()
        {
            try
            {
                otherPersonals = personalRepository.List().Where(x => x.IsActive == true).Except(relatedPersonals).ToList();

                otherChangedList = otherPersonals.PersonalDisplayerFormatList();
                lstAllPersonal.DataSource = null;
                if (otherChangedList != null)
                {
                    lstAllPersonal.DataSource = otherChangedList.ToList();
                    lstAllPersonal.ValueMember = "PersonalId";
                    lstAllPersonal.DisplayMember = "Name";
                }
            }
            catch (Exception)
            {

                throw;
            }
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
                foreach (var personal in otherChangedList)
                {
                    if (personal.Name.ToUpper().Contains(searchBox.Text.ToUpper()))
                        lstAllPersonal.Items.Add(personal);
                }
            }
        }
        //Tüm personellerden seçilen personeli , Nöbete ata buton
        private void btnAddPersonalToGuard_Click(object sender, EventArgs e)
        {
            var relatedPersonalViewModal = (PersonalViewModal)lstAllPersonal.SelectedItem;
            if (relatedPersonalViewModal != null)
            {
                guardPersonalRepository.Insert(new GuardPersonal() { GuardId = relatedGuardId, PersonalId = relatedPersonalViewModal.PersonalId });
                FillPersonalListBoxes();
            }
        }
        //Tüm personellerden seçilen personeli , Nöbete ata çift tıklandığında
        private void lstAllPersonal_DoubleClick(object sender, EventArgs e)
        {
            var relatedPersonalViewModal = (PersonalViewModal)lstAllPersonal.SelectedItem;
            if (relatedPersonalViewModal != null)
            {
                guardPersonalRepository.Insert(new GuardPersonal() { GuardId = relatedGuardId, PersonalId = relatedPersonalViewModal.PersonalId });
                FillPersonalListBoxes();
            }
        }
        //Nöbetteki personeli , Nöbetten çıkar buton
        private void btnPersonalRemove_Click(object sender, EventArgs e)
        {
            var relatedPersonalViewModal = (PersonalViewModal)lstGuardPersonal.SelectedItem;
            if (relatedPersonalViewModal != null)
            {
                var relatedPersonalGuard = guardPersonalRepository.List().FirstOrDefault(x => x.GuardId == relatedGuardId && x.PersonalId == relatedPersonalViewModal.PersonalId);
                guardPersonalRepository.Delete(relatedPersonalGuard);
                FillPersonalListBoxes();
            }

        }
        //Nöbetteki personeli , Nöbetten çıkar  doubleclick
        private void lstGuardPersonal_DoubleClick(object sender, EventArgs e)
        {
            var relatedPersonalViewModal = (PersonalViewModal)lstGuardPersonal.SelectedItem;
            if (relatedPersonalViewModal != null)
            {
                var relatedPersonalGuard = guardPersonalRepository.List().FirstOrDefault(x => x.GuardId == relatedGuardId && x.PersonalId == relatedPersonalViewModal.PersonalId);
                guardPersonalRepository.Delete(relatedPersonalGuard);
                FillPersonalListBoxes();
            }
        }

        private void lstGuard_MouseClick(object sender, MouseEventArgs e)
        {
            ShowGuardNameOnLabel();
            FillPersonalListBoxes();
        }

        private void FillPersonalListBoxes()
        {
            var selectedGuard = (Guard)lstGuard.SelectedItem;
            if (selectedGuard != null)
                relatedGuardId = selectedGuard.Id;
            FillRelatedPersonalListBox();
            FillAllPersonalListBox();
        }

        private void ShowGuardNameOnLabel()
        {
            Guard selectedGuard = (Guard)lstGuard.SelectedItem;
            if (selectedGuard != null)
            {
                lblDisplayGuard.Text = selectedGuard.Name;
            }
        }

    }
}
