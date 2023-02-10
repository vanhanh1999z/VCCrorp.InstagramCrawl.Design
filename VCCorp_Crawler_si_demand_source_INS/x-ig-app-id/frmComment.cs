using CefSharp.WinForms;
using CefSharp;
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
using VCCorp.CrawlerCore.BUS.ig_app_id;
using VCCorp.CrawlerCore.SysEnum;

namespace VCCorp_Crawler_si_demand_source_INS.x_ig_app_id
{
    public partial class frmComment : Form
    {
        private ChromiumWebBrowser _browser;
        public frmComment()
        {
            InitializeComponent();
            InitBrowser();
        }

        private async void btCommentCheck_ClickAsync(object sender, EventArgs e)
        {
            var cookie = await IgRunTime.GetGlobalCookie();
            MessageBox.Show($"cookie: {cookie} \n appId: {IgRunTime.AppId}");
        }

        private async void btCommentStart_Click(object sender, EventArgs e)
        {
            var commentBUS = new CommentBUS();
            State state = await commentBUS.CrawlCommentAsync(_browser, string.Empty, lblTotal, lblCurrentPost, lblSuccess, lblErr, rtbResult);
            if (state == State.Success)
            {
                stState.Text = "Đã hoàn tất!"; return;
            }
            stState.Text = "Đã có sự cố xảy ra, vui lòng kiểm ra lại!";
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
                _browser = new ChromiumWebBrowser(IgRunTime.Config.DeafultLoadUrl);
                this.Controls.Add(_browser);
                this._browser.Location = new System.Drawing.Point(1, 70);
                this._browser.MinimumSize = new System.Drawing.Size(20, 20);
                this._browser.Name = "web_browser";
                this._browser.Size = new System.Drawing.Size(956, 827);
                this._browser.TabIndex = 4;
                this.pnResult.Controls.Add(this._browser);
                //_browser.LoadingStateChanged += OnLoadingStateChanged;
                //_browser.AddressChanged += On_browserAddressChanged;
            }
            catch (Exception ex)
            {
                Logging.Error(ex);
            }
        }

        private void btShowDevTool_Click(object sender, EventArgs e)
        {
            _browser.ShowDevTools();
        }
    }
}
