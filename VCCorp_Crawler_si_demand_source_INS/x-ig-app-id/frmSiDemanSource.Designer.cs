namespace VCCorp_Crawler_si_demand_source_INS.x_ig_app_id
{
    partial class frmSiDemanSource
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSiDemanSource));
            this.btCheckCookie = new VCCorp_Crawler_si_demand_source_INS.ext.Control.RButton();
            this.btStartCrawl = new VCCorp_Crawler_si_demand_source_INS.ext.Control.RButton();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.pnResult = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSuccess = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblErr = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btCheckCookie
            // 
            this.btCheckCookie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(165)))), ((int)(((byte)(157)))));
            this.btCheckCookie.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(165)))), ((int)(((byte)(157)))));
            this.btCheckCookie.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btCheckCookie.BorderRadius = 10;
            this.btCheckCookie.BorderSize = 0;
            this.btCheckCookie.FlatAppearance.BorderSize = 0;
            this.btCheckCookie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCheckCookie.ForeColor = System.Drawing.Color.White;
            this.btCheckCookie.Location = new System.Drawing.Point(637, 13);
            this.btCheckCookie.Name = "btCheckCookie";
            this.btCheckCookie.Size = new System.Drawing.Size(130, 35);
            this.btCheckCookie.TabIndex = 0;
            this.btCheckCookie.Text = "CheckCookie";
            this.btCheckCookie.TextColor = System.Drawing.Color.White;
            this.btCheckCookie.UseVisualStyleBackColor = false;
            this.btCheckCookie.Click += new System.EventHandler(this.btCheckCookie_Click);
            // 
            // btStartCrawl
            // 
            this.btStartCrawl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(132)))), ((int)(((byte)(130)))));
            this.btStartCrawl.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(132)))), ((int)(((byte)(130)))));
            this.btStartCrawl.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btStartCrawl.BorderRadius = 10;
            this.btStartCrawl.BorderSize = 0;
            this.btStartCrawl.FlatAppearance.BorderSize = 0;
            this.btStartCrawl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btStartCrawl.ForeColor = System.Drawing.Color.White;
            this.btStartCrawl.Location = new System.Drawing.Point(773, 13);
            this.btStartCrawl.Name = "btStartCrawl";
            this.btStartCrawl.Size = new System.Drawing.Size(130, 35);
            this.btStartCrawl.TabIndex = 0;
            this.btStartCrawl.Text = "Bắt đầu";
            this.btStartCrawl.TextColor = System.Drawing.Color.White;
            this.btStartCrawl.UseVisualStyleBackColor = false;
            this.btStartCrawl.Click += new System.EventHandler(this.btStartCrawl_ClickAsync);
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(22, 20);
            this.txtUrl.Multiline = true;
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(609, 28);
            this.txtUrl.TabIndex = 1;
            // 
            // pnResult
            // 
            this.pnResult.Location = new System.Drawing.Point(22, 84);
            this.pnResult.Name = "pnResult";
            this.pnResult.Size = new System.Drawing.Size(881, 365);
            this.pnResult.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Số bài viết lấy thành công";
            // 
            // lblSuccess
            // 
            this.lblSuccess.AutoSize = true;
            this.lblSuccess.ForeColor = System.Drawing.Color.Red;
            this.lblSuccess.Location = new System.Drawing.Point(157, 58);
            this.lblSuccess.Name = "lblSuccess";
            this.lblSuccess.Size = new System.Drawing.Size(13, 13);
            this.lblSuccess.TabIndex = 4;
            this.lblSuccess.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Số bài viết lấy thất bại";
            // 
            // lblErr
            // 
            this.lblErr.AutoSize = true;
            this.lblErr.ForeColor = System.Drawing.Color.Red;
            this.lblErr.Location = new System.Drawing.Point(305, 58);
            this.lblErr.Name = "lblErr";
            this.lblErr.Size = new System.Drawing.Size(13, 13);
            this.lblErr.TabIndex = 4;
            this.lblErr.Text = "0";
            // 
            // frmSiDemanSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 461);
            this.Controls.Add(this.lblErr);
            this.Controls.Add(this.lblSuccess);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnResult);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.btStartCrawl);
            this.Controls.Add(this.btCheckCookie);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSiDemanSource";
            this.Text = "Bóc post theo url của si_deman_source";
            this.Load += new System.EventHandler(this.frmSiDemanSource_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ext.Control.RButton btCheckCookie;
        private ext.Control.RButton btStartCrawl;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Panel pnResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSuccess;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblErr;
    }
}