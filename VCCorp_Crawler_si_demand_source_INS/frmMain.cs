using CefSharp.WinForms;
using CefSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Crwal.Core.Base;
using VCCorp_Crawler_si_demand_source_INS.Config;
using VCCorp_Crawler_si_demand_source_INS.x_ig_app_id;
using VCCorp.CrawlerCore.Base;

namespace VCCorp_Crawler_si_demand_source_INS
{
    public partial class frmMain : Form
    {
        private int _loading;
        public ChromiumWebBrowser browser;
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public frmMain()
        {
            InitializeComponent();
            var rnd = new Random();
            //IgRunTime.CachePath = @"C:\CEFSharp_Cache_" + RandomString(6);
            IgRunTime.CachePath = @"C:\CEFSharp_Cache";
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
            grSiDemand.Enabled = enable;
            grSiDataExcel.Enabled = enable;
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

                    CefSharp.Cef.Initialize(settings);
                }

                //Cef.Initialize(new CefSettings());

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
                //browser.AddressChanged += OnBrowserAddressChanged;
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

        // private async void button1_Click(object sender, EventArgs e)
        // {
        //     Task<string> ck = IgRunTime.GetGlobalCookie();
        //     Task<string> html = GetAppIdIns();
        //     await Task.WhenAll(ck, html);
        //     Console.WriteLine(html.Result);
        //     Console.WriteLine(ck.Result);
        // }

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
    }

}
