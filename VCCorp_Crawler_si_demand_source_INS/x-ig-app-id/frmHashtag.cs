using CefSharp;
using CefSharp.WinForms;
using Crwal.Core.Base;
using Crwal.Core.Log;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using VCCorp.CrawlerCore.Base;
using VCCorp.CrawlerCore.BUS;
using VCCorp.CrawlerCore.BUS.ig_app_id;
using VCCorp.CrawlerCore.DTO.ig_app_id;
using VCCorp.CrawlerCore.SysEnum;

namespace VCCorp_Crawler_si_demand_source_INS.x_ig_app_id
{

    public partial class frmHashtag : Form
    {
        private ChromiumWebBrowser _browser;
        private INSsihashtagBUS _bll = new INSsihashtagBUS(IgRunTime.Config.CloudDbConnection.FBExce);
        private HashtagBUS _hashtagBUS = new HashtagBUS();

        public frmHashtag()
        {
            InitializeComponent();
            InitBrowser();
        }

        private void frmHashtag_Load(object sender, EventArgs e)
        {

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
        private void btnShowDevtool_Click(object sender, EventArgs e)
        {
            _browser.ShowDevTools();
        }
        private async void btnCheckCookir_Click(object sender, EventArgs e)
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
        private async void btnStart_Click(object sender, EventArgs e)
        {
            await CrawlerStarted();

            Timer timer = new Timer();
            timer.Interval = 1000 * 60 * 60 * 6;
            timer.Tick += Timer_Tick;
            timer.Enabled = true;

        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            await CrawlerStarted();
            stStatus2.Text = "Hệ thống đang tạm nghỉ, sẽ bắt đầu lại sai 6 tiếng sau";
        }

        private async Task CrawlerStarted()
        {
            try
            {
                var tags = await GetHashtagAsync();
                if (!HasAppId()) { MessageBox.Show("AppId hiện không khả dụng, vui lòng khởi động lại ứng dụng"); return; }
                if (tags != null && tags.Count > 0)
                {
                    int currentIdx = 0;
                    lblTotal.Text = tags.Count.ToString();
                    foreach (var tag in tags)
                    {
                        await Task.Delay(3_000);
                        currentIdx++;
                        lblCurr.Text = currentIdx.ToString();
                        string url = "https://www.instagram.com/explore/tags/" + tag.Hashtag;
                        await _browser.LoadUrlAsync(url);
                        await Task.Delay(3_000);
                        Logging.Warning("Bắt đàu crawl tag:" + tag);

                        // {{MAX_REQUEST}} request sẽ tạm dừng {{DELAY_TIME}}
                        const int MAX_REQUEST = 50;
                        const int DELAY_TIME = 1000 * 60 * 30;

                        if (currentIdx > MAX_REQUEST)
                        {
                            currentIdx = 0;
                            stStatus2.Text = "Hệ thống tạm dừng 30p trước khi tiếp tục!";
                            await Task.Delay(DELAY_TIME);
                        }

                        LoopState state = await _hashtagBUS.CrawlData(_browser, tag.Hashtag, lblSuccess, lblErr, rtbResult, stStatus);
                        if (state == LoopState.Continue || state == LoopState.Ok)
                        {
                            await _bll.UpdateStatusHashtag(tag.Id, ((int)State.Success).ToString());
                            Logging.Infomation($"Update {tag.Id} trạng thái:  {((int)State.Success).ToString()}");
                            continue;
                        }
                        else break;
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.Error(ex);
            }
        }
        /// <summary>
        /// Lấy danh sách hashtag đã được xử lý
        /// </summary>
        /// <returns></returns>
        public async Task<List<HashtagDTO.SiHashtag>> GetHashtagAsync()
        {
            List<HashtagDTO.SiHashtag> lstHashtag = await _bll.GetHashtags();

            for (int i = 0; i < lstHashtag.Count; i++)
            {
                string rawHashtag = lstHashtag[i].Hashtag;
                string hashtagRemoveSign = HashtagHelper.RemoveSignVietnameseString(rawHashtag);
                string hashtagRemoveSpace = Regex.Replace(hashtagRemoveSign, @"\s+", "");
                string hashtagRemoveChar = hashtagRemoveSpace.Replace(".", string.Empty).ToLower();
                lstHashtag[i].Hashtag = hashtagRemoveChar;
            }
            return lstHashtag;
        }
        private bool HasAppId()
        {
            return String.IsNullOrEmpty(IgRunTime.AppId) ? false : true;
        }


    }
}
