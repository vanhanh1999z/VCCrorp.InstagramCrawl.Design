using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace VCCorp_Crawler_si_demand_source_INS
{
    public partial class loginINS : Form
    {
        private int _loading;
        public ChromiumWebBrowser browser;

        public loginINS()
        {
            InitializeComponent();
            InitBrowser();
        }

        public void InitBrowser()
        {
            try
            {
                if (!Cef.IsInitialized)
                {
                    var pathCache = @"C:\CEFSharp_Cache";
                    if (!Directory.Exists(pathCache)) Directory.CreateDirectory(pathCache);

                    var settings = new CefSettings();
                    settings.CachePath = pathCache;
                    settings.LogSeverity = LogSeverity.Disable;

                    Cef.Initialize(settings);
                }

                //Cef.Initialize(new CefSettings());

                _loading = 0;

                browser = new ChromiumWebBrowser(txtAddress.Text);

                Controls.Add(browser);

                browser.Location = new Point(1, 70);
                browser.MinimumSize = new Size(20, 20);
                browser.Name = "webBrowser";
                browser.Size = new Size(956, 827);
                browser.TabIndex = 4;
                groupLeft.Controls.Add(browser);
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
            if (!args.IsLoading) _loading = 1;
        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            _loading = 0;
            browser.Load(txtAddress.Text);
        }

        private void loginINS_Load(object sender, EventArgs e)
        {
        }
    }
}