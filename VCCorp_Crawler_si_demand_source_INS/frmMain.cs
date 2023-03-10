using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using Crwal.Core.Base;
using VCCorp_Crawler_si_demand_source_INS.x_ig_app_id;
using VCCorp.CrawlerCore.Base;

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
            SetEnableMainGroupBox(false);
            await Task.Delay(4_000);
            IgRunTime.AppId = await GetAppIdIns();
            SetEnableMainGroupBox(true);
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
                if (!Cef.IsInitialized)
                {
                    var pathCache = IgRunTime.CachePath;
                    if (!Directory.Exists(pathCache)) Directory.CreateDirectory(pathCache);
                    var settings = new CefSettings();
                    settings.CachePath = pathCache;
                    settings.LogSeverity = LogSeverity.Disable;
                    //settings.CefCommandLineArgs.Add("proxy-server", IgRunTime.Config.Proxy);
                    Cef.Initialize(settings);
                }


                _loading = 0;

                browser = new ChromiumWebBrowser("https://www.instagram.com/");

                Controls.Add(browser);

                browser.Location = new Point(1, 70);
                browser.MinimumSize = new Size(20, 20);
                browser.Name = "webBrowser";
                browser.Size = new Size(956, 827);
                browser.TabIndex = 4;
                pnLogin.Controls.Add(browser);
                browser.LoadingStateChanged += OnLoadingStateChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnLoadingStateChanged(object sender, LoadingStateChangedEventArgs args)
        {
            if (!args.IsLoading) _loading = 1;
        }

        private void btPostINS_Click(object sender, EventArgs e)
        {
            var fr = new frmSourcedemaind_INS();
            fr.Show();
        }

        private void btCmtINS_Click(object sender, EventArgs e)
        {
            var fr = new frmPostdemandsource_INS();
            fr.Show();
        }

        private void btSourcStatus0_Click(object sender, EventArgs e)
        {
            var fr = new frmSourcesdemainNew();
            fr.Show();
        }

        private void btFindsourceID_Click(object sender, EventArgs e)
        {
            var fr = new frmFindlSourceID_INS();
            fr.Show();
        }

        private void btCrwSidataExcel_Click(object sender, EventArgs e)
        {
            var fr = new frmCrwSi_data_ExcelPost();
            fr.Show();
        }

        private void btINS_Click(object sender, EventArgs e)
        {
            var fr = new frmOneINS();
            fr.Show();
        }

        private async Task<string> GetAppIdIns()
        {
            var html = await browser.GetSourceAsync();
            html = CleanHtml(html);
            var appId = Utilities.RegexFilter(html, "(?<=appId\":)(.*?)(?=,)");
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
            var ck = IgRunTime.GetGlobalCookie();
            var id = GetAppIdIns();
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
            var frm = new frmComment();
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