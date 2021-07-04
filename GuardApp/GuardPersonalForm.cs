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

        Repository<GuardProgram> guardProgramRepository = new Repository<GuardProgram>();
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
    }
}
