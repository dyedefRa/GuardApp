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
    public partial class GuardProgress : Form
    {
        public GuardProgress()
        {
            InitializeComponent();
        }
        private List<FlowLayoutPanel> flowLayoutPanels = new List<FlowLayoutPanel>();

        private void GuardProgress_Load(object sender, EventArgs e)
        {
            GenerateDayPanel(42);
            AddLabelDayToFlDay(6,31);
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
            for (int i = 1; i < totalDaysInMonth+1; i++)
            {
                Label lbl = new Label();
                lbl.Name = $"lblDay{i}";
                lbl.AutoSize = false;
                lbl.TextAlign = ContentAlignment.MiddleRight;
                lbl.Size = new Size(150, 23);
                lbl.Text = i.ToString();
                lbl.Font = new Font("Microsoft Sans Serif", 10);
                flowLayoutPanels[(i-1)+startDayAtFlNumber-1].Controls.Add(lbl);
            }

            int count = flowLayoutPanels.Count;
       
        }
       
    }
}
