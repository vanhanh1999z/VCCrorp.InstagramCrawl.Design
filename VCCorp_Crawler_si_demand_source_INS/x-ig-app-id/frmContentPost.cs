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
using VCCorp.CrawlerCore.BUS.ig_app_id;
using VCCorp.CrawlerCore.Base;
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
            string userNameUrl = Regex.Match(txtUrl.Text, "(?<=https://www.instagram.com/)(.*?)(?=/)").Value;
            Logging.Infomation("Bắt đầu crawl dữ liệu post...");
            var result = await _contentBUS.CrawlInstagram(String.Empty, _browser, userNameUrl, lblSuccess, lblErr);
            await Task.Delay(3_000);
            if (result == State.Erorr)
            {
                tsStatus.Text = "Không lấy được dữ liệu, vui lòng thử lại sau";
                return;
            }
            //tsStatus.Text = "Đang đẩy dữ liệu vào si_source_post, vui lòng đợi";
            tsStatus.Text = "Đã hoàn tất";
        }
    }
}
