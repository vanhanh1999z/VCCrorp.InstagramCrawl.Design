using CefSharp.WinForms;
using CefSharp;
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
using System.Threading;

namespace VCCorp_Crawler_si_demand_source_INS
{


    public partial class frmMain : Form
    {
        private int _loading;
        public ChromiumWebBrowser browser;
        public frmMain()
        {
            InitializeComponent();
            InitBrowser();
        }

        private async void frmMain_LoadAsync(object sender, EventArgs e)
        {
            this.SetEnableMainGroupBox(false);
            await Task.Delay(3_000);
            this.SetEnableMainGroupBox(true);
        }

        private void SetEnableMainGroupBox(bool enable)
        {
            grSiDemand.Enabled = enable;
            grSiDataExcel.Enabled = enable;
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

                browser = new ChromiumWebBrowser("https://www.instagram.com/");

                this.Controls.Add(browser);

                this.browser.Location = new System.Drawing.Point(1, 70);
                this.browser.MinimumSize = new System.Drawing.Size(20, 20);
                this.browser.Name = "webBrowser";
                this.browser.Size = new System.Drawing.Size(956, 827);
                this.browser.TabIndex = 4;
                this.pnLogin.Controls.Add(this.browser);
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

        private void btPostINS_Click(object sender, EventArgs e)
        {
            frmSourcedemaind_INS fr = new frmSourcedemaind_INS();
            fr.Show();
        }

        private void btCmtINS_Click(object sender, EventArgs e)
        {
            frmPostdemandsource_INS fr = new frmPostdemandsource_INS();
            fr.Show();
        }

        private void btSourcStatus0_Click(object sender, EventArgs e)
        {
            frmSourcesdemainNew fr = new frmSourcesdemainNew();
            fr.Show();
        }

        private void btFindsourceID_Click(object sender, EventArgs e)
        {
            frmFindlSourceID_INS fr = new frmFindlSourceID_INS();
            fr.Show();
        }

        private void btCrwSidataExcel_Click(object sender, EventArgs e)
        {
            frmCrwSi_data_ExcelPost fr = new frmCrwSi_data_ExcelPost();
            fr.Show();
        }

        private void btINS_Click(object sender, EventArgs e)
        {
            frmOneINS fr = new frmOneINS();
            fr.Show();
        }
    }
}
