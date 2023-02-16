using CefSharp;
using CefSharp.WinForms;
using Crwal.Core.Log;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using VCCorp.CrawlerCore.Base;
using VCCorp.CrawlerCore.BUS;
using VCCorp.CrawlerCore.BUS.ig_app_id;
using VCCorp.CrawlerCore.SysEnum;

namespace VCCorp_Crawler_si_demand_source_INS
{
    public partial class frmContentPost : Form
    {
        public ChromiumWebBrowser _browser;
        private INSsidemandsourcepostBUS _bll = new INSsidemandsourcepostBUS(IgRunTime.Config.DbConnection.FBExce);
        private ContentBUS _contentBUS = new ContentBUS();
        public frmContentPost()
        {
            InitializeComponent();
            InitBrowser();
        }

        private async void btCheckCookie_Click(object sender, EventArgs e)
        {
            try
            {
                var cookie = await IgRunTime.GetGlobalCookie();
                MessageBox.Show($"cookie: {cookie} \n appId: {IgRunTime.AppId}");
            }
            catch (Exception ex)
            {

                Logging.Error(ex);
            }
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
                this.pnView.Controls.Add(this._browser);
                _browser.LoadingStateChanged += (sender, args) =>
                {
                    var script = VCCorp.CrawlerCore.Base.Request.LoadScriptJs().Result;
                    _browser.ExecuteScriptAsync(script);
                };
            }
            catch (Exception ex)
            {
                Logging.Error(ex);
            }
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            try
            {
                tsStatus.Text = "Loading...";
                if (String.IsNullOrEmpty(txtUrl.Text))
                {
                    MessageBox.Show("Url không được để trống!!!", "Đã có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                await _browser.LoadUrlAsync(txtUrl.Text);
                await Task.Delay(3_000);
                string userNameUrl = Regex.Match(txtUrl.Text, "(?<=https://www.instagram.com/)(.*?)(?=/)").Value;
                Logging.Infomation("Bắt đầu crawl dữ liệu post...");
                var tsk = await _contentBUS.CrawlInstagram(String.Empty, _browser, userNameUrl, lblSuccess, lblErr, rtbResult);
                await Task.Delay(3_000);
                if (tsk == State.Erorr)
                {
                    tsStatus.Text = "Không lấy được dữ liệu, vui lòng thử lại sau";
                    return;
                }
                tsStatus.Text = "Đã hoàn tất";
            }
            catch (Exception ex)
            {

                tsStatus.Text = "Đã xảy ra sự cố, vui lòng kiểm tra lại!";
                Logging.Error(ex);
            }
        }
        private void btShowDevTool_Click(object sender, EventArgs e)
        {
            _browser.ShowDevTools();
        }

        private void frmContentPost_Load(object sender, EventArgs e)
        {

        }
    }
}
