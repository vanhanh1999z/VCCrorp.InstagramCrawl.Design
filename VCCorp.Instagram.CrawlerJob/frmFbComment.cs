using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using CefSharp;
using CefSharp.DevTools.Network;
using CefSharp.WinForms;
using Crwal.Core.Base;
using Crwal.Core.Log;
using Newtonsoft.Json;
using VCCorp.CrawlerCore.Base;
using VCCorp.CrawlerCore.BUS;
using VCCorp.CrawlerCore.DTO;
using VCCorp.CrawlerCore.DTO.ig_app_id;
using VCCorp.CrawlerCore.SysEnum;
using Request = VCCorp.CrawlerCore.Base.Request;
using Utilities = Crwal.Core.Base.Utilities;

namespace VCCorp.Instagram.CrawlerJob
{
    public partial class frmFbComment : Form
    {
        private readonly INSFbCommentBUS _bll = INSFbCommentBUS.GetInstance(IgRunTime.Config.CloudDbConnection.FBExce);
        private ChromiumWebBrowser _browser;
        private string _currId = "";
        private string _currPage = "";
        private string _currUrl = "";
        private IEnumerator<INSFbCommentDTO> _enumrator;

        public frmFbComment()
        {
            InitializeComponent();
            InitBrowser();
        }

        private async void frmFbComment_Load(object sender, EventArgs e)
        {
            await Task.Delay(5000);
            var devtool = _browser.GetDevToolsClient();
            await devtool.Network.EnableAsync();
            var script = Request.LoadScriptJs().Result;
            _browser.ExecuteScriptAsync(script);
            devtool.Network.RequestWillBeSent += Network_RequestWillBeSent;
            await CrawlAndSend();
            var tm = new Timer();
            tm.Tick += Tm_Tick;
            const int DELAY_TIME = 1000 * 60 * 15; //30p
            tm.Interval = DELAY_TIME;
            tm.Enabled = true;
            $"FBCOMMENT - Cài đặt timer thành công với tổng số thời gian là {TimeSpan.FromMilliseconds(DELAY_TIME).Minutes}"
                .Infomation();
        }

        private async void Tm_Tick(object sender, EventArgs e)
        {
            await CrawlAndSend();
        }

        private async Task CrawlAndSend()
        {
            " FBCOMMENT- Bắt đầu chạy job".Infomation();
            var sources = await GetSources();
            if (sources == null || sources.Count == 0)
            {
                "FBCOMMENT - Không có dữ liệu".Infomation();
                return;
            }

            _enumrator = GetSources(sources).GetEnumerator();
            if (_enumrator.MoveNext())
            {
                _currPage = _enumrator.Current.link;
                _currId = _enumrator.Current.id;
                await _browser.LoadUrlAsync(_currPage);
            }
        }

        private IEnumerable<INSFbCommentDTO> GetSources(List<INSFbCommentDTO> sources)
        {
            if (sources != null && sources.Count > 0)
                foreach (var source in sources)
                    yield return source;
        }

        private async Task<List<INSFbCommentDTO>> GetSources()
        {
            await Task.Delay(3_000);
            var sources = await _bll.GetSourceAsync();
            if (sources != null && sources.Count > 0) return sources;
            return null;
        }

        public void InitBrowser()
        {
            try
            {
                if (!Cef.IsInitialized)
                {
                    //var pathCache = IgRunTime.CachePath;
                    var pathCache = IgRunTime.CachePath;
                    if (!Directory.Exists(pathCache)) Directory.CreateDirectory(pathCache);
                    var settings = new CefSettings();
                    settings.CachePath = pathCache;
                    settings.LogSeverity = LogSeverity.Disable;
                    settings.CefCommandLineArgs.Add("proxy-server", IgRunTime.Config.Proxy);
                    Cef.Initialize(settings);
                }

                _browser = new ChromiumWebBrowser("https://www.instagram.com/");
                pnResult.Controls.Add(_browser);
                _browser.Location = new Point(1, 70);
                _browser.MinimumSize = new Size(20, 20);
                _browser.Name = "webBrowser";
                _browser.Size = new Size(956, 827);
                _browser.TabIndex = 4;
                _browser.LoadingStateChanged += async (sender, args) => { };
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
                if (e.Request.Method == "GET" && e.Request.Url.StartsWith("https://www.instagram.com/api/v1/media/"))
                    if (e.Request.Url.Equals(_currUrl) == false)
                    {
                        _currUrl = e.Request.Url;
                        var reqId = e.RequestId;
                        await Task.Delay(2500);
                        var content = await devtool.Network.GetResponseBodyAsync(reqId);
                        var result =
                            JsonConvert.DeserializeObject<CommentDTO.Root>(
                                content.Body);
                        if (result != null && result.comments != null)
                        {
                            ("FBCOMMENT - Bắt đầu crwal comment bài viết " + _currPage).Infomation();
                            var tasks = new List<Task>();
                            foreach (var cmt in result.comments)
                                try
                                {
                                    if (result.caption == null) continue;
                                    var entrydataCmt = new kafaCommentINSDTO();
                                    {
                                        entrydataCmt.CommentId = cmt.pk;
                                        entrydataCmt.CommentText = HttpUtility.HtmlEncode(cmt.text);
                                        entrydataCmt.PostId = result.caption.pk;
                                        entrydataCmt.Url = _currPage;
                                        entrydataCmt.ShortCode = GetShortCodeByUrl(_currPage);
                                        entrydataCmt.OwnerId = result.caption.user_id;
                                        entrydataCmt.OwnerUser = result.caption.user.username;
                                        entrydataCmt.OwnerProfilePicUrl = result.caption.user.profile_pic_url;
                                        entrydataCmt.CreateTime =
                                            Utilities.UnixTimestampToDateTime(result.caption.created_at);
                                        entrydataCmt.CmtTimeDate = cmt.created_at;
                                        entrydataCmt.TimeCrw = DateTime.Now;
                                    }
                                    tasks.Add(SaveKafraComment(entrydataCmt));
                                    await Task.WhenAll(tasks);
                                }
                                catch (Exception ex)
                                {
                                    Logging.Error(ex);
                                }

                            _browser.ExecuteScriptAsync(
                                "document.querySelector(`[aria-label='Load more comments']`).parentElement.click()");
                        }
                        else
                        {
                            "FBCOMMENT - Lấy context thất bại".Infomation();
                        }

                        await _bll.UpdateSourceAsync(_currId, ((int)SiDemandSourceStatus.Done).ToString());
                        await Task.Delay(2_000);
                        if (_enumrator.MoveNext())
                        {
                            _currPage = _enumrator.Current.link;
                            _currId = _enumrator.Current.id;
                            await _browser.LoadUrlAsync(_currPage);
                        }
                    }

                "FBCOMMENT- Chạy job hoàn tất".Infomation();
            }
            catch (Exception ex)
            {
            }
        }

        public string GetShortCodeByUrl(string url)
        {
            return url.Replace("https://www.instagram.com/", "").Replace("/", "").Replace("p", "");
        }

        private async Task SaveKafraComment(kafaCommentINSDTO postDTO)
        {
            try
            {
                var messagejson = postDTO.ToJson();
                // Bắn data cmt
                var intfag = await KafkaBll.PutOnKafkaCmtINS(messagejson);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Lỗi phần SaveKafra" + ex);
            }
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            ni.BalloonTipText = "fb_comment đang chạy";
            ni.BalloonTipTitle = "Thông báo";
            ni.Visible = true;
            ni.ShowBalloonTip(500);
            Hide();
        }

        private void ni_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            ni.Visible = false;
        }
    }
}