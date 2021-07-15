using GuardApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GuardApp.Repository;
using GuardApp.Helper;

namespace GuardApp
{
    public partial class GuardProgress : Form
    {
        public GuardProgress(int guardId)
        {
            InitializeComponent();
            _guardId = guardId;
        }
        Repository<Guard> guardRepository = new Repository<Guard>();
        Repository<GuardPersonal> guardPersonalRepository = new Repository<GuardPersonal>();
        Repository<GuardProgram> guardProgramRepository = new Repository<GuardProgram>();

        private int _guardId;
        private List<FlowLayoutPanel> flowLayoutPanels = new List<FlowLayoutPanel>();

        //Program açıldığında bir sonraki ay default olarak gelsin.
        //nextDate üzerinden yakalacagız -1 Month +1Month next prevleri
        private DateTime nextDate = DateTime.Today.AddMonths(1);
        private void GuardProgress_Load(object sender, EventArgs e)
        {
            lnkToday.Text = DateTime.Today.TurkishDateTimeLongToString();
            lblSelectedGuard.Text = guardRepository.GetById(_guardId).Name;
            GenerateDayPanel(42);
            DisplayCurrentDate();
        }

        private void DisplayCurrentDate()
        {
            lblMonthAndYear.Text = nextDate.TurkishDateTimeShortToString();
            AddLabelDayToFlDay(GetFirstDayOfWeekOfCurrentDate(), GetTotalDaysOfDate());
        }

        private void PrevMonth()
        {
            nextDate = nextDate.AddMonths(-1);
            DisplayCurrentDate();
        }

        private void NextMonth()
        {
            nextDate = nextDate.AddMonths(1);
            DisplayCurrentDate();
        }

        //Toplam kaç Panel oluşturulsun (içlerine günleri yazacagız)
        private void GenerateDayPanel(int totalDays)
        {
            flDays.Controls.Clear();
            flowLayoutPanels.Clear();
            for (int i = 1; i <= totalDays; i++)
            {
                FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
                flowLayoutPanel.Name = $"flDay{i}";
                flowLayoutPanel.Size = new Size(158, 115);
                flowLayoutPanel.BackColor = Color.White;
                flowLayoutPanel.Margin = new Padding(2, 2, 2, 2);
                flowLayoutPanel.BorderStyle = BorderStyle.FixedSingle;
                flowLayoutPanel.Click += FlowLayoutPanel_Click;
                flowLayoutPanel.Cursor = Cursors.Hand;
                flDays.Controls.Add(flowLayoutPanel);
                flowLayoutPanels.Add(flowLayoutPanel);
            }
        }

        private void FlowLayoutPanel_Click(object sender, EventArgs e)
        {
            FlowLayoutPanel clickedFl = (FlowLayoutPanel)sender;

            int clickedFlowLayoutNumber = Convert.ToInt32(clickedFl.Name.Remove(0, 5));

            //Sadece numaralı olan flowlayoutlar tıklandıgında tıklanılsın
            if (GetFirstDayOfWeekOfCurrentDate() - 1 < clickedFlowLayoutNumber && clickedFlowLayoutNumber < GetFirstDayOfWeekOfCurrentDate() + GetTotalDaysOfDate())
            {
                int clickedDay = clickedFlowLayoutNumber - GetFirstDayOfWeekOfCurrentDate() + 1;
                var clickedDate = new DateTime(nextDate.Year, nextDate.Month, clickedDay);
                if (DateTime.Now > clickedDate)
                    MessageBox.Show("Geçmiş Tarihli Nöbetleri Değiştiremezsiniz.");
                else
                {
                    //Buraya GuardPersonalApply formu acıp ılgılı tarıhe seçilen personeli atayacagız.
                    GuardPersonalAppointDayForm guardPersonalAppointDayForm = new GuardPersonalAppointDayForm(_guardId, clickedDate);
                    guardPersonalAppointDayForm.Show();
                    this.Hide();
                }
            }
            else
                MessageBox.Show("Bu tarihe personel atayamazsınız.");
        }

        //Kaçıncı flatlayouttan başlasın ve ayda kaç gun olacak. (Günleri oluşturma)
        private void AddLabelDayToFlDay(int startDayAtFlNumber, int totalDaysInMonth)
        {
            flowLayoutPanels.ForEach(x => x.Controls.Clear());

            for (int i = 1; i < totalDaysInMonth + 1; i++)
            {
                Label lbl = new Label();
                lbl.Name = $"lblDay{i}";
                lbl.AutoSize = false;
                lbl.TextAlign = ContentAlignment.MiddleRight;
                lbl.Size = new Size(150, 23);
                lbl.Text = i.ToString();
                lbl.Font = new Font("Microsoft Sans Serif", 10);
                flowLayoutPanels[(i - 1) + (startDayAtFlNumber - 1)].Controls.Add(lbl);

                ////Sistemdeki atanmış günleri ve o gündeki kişileri flowlayout içine yazalım.
                DateTime thisDate = new DateTime(nextDate.Year, nextDate.Month, i);
                var thatSavedDate = guardProgramRepository.List().FirstOrDefault(x => x.Date == thisDate && x.GuardPersonal.GuardId == _guardId);

                if (thatSavedDate != null)
                {
                    Label lblAppointedPersonal = new Label();
                    lblAppointedPersonal.Name = $"lblAppointDay{i}";
                    lblAppointedPersonal.AutoSize = true;
                    lblAppointedPersonal.TextAlign = ContentAlignment.MiddleCenter;
                    lblAppointedPersonal.Margin = new Padding(0, 10, 0, 10);
                    lblAppointedPersonal.Size = new Size(160, 30);
                    lblAppointedPersonal.Text = thatSavedDate.GuardPersonal.GetFullName();
                    lblAppointedPersonal.Font = new Font("Microsoft Sans Serif", 10,FontStyle.Bold);
                    lblAppointedPersonal.ForeColor = Color.Black;
                    flowLayoutPanels[(i - 1) + (startDayAtFlNumber - 1)].Controls.Add(lblAppointedPersonal);
                }
            }
            int count = flowLayoutPanels.Count;
        }

        private void btnPrevMonth_Click(object sender, EventArgs e)
        {
            PrevMonth();
        }

        private void btnNextMonth_Click(object sender, EventArgs e)
        {
            NextMonth();
        }

        private void lnkToday_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lblMonthAndYear.Text = DateTime.Today.TurkishDateTimeShortToString();
            nextDate = DateTime.Today;
            AddLabelDayToFlDay(GetFirstDayOfWeekOfCurrentDate(), GetTotalDaysOfDate());
        }

        private int GetFirstDayOfWeekOfCurrentDate()
        {
            DateTime firstDayOfMonth = new DateTime(nextDate.Year, nextDate.Month, 1);
            int day = (int)firstDayOfMonth.DayOfWeek;
            return day == 0 ? 7 : day;
        }

        private int GetTotalDaysOfDate()
        {
            DateTime totalDaysOfDate = new DateTime(nextDate.Year, nextDate.Month, 1);
            return totalDaysOfDate.AddMonths(1).AddDays(-1).Day;
        }
    }
}
