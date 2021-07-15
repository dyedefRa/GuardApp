using GuardApp.Model;
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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Context ctx = new Context();
      
        }

        private void btnPersonal_Click(object sender, EventArgs e)
        {
            var formPersonal = new PersonalForm();
            formPersonal.Show();
            this.Hide();

        }

        private void btnRank_Click(object sender, EventArgs e)
        {
            RankForm rankForm = new RankForm();
            rankForm.Show();
            this.Hide();
        }

        private void btnGuard_Click(object sender, EventArgs e)
        {
            GuardForm guardForm = new GuardForm();
            guardForm.Show();
            this.Hide();
        }

        private void btnMonthly_Click(object sender, EventArgs e)
        {
            GuardSelectForm guardSelectForm = new GuardSelectForm();
            guardSelectForm.Show();
            this.Hide();
        }

        private void btnGuardPersonal_Click(object sender, EventArgs e)
        {
            GuardPersonalForm guardPersonalForm = new GuardPersonalForm();
            guardPersonalForm.Show();
            this.Hide();
        }
    }
}
