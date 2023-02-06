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
using VCCorp.CrawlerCore.BUS;
using VCCorp.CrawlerCore.Common;
using VCCorp.CrawlerCore.DTO;

namespace VCCorp_Crawler_si_demand_source_INS
{

    public partial class frmOneINS : Form
    {
        private int _loading;
        public ChromiumWebBrowser browser;
        int _count = 0;
        private int _flag;
        private int _indexCurr; // vị trí hiện hành của url bóc
        string _logFile;
        string _strId;

        string _strPostId;
        public frmOneINS()
        {
            InitializeComponent();
            InitBrowser();
            VarInit();

        }

        private void btStart_Click(object sender, EventArgs e)
        {
            CrawlerAndSend();
        }
        private async void CrawlerAndSend()
        {
            try
            {
                string shortcode = txtAddress.Text;
                shortcode = shortcode.Replace("https://www.instagram.com/p/", "");
                shortcode = shortcode.Replace("?__a=1&__d=dis", "");
                shortcode = shortcode.Replace("/", "");
                lbToolStripStatus.Text = "Đang bóc INfos " + txtAddress.Text;
                string source = GetSourceFromBrowser();
                //xóa cặp thẻ không cần thiết để trở về định dạng chuẩn json
                source = Regex.Replace(source, "(<html)(.*?)(pre-wrap;\">)", "", RegexOptions.IgnoreCase); // xóa cặp thẻ
                source = Regex.Replace(source, "</pre></body></html>", "", RegexOptions.IgnoreCase);

                //phân tích ra json xong lưu vào db
                var ObjRoot = JsonConvert.DeserializeObject<JsonSiDataExcel.Root>(source);
                if (ObjRoot != null)
                {
                    if (ObjRoot.items != null)
                    {
                        foreach (var data in ObjRoot.items)
                        {
                            INSsidemandsourcepostDTO entrydatapost = new INSsidemandsourcepostDTO();
                            entrydatapost.si_demand_source_id = _strId;
                            entrydatapost.post_id = data.id;
                            _strPostId = entrydatapost.post_id;
                            entrydatapost.shortcode = data.code;
                            entrydatapost.link = "https://www.instagram.com/p/" + entrydatapost.shortcode;
                            entrydatapost.total_comment = data.comment_count;
                            entrydatapost.total_like = data.like_count;
                            try
                            {
                                entrydatapost.content = data.caption.text;
                            }
                            catch
                            { }
                            try
                            {
                                entrydatapost.creat_time = UnixTimeStampToDateTime(data.device_timestamp);
                            }
                            catch { }

                            entrydatapost.TimeCrw = DateTime.Now;
                            try
                            {
                                entrydatapost.idUser = data.user.pk.ToString();
                            }
                            catch { }
                            try
                            {
                                entrydatapost.nameUser = data.user.username;
                            }
                            catch { }

                            try
                            {
                                entrydatapost.fullName = data.user.full_name;
                            }
                            catch { }

                            try
                            {
                                entrydatapost.profile_pic_url = data.user.profile_pic_url;
                            }
                            catch { }

                            try
                            {
                                entrydatapost.imagePost = data.carousel_media[0].image_versions2.candidates[0].url;
                            }
                            catch { }

                            #region bắn lên kafa
                            //Bắn Post lên kafa
                            //Khai báo class bắn lên kafa
                            kafaPostINSDTO entdatakafapost = new kafaPostINSDTO();
                            entdatakafapost.Id = entrydatapost.post_id;
                            entdatakafapost.Message = entrydatapost.content;
                            entdatakafapost.ShortCode = entrydatapost.shortcode;
                            entdatakafapost.Link = entrydatapost.link;
                            entdatakafapost.TotalComment = entrydatapost.total_comment;
                            entdatakafapost.TotalLike = entrydatapost.total_like;
                            entdatakafapost.TotalShare = entrydatapost.total_share;
                            entdatakafapost.TotalReaction = 0;
                            entdatakafapost.ImagePost = entrydatapost.imagePost;
                            entdatakafapost.Platform = entrydatapost.platform;
                            entdatakafapost.CreateTime = entrydatapost.creat_time;
                            entdatakafapost.TimeCrw = DateTime.Now;
                            entdatakafapost.TmpTime = data.device_timestamp;
                            entdatakafapost.UserId = entrydatapost.idUser;
                            entdatakafapost.Username = entrydatapost.nameUser;
                            entdatakafapost.ImageUser = entrydatapost.profile_pic_url;
                            entdatakafapost.Platform = "instagram";

                         await  SaveKafraPost(entdatakafapost);
                        }
                    }

                }
                else
                {
                    //lỗi source ko lấy đc data update trạng thái source = -1
                }
                try
                {
                    //Bóc comment 
                    string url = "https://www.instagram.com/graphql/query/?query_hash=33ba35852cb50da46f5b5e889df7d159&variables=%7B%22shortcode%22:%22" + shortcode.Trim() + "%22,%22first%22:100,%22after%22:%22%22%7D";
                    browser.Load(url);
                    Thread.Sleep(5000);
                    string sourceCmt = GetSourceFromBrowser();
                    //xóa cặp thẻ không cần thiết để trở về định dạng chuẩn json
                    sourceCmt = Regex.Replace(sourceCmt, "(<html)(.*?)(pre-wrap;\">)", " ", RegexOptions.IgnoreCase); // xóa cặp thẻ
                    sourceCmt = Regex.Replace(sourceCmt, "</pre></body></html>", "", RegexOptions.IgnoreCase);

                    #region
                    //phân tích ra json xong lưu vào db
                    var ObjRootCmt = JsonConvert.DeserializeObject<INSJsonComment_Post.Root>(sourceCmt);
                    if (ObjRootCmt != null)
                    {
                        if (ObjRootCmt.data != null)
                        {
                            foreach (var data in ObjRootCmt.data.shortcode_media.edge_media_to_comment.edges)
                            {
                                kafaCommentINSDTO entrydataCmt = new kafaCommentINSDTO();
                                //entrydataCmt.Id = data.node.id;
                                entrydataCmt.CommentId = data.node.id;
                                entrydataCmt.CommentText = data.node.text;
                                entrydataCmt.PostId = _strPostId;
                                entrydataCmt.Url = "https://www.instagram.com/p/" + shortcode;
                                entrydataCmt.ShortCode = shortcode;
                                entrydataCmt.OwnerId = data.node.owner.id;
                                entrydataCmt.OwnerUser = data.node.owner.username;
                                entrydataCmt.OwnerProfilePicUrl = data.node.owner.profile_pic_url;
                                entrydataCmt.CreateTime = UnixTimeStampToDateTime(data.node.created_at);
                                entrydataCmt.CmtTimeDate = data.node.created_at;
                                entrydataCmt.TimeCrw = DateTime.Now;

                                //Bắn Post lên kafa
                                await SaveKafraComment(entrydataCmt);
                                //Không cần lưu comment mà bắn đi kafa luôn
                            }
                        }
                        string nextPage = ObjRootCmt.data.shortcode_media.edge_media_to_comment.page_info.end_cursor;
                        Boolean has_next_page = ObjRootCmt.data.shortcode_media.edge_media_to_comment.page_info.has_next_page;
                        if (has_next_page = true && !string.IsNullOrEmpty(nextPage))
                        {
                            endursor(shortcode, nextPage);
                        }
                    }
                    #endregion

                   
                }
                catch
                { }
                _flag = 2;
                #endregion

            }
            catch (Exception ex)
            {
            }
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
                            //entrydataCmt.Id = data.node.id;
                            entrydataCmt.CommentId = data.node.id;
                            entrydataCmt.CommentText = data.node.text;
                            entrydataCmt.PostId = _strPostId;
                            entrydataCmt.Url = "https://www.instagram.com/p/" + shortcode;
                            entrydataCmt.ShortCode = shortcode;
                            entrydataCmt.OwnerId = data.node.owner.id;
                            entrydataCmt.OwnerUser = data.node.owner.username;
                            entrydataCmt.OwnerProfilePicUrl = data.node.owner.profile_pic_url;
                            entrydataCmt.CreateTime = UnixTimeStampToDateTime(data.node.created_at);
                            entrydataCmt.CmtTimeDate = data.node.created_at;
                            entrydataCmt.TimeCrw = DateTime.Now;

                            //Bắn Post lên kafa
                            await SaveKafraComment(entrydataCmt);
                            //Không cần lưu comment mà bắn đi kafa luôn
                        }
                        //tìm phân trang
                        string UserId = shortcode;
                        Boolean has_next_page = ObjRoot.data.shortcode_media.edge_media_to_comment.page_info.has_next_page;
                        string nextPage = ObjRoot.data.shortcode_media.edge_media_to_comment.page_info.end_cursor;
                        if (has_next_page = true && !string.IsNullOrEmpty(nextPage))
                        {
                            endursor(UserId, nextPage);
                        }
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

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }

        private string GetSourceFromBrowser()
        {
            var task1 = browser.GetSourceAsync();
            task1.Wait();
            string source = task1.Result;
            return source;
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
                string a = "";
                string messagejson = postDTO.ToJson();
                // Bắn data cmt
                string intfag = await KafkaBll.PutOnKafkaPostINS(messagejson);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Lỗi phần SaveKafra" + ex);
            }
        }

        private async Task SaveKafraComment(kafaCommentINSDTO postDTO)
        {
            try
            {
                string messagejson = postDTO.ToJson();
                // Bắn data cmt
                string intfag = await KafkaBll.PutOnKafkaCmtINS(messagejson);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Lỗi phần SaveKafra" + ex);
            }
        }

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

    }
}
