using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VCCorp_Crawler_si_demand_source_INS
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            loginINS fr = new loginINS();
            fr.Show();
        }

        private void btnPostINS_Click(object sender, EventArgs e)
        {
            frmSourcedemaind_INS fr = new frmSourcedemaind_INS();
            fr.Show();
        }

        private void btnCmtINS_Click(object sender, EventArgs e)
        {
            frmPostdemandsource_INS fr = new frmPostdemandsource_INS();
            fr.Show();
        }

        private void btnFindsourceID_Click(object sender, EventArgs e)
        {
            frmFindlSourceID_INS fr = new frmFindlSourceID_INS();
            fr.Show();
        }

        private void btnCrwSidataExcel_Click(object sender, EventArgs e)
        {
            frmCrwSi_data_ExcelPost fr = new frmCrwSi_data_ExcelPost();
            fr.Show();
        }

        private void btnSourcStatus0_Click(object sender, EventArgs e)
        {
            frmSourcesdemainNew fr = new frmSourcesdemainNew();
            fr.Show();
        }

        private void btnINS_Click(object sender, EventArgs e)
        {
            frmOneINS fr = new frmOneINS();
            fr.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
