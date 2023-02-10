using CefSharp;
using CefSharp.WinForms;
using Crwal.Core.Base;
using Crwal.Core.Log;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VCCorp.CrawlerCore.Base;
using VCCorp.CrawlerCore.BUS;
using VCCorp.CrawlerCore.BUS.ig_app_id;
using VCCorp_Crawler_si_demand_source_INS.Config;

namespace VCCorp_Crawler_si_demand_source_INS.x_ig_app_id
{
    public partial class frmSiDemanSource : Form
    {
        public ChromiumWebBrowser _browser;
        private ContentBUS _contentBUS = new ContentBUS();
        private int _idx = 1;
        public frmSiDemanSource()
        {
            InitializeComponent();
            InitBrowser();
        }

        private void frmSiDemanSource_Load(object sender, EventArgs e)
        {
        }

        private async void btCheckCookie_Click(object sender, EventArgs e)
        {
            var cookie = await IgRunTime.GetGlobalCookie();
            MessageBox.Show($"cookie: {cookie} \n appId: {IgRunTime.AppId}");
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
                _browser = new ChromiumWebBrowser(IgRunTime.Config.DeafultLoadUrl);
                this.Controls.Add(_browser);
                this._browser.Location = new System.Drawing.Point(1, 70);
                this._browser.MinimumSize = new System.Drawing.Size(20, 20);
                this._browser.Name = "web_browser";
                this._browser.Size = new System.Drawing.Size(956, 827);
                this._browser.TabIndex = 4;
                this.pnResult.Controls.Add(this._browser);
            }
            catch (Exception ex)
            {
                Logging.Error(ex);
            }
        }

        private async void btStartCrawl_ClickAsync(object sender, EventArgs e)
        {
            //var links = _bll.GetDefaultSourcesidemandINS();

            //if (links != null && links.Count > 0)
            //{
            //    List<Task> tasks = new List<Task>();
            //    foreach (var link in links)
            //    {
            //        string url = link.link.Replace("https://www.instagram.com", "");
            //        url = url.Replace("/", "");
            //        var result = await _contentBUS.CrawlInstagram(string.Empty, _browser, url);
            //    }
            //}
        }
    }
}
