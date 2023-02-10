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
    public partial class frmPostdemandsource_INS : Form
    {
        private int _loading;
        public ChromiumWebBrowser browser;
        List<INSsidemandsourcepostDTO> _listsidemandPost;
        INSsidemandsourcepostBUS _bll = new INSsidemandsourcepostBUS(IgRunTime.Config.DbConnection.FBExce);
        List<kafaCommentINSDTO> _listCmt = new List<kafaCommentINSDTO>();

        int _count = 0;
        private int _flag;
        private int _indexCurr; // vị trí hiện hành của url bóc
        string _logFile;
        string _strId;
        public frmPostdemandsource_INS()
        {
            InitializeComponent();
            InitBrowser();
            GetUrlInstargram();
            lbTotalLink.Text = _listsidemandPost.Count.ToString();
            VarInit();
            lbToolStripStatus.Text = "Hệ thống sẽ tự động chạy sau 1 phút nữa, xin chờ...";
            //timerStart.Interval = 1000 * 60;
            timerStart.Enabled = true;
        }

        /// <summary>
        /// button load website ra rb
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btLoad_Click(object sender, EventArgs e)
        {
            _loading = 0;
            browser.Load(txtAddress.Text);
        }
        /// <summary>
        /// KHởi tạo cefsharp
        /// </summary>
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
                //_logFile = "Lỗi " + ex.Message;
                //WriteLog(_logFile);
            }


        }

        private void OnLoadingStateChanged(object sender, LoadingStateChangedEventArgs args)
        {
            if (!args.IsLoading)
            {
                _loading = 1;
            }
        }
        private void VarInit()
        {
            _flag = -1;
            _logFile = DateTime.Now.ToString("yyyy.MM.dd_HH.mm") + ".txt";
            _loading = -1;
            _indexCurr = -1;
        }
        /// <summary>
        /// get source INS trong bảng si_demand_source
        /// </summary>
        private void GetUrlInstargram()
        {
            try
            {
                _listsidemandPost = _bll.GetSourcesidemandPostINS();
            }
            catch (Exception ex) { }
        }

        private string GetSourceFromBrowser()
        {
            var task1 = browser.GetSourceAsync();
            task1.Wait();
            string source = task1.Result;
            return source;
        }
        /// <summary>
        /// Chuyển đổi ngày tháng
        /// </summary>
        /// <param name="unixTimeStamp"></param>
        /// <returns></returns>
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }

        private async void CrawlerAndSend()
        {
            try
            {
                lbToolStripStatus.Text = "Đang bóc INfos " + _listsidemandPost[_indexCurr].link;
                _strId = _listsidemandPost[_indexCurr].post_id;
                //update trạng thái đang bóc source
                _bll.UpdatesidemandPostINS(_strId, "1", "");
                string source = GetSourceFromBrowser();
                //xóa cặp thẻ không cần thiết để trở về định dạng chuẩn json
                source = Regex.Replace(source, "(<html)(.*?)(pre-wrap;\">)", " ", RegexOptions.IgnoreCase); // xóa cặp thẻ
                source = Regex.Replace(source, "</pre></body></html>", "", RegexOptions.IgnoreCase);

                #region
                //phân tích ra json xong lưu vào db
                var ObjRoot = JsonConvert.DeserializeObject<INSJsonComment_Post.Root>(source);
                if (ObjRoot != null)
                {
                    if (ObjRoot.data != null)
                    {
                        foreach (var data in ObjRoot.data.shortcode_media.edge_media_to_comment.edges)
                        {
                            kafaCommentINSDTO entrydataCmt = new kafaCommentINSDTO();
                            entrydataCmt.CommentId = data.node.id;
                            try
                            {
                                entrydataCmt.CommentText = data.node.text;
                            }
                            catch { }

                            entrydataCmt.PostId = _listsidemandPost[_indexCurr].post_id;
                            entrydataCmt.Url = "https://www.instagram.com/p/" + _listsidemandPost[_indexCurr].shortcode;
                            entrydataCmt.OwnerId = data.node.owner.id;
                            entrydataCmt.OwnerUser = data.node.owner.username;
                            try
                            {
                                entrydataCmt.OwnerProfilePicUrl = data.node.owner.profile_pic_url;
                            }
                            catch { }
                            try
                            {
                                entrydataCmt.CreateTime = UnixTimeStampToDateTime(data.node.created_at);
                            }
                            catch { }

                            //Bắn Post lên kafa
                            _listCmt.Add(entrydataCmt);
                            //await SaveKafraPost(entrydatapost);
                            //Không cần lưu comment mà bắn đi kafa luôn
                        }
                        //tìm phân trang
                        string UserId = _listsidemandPost[_indexCurr].shortcode;
                        Boolean has_next_page = ObjRoot.data.shortcode_media.edge_media_to_comment.page_info.has_next_page;
                        string nextPage = ObjRoot.data.shortcode_media.edge_media_to_comment.page_info.end_cursor;
                        if (has_next_page = true && !string.IsNullOrEmpty(nextPage))
                        {
                            endursor(UserId, nextPage);
                        }

                        _bll.UpdatesidemandPostINS(_strId, "2", "");
                    }
                    _flag = 2;
                }
                else
                {
                    //lỗi source ko lấy đc data update trạng thái source = -1
                    //_bll.UpdatesidemandINS(_strId, "-1");
                }
                #endregion

            }
            catch (Exception ex)
            {
                //gặp lỗi thì cho cờ trở về 2 để cho nó chạy tiếp Url tiếp theo
                _flag = 2;
                //update trang thai loi ko boc dc
                // _bll.UpdatesidemandINS(_strId, "-1");
            }
        }
        /// <summary>
        /// Bắn Post lên kafka
        /// </summary>
        /// <param name="postDTO"></param>
        /// <returns></returns>
        private async Task SaveKafraPost(INSsidemandsourcepostDTO postDTO)
        {
            try
            {
                string a = "";
                string messagejson = postDTO.ToJson();
                // Bắn data cmt
                string intfag = await KafkaBll.PutOnKafkaCmtINS(messagejson);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Lỗi phần SaveKafra" + ex);
            }
        }
        private void Crawler()
        {
            CrawlerAndSend();
            _flag = 2;

        }

        /// <summary>
        /// Load data ở những trang tiếp theo
        /// </summary>
        /// <param name="strid"></param>
        /// <param name="endcursor"></param>
        private async void endursor(string shortcode, string endcursor)
        {
            try
            {
                List<INSsidemandsourcepostDTO> listPostINS = new List<INSsidemandsourcepostDTO>();

                string urlpage = "https://www.instagram.com/graphql/query/?query_hash=33ba35852cb50da46f5b5e889df7d159&variables=%7B%22shortcode%22:%22" + shortcode + "%22,%22first%22:100,%22after%22:%22" + endcursor + "%22%7D";
                browser.Load(urlpage);
                Thread.Sleep(6000);
                string source = GetSourceFromBrowser();
                //xóa cặp thẻ không cần thiết để trở về định dạng chuẩn json
                source = Regex.Replace(source, "(<html)(.*?)(pre-wrap;\">)", " ", RegexOptions.IgnoreCase); // xóa cặp thẻ
                source = Regex.Replace(source, "</pre></body></html>", "", RegexOptions.IgnoreCase);

                #region
                //phân tích ra json xong lưu vào db
                var ObjRoot = JsonConvert.DeserializeObject<INSJsonComment_Post.Root>(source);
                if (ObjRoot != null)
                {
                    if (ObjRoot.data != null)
                    {
                        foreach (var data in ObjRoot.data.shortcode_media.edge_media_to_comment.edges)
                        {
                            kafaCommentINSDTO entrydataCmt = new kafaCommentINSDTO();
                            entrydataCmt.CommentId = data.node.id;
                            entrydataCmt.CommentText = data.node.text;
                            entrydataCmt.PostId = _listsidemandPost[_indexCurr].post_id;
                            entrydataCmt.Url = "https://www.instagram.com/p/" + _listsidemandPost[_indexCurr].shortcode;
                            entrydataCmt.OwnerId = data.node.owner.id;
                            entrydataCmt.OwnerUser = data.node.owner.username;
                            entrydataCmt.OwnerProfilePicUrl = data.node.owner.profile_pic_url;
                            entrydataCmt.CreateTime = UnixTimeStampToDateTime(data.node.created_at);

                            //Bắn Post lên kafa
                            _listCmt.Add(entrydataCmt);
                            //await SaveKafraPost(entrydatapost);
                            //Không cần lưu comment mà bắn đi kafa luôn
                        }
                        //tìm phân trang
                        //string UserId = _listsidemandPost[_indexCurr].shortcode;
                        //Boolean has_next_page = ObjRoot.data.shortcode_media.edge_media_to_comment.page_info.has_next_page;
                        //string nextPage = ObjRoot.data.shortcode_media.edge_media_to_comment.page_info.end_cursor;
                        //if (has_next_page = true && !string.IsNullOrEmpty(nextPage))
                        //{
                        //    endursor(UserId, nextPage);
                        //}
                    }
                }
                else
                {
                    //lỗi source ko lấy đc data update trạng thái source = -1
                    //_bll.UpdatesidemandINS(_strId, "-1");
                }
            }
            #endregion

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btPause_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            CrawlerAndSend();
        }

        private void timerStart_Tick(object sender, EventArgs e)
        {
            timerStart.Interval = 1000;

            if (_loading == 0)
            {
                return;
            }

            if (_listsidemandPost == null || _listsidemandPost.Count == 0)
            {
                lbToolStripStatus.Text = "không có link nào để bóc - Dừng chạy";
                timerStart.Enabled = false;
                timerStart.Stop();

                btStart.Enabled = true;

                return;
            }

            if (_flag == -1)
            {
                #region load link ra trình duyệt
                _indexCurr = _listsidemandPost.FindIndex(x => x.IsCrawled == false);
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

                txtAddress.Text = _listsidemandPost[_indexCurr].link;
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
                _listsidemandPost[_indexCurr].IsCrawled = true;
                _flag = -1; // trả cờ
                _indexCurr = -1;// trả cờ

                return;
            }

            if (_flag == 10) // xong
            {
                lbToolStripStatus.Text = "Đã bóc xong 1 vòng rồi - hệ thống sẽ nghỉ 6 giờ rồi chạy bóc tách lại";
                timerStart.Interval = 1000 * 60 * 60 * 6;
                _flag = -1;
                btStart.Enabled = true;
                VarInit();
                GetUrlInstargram();
                return;
            }
        }
    }
}
