using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.DevTools.Network;
using CefSharp.WinForms;
using Crwal.Core.Base;
using Crwal.Core.Log;
using Newtonsoft.Json;
using VCCorp.CrawlerCore.Base;
using VCCorp.CrawlerCore.BUS;
using VCCorp.CrawlerCore.BUS.ig_app_id;
using VCCorp.CrawlerCore.DTO;
using VCCorp.CrawlerCore.DTO.ig_app_id;
using Request = VCCorp.CrawlerCore.Base.Request;
using Utilities = Crwal.Core.Base.Utilities;

namespace VCCorp_Crawler_si_demand_source_INS
{
    public partial class frmContentPost : Form
    {
        private readonly INSsidemandsourcepostBUS _bll =
            new INSsidemandsourcepostBUS(IgRunTime.Config.CloudDbConnection.FBExce);

        private readonly Dictionary<string, string> _dic = new Dictionary<string, string>
        {
            { "UrlPost", "https://www.instagram.com/api/v1/feed/user" },
            { "Domain", "https://www.instagram.com" }
        };

        public ChromiumWebBrowser _browser;
        private ContentBUS _contentBUS = new ContentBUS();
        private string _ctx = string.Empty;
        private string _currUrl = string.Empty;

        private int _idx = 0;

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
                if (!Cef.IsInitialized)
                {
                    var pathCache = IgRunTime.CachePath;
                    if (!Directory.Exists(pathCache)) Directory.CreateDirectory(pathCache);
                    var settings = new CefSettings();
                    settings.CachePath = pathCache;
                    settings.LogSeverity = LogSeverity.Disable;
                    Cef.Initialize(settings);
                }

                //Cef.Initialize(new CefSettings());
                _browser = new ChromiumWebBrowser(IgRunTime.Config.DeafultLoadUrl);
                _browser = new ChromiumWebBrowser();
                Controls.Add(_browser);
                _browser.Location = new Point(1, 70);
                _browser.MinimumSize = new Size(20, 20);
                _browser.Name = "web_browser";
                _browser.Size = new Size(956, 827);
                _browser.TabIndex = 4;
                pnView.Controls.Add(_browser);
                _browser.LoadingStateChanged += async (sender, args) =>
                {
                    var script = Request.LoadScriptJs().Result;
                    _browser.ExecuteScriptAsync(script);
                    var devtool = _browser.GetDevToolsClient();
                    await devtool.Network.EnableAsync();
                    devtool.Network.RequestWillBeSent += Network_RequestWillBeSent;
                };
            }
            catch (Exception ex)
            {
                Logging.Error(ex);
            }
        }


        private async void Network_RequestWillBeSent(object sender, RequestWillBeSentEventArgs e)
        {
            try
            {
                var devtool = _browser.GetDevToolsClient();

                if (e.Request.Method == "GET" && e.Request.Url.StartsWith(_dic["UrlPost"]))
                    if (e.Request.Url.Equals(_currUrl) == false)
                    {
                        _currUrl = e.Request.Url;
                        var reqId = e.RequestId;
                        await Task.Delay(2500);
                        var res = await devtool.Network.GetResponseBodyAsync(reqId);
                        if (res != null && res.Body != null)
                        {
                            _currUrl.Infomation();
                            "Lấy context thành công!".Infomation();
                            var posts = JsonConvert.DeserializeObject<ContentDTO.Root>(res.Body);

                            if (posts != null && posts.items != null && posts.items.Count >= 0)
                            {
                                "Bắt đầu xử lý dữ liệu instagram...".Infomation();
                                foreach (var post in posts.items)
                                {
                                    var pos = new INSsidemandsourcepostDTO
                                    {
                                        post_id = post.pk,
                                        platform = IgRunTime.Config.Platform,
                                        link = IgRunTime.Config.InstagramDomainUrlOnePose + post.code,
                                        title = post.caption != null ? post.caption.text : "",
                                        creat_time = Utilities.UnixTimestampToDateTime(post.taken_at),
                                        status = 0.ToString(),
                                        total_comment = post.comment_count,
                                        total_like = post.like_count,
                                        total_share = 0,
                                        user_crawler = IgRunTime.Config.UserCrawler,
                                        fullName = post.user.full_name != null ? post.user.full_name : "",
                                        si_demand_source_id = "0"
                                    };
                                    var entdatakafapost = new kafaPostINSDTO
                                    {
                                        Id = post.pk != null ? post.pk : "",
                                        Message = post.caption != null ? post.caption.text : "",
                                        ShortCode = post.code != null ? post.code : "",
                                        Link = IgRunTime.Config.InstagramDomainUrlOnePose + post.code,
                                        TotalComment = post.comment_count,
                                        TotalLike = post.like_count,
                                        TotalShare = 0,
                                        TotalReaction = 0,
                                        ImagePost = post.carousel_media_count > 0
                                            ? post.carousel_media[0].image_versions2.candidates[0].url
                                            : "",
                                        Platform = IgRunTime.Config.Platform,
                                        CreateTime = Utilities.UnixTimestampToDateTime(post.taken_at),
                                        TimeCrw = DateTime.Now,
                                        TmpTime = post.taken_at,
                                        UserId = post.user.pk_id != null ? post.user.pk_id : "",
                                        Username = post.user.username != null ? post.user.username : "",
                                        ImageUser = post.user.profile_pic_url != null ? post.user.profile_pic_url : ""
                                    };
                                    await SaveKafraPost(entdatakafapost);
                                    await _bll.InsertsidemandsourcepostAsync(pos);
                                    Utilities.WriteToBox("Lấy thành công bài viết: " + post.pk, rtbResult);
                                }
                            }

                            await Task.Delay(3_000);
                            _browser.ExecuteScriptAsync("window.scrollTo(0, document.body.scrollHeight);");
                            return;
                        }

                        "Lấy context thất bại".Infomation();
                    }
            }
            catch (Exception ex)
            {
                Logging.Error(ex);
            }
        }

        /// <summary>
        ///     Gửi dữ liệu vào kafka
        /// </summary>
        /// <param name="postDTO">kafaPostINSDTO</param>
        /// <returns></returns>
        private async Task SaveKafraPost(kafaPostINSDTO postDTO)
        {
            try
            {
                "Bắt đầu đẩy dữ liệu vào kafka".Warning();
                var messagejson = postDTO.ToJson();
                var intfag = await KafkaBll.PutOnKafkaPostINS(messagejson);
                "Đẩy dữ liệu vào kafka thành công".Warning();
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
                if (string.IsNullOrEmpty(txtUrl.Text))
                {
                    MessageBox.Show("Url không được để trống!!!", "Đã có lỗi xảy ra", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                await _browser.LoadUrlAsync(txtUrl.Text);
                //await Task.Delay(3_000);
                //string userNameUrl = txtUrl.Text;
                //userNameUrl = userNameUrl.Replace(_dic["Domain"], "").Replace("/", "");
                //Logging.Infomation("Bắt đầu crawl dữ liệu post...");
                //_currUrl = String.Empty;
                //var tsk = await _contentBUS.CrawlInstagram(String.Empty, _browser, userNameUrl, lblSuccess, lblErr, rtbResult);
                //await Task.Delay(3_000);
                //if (tsk == State.Erorr)
                //{
                //    tsStatus.Text = "Không lấy được dữ liệu, vui lòng thử lại sau";
                //    return;
                //}
                //tsStatus.Text = "Đã hoàn tất";
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