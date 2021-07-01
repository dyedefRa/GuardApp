using GuardApp.Helper;
using GuardApp.Model;
using System;
using System.Collections;
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
    public partial class PersonalForm : Form
    {
        public PersonalForm()
        {
            InitializeComponent();
        }

        Context cn = new Context ();
      

        private void btnCreatePersonal_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void PersonalForm_Load(object sender, EventArgs e)
        {
            //var ss = cn.Personals.ToList();
            //var hg=cn.Ranks.ToList();
            //ViewModals viewModals = new ViewModals();
            //dataGridView1.DataSource = viewModals.ConvertPersonalModel(cn.Personals.ToList());
         

            dataGridView1.DataSource = cn.Personals.ToList();
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["RankId"].Visible = false;
        
            //dataGridView1.AutoGenerateColumns = false;
            //dataGridView1.Columns[0].HeaderText = "Id";
            //dataGridView1.Columns[1].HeaderText = "Rütbe";
            //dataGridView1.Columns[2].HeaderText = "Ad / Soyad";
            //dataGridView1.Columns[3].HeaderText = "Dönemi";
            //dataGridView1.Columns[4].HeaderText = "Aktif Mi?";
            //dataGridView1.Columns[0].Visible = false;
            //dataGridView1.DataSource = cn.Personals.ToList();

            // foreach (var item in collection)
            // {

            // }
            //ArrayList




            ////dataGridView1.Columns[""]
            ///UpdateGrid
            //UpdateGrid();
        }

        public void UpdateGrid()
        {
            //dataGridView1.ColumnCount = 4;
            //dataGridView1.Columns[0].Name = "Rütbe";
            //dataGridView1.Columns[1].Name = "Ad / Soyad";
            //dataGridView1.Columns[2].Name = "Dönemi";
            //dataGridView1.Columns[3].Name = "Aktif Mi?";

            //ArrayList row = new ArrayList();
            //foreach (var per in cn.Personals.ToList())
            //{
            //    row.Add(per.Rank);
            //    row.Add(per.Name);
            //    row.Add(per.Term);
            //    row.Add(per.IsActive);
            //    dataGridView1.Rows.Add(row.ToArray());             
            //}
            dataGridView1.DataSource = cn.Personals.ToList();
        }
    }
}
