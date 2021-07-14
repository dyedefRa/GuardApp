using GuardApp.Model;
using GuardApp.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuardApp
{
    public partial class GuardPersonalAppointDayForm : Form
    {
        int _guardId;
        DateTime _clickedDate;
        Repository<GuardPersonal> guardPersonalRepository = new Repository<GuardPersonal>();
        Repository<GuardProgram> guardProgramRepository = new Repository<GuardProgram>();
        Repository<Personal> personalRepository = new Repository<Personal>();

        public GuardPersonalAppointDayForm(int guardId, DateTime clickedDate)
        {
            _guardId = guardId;
            _clickedDate = clickedDate;
            InitializeComponent();
        }

        private void GuardPersonalAppointDayForm_Load(object sender, EventArgs e)
        {
            var relatedPersonalId = guardPersonalRepository.List().Where(x => x.GuardId == _guardId).Select(x => x.PersonalId).ToList();
            var personalList = personalRepository.List().Where(x => relatedPersonalId.Contains(x.Id)).ToList();
            lstPersonal.DataSource = null;
            lstPersonal.Items.Clear();
            if (personalList != null)
            {
                lstPersonal.DataSource = personalList;
                lstPersonal.ValueMember = "Id";
                lstPersonal.DisplayMember = "Name";
            }
        }

        private void lstPersonal_DoubleClick(object sender, EventArgs e)
        {

        }

        private void btnAppoint_Click(object sender, EventArgs e)
        {

            var selectedPersonal = (Personal)lstPersonal.SelectedItem;


            GuardProgram guardProgram = new GuardProgram()
            {
                GuardPersonal = new GuardPersonal() { GuardId = _guardId, PersonalId = selectedPersonal.Id },
                Date = _clickedDate
            };
            guardProgramRepository.Insert(guardProgram);

        }


    }
}
