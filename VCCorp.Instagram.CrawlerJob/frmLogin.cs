using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using Crwal.Core.Log;
using VCCorp.CrawlerCore.Base;

namespace VCCorp.Instagram.CrawlerJob
{
    public partial class frmLogin : Form
    {
        private ChromiumWebBrowser _browser;

        public frmLogin()
        {
            InitializeComponent();
            if (IgRunTime.CachePath == null) IgRunTime.CachePath = "C:\\CEFSharp_CacheJOB";
            InitBrowser();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
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
                pnLogin.Controls.Add(_browser);
                _browser.Location = new Point(1, 70);
                _browser.MinimumSize = new Size(20, 20);
                _browser.Name = "webBrowser";
                _browser.Size = new Size(956, 827);
                _browser.TabIndex = 4;
            }
            catch (Exception ex)
            {
                Logging.Error(ex);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var frmExcel = new frmMain();
            var frmComment = new frmFbComment();


            frmExcel.FormClosed += FrmExcel_FormClosed;
            frmComment.FormClosed += FrmComment_FormClosed;

            frmExcel.Show();
            frmComment.Show();
            Hide();
        }


        private void FrmComment_FormClosed(object sender, FormClosedEventArgs e)
        {
            //var frmExcel = Application.OpenForms["frmMain"];
            //var frmComment = Application.OpenForms["frmFbComment"];
            //if (frmExcel == null && frmComment == null)
            //{
            //}
            Show();
        }

        private void FrmExcel_FormClosed(object sender, FormClosedEventArgs e)
        {
            //var frmExcel = Application.OpenForms["frmMain"];
            //var frmComment = Application.OpenForms["frmFbComment"];
            //if (frmExcel == null && frmComment == null)
            //{
            //}
            Show();
        }
    }
}