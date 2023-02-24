namespace VCCorp.Instagram.CrawlerJob
{
    partial class frmFbComment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFbComment));
            this.pnResult = new System.Windows.Forms.Panel();
            this.ni = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnHide = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnResult
            // 
            this.pnResult.Location = new System.Drawing.Point(13, 13);
            this.pnResult.Name = "pnResult";
            this.pnResult.Size = new System.Drawing.Size(1169, 616);
            this.pnResult.TabIndex = 0;
            // 
            // ni
            // 
            this.ni.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ni.Icon = ((System.Drawing.Icon)(resources.GetObject("ni.Icon")));
            this.ni.Text = "notifyIcon1";
            this.ni.Visible = true;
            this.ni.DoubleClick += new System.EventHandler(this.ni_DoubleClick);
            // 
            // btnHide
            // 
            this.btnHide.Location = new System.Drawing.Point(13, 635);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(75, 23);
            this.btnHide.TabIndex = 1;
            this.btnHide.Text = "Hide";
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // frmFbComment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 662);
            this.Controls.Add(this.btnHide);
            this.Controls.Add(this.pnResult);
            this.Name = "frmFbComment";
            this.Text = "frmFbComment";
            this.Load += new System.EventHandler(this.frmFbComment_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnResult;
        private System.Windows.Forms.NotifyIcon ni;
        private System.Windows.Forms.Button btnHide;
    }
}