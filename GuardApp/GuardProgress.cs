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

        private void GuardProgress_Load(object sender, EventArgs e)
        {
            GenerateDayPanel(37);
        }

        private void GenerateDayPanel(int totalDays)
        {
            flDays.Controls.Clear();
            for (int i = 1; i <= totalDays; i++)
            {
                FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
                flowLayoutPanel.Name = $"flDay{i} fsagg";
                flowLayoutPanel.Size = new Size(158, 115);
                flowLayoutPanel.BackColor = Color.White;
                flowLayoutPanel.Margin = new Padding(2, 2, 2, 2);
       
                flDays.Controls.Add(flowLayoutPanel);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
