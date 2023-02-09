using CefSharp;
using CefSharp.WinForms;
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
using VCCorp_Crawler_si_demand_source_INS.Config;
using CefSharp.WinForms;
using Crwal.Core.Log;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using VCCorp.CrawlerCore.DTO;
using VCCorp.CrawlerCore.DTO.ig_app_id;
using System.Xml;
using VCCorp.CrawlerCore.BUS;
using VCCorp.CrawlerCore.DAO;
using System.Security.Cryptography;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using System.Security.Policy;
using System.Threading;
using CefSharp.DevTools.Debugger;

namespace VCCorp_Crawler_si_demand_source_INS
{
    public partial class frmContentPost : Form
    {
        public ChromiumWebBrowser _browser;
        private INSsidemandsourcepostBUS _bll = new INSsidemandsourcepostBUS(IgRunTime.Config.DbConnection.FBExce);
        private int _idx = 1;
        public frmContentPost()
        {
            InitializeComponent();
            InitBrowser();
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
                //Cef.Initialize(new CefSettings());
                _browser = new ChromiumWebBrowser("https://www.instagram.com/");
                this.Controls.Add(_browser);
                this._browser.Location = new System.Drawing.Point(1, 70);
                this._browser.MinimumSize = new System.Drawing.Size(20, 20);
                this._browser.Name = "web_browser";
                this._browser.Size = new System.Drawing.Size(956, 827);
                this._browser.TabIndex = 4;
                this.pnView.Controls.Add(this._browser);
                //_browser.LoadingStateChanged += OnLoadingStateChanged;
                //_browser.AddressChanged += On_browserAddressChanged;
            }
            catch (Exception ex)
            {
                Logging.Error(ex);
            }
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            tsStatus.Text = "Loading...";
            await _browser.LoadUrlAsync(txtUrl.Text);
            await Task.Delay(3_000);
            await CrawlInstagram(String.Empty);
            await Task.Delay(3_000);
            tsStatus.Text = "Đã hoàn tất";
        }
        private async Task CrawlInstagram(string maxId)
        {
            string url = await GetUrlContent(maxId);
            VCCorp.CrawlerCore.Base.Request req = new VCCorp.CrawlerCore.Base.Request();
            string cookie = await IgRunTime.GetGlobalCookie();
            tsStatus.Text = "Vui lòng chờ 30s nữa...";
            var content = await req.GetContentProfile(url, IgRunTime.AppId, cookie);
            tsStatus.Text = "Đang xử lý dữ liệu";
            if (String.IsNullOrEmpty(content))
            {
                tsStatus.Text = "Không lấy được dữ liệu, vui lòng kiểm tra lại!";
                return;
            }
            var posts = JsonConvert.DeserializeObject<ContentDTO.Root>(content);
            List<Task> tasks = new List<Task>();
            if (posts != null && posts.items != null && posts.items.Count >= 0)
            {
                foreach (var post in posts.items)
                {
                    var pos = new INSsidemandsourcepostDTO()
                    {
                        post_id = post.pk,
                        platform = IgRunTime.Config.Platform,
                        link = IgRunTime.Config.InstagramDomainUrlOnePose + post.code,
                        creat_time = Utilities.UnixTimestampToDateTime(post.taken_at),
                        status = 0.ToString(),
                        total_comment = post.comment_count,
                        total_like = post.like_count,
                        total_share = 0,
                        user_crawler = IgRunTime.Config.UserCrawler,
                        fullName = post.user.full_name,
                        si_demand_source_id = "7"
                    };
                    if (post.caption != null)
                    {
                        pos.title = post.caption.text;
                    }
                    else
                    {
                        pos.title = "";
                    }

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
                    lblCountFile.Text = _idx.ToString();
                    tasks.Add(_bll.InsertsidemandsourcepostAsync(pos));
                }
                await Task.WhenAll(tasks);
                if (posts.more_available)
                {
                    await CrawlInstagram(posts.next_max_id);
                }
            }

        }
        private async Task<Users> GetUserIdByUserNameAsync(string username)
        {
            string url = String.Concat(IgRunTime.Config.InsQuery.TopSearchUrl, username);
            var Users = new Users();
            await _browser.LoadUrlAsync(url);
            var source = await _browser.GetSourceAsync();
            source = Regex.Replace(source, "(<html)(.*?)(pre-wrap;\">)", " ", RegexOptions.IgnoreCase); // xóa cặp thẻ
            source = Regex.Replace(source, "</pre></body></html>", "", RegexOptions.IgnoreCase);
            Users = JsonConvert.DeserializeObject<Users>(source);
            if (Users != null && Users.users != null)
            {
                return Users;
            }
            return null;
        }
        private async Task<string> GetUrlContent(string maxId, int count = 22)
        {
            string userNameUrl = Regex.Match(txtUrl.Text, "(?<=https://www.instagram.com/)(.*?)(?=/)").Value;
            var user = await GetUserIdByUserNameAsync(userNameUrl);
            string baseUrl = string.Empty;
            if (user != null)
            {
                baseUrl = $"https://www.instagram.com/api/v1/feed/user/{user.users[0].user.pk_id}?count={count.ToString()}";
                if (!String.IsNullOrEmpty(maxId))
                {
                    baseUrl += $"&max_id={maxId}";
                }
            }

            return baseUrl;
        }

        private void frmContentPost_Load(object sender, EventArgs e)
        {

        }
    }
}
