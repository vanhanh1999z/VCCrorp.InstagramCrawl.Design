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
            this.rtbResult = new System.Windows.Forms.RichTextBox();
            this.btShowDevTool = new VCCorp_Crawler_si_demand_source_INS.ext.Control.RButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCurr = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btCheckCookie
            // 
            this.btCheckCookie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(67)))), ((int)(((byte)(50)))));
            this.btCheckCookie.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(67)))), ((int)(((byte)(50)))));
            this.btCheckCookie.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btCheckCookie.BorderRadius = 4;
            this.btCheckCookie.BorderSize = 0;
            this.btCheckCookie.FlatAppearance.BorderSize = 0;
            this.btCheckCookie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCheckCookie.ForeColor = System.Drawing.Color.White;
            this.btCheckCookie.Location = new System.Drawing.Point(908, 15);
            this.btCheckCookie.Name = "btCheckCookie";
            this.btCheckCookie.Size = new System.Drawing.Size(95, 35);
            this.btCheckCookie.TabIndex = 0;
            this.btCheckCookie.Text = "CheckCookie";
            this.btCheckCookie.TextColor = System.Drawing.Color.White;
            this.btCheckCookie.UseVisualStyleBackColor = false;
            this.btCheckCookie.Click += new System.EventHandler(this.btCheckCookie_Click);
            // 
            // btStartCrawl
            // 
            this.btStartCrawl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(97)))), ((int)(((byte)(238)))));
            this.btStartCrawl.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(97)))), ((int)(((byte)(238)))));
            this.btStartCrawl.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btStartCrawl.BorderRadius = 4;
            this.btStartCrawl.BorderSize = 0;
            this.btStartCrawl.FlatAppearance.BorderSize = 0;
            this.btStartCrawl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btStartCrawl.ForeColor = System.Drawing.Color.White;
            this.btStartCrawl.Location = new System.Drawing.Point(1009, 15);
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
            this.txtUrl.Enabled = false;
            this.txtUrl.Location = new System.Drawing.Point(22, 20);
            this.txtUrl.Multiline = true;
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(734, 28);
            this.txtUrl.TabIndex = 1;
            // 
            // pnResult
            // 
            this.pnResult.Location = new System.Drawing.Point(22, 84);
            this.pnResult.Name = "pnResult";
            this.pnResult.Size = new System.Drawing.Size(734, 454);
            this.pnResult.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(184, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Số bài viết lấy thành công:";
            // 
            // lblSuccess
            // 
            this.lblSuccess.AutoSize = true;
            this.lblSuccess.ForeColor = System.Drawing.Color.Red;
            this.lblSuccess.Location = new System.Drawing.Point(320, 60);
            this.lblSuccess.Name = "lblSuccess";
            this.lblSuccess.Size = new System.Drawing.Size(13, 13);
            this.lblSuccess.TabIndex = 4;
            this.lblSuccess.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(351, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Số bài viết lấy thất bại:";
            // 
            // lblErr
            // 
            this.lblErr.AutoSize = true;
            this.lblErr.ForeColor = System.Drawing.Color.Red;
            this.lblErr.Location = new System.Drawing.Point(468, 60);
            this.lblErr.Name = "lblErr";
            this.lblErr.Size = new System.Drawing.Size(13, 13);
            this.lblErr.TabIndex = 4;
            this.lblErr.Text = "0";
            // 
            // rtbResult
            // 
            this.rtbResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbResult.Location = new System.Drawing.Point(773, 84);
            this.rtbResult.Name = "rtbResult";
            this.rtbResult.Size = new System.Drawing.Size(366, 454);
            this.rtbResult.TabIndex = 5;
            this.rtbResult.Text = "";
            // 
            // btShowDevTool
            // 
            this.btShowDevTool.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(163)))), ((int)(((byte)(17)))));
            this.btShowDevTool.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(163)))), ((int)(((byte)(17)))));
            this.btShowDevTool.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btShowDevTool.BorderRadius = 4;
            this.btShowDevTool.BorderSize = 0;
            this.btShowDevTool.FlatAppearance.BorderSize = 0;
            this.btShowDevTool.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btShowDevTool.ForeColor = System.Drawing.Color.White;
            this.btShowDevTool.Location = new System.Drawing.Point(773, 15);
            this.btShowDevTool.Name = "btShowDevTool";
            this.btShowDevTool.Size = new System.Drawing.Size(129, 35);
            this.btShowDevTool.TabIndex = 0;
            this.btShowDevTool.Text = "Show DevTool";
            this.btShowDevTool.TextColor = System.Drawing.Color.White;
            this.btShowDevTool.UseVisualStyleBackColor = false;
            this.btShowDevTool.Click += new System.EventHandler(this.btShowDevTool_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 544);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1151, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // stStatus
            // 
            this.stStatus.Name = "stStatus";
            this.stStatus.Size = new System.Drawing.Size(74, 17);
            this.stStatus.Text = "Trạng thái: ...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tổng số: ";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.ForeColor = System.Drawing.Color.Red;
            this.lblTotal.Location = new System.Drawing.Point(73, 60);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(13, 13);
            this.lblTotal.TabIndex = 8;
            this.lblTotal.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(101, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Hiện tại:";
            // 
            // lblCurr
            // 
            this.lblCurr.AutoSize = true;
            this.lblCurr.ForeColor = System.Drawing.Color.Red;
            this.lblCurr.Location = new System.Drawing.Point(152, 60);
            this.lblCurr.Name = "lblCurr";
            this.lblCurr.Size = new System.Drawing.Size(13, 13);
            this.lblCurr.TabIndex = 8;
            this.lblCurr.Text = "0";
            // 
            // frmSiDemanSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 566);
            this.Controls.Add(this.lblCurr);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.rtbResult);
            this.Controls.Add(this.lblErr);
            this.Controls.Add(this.lblSuccess);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnResult);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.btStartCrawl);
            this.Controls.Add(this.btShowDevTool);
            this.Controls.Add(this.btCheckCookie);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSiDemanSource";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bóc post theo url của si_deman_source";
            this.Load += new System.EventHandler(this.frmSiDemanSource_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
        private System.Windows.Forms.RichTextBox rtbResult;
        private ext.Control.RButton btShowDevTool;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel stStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCurr;
    }
}