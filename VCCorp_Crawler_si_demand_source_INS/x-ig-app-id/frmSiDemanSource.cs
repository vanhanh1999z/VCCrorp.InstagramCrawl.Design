using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using Crwal.Core.Log;
using VCCorp.CrawlerCore.Base;
using VCCorp.CrawlerCore.BUS;
using VCCorp.CrawlerCore.BUS.ig_app_id;
using VCCorp.CrawlerCore.SysEnum;
using Request = VCCorp.CrawlerCore.Base.Request;

namespace VCCorp_Crawler_si_demand_source_INS.x_ig_app_id
{
    public partial class frmSiDemanSource : Form
    {
        private readonly INSsidemandsourceBUS _bll = new INSsidemandsourceBUS(IgRunTime.Config.DbConnection.FBExce);
        private readonly ContentBUS _contentBUS = new ContentBUS();
        public ChromiumWebBrowser _browser;

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
                if (!Cef.IsInitialized)
                {
                    var pathCache = IgRunTime.CachePath;
                    if (!Directory.Exists(pathCache)) Directory.CreateDirectory(pathCache);
                    var settings = new CefSettings();
                    settings.CachePath = pathCache;
                    settings.LogSeverity = LogSeverity.Disable;
                    Cef.Initialize(settings);
                }

                _browser = new ChromiumWebBrowser(IgRunTime.Config.DeafultLoadUrl);
                Controls.Add(_browser);
                _browser.Location = new Point(1, 70);
                _browser.MinimumSize = new Size(20, 20);
                _browser.Name = "web_browser";
                _browser.Size = new Size(956, 827);
                _browser.TabIndex = 4;
                pnResult.Controls.Add(_browser);
                _browser.LoadingStateChanged += (sender, args) =>
                {
                    var script = Request.LoadScriptJs().Result;
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
                var currIdx = 1;
                stStatus.Text = "Bắt đầu lấy dữ liệu...";
                var links = _bll.GetDefaultSourcesidemandINS();
                var crawlerdate = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                if (links != null && links.Count > 0)
                {
                    var totalPost = links.Count.ToString();
                    lblTotal.Text = totalPost;
                    foreach (var link in links)
                    {
                        var isWait = await _bll.IsWait(link.id);
                        var isCrawl = IsCrawl(DateTime.Parse(link.update_time_crawl), link.frequency);

                        if (!isWait || !isCrawl) continue;
                        _bll.UpdatesidemandsrcINS(link.id, ((int)SiDemandSourceStatus.Processing).ToString(), "Process",
                            "", crawlerdate);

                        lblCurr.Text = $"{currIdx} / {totalPost}";
                        txtUrl.Text = link.link;
                        var url = link.link.Replace("https://www.instagram.com", "");
                        url = url.Replace("/", "");
                        var result = await _contentBUS.CrawlInstagram(string.Empty, _browser, url, lblSuccess, lblErr,
                            rtbResult);
                        if (result == State.Erorr)
                        {
                            Logging.Error("Thêm bài viết: " + url + " thất bại!");
                            _bll.UpdatesidemandsrcINS(link.id, ((int)SiDemandSourceStatus.Wait).ToString(), "Eror", "",
                                "");
                        }
                        else
                        {
                            var crawlcurrentdate = link.crawlcurrentdate.ToString();
                            crawlcurrentdate = crawlcurrentdate + 1;

                            _bll.UpdatesidemandsrcINS(link.id, ((int)SiDemandSourceStatus.Done).ToString(), "Done",
                                crawlcurrentdate, crawlerdate);

                            ("Thêm bài viết: " + url + " thành công!").Infomation();
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
                var dttime = updateTime;
                var dtnow = DateTime.Now;
                var dtday = dtnow - dttime;
                var dtdatyu = dtday.TotalDays * 24 * 60 * 60;
                var intdtday = Convert.ToInt32(dtdatyu);
                var intettime = Convert.ToInt32(frequency);
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