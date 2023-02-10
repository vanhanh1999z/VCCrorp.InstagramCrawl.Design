using CefSharp;
using CefSharp.WinForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VCCorp.CrawlerCore.Base;
using VCCorp.CrawlerCore.BUS;
using VCCorp.CrawlerCore.Common;
using VCCorp.CrawlerCore.DTO;
using VCCorp_Crawler_si_demand_source_INS.Config;

namespace VCCorp_Crawler_si_demand_source_INS
{
    public partial class frmFindlSourceID_INS : Form
    {
        private int _loading;
        public ChromiumWebBrowser browser;
        List<INSsidemandsourceDTO> _listsidemandsource;
        INSsidemandsourceBUS _bll = new INSsidemandsourceBUS(IgRunTime.Config.DbConnection.FBExce);

        private int _flag;
        private int _indexCurr; // vị trí hiện hành của url bóc
        string _logFile;
        string _strId;

        public frmFindlSourceID_INS()
        {
            InitializeComponent();
            GetUrlInstargram();
            VarInit();
            InitBrowser();
            lbToolStripStatus.Text = "Hệ thống sẽ tự động chạy sau 1 phút nữa, xin chờ...";
            timerStart.Interval = 1000;
            timerStart.Enabled = true;

        }

        private string GetSourceFromBrowser()
        {
            var task1 = browser.GetSourceAsync();
            task1.Wait();
            string source = task1.Result;
            return source;
        }

        private void VarInit()
        {
            _flag = -1;
            _logFile = DateTime.Now.ToString("yyyy.MM.dd_HH.mm") + ".txt";
            _loading = -1;
            _indexCurr = -1;
        }
        public void InitBrowser()
        {
            try
            {
                if (!CefSharp.Cef.IsInitialized)
                {
                    string pathCache = @"C:\CEFSharp_Cache";
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

                _loading = 0;

                browser = new ChromiumWebBrowser(txtAddress.Text);

                this.Controls.Add(browser);

                this.browser.Location = new System.Drawing.Point(1, 70);
                this.browser.MinimumSize = new System.Drawing.Size(20, 20);
                this.browser.Name = "webBrowser";
                this.browser.Size = new System.Drawing.Size(956, 827);
                this.browser.TabIndex = 4;

                this.groupLeft.Controls.Add(this.browser);

                browser.LoadingStateChanged += OnLoadingStateChanged;
                //browser.AddressChanged += OnBrowserAddressChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
        private void OnLoadingStateChanged(object sender, LoadingStateChangedEventArgs args)
        {
            if (!args.IsLoading)
            {
                _loading = 1;
            }
        }
        private void btLoad_Click(object sender, EventArgs e)
        {
            _loading = 0;
            browser.Load(txtAddress.Text);
        }

        /// <summary>
        /// get source INS trong bảng si_demand_source
        /// </summary>
        private void GetUrlInstargram()
        {
            try
            {
                _listsidemandsource = _bll.GetlinkINSsidemanINS();
                lbTotalLink.Text = _listsidemandsource.Count().ToString();
            }
            catch (Exception ex) { }
        }

        private void Crawler()
        {
            CrawlerAndSend();
            _flag = 2;
        }

        private async void CrawlerAndSend()
        {
            try
            {
                lbToolStripStatus.Text = "Đang bóc INfos " + _listsidemandsource[_indexCurr].link;
                _strId = _listsidemandsource[_indexCurr].id;
                string source = GetSourceFromBrowser();
                //xóa cặp thẻ không cần thiết để trở về định dạng chuẩn json
                source = Regex.Replace(source, "(<html)(.*?)(pre-wrap;\">)", "", RegexOptions.IgnoreCase); // xóa cặp thẻ
                source = Regex.Replace(source, "</pre></body></html>", "", RegexOptions.IgnoreCase);
                var ObjRoot = JsonConvert.DeserializeObject<jsonFindSourceID.Root>(source);
                if (ObjRoot != null)
                {
                    string source_Id = ObjRoot.graphql.user.id;
                    if (!string.IsNullOrEmpty(source_Id))
                    {
                        int re = _bll.UpdatesourceIdsidemancINS(_strId, source_Id);
                    }
                    else
                    {
                        source_Id = "-1";
                        int re = _bll.UpdatesourceIdsidemancINS(_strId, source_Id);
                    }
                }
            }
            catch (Exception) { }
        }

        private void timerStart_Tick(object sender, EventArgs e)
        {
            timerStart.Interval = 1000;

            if (_loading == 0)
            {
                return;
            }

            if (_listsidemandsource == null || _listsidemandsource.Count == 0)
            {
                lbToolStripStatus.Text = "không có link nào để bóc - Dừng chạy chờ 1p sau chạy lại";
                timerStart.Interval = 1000 * 60;
                _listsidemandsource.Clear();
                timerStart.Enabled = true;
                _flag = -1;
                VarInit();
                GetUrlInstargram();
                return;
            }

            if (_flag == -1)
            {
                #region load link ra trình duyệt
                _indexCurr = _listsidemandsource.FindIndex(x => x.IsCrawled == false);
                if (_indexCurr == -1)
                {
                    _flag = 10; // xong 1 vòng
                    return;
                }

                if (_indexCurr == 0)
                {
                    //_blockNameLog = DateTime.Now.ToString("HH") + "_gio_" + DateTime.Now.ToString("mm") + "_phut_" + DateTime.Now.ToString("ss") + "_giay"; // tên log file 1 vòng
                }
                lbLinkIndexCurr.Text = _indexCurr.ToString();
                txtAddress.Text = _listsidemandsource[_indexCurr].link;
                _loading = 0;
                browser.Load(txtAddress.Text);

                int sec = 15;

                Random ran = new Random();
                sec = ran.Next(20, 30);

                timerStart.Interval = 1000 * sec;

                lbToolStripStatus.Text = "loading, xin chờ " + sec + " giây để hoàn thành...";

                _flag = 0;

                return;
                #endregion
            }

            if (_flag == 0)
            {
                _flag = 1;
                Thread th = new Thread(new ThreadStart(Crawler));
                th.Start();
            }

            if (_flag == 1)
            {
                return;
            }

            if (_flag == 2) // xong
            {
                _listsidemandsource[_indexCurr].IsCrawled = true;
                _flag = -1; // trả cờ
                _indexCurr = -1;// trả cờ

                return;
            }

            if (_flag == 10) // xong
            {
                lbToolStripStatus.Text = "Đã bóc xong 1 vòng rồi - hệ thống sẽ nghỉ 1p rồi chạy bóc tách lại";
                timerStart.Interval = 1000 * 60;
                timerStart.Enabled = true;
                _listsidemandsource.Clear();
                _flag = -1;
                VarInit();
                GetUrlInstargram();
                return;
            }
        }
        private void btnsource_Click(object sender, EventArgs e)
        {
            DownloadHtmlResult sourceObj = DownloadHtml.GetContentHtml(txtAddress.Text);
        }
    }
}
