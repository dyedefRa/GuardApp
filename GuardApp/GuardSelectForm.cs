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

        //Burayı sil 
        Repository<Personal> personalRepository = new Repository<Personal>();

        Repository<Guard> guardRepository = new Repository<Guard>();
        Repository<GuardProgram> guardProgramRepository = new Repository<GuardProgram>();
        List<bool> guardCompleteList = new List<bool>();

        private void GuardSelectForm_Load(object sender, EventArgs e)
        {
            int totalDayOnNextMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month + 1);

            if (guardRepository != null)
            {
                var newModel = guardRepository.List().Where(x=>x.IsActive==true).Select(x =>
                {
                    bool isCompleteGuard = guardProgramRepository.List().Where(y => y.GuardPersonal.GuardId == x.Id && y.Date.Month == DateTime.Now.Month + 1 && y.Date.Year == DateTime.Now.Year).ToList().Count == totalDayOnNextMonth ? true : false;
                    guardCompleteList.Add(isCompleteGuard);
                    return new GuardSelectionHelperModel()
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

            if (guardCompleteList.Any(x=>x==false))
            {
                string date = DateTime.Now.AddMonths(1).TurkishDateTimeShortToString();         
                MessageBox.Show(date +" tarihi için tamamlanmamış nöbetler bulunmaktadır.Lütfen tüm nöbetleri eksiksiz doldurun...");
            }
            else
            {
                MessageBox.Show("Yazdırılıyor.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReportHelper reportHelper = new ReportHelper();

            File.WriteAllBytes("D:/hello.pdf", reportHelper.PrepareReport(personalRepository.List()));
        }
    }
}
