using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using Crwal.Core.Base;
using Crwal.Core.Log;
using VCCorp.CrawlerCore.Base;
using VCCorp.CrawlerCore.BUS;
using VCCorp.CrawlerCore.BUS.ig_app_id;
using VCCorp.CrawlerCore.DTO.ig_app_id;
using VCCorp.CrawlerCore.SysEnum;
using Request = VCCorp.CrawlerCore.Base.Request;

namespace VCCorp_Crawler_si_demand_source_INS.x_ig_app_id
{
    public partial class frmHashtag : Form
    {
        private readonly INSsihashtagBUS _bll = new INSsihashtagBUS(IgRunTime.Config.CloudDbConnection.FBExce);
        private readonly HashtagBUS _hashtagBUS = new HashtagBUS();
        private ChromiumWebBrowser _browser;

        public frmHashtag()
        {
            InitializeComponent();
            lblQuery.Text = " SELECT * FROM `social_index_v2`.`si_hashtag` WHERE `status` = '6' ORDER BY `update_time` DESC";
            InitBrowser();
        }

        private void frmHashtag_Load(object sender, EventArgs e)
        {
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
            var timer = new Timer();
            timer.Interval = 1000 * 60 * 60 * 6;
            timer.Tick += Timer_Tick;
            timer.Enabled = true;
            stStatus2.Text = "Hệ thống đang tạm nghỉ, sẽ bắt đầu lại sai 6 tiếng sau";
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
                if (!HasAppId())
                {
                    MessageBox.Show("AppId hiện không khả dụng, vui lòng khởi động lại ứng dụng");
                    return;
                }
                if (tags != null && tags.Count > 0)
                {
                    dgvMain.DataSource = tags;

                    var currentIdx = 0;
                    lblTotal.Text = tags.Count.ToString();
                    foreach (var tag in tags)
                    {
                        currentIdx++;
                        lblCurr.Text = currentIdx.ToString();
                        var url = "https://www.instagram.com/explore/tags/" + tag.Hashtag;

                        await _browser.LoadUrlAsync(url);
                        await Task.Delay(3_000);

                        ("Bắt đàu crawl tag:" + tag).Warning();
                        // {{MAX_REQUEST}} request sẽ tạm dừng {{DELAY_TIME}}
                        const int MAX_REQUEST = 50;
                        const int DELAY_TIME = 1000 * 60 * 30;

                        if (currentIdx > MAX_REQUEST)
                        {
                            currentIdx = 0;
                            stStatus2.Text = "Hệ thống tạm dừng 30p trước khi tiếp tục!";
                            await Task.Delay(DELAY_TIME);
                        }

                        var state = await _hashtagBUS.CrawlData(_browser, tag.Hashtag, lblSuccess, lblErr, rtbResult,
                            stStatus);
                        if (state == LoopState.Continue || state == LoopState.Ok)
                        {
                            await _bll.UpdateTimeHashtagAsync(tag.Id, DateTime.Now);
                            $"Update {tag.Id} thời gian:  {DateTime.Now}".Infomation();
                            continue;
                        }

                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.Error(ex);
            }
        }

        /// <summary>
        ///     Lấy danh sách hashtag đã được xử lý
        /// </summary>
        /// <returns></returns>
        public async Task<List<HashtagDTO.SiHashtag>> GetHashtagAsync()
        {
            if (String.IsNullOrEmpty(lblQuery.Text)) return null;
            var lstHashtag = await _bll.GetHashtags(lblQuery.Text);
            for (var i = 0; i < lstHashtag.Count; i++)
            {
                var rawHashtag = lstHashtag[i].Hashtag;
                var hashtagRemoveSign = HashtagHelper.RemoveSignVietnameseString(rawHashtag);
                var hashtagRemoveSpace = Regex.Replace(hashtagRemoveSign, @"\s+", "");
                var hashtagRemoveChar = hashtagRemoveSpace.Replace(".", string.Empty).ToLower();
                lstHashtag[i].Hashtag = hashtagRemoveChar;
            }
            return lstHashtag;

        }

        /// <summary>
        ///     Kiểm tra đã lấy được AppId hay chưa
        /// </summary>
        /// <returns></returns>
        private bool HasAppId()
        {
            return string.IsNullOrEmpty(IgRunTime.AppId) ? false : true;
        }

        private void lblQuery_TextChanged(object sender, EventArgs e)
        {

        }
    }
}