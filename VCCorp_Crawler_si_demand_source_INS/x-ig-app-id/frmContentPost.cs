using CefSharp;
using CefSharp.DevTools;
using CefSharp.DevTools.Network;
using CefSharp.WinForms;
using Crwal.Core.Base;
using Crwal.Core.Log;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using VCCorp.CrawlerCore.Base;
using VCCorp.CrawlerCore.BUS;
using VCCorp.CrawlerCore.BUS.ig_app_id;
using VCCorp.CrawlerCore.DTO.ig_app_id;
using VCCorp.CrawlerCore.DTO;
using VCCorp.CrawlerCore.SysEnum;
using System.Net;

namespace VCCorp_Crawler_si_demand_source_INS
{
    public partial class frmContentPost : Form
    {
        public ChromiumWebBrowser _browser;
        private INSsidemandsourcepostBUS _bll = new INSsidemandsourcepostBUS(IgRunTime.Config.DbConnection.FBExce);
        private ContentBUS _contentBUS = new ContentBUS();
        private string _ctx = String.Empty;
        private int _idx = 0;
        private string _currUrl = String.Empty;

        private Dictionary<string, string> _dic = new Dictionary<string, string>
        {
            {"UrlPost", "https://www.instagram.com/api/v1/feed/user" },
            {"Domain", "https://www.instagram.com" },
        };
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
                _browser.LoadingStateChanged += async (sender, args) =>
                {
                    var script = VCCorp.CrawlerCore.Base.Request.LoadScriptJs().Result;
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
                {
                    if (e.Request.Url.Equals(_currUrl) == false)
                    {
                        _currUrl = e.Request.Url;
                        var reqId = e.RequestId;
                        await Task.Delay(2_000);
                        var res = await devtool.Network.GetResponseBodyAsync(reqId);
                        if (res != null && res.Body != null)
                        {
                            Logging.Infomation(_currUrl);
                            Logging.Infomation("Lấy context thành công!");
                            var posts = JsonConvert.DeserializeObject<ContentDTO.Root>(res.Body);
                            if (posts != null && posts.items != null && posts.items.Count >= 0)
                            {
                                Logging.Infomation("Bắt đầu xử lý dữ liệu instagram...");
                                List<Task<int>> tasks = new List<Task<int>>();
                                foreach (var post in posts.items)
                                {
                                    //Crwal.Core.Base.Utilities.WriteToBox("Lấy thành công bài viết: " + post.pk, rtbResult);
                                    #region Download image
                                    if (post.carousel_media_count != null)
                                    {
                                        post.carousel_media.ForEach(el =>
                                        {
                                            using (WebClient client = new WebClient())
                                            {
                                                client.DownloadFile(new Uri(el.image_versions2.candidates[0].url), $@"C:\temp\image{_idx}.jpg");
                                                _idx++;
                                            }
                                        });
                                    }
                                    if (post.image_versions2 != null)
                                    {
                                        using (WebClient client = new WebClient())
                                        {
                                            client.DownloadFile(new Uri(post.image_versions2.candidates[0].url), $@"C:\temp\image{_idx}.jpg");
                                            _idx++;
                                        }
                                    }
                                    #endregion
                                }
                            }
                            await Task.Delay(3_000);
                            _browser.ExecuteScriptAsync("window.scrollTo(0, document.body.scrollHeight);");
                            return;
                        }
                        Logging.Infomation("Lấy context thất bại");
                    }
                }
            }
            catch (Exception)
            {
                //logging.error(ex);
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

                string userNameUrl = txtUrl.Text;
                userNameUrl = userNameUrl.Replace(_dic["Domain"], "").Replace("/", "");
                Logging.Infomation("Bắt đầu crawl dữ liệu post...");
                _currUrl = String.Empty;
                //var tsk = await _contentBUS.CrawlInstagram(String.Empty, _browser, userNameUrl, lblSuccess, lblErr, rtbResult);
                //await Task.Delay(3_000);
                //if (tsk == State.Erorr)
                //{
                //    tsStatus.Text = "Không lấy được dữ liệu, vui lòng thử lại sau";
                //    return;
                //}
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
