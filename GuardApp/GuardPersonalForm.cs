﻿using System;
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
            this.BackgroundImage = Properties.Resources.tr;
            BackgroundImageLayout = ImageLayout.Stretch;
        }
        // liste olayını degıstır.
        Repository<GuardPersonal> guardPersonalRepository = new Repository<GuardPersonal>();
        Repository<Personal> personalRepository = new Repository<Personal>();
        Repository<Guard> guardRepository = new Repository<Guard>();



        int relatedGuardId = 0;
        List<Personal> relatedPersonals = new List<Personal>();
        List<Personal> otherPersonals = new List<Personal>();
        private void GuardPersonalForm_Load(object sender, EventArgs e)
        {
            //Apply();
            FillGuardListBox();

            //FillRelatedPersonalListBox();


            FillPersonalListBoxes();
            // USTTEK METHODLARI DUZENLE . SAYFA YUKLENDIGINDE OTOMATIK VAR OLAN KAYITLARI GETIR DEGISTIRILDIGINDE ISE GUNCELLE
            //var defaultChoosenGuard =(Guard) lstGuard.SelectedItem;
            //relatedGuardId = defaultChoosenGuard.Id;

            ////if (lstGuard.Items.Count > 0)
            ////{
            ////    var ss = lstGuard.Items[0];

            //// var gasa=   lstGuard.SelectedItem;
            ////    lstGuard.Select();
            ////    lstGuard.Select();
            ////}
            //FillRelatedPersonalListBox();

            //FillAllPersonalListBox();

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

            var relatedPersonalId = guardPersonalRepository.List().Where(x => x.GuardId == relatedGuardId).ToList().Select(x => x.PersonalId).ToList();

             relatedPersonals = personalRepository.List().Where(x => relatedPersonalId.Contains(x.Id)).ToList();

            lstGuardPersonal.DataSource = null;
            if (relatedPersonals != null)
            {
                lstGuardPersonal.DataSource = relatedPersonals.ToList();
                lstGuardPersonal.ValueMember = "Id";
                lstGuardPersonal.DisplayMember = "Name";
            }
        }

        private void FillAllPersonalListBox()
        {
            //var relatedPersonalId = guardPersonalRepository.List().Where(x => x.GuardId == relatedGuardId).ToList().Select(x => x.PersonalId).ToList();

            //var otherPersonals = personalRepository.List().Where(x => !relatedPersonalId.Contains(x.Id)).ToList();
            otherPersonals = personalRepository.List().Except(relatedPersonals).ToList();

            lstAllPersonal.DataSource = null;
            if (otherPersonals != null)
            {
                lstAllPersonal.DataSource = otherPersonals.ToList();
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
                foreach (var personal in otherPersonals)
                {
                    if (personal.Name.ToUpper().Contains(searchBox.Text.ToUpper()))
                        lstAllPersonal.Items.Add(personal);
                }
            }
        }

        private void btnAddPersonalToGuard_Click(object sender, EventArgs e)
        {
            var relatedPersonal = (Personal)lstAllPersonal.SelectedItem;
            guardPersonalRepository.Insert(new GuardPersonal() { GuardId = relatedGuardId, PersonalId = relatedPersonal.Id });
            FillPersonalListBoxes();
        }

        private void btnPersonalRemove_Click(object sender, EventArgs e)
        {
            var relatedPersonal = (Personal)lstGuardPersonal.SelectedItem;
            var relatedPersonalGuard = guardPersonalRepository.List().FirstOrDefault(x => x.GuardId == relatedGuardId && x.PersonalId == relatedPersonal.Id);

            guardPersonalRepository.Delete(relatedPersonalGuard);
            FillPersonalListBoxes();
        }

        private void lstGuard_MouseClick(object sender, MouseEventArgs e)
        {
            FillPersonalListBoxes();
        }

        private void FillPersonalListBoxes()
        {

            var selectedGuard = (Guard)lstGuard.SelectedItem;
            relatedGuardId = selectedGuard.Id;
            FillRelatedPersonalListBox();
            FillAllPersonalListBox();
            //lstGuardPersonal.DataSource = null;
            //lstGuardPersonal.Items.Clear();
            //var selectedGuard = (Guard)lstGuard.SelectedItem;
            //var guardPersonals = guardPersonalRepository.List().Where(x => x.GuardId == selectedGuard.Id);
            //var personals = personalRepository.List().Where(x => guardPersonals.Any(y => y.PersonalId == x.Id)).ToList();
            //personOnTheGuard = personals;
            //allPersonalExceptRelatedGroup = personalRepository.List().Except(personals).ToList();
            //lstGuardPersonal.DataSource = personOnTheGuard.ToList();
            //lstGuardPersonal.ValueMember = "Id";
            //lstGuardPersonal.DisplayMember = "Name";
        }

      
    }
}
