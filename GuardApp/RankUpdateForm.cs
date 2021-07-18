using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GuardApp.Model;
using GuardApp.Repository;

namespace GuardApp
{
    public partial class RankUpdateForm : Form
    {
        Repository<Rank> rankRepository = new Repository<Rank>();
        Rank selectedRank;
        public RankUpdateForm(int rankId)
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(237, 247, 210);
            this.FormClosing += RankUpdateForm_FormClosing;
            selectedRank = rankRepository.GetById(rankId);
            txtRankName.Text = selectedRank.Name;
        }

        private void RankUpdateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            RankForm rankForm = new RankForm();
            rankForm.Show();
        }

        private void btnUpdateRank_Click(object sender, EventArgs e)
        {
            if (CreatedValid())
            {
                selectedRank.Name = txtRankName.Text;
                if (rankRepository.Update(selectedRank))
                {
                    MessageBox.Show("Rütbe Güncellendi");
                    RankForm rankForm = new RankForm();
                    rankForm.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Sistemde hata oluştu.");

            }
            else
                MessageBox.Show("Lütfen rütbe bilgilerini eksiksiz doldurun.");
        }
        public bool CreatedValid()
        {
            return !(string.IsNullOrEmpty(txtRankName.Text));
        }
    }
}
