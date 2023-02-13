using CefSharp;
using CefSharp.WinForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VCCorp.CrawlerCore.Base;
using VCCorp.CrawlerCore.BUS;
using VCCorp.CrawlerCore.Common;
using VCCorp.CrawlerCore.DTO;

namespace VCCorp_Crawler_si_demand_source_INS
{
    public partial class frmSourcesdemainNew : Form
    {
        private int _loading;
        public ChromiumWebBrowser browser;
        List<INSsidemandsourceDTO> _listsidemandsource;
        INSsidemandsourceBUS _bll = new INSsidemandsourceBUS(IgRunTime.Config.DbConnection.FBExce);
        INSsidemandsourcepostBUS _bllpost = new INSsidemandsourcepostBUS(IgRunTime.Config.DbConnection.FBExce);
        int _count = 0;
        private int _flag;
        private int _indexCurr; // vị trí hiện hành của url bóc
        string _logFile;
        string _strId;
        public frmSourcesdemainNew()
        {
            InitializeComponent();
            InitBrowser();
            GetUrlInstargram();
            VarInit();

            lbTotalLink.Text = _listsidemandsource.Count.ToString();

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
                _listsidemandsource = _bll.GetSourcesidemainNew();
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
                lbToolStripStatus.Text = "Đang bóc INfos " + _listsidemandsource[_indexCurr].link;
                _strId = _listsidemandsource[_indexCurr].id;
                //update trạng thái đang bóc source
                int re = _bll.UpdatesidemandsrcINS(_strId, "1", "in process", "", "");
                string source = GetSourceFromBrowser();
                //xóa cặp thẻ không cần thiết để trở về định dạng chuẩn json
                source = Regex.Replace(source, "(<html)(.*?)(pre-wrap;\">)", "", RegexOptions.IgnoreCase); // xóa cặp thẻ
                source = Regex.Replace(source, "</pre></body></html>", "", RegexOptions.IgnoreCase);

                #region
                //phân tích ra json xong lưu vào db
                var ObjRoot = JsonConvert.DeserializeObject<JsonProfileINS.Root>(source);
                if (ObjRoot != null)
                {
                    if (ObjRoot.data != null)
                    {
                        foreach (var data in ObjRoot.data.user.edge_owner_to_timeline_media.edges)
                        {
                            INSsidemandsourcepostDTO entrydatapost = new INSsidemandsourcepostDTO();
                            entrydatapost.post_id = data.node.id;
                            foreach (var datatext in data.node.edge_media_to_caption.edges)
                            {
                                string text = Regex.Replace(datatext.node.text, @"[^\w\.@-]", " ");
                                entrydatapost.content = text;
                            }
                            entrydatapost.link = "https://www.instagram.com/p/" + data.node.shortcode;
                            entrydatapost.total_comment = data.node.edge_media_to_comment.count;
                            entrydatapost.total_like = data.node.edge_media_preview_like.count;
                            entrydatapost.idUser = data.node.owner.id;
                            entrydatapost.imagePost = data.node.thumbnail_src;
                            entrydatapost.creat_time = UnixTimeStampToDateTime(data.node.taken_at_timestamp);

                            //data từ bảng si_demand_source lấy sang
                            entrydatapost.si_demand_source_id = _listsidemandsource[_indexCurr].id;
                            entrydatapost.platform = _listsidemandsource[_indexCurr].platform;
                            entrydatapost.TimeCrw = DateTime.Now;
                            entrydatapost.status = "0";
                            entrydatapost.title = "";
                            entrydatapost.total_share = 0;
                            entrydatapost.user_crawler = "cucnt";
                            entrydatapost.server_name_crawl = Utilities.GetLocalIP();

                            //Bắn Post lên kafa
                            //Khai báo class bắn lên kafa
                            kafaPostINSDTO entdatakafapost = new kafaPostINSDTO();
                            entdatakafapost.Id = entrydatapost.post_id;
                            entdatakafapost.Message = entrydatapost.content;
                            entdatakafapost.ShortCode = data.node.shortcode;
                            entdatakafapost.Link = entrydatapost.link;
                            entdatakafapost.TotalComment = entrydatapost.total_comment;
                            entdatakafapost.TotalLike = entrydatapost.total_like;
                            entdatakafapost.TotalShare = 0;
                            entdatakafapost.TotalReaction = 0;
                            entdatakafapost.ImagePost = entrydatapost.imagePost;
                            entdatakafapost.Platform = entrydatapost.platform;
                            entdatakafapost.CreateTime = entrydatapost.creat_time;
                            entdatakafapost.TimeCrw = DateTime.Now;
                            entdatakafapost.TmpTime = data.node.taken_at_timestamp;
                            entdatakafapost.UserId = entrydatapost.idUser;
                            entdatakafapost.Username = "";
                            entdatakafapost.ImageUser = "";

                            await SaveKafraPost(entdatakafapost);
                            //Insert post vào DB si_demand_source_post
                            _bllpost.Insertsidemandsourcepost(entrydatapost);
                        }
                        //tìm phân trang
                        string UserId = _listsidemandsource[_indexCurr].source_id;
                        Boolean has_next_page = ObjRoot.data.user.edge_owner_to_timeline_media.page_info.has_next_page;
                        string nextPage = ObjRoot.data.user.edge_owner_to_timeline_media.page_info.end_cursor;
                        if (has_next_page = true && !string.IsNullOrEmpty(nextPage))
                        {
                            endursor(UserId, nextPage);
                        }
                        string crawlcurrentdate = _listsidemandsource[_indexCurr].crawlcurrentdate.ToString();
                        crawlcurrentdate = crawlcurrentdate + 1;
                        string crawlerdate = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                        _bll.UpdatesidemandsrcINS(_strId, "2", "done", crawlcurrentdate, crawlerdate);
                    }
                    _flag = 2;
                }
                else
                {
                    //lỗi source ko lấy đc data update trạng thái source = -1
                    _bll.UpdatesidemandsrcINS(_strId, "-1", "", "", "");
                    //_bll.UpdatesidemandINS(_strId, "-1");
                }
                #endregion

            }
            catch (Exception ex)
            {
                //gặp lỗi thì cho cờ trở về 2 để cho nó chạy tiếp Url tiếp theo
                _flag = 2;
                //update trang thai loi ko boc dc
                _bll.UpdatesidemandsrcINS(_strId, "-1", "", "", "");

            }
        }
        /// <summary>
        /// Bắn Post lên kafka
        /// </summary>
        /// <param name="postDTO"></param>
        /// <returns></returns>
        private async Task SaveKafraPost(kafaPostINSDTO postDTO)
        {
            try
            {
                string messagejson = postDTO.ToJson();
                // Bắn data cmt
                string intfag = await KafkaBll.PutOnKafkaPostINS(messagejson);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Lỗi phần SaveKafra" + ex);
            }
        }
        private void Crawler()
        {
            CrawlerAndSend();

        }

