using System;
using System.Linq;
using System.Windows.Forms;
using VCCorp.CrawlerCore.Base;

namespace VCCorp_Crawler_si_demand_source_INS.x_ig_app_id
{
    public partial class frmCache : Form
    {
        private static readonly Random random = new Random();

        public frmCache()
        {
            InitializeComponent();
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ckbCheck.Checked)
                IgRunTime.CachePath = @"C:\CEFSharp_Cache" + RandomString(6);
            else
                IgRunTime.CachePath = @"C:\CEFSharp_Cache";
            Hide();
            var frm = new frmMain();
            frm.Closed += (s, args) => Close();
            frm.Show();
            //create random string by length
        }
    }
}