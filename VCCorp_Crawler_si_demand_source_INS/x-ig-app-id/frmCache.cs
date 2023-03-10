using Crwal.Core.Base;
using System;
using System.Collections.Generic;
using System.IO;
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
            GetProfileCef();
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //if (!Directory.Exists("@\"C:InstagramCEF"))
            //{
            //    Directory.CreateDirectory("@\"C:InstagramCEF");
            //}
            if (ckbCheck.Checked)
                IgRunTime.CachePath = @"C:\InstagramCEF\CEFSharp_Cache" + RandomString(6);
            else
                IgRunTime.CachePath = @"C:\InstagramCEF\CEFSharp_Cache";
            Hide();
            var frm = new frmMain();
            frm.Closed += (s, args) => Close();
            frm.Show();
            //create random string by length
        }
        private void GetProfileCef()
        {
            List<string> profiles = CustomSearcher.GetDirectories("C:\\InstagramCEF");
            foreach (var profile in profiles)
            {
                var btn = new Button()
                {
                    Width = 120,
                    Height = 40
                };
                var profileSplit = profile.Split('\\').ToList();
                //btn.Text = profileSplit[profileSplit.Count-1];
                btn.Text = profile;
                flowLayoutPanel1.Controls.Add(btn);
                btn.Click += (s, args) =>
                {
                    string path = (s as Button).Text;
                    IgRunTime.CachePath = path;
                    Hide();
                    var frm = new frmMain();
                    frm.Closed += (sender, e) => Close();
                    frm.Show();
                };
            }
        }

        private void frmCache_Load(object sender, EventArgs e)
        {

        }
    }
}