        /// <summary>
        /// Load data ở những trang tiếp theo
        /// </summary>
        /// <param name="strid"></param>
        /// <param name="endcursor"></param>
        private async void endursor(string strid, string endcursor)
        {
            try
            {
                int intcount = 0;
                List<INSsidemandsourcepostDTO> listPostINS = new List<INSsidemandsourcepostDTO>();

                string urlpage = "https://www.instagram.com/graphql/query/?query_hash=472f257a40c653c64c666ce877d59d2b&variables={%22id%22:%22" + strid + "%22,%22first%22:50,%22after%22:%22" + endcursor + "%22}";
                browser.Load(urlpage);
                Thread.Sleep(6000);
                string source = GetSourceFromBrowser();

                source = Regex.Replace(source, "(<html)(.*?)(pre-wrap;\">)", " ", RegexOptions.IgnoreCase); // xóa cặp thẻ
                source = Regex.Replace(source, "</pre></body></html>", "", RegexOptions.IgnoreCase);

                #region
                //phân tích ra json xong lưu vào db
                var ObjRoot = JsonConvert.DeserializeObject<JsonProfileINS.Root>(source);
                if (ObjRoot != null)
                {
                    foreach (var data in ObjRoot.data.user.edge_owner_to_timeline_media.edges)
                    {
                        INSsidemandsourcepostDTO entrydatapost = new INSsidemandsourcepostDTO();
                        entrydatapost.post_id = data.node.id;
                        entrydatapost.content = data.node.text;
                        entrydatapost.link = "https://www.instagram.com/p/" + data.node.shortcode;
                        entrydatapost.total_comment = data.node.edge_media_to_comment.count;
                        entrydatapost.total_like = data.node.edge_media_preview_like.count;
                        entrydatapost.idUser = data.node.owner.id;
                        entrydatapost.imagePost = data.node.thumbnail_src;
                        entrydatapost.creat_time = UnixTimeStampToDateTime(data.node.taken_at_timestamp);

                        //data từ bảng si_demand_source lấy sang
                        entrydatapost.si_demand_source_id = _listsidemandsource[_indexCurr].id;
                        entrydatapost.platform = _listsidemandsource[_indexCurr].platform;
                        entrydatapost.TimeCrw = DateTime.Now;
                        entrydatapost.status = "0";
                        entrydatapost.title = "";
                        entrydatapost.total_share = 0;
                        entrydatapost.user_crawler = "cucnt";
                        entrydatapost.server_name_crawl = Utilities.GetLocalIP();


                        //Bắn Post lên kafa
                        //Khai báo class bắn lên kafa
                        kafaPostINSDTO entdatakafapost = new kafaPostINSDTO();
                        entdatakafapost.Id = entrydatapost.post_id;
                        entdatakafapost.Message = entrydatapost.content;
                        entdatakafapost.ShortCode = data.node.shortcode;
                        entdatakafapost.Link = entrydatapost.link;
                        entdatakafapost.TotalComment = entrydatapost.total_comment;
                        entdatakafapost.TotalLike = entrydatapost.total_like;
                        entdatakafapost.TotalShare = 0;
                        entdatakafapost.TotalReaction = 0;
                        entdatakafapost.ImagePost = entrydatapost.imagePost;
                        entdatakafapost.Platform = entrydatapost.platform;
                        entdatakafapost.CreateTime = entrydatapost.creat_time;
                        entdatakafapost.TimeCrw = DateTime.Now;
                        entdatakafapost.TmpTime = data.node.taken_at_timestamp;
                        entdatakafapost.UserId = entrydatapost.idUser;
                        entdatakafapost.Username = "";
                        entdatakafapost.ImageUser = "";

                        await SaveKafraPost(entdatakafapost);

                        //Insert post vào DB si_demand_source_post
                        _bllpost.Insertsidemandsourcepost(entrydatapost);

                        //tìm phân trang
                        //string UserId = _listsidemandsource[_indexCurr].source_id;
                        //Boolean has_next_page = ObjRoot.data.user.edge_owner_to_timeline_media.page_info.has_next_page;
                        //string nextPage = ObjRoot.data.user.edge_owner_to_timeline_media.page_info.end_cursor;
                        //if (has_next_page = true && string.IsNullOrEmpty(nextPage))
                        //{
                        //    endursor(_strId, nextPage);
                        //}
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                lbToolStripStatus.Text = "không có link nào để bóc - hệ thống sẽ nghỉ 1phut rồi chạy bóc tách lại";
                timerStart.Interval = 1000 * 60 * 60;
                _listsidemandsource.Clear();
                _flag = -1;
                btStart.Enabled = true;
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

                //int sec = 15;

                //Random ran = new Random();
                //sec = ran.Next(20, 30);

                //timerStart.Interval = 1000 * sec;

                //lbToolStripStatus.Text = "loading, xin chờ " + sec + " giây để hoàn thành...";

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
                lbToolStripStatus.Text = "Đã bóc xong 1 vòng rồi - hệ thống sẽ nghỉ 6 giờ rồi chạy bóc tách lại";
                timerStart.Interval = 1000 * 60 * 60;
                _listsidemandsource.Clear();
                _flag = -1;
                btStart.Enabled = true;
                VarInit();
                GetUrlInstargram();
                return;
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
    }
}
