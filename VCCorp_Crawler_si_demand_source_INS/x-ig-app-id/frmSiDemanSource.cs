using CefSharp;
using CefSharp.WinForms;
using Crwal.Core.Log;
using System;
using System.IO;
using System.Windows.Forms;
using VCCorp.CrawlerCore.Base;
using VCCorp.CrawlerCore.BUS;
using VCCorp.CrawlerCore.BUS.ig_app_id;
using VCCorp.CrawlerCore.SysEnum;

namespace VCCorp_Crawler_si_demand_source_INS.x_ig_app_id
{
    public partial class frmSiDemanSource : Form
    {
        public ChromiumWebBrowser _browser;
        private ContentBUS _contentBUS = new ContentBUS();
        private INSsidemandsourceBUS _bll = new INSsidemandsourceBUS(IgRunTime.Config.DbConnection.FBExce);
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
                _browser = new ChromiumWebBrowser(IgRunTime.Config.DeafultLoadUrl);
                this.Controls.Add(_browser);
                this._browser.Location = new System.Drawing.Point(1, 70);
                this._browser.MinimumSize = new System.Drawing.Size(20, 20);
                this._browser.Name = "web_browser";
                this._browser.Size = new System.Drawing.Size(956, 827);
                this._browser.TabIndex = 4;
                this.pnResult.Controls.Add(this._browser);
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
        private async void btStartCrawl_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                int currIdx = 1;
                stStatus.Text = "Bắt đầu lấy dữ liệu...";
                var links = _bll.GetDefaultSourcesidemandINS();
                if (links != null && links.Count > 0)
                {

                    var totalPost = links.Count.ToString();
                    lblTotal.Text = totalPost;
                    foreach (var link in links)
                    {
                        if (!this.IsCrawl(DateTime.Parse(link.update_time_crawl), link.frequency)) return;

                        lblCurr.Text = $"{currIdx} / {totalPost}";
                        txtUrl.Text = link.link;
                        string url = link.link.Replace("https://www.instagram.com", "");
                        url = url.Replace("/", "");
                        var result = await _contentBUS.CrawlInstagram(string.Empty, _browser, url, lblSuccess, lblErr, rtbResult);



                        if (result == State.Erorr)
                        {
                            Logging.Error("Thêm bài viết: " + url + " thất bại!");
                            _bll.UpdatesidemandsrcINS(link.id, SiDemandSourceStatus.Wait.ToString(), "Done", "", "");
                        }
                        else
                        {
                            string crawlcurrentdate = link.crawlcurrentdate.ToString();
                            crawlcurrentdate = crawlcurrentdate + 1;
                            string crawlerdate = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                            _bll.UpdatesidemandsrcINS(link.id, SiDemandSourceStatus.Done.ToString(), "Done", crawlcurrentdate, crawlerdate);

                            Logging.Infomation("Thêm bài viết: " + url + " thành công!");
                        }
                    }
                }
                stStatus.Text = "Đã hoàn tất";
            }
            catch (Exception ex)
            {
                stStatus.Text = "Đã xảy ra sự cố, vui lòng kiểm tra lại";

                Logging.Error(ex);
            }
        }
        private void btShowDevTool_Click(object sender, EventArgs e)
        {
            _browser.ShowDevTools();
        }
        private bool IsCrawl(DateTime updateTime, string frequency)
        {
            try
            {
                DateTime dttime = updateTime;
                DateTime dtnow = DateTime.Now;
                var dtday = dtnow - dttime;
                var dtdatyu = dtday.TotalDays * 24 * 60 * 60;
                int intdtday = Convert.ToInt32(dtdatyu);
                int intettime = Convert.ToInt32(frequency);
                if (intdtday > intettime) return true;
                return false;
            }
            catch (Exception ex)
            {

                Logging.Error(ex);
            }
            return false;
        }

    }
}
