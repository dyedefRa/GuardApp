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
    public partial class GuardSelectForm : Form
    {
        public GuardSelectForm()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.tr;
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        Repository<Guard> guardRepository = new Repository<Guard>();

        private void GuardSelectForm_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = null;
            listBox1.Items.Clear();
            if (guardRepository != null)
            {
                listBox1.DataSource = guardRepository.List();
                listBox1.ValueMember = "Id";
                listBox1.DisplayMember = "Name";
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            Guard selectedGuard = (Guard)listBox1.SelectedItem;
            GuardProgress guardProgress = new GuardProgress(selectedGuard.Id);
            guardProgress.Show();
            this.Hide();
        }
    }
}
