using CefSharp;
using CefSharp.WinForms;
using Crwal.Core.Log;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using VCCorp.CrawlerCore.Base;
using VCCorp.CrawlerCore.BUS;
using VCCorp.CrawlerCore.BUS.ig_app_id;
using VCCorp.CrawlerCore.DTO;
using VCCorp.CrawlerCore.SysEnum;

namespace VCCorp_Crawler_si_demand_source_INS.x_ig_app_id
{
    public partial class frmComment : Form
    {
        private INSsidemandsourcepostBUS _soucePost = new INSsidemandsourcepostBUS(IgRunTime.Config.CloudDbConnection.FBExce);
        private ChromiumWebBrowser _browser;
        private ChromiumWebBrowser _browserR;
        private IEnumerator<string> _enumrator;
        public frmComment()
        {
            InitializeComponent();
            InitBrowser(pnResult);
            InitBrowserR(pnResultR);
            _enumrator = this.GetSource().GetEnumerator();

        }
        private async void btCommentCheck_ClickAsync(object sender, EventArgs e)
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
        private async void btCommentStart_Click(object sender, EventArgs e)
        {
            var posts = await _soucePost.GetLinkPostAsync();
            var tasks = new List<Task>();
            if (posts != null)
            {
                var lPosts = new List<INSsidemandsourcepostDTO>();
                var rPosts = new List<INSsidemandsourcepostDTO>();
                double midIdx = posts.Count / 2;
                midIdx = Math.Floor(midIdx);

                for (int i = 0; i < posts.Count; i++)
                {
                    if (i <= midIdx)
                    {
                        lPosts.Add(posts[i]);
                    }
                    else
                    {
                        rPosts.Add(posts[i]);
                    }
                }
                tasks.Add(CrawlStarted(_browser, String.Empty, lblTotal, lblCurrentPost, lblSuccess, lblErr, rtbResult, lPosts));
                tasks.Add(CrawlStarted(_browserR, String.Empty, lblTotalR, lblCurrR, lblSuccessR, lblErrR, rtbResultM, rPosts));
                await Task.WhenAll(tasks);
            }
        }
        public IEnumerable<string> GetSource()
        {
            var posts = _soucePost.GetLinkPostAsync();
            posts.Wait();

            foreach (var post in posts.Result)
            {
                yield return post.link;
            }
        }
        public async Task CrawlStarted(ChromiumWebBrowser browser, string nextMinIdJson, Label lblTotal, Label lblCurrent, Label lblSuccess, Label lblErr, RichTextBox rtbResult, List<INSsidemandsourcepostDTO> posts)
        {
            try
            {
                var commentBUS = new CommentBUS();
                State state = await commentBUS.CrawlCommentAsync(browser, nextMinIdJson, lblTotal, lblCurrent, lblSuccess, lblErr, rtbResult, posts);
                if (state == State.Success)
                {
                    stState.Text = "Đã hoàn tất!"; return;
                }
                stState.Text = "Đã có sự cố xảy ra, vui lòng kiểm ra lại!";
            }
            catch (Exception ex)
            {
                stState.Text = "Đã có sự cố xảy ra, vui lòng kiểm ra lại!";
                Logging.Error(ex);
            }
        }
        public void InitBrowser(Panel pn)
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
                //this.Controls.Add(browser);
                _browser.Location = new System.Drawing.Point(1, 70);
                _browser.MinimumSize = new System.Drawing.Size(20, 20);
                _browser.Name = "webbrowser";
                _browser.Size = new System.Drawing.Size(956, 827);
                _browser.TabIndex = 4;
                pn.Controls.Add(_browser);
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
        public void InitBrowserR(Panel pn)
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
                _browserR = new ChromiumWebBrowser(IgRunTime.Config.DeafultLoadUrl);
                //this.Controls.Add(browser);

                _browserR.Location = new System.Drawing.Point(1, 70);
                _browserR.MinimumSize = new System.Drawing.Size(20, 20);
                _browserR.Name = "webbrowser";
                _browserR.Size = new System.Drawing.Size(956, 827);
                _browserR.TabIndex = 4;
                pn.Controls.Add(_browserR);
                _browserR.LoadingStateChanged += async (sender, args) =>
                {
                    var script = await VCCorp.CrawlerCore.Base.Request.LoadScriptJs();
                    _browserR.ExecuteScriptAsync(script);
                };
            }
            catch (Exception ex)
            {
                Logging.Error(ex);
            }
        }
        private void btShowDevTool_Click(object sender, EventArgs e)
        {
            _browser.ShowDevTools();
            _browserR.ShowDevTools();
        }
        private void frmComment_Load(object sender, EventArgs e)
        {

        }
    }
}
