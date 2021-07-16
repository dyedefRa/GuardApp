using GuardApp.Model;
using GuardApp.Model.HelperModel;
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
        Repository<GuardProgram> guardProgramRepository = new Repository<GuardProgram>();

        private void GuardSelectForm_Load(object sender, EventArgs e)
        {
            //listBox1.DataSource = null;
            //listBox1.Items.Clear();
            //if (guardRepository != null)
            //{
            //    listBox1.DataSource = guardRepository.List();
            //    listBox1.ValueMember = "Id";
            //    listBox1.DisplayMember = "Name";
            //}
            int totalDayOnNextMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month + 1);

            if (guardRepository != null)
            {
                var newModel = guardRepository.List().Select(x =>
                {
                    return new GuardSelectionHelperModel()
                    {
                        GuardId = x.Id,
                        Name = x.Name,
                        IsFullSelectedGuardForNextMonth = guardProgramRepository.List().Where(y => y.GuardPersonal.GuardId == x.Id && y.Date.Month == DateTime.Now.Month + 1 && y.Date.Year == DateTime.Now.Year).ToList().Count == totalDayOnNextMonth ? true : false
                    };
                }).ToList();

                dataGridModel.DataSource = newModel;
                dataGridModel.Columns["GuardId"].Visible = false;
            }
        }


        //private void GuardSelectForm_Load(object sender, EventArgs e)
        //{
        //    //listBox1.DataSource = null;
        //    //listBox1.Items.Clear();
        //    //if (guardRepository != null)
        //    //{
        //    //    listBox1.DataSource = guardRepository.List();
        //    //    listBox1.ValueMember = "Id";
        //    //    listBox1.DisplayMember = "Name";
        //    //}
        //    int totalDayOnNextMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month + 1);

        //    dataGridView1.DataSource = null;

        //    if (guardRepository != null)
        //    {




        //        var newModel = guardRepository.List().Select(x =>
        //        {
        //            return new GuardSelectionHelperModel()
        //            {
        //                GuardId = x.Id,
        //                Name = x.Name,
        //                IsFullSelectedGuardForNextMonth = guardProgramRepository.List().Where(y => y.GuardPersonal.GuardId == x.Id && y.Date.Month == DateTime.Now.Month + 1 && y.Date.Year == DateTime.Now.Year).ToList().Count == totalDayOnNextMonth ? true : false

        //            };
        //        }).ToList();

        //        dataGridView1.DataSource = newModel;

        //    }
        //}

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
    }
}
