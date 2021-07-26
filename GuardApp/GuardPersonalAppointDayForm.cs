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
using GuardApp.Model.HelperModel;

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
            try
            {
                beforeProgramPersonal = guardProgramRepository.List().FirstOrDefault(x => x.Date == _clickedDate && x.GuardPersonal.GuardId == _guardId);

                var relatedPersonalId = guardPersonalRepository.List().Where(x => x.GuardId == _guardId).Select(x => x.PersonalId).ToList();
                var personalList = personalRepository.List().Where(x => relatedPersonalId.Contains(x.Id)).ToList();
              
                List<PersonalViewModal> personalViewModals = personalList.PersonalDisplayerFormatList();
                lstPersonal.DataSource = null;
                lstPersonal.Items.Clear();
                if (personalViewModals != null)
                {
                    lstPersonal.DataSource = beforeProgramPersonal == null ? personalViewModals : personalViewModals.Where(x => x.PersonalId != beforeProgramPersonal.GuardPersonal.PersonalId).ToList();
                    lstPersonal.ValueMember = "PersonalId";
                    lstPersonal.DisplayMember = "Name";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void lstPersonal_Click(object sender, EventArgs e)
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
            var selectedPersonalViewModal = (PersonalViewModal)lstPersonal.SelectedItem;
            if (selectedPersonalViewModal!=null)
            {


                GuardProgram guardProgram = new GuardProgram()
                {
                    GuardPersonal = new GuardPersonal() { GuardId = _guardId, PersonalId = selectedPersonalViewModal.PersonalId },
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
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            GuardProgress guardProgress = new GuardProgress(_guardId);
            guardProgress.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GuardPersonalForm guardPersonalForm = new GuardPersonalForm();
            guardPersonalForm.Show();
            this.Hide();
        }
    }
}
