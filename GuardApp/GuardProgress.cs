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

namespace GuardApp
{
    public partial class GuardProgress : Form
    {
        public GuardProgress()
        {
            InitializeComponent();
        }
        private List<FlowLayoutPanel> flowLayoutPanels = new List<FlowLayoutPanel>();
        private CultureInfo uiCulture1 = new CultureInfo("tr-TR");
        private DateTime nextDate = DateTime.Today.AddMonths(1);
        private void GuardProgress_Load(object sender, EventArgs e)
        {
            lnkToday.Text = DateTime.Today.ToString("dd/MMMM/yyyy", uiCulture1);
            GenerateDayPanel(42);
            AddLabelDayToFlDay(6, 31);
            DisplayCurrentDate();
        }

        private void DisplayCurrentDate()
        {

            lblMonthAndYear.Text = nextDate.ToString("MMMM, yyyy", uiCulture1);
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
                flDays.Controls.Add(flowLayoutPanel);
                flowLayoutPanels.Add(flowLayoutPanel);
            }
        }

        //Kaçıncı flatlayouttan başlasın ve ayda kaç gun olacak.
        private void AddLabelDayToFlDay(int startDayAtFlNumber, int totalDaysInMonth)
        {
            for (int i = 1; i < totalDaysInMonth + 1; i++)
            {
                Label lbl = new Label();
                lbl.Name = $"lblDay{i}";
                lbl.AutoSize = false;
                lbl.TextAlign = ContentAlignment.MiddleRight;
                lbl.Size = new Size(150, 23);
                lbl.Text = i.ToString();
                lbl.Font = new Font("Microsoft Sans Serif", 10);
                flowLayoutPanels[(i - 1) + startDayAtFlNumber - 1].Controls.Add(lbl);
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
            lblMonthAndYear.Text = DateTime.Today.ToString("MMMM, yyyy", uiCulture1);
        }
    }
}
