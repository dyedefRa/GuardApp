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
using GuardApp.Helper;

namespace GuardApp
{
    public partial class GuardPersonalAppointDayForm : Form
    {
        int _guardId;
        DateTime _clickedDate;
        Repository<GuardPersonal> guardPersonalRepository = new Repository<GuardPersonal>();
        Repository<GuardProgram> guardProgramRepository = new Repository<GuardProgram>();
        Repository<Personal> personalRepository = new Repository<Personal>();
        Repository<Guard> guardRepository = new Repository<Guard>();

        GuardProgram beforeProgramPersonal;
        public GuardPersonalAppointDayForm(int guardId, DateTime clickedDate)
        {
            _guardId = guardId;
            _clickedDate = clickedDate;
            InitializeComponent();

            lblDate.Text = _clickedDate.TurkishDateTimeLongToString();
            lblGuard.Text = guardRepository.GetById(_guardId).Name;
        }

        private void GuardPersonalAppointDayForm_Load(object sender, EventArgs e)
        {
            beforeProgramPersonal = guardProgramRepository.List().FirstOrDefault(x => x.Date == _clickedDate && x.GuardPersonal.GuardId == _guardId);

            var relatedPersonalId = guardPersonalRepository.List().Where(x => x.GuardId == _guardId).Select(x => x.PersonalId).ToList();
            var personalList = personalRepository.List().Where(x => relatedPersonalId.Contains(x.Id)).ToList();

            lstPersonal.DataSource = null;
            lstPersonal.Items.Clear();
            if (personalList != null)
            {
                lstPersonal.DataSource = beforeProgramPersonal == null ? personalList : personalList.Where(x => x.Id != beforeProgramPersonal.GuardPersonal.PersonalId).ToList();
                lstPersonal.ValueMember = "Id";
                lstPersonal.DisplayMember = "Name";
            }
        }

        private void lstPersonal_DoubleClick(object sender, EventArgs e)
        {
            ApplyAppoint();
        }

        private void btnAppoint_Click(object sender, EventArgs e)
        {
            ApplyAppoint();

        }

        private void ApplyAppoint()
        {
            if (beforeProgramPersonal != null)
            {
                guardProgramRepository.Delete(beforeProgramPersonal);
            }
            var selectedPersonal = (Personal)lstPersonal.SelectedItem;

            GuardProgram guardProgram = new GuardProgram()
            {
                GuardPersonal = new GuardPersonal() { GuardId = _guardId, PersonalId = selectedPersonal.Id },
                Date = _clickedDate
            };
            if (guardProgramRepository.Insert(guardProgram))
            {
                GuardProgress guardProgress = new GuardProgress(_guardId);
                guardProgress.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sistemde sorun oluştu.");
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            GuardProgress guardProgress = new GuardProgress(_guardId);
            guardProgress.Show();
            this.Hide();
        }
    }
}
