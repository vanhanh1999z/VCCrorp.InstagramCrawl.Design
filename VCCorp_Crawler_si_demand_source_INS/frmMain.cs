using CefSharp;
using CefSharp.WinForms;
using Crwal.Core.Base;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using VCCorp.CrawlerCore.Base;
using VCCorp_Crawler_si_demand_source_INS.x_ig_app_id;

namespace VCCorp_Crawler_si_demand_source_INS
{
    public partial class frmMain : Form
    {
        private int _loading;
        public ChromiumWebBrowser browser;

        public frmMain()
        {
            InitializeComponent();
            InitBrowser();
        }

        private async void frmMain_LoadAsync(object sender, EventArgs e)
        {
            this.SetEnableMainGroupBox(false);
            await Task.Delay(4_000);
            IgRunTime.AppId = await GetAppIdIns();
            this.SetEnableMainGroupBox(true);
        }

        private void SetEnableMainGroupBox(bool enable)
        {
            groupBox1.Enabled = enable;
            groupBox2.Enabled = enable;
            grCookie.Enabled = enable;
        }

        public void InitBrowser()
        {
            try
            {
                if (!CefSharp.Cef.IsInitialized)
                {
                    string pathCache = IgRunTime.CachePath;
                    if (!Directory.Exists(pathCache))
                    {
                        Directory.CreateDirectory(pathCache);
                    }
                    CefSharp.WinForms.CefSettings settings = new CefSharp.WinForms.CefSettings();
                    settings.CachePath = pathCache;
                    settings.LogSeverity = LogSeverity.Disable;
                    settings.CefCommandLineArgs.Add("proxy-server", IgRunTime.Config.Proxy);
                    CefSharp.Cef.Initialize(settings);
                }


                _loading = 0;

                browser = new ChromiumWebBrowser("https://www.instagram.com/");

                this.Controls.Add(browser);

                this.browser.Location = new System.Drawing.Point(1, 70);
                this.browser.MinimumSize = new System.Drawing.Size(20, 20);
                this.browser.Name = "webBrowser";
                this.browser.Size = new System.Drawing.Size(956, 827);
                this.browser.TabIndex = 4;
                this.pnLogin.Controls.Add(this.browser);
                browser.LoadingStateChanged += OnLoadingStateChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void OnLoadingStateChanged(object sender, LoadingStateChangedEventArgs args)
        {
            if (!args.IsLoading)
            {
                _loading = 1;
            }
        }

        private void btPostINS_Click(object sender, EventArgs e)
        {
            frmSourcedemaind_INS fr = new frmSourcedemaind_INS();
            fr.Show();
        }

        private void btCmtINS_Click(object sender, EventArgs e)
        {
            frmPostdemandsource_INS fr = new frmPostdemandsource_INS();
            fr.Show();
        }

        private void btSourcStatus0_Click(object sender, EventArgs e)
        {
            frmSourcesdemainNew fr = new frmSourcesdemainNew();
            fr.Show();
        }

        private void btFindsourceID_Click(object sender, EventArgs e)
        {
            frmFindlSourceID_INS fr = new frmFindlSourceID_INS();
            fr.Show();
        }

        private void btCrwSidataExcel_Click(object sender, EventArgs e)
        {
            frmCrwSi_data_ExcelPost fr = new frmCrwSi_data_ExcelPost();
            fr.Show();
        }

        private void btINS_Click(object sender, EventArgs e)
        {
            frmOneINS fr = new frmOneINS();
            fr.Show();
        }

        private async Task<string> GetAppIdIns()
        {
            string html = await browser.GetSourceAsync();
            html = this.CleanHtml(html);
            string appId = Utilities.RegexFilter(html, "(?<=appId\":)(.*?)(?=,)");
            return appId;
        }

        private string CleanHtml(string html)
        {
            html = html.Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace("&#13;", "").Replace("&#10;", "");
            html = Regex.Replace(html, @"[\s]{2,}", " ");
            return html;
        }

        private async void btGetId_Click(object sender, EventArgs e)
        {
            Task<string> ck = IgRunTime.GetGlobalCookie();
            Task<string> id = GetAppIdIns();
            await Task.WhenAll(ck, id);
            MessageBox.Show($@"AppId: {id.Result} \n Cookie: {ck.Result}");
        }

        private void btPostUser_Click(object sender, EventArgs e)
        {
            var frmContentUser = new frmContentPost();
            frmContentUser.Show();
        }

        private void btSiDemanSource_Click(object sender, EventArgs e)
        {
            var frm = new frmSiDemanSource();
            frm.Show();
        }

        private void btComment_Click(object sender, EventArgs e)
        {
            frmComment frm = new frmComment();
            frm.Show();
        }

        private void btnHashtag_Click(object sender, EventArgs e)
        {
            var frm = new frmHashtag();
            frm.Show();
        }

        private void btnSiDemandSourcePost_Click(object sender, EventArgs e)
        {

        }
    }

}
