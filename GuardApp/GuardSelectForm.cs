using GuardApp.Helper;
using GuardApp.Model;
using GuardApp.Model.HelperModel;
using GuardApp.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuardApp
{
    public partial class GuardSelectForm : Form
    {
        public GuardSelectForm()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.tr;
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        Repository<Personal> personalRepository = new Repository<Personal>();
        Repository<Guard> guardRepository = new Repository<Guard>();
        Repository<GuardProgram> guardProgramRepository = new Repository<GuardProgram>();
        List<bool> guardCompleteList = new List<bool>();

        private void GuardSelectForm_Load(object sender, EventArgs e)
        {
            int totalDayOnNextMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month + 1);

            if (guardRepository != null)
            {
                var newModel = guardRepository.List().Where(x => x.IsActive == true).Select(x =>
                    {
                        bool isCompleteGuard = guardProgramRepository.List().Where(y => y.GuardPersonal.GuardId == x.Id && y.Date.Month == DateTime.Now.Month + 1 && y.Date.Year == DateTime.Now.Year).ToList().Count == totalDayOnNextMonth ? true : false;
                        guardCompleteList.Add(isCompleteGuard);
                        return new GuardSelectionHelperModal()
                        {
                            GuardId = x.Id,
                            Name = x.Name,
                            IsFullSelectedGuardForNextMonth = isCompleteGuard
                        };

                    }).ToList();

                dataGridModel.DataSource = newModel;
                dataGridModel.Columns["GuardId"].Visible = false;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormMain formMain = new FormMain();
            formMain.Show();
            this.Hide();
        }

        private void dataGridModel_Click(object sender, EventArgs e)
        {
            if (dataGridModel.CurrentCell != null)
            {
                int rowIndex = dataGridModel.CurrentCell.RowIndex;
                int selectedGuardId = Convert.ToInt32(dataGridModel.Rows[rowIndex].Cells["GuardId"].Value);
                GuardProgress guardProgress = new GuardProgress(selectedGuardId);
                guardProgress.Show();
                this.Hide();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DateTime nextDate = DateTime.Now.AddMonths(1);


            //if (guardCompleteList.Any(x => x == false))
            //{
            //    MessageBox.Show(nextDate.TurkishDateTimeShortToString() + " tarihi için tamamlanmamış nöbetler bulunmaktadır.Lütfen tüm nöbetleri eksiksiz doldurun...");
            //}
            //else
            //{

            List<PDFHelperViewModal> pDFHelperModals;

                var nextMonthGuardProgramList = guardProgramRepository.List().Where(x => x.Date.Month == nextDate.Month && x.Date.Year == nextDate.Year).ToList();
                if (nextMonthGuardProgramList != null)
                {

                    pDFHelperModals = nextMonthGuardProgramList
                      .GroupBy(x => new { x.GuardPersonal.Guard, x.GuardPersonal.Personal })
                      .Select(y => new PDFHelperViewModal()
                      {
                          GuardName = y.Key.Guard.Name,
                          GuardNumber = y.Key.Guard.Number,
                          PersonalInformation = y.Key.Personal.GetIdentityForPdf(),
                          UnityName = y.Key.Personal.PersonalUnity?.Name,
                          GuardDayOnMonth = y.ToList().Select(x => x.Date.Day).ToList(),

                      }).ToList();

                    ReportHelper reportHelper = new ReportHelper();

                    string documentName = nextDate.PDFDocumentFolderPathToString();
                    File.WriteAllBytes(documentName, reportHelper.PrepareReport(pDFHelperModals));
                }
                else
                {
                    MessageBox.Show("Sistemde hata oluştu.Lütfen daha sonra tekrar deneyiniz...");
                }

            //    MessageBox.Show("Yazdırılıyor.");
            //}
        }


    }
}

