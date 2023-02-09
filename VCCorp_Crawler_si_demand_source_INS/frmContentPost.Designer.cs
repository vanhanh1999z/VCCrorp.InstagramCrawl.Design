namespace VCCorp_Crawler_si_demand_source_INS
{
    partial class frmContentPost
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmContentPost));
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.btCheckCookie = new VCCorp_Crawler_si_demand_source_INS.ext.Control.RButton();
            this.btStart = new VCCorp_Crawler_si_demand_source_INS.ext.Control.RButton();
            this.lblUrl = new System.Windows.Forms.Label();
            this.pnView = new System.Windows.Forms.Panel();
            this.lblCountFile = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.stsTimer = new System.Windows.Forms.StatusStrip();
            this.tsStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.stsTimer.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(33, 12);
            this.txtUrl.Multiline = true;
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(500, 31);
            this.txtUrl.TabIndex = 0;
            // 
            // btCheckCookie
            // 
            this.btCheckCookie.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btCheckCookie.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btCheckCookie.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btCheckCookie.BorderRadius = 3;
            this.btCheckCookie.BorderSize = 0;
            this.btCheckCookie.FlatAppearance.BorderSize = 0;
            this.btCheckCookie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCheckCookie.ForeColor = System.Drawing.Color.White;
            this.btCheckCookie.Location = new System.Drawing.Point(549, 12);
            this.btCheckCookie.Name = "btCheckCookie";
            this.btCheckCookie.Size = new System.Drawing.Size(109, 31);
            this.btCheckCookie.TabIndex = 2;
            this.btCheckCookie.Text = "Check Cookie";
            this.btCheckCookie.TextColor = System.Drawing.Color.White;
            this.btCheckCookie.UseVisualStyleBackColor = false;
            this.btCheckCookie.Click += new System.EventHandler(this.btCheckCookie_Click);
            // 
            // btStart
            // 
            this.btStart.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btStart.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btStart.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btStart.BorderRadius = 3;
            this.btStart.BorderSize = 0;
            this.btStart.FlatAppearance.BorderSize = 0;
            this.btStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btStart.ForeColor = System.Drawing.Color.White;
            this.btStart.Location = new System.Drawing.Point(669, 12);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(109, 31);
            this.btStart.TabIndex = 2;
            this.btStart.Text = "Bắt đầu crwal";
            this.btStart.TextColor = System.Drawing.Color.White;
            this.btStart.UseVisualStyleBackColor = false;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(4, 21);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(23, 13);
            this.lblUrl.TabIndex = 3;
            this.lblUrl.Text = "Url:";
            // 
            // pnView
            // 
            this.pnView.Location = new System.Drawing.Point(12, 77);
            this.pnView.Name = "pnView";
            this.pnView.Size = new System.Drawing.Size(781, 479);
            this.pnView.TabIndex = 5;
            // 
            // lblCountFile
            // 
            this.lblCountFile.AutoSize = true;
            this.lblCountFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCountFile.Location = new System.Drawing.Point(85, 50);
            this.lblCountFile.Name = "lblCountFile";
            this.lblCountFile.Size = new System.Drawing.Size(13, 13);
            this.lblCountFile.TabIndex = 6;
            this.lblCountFile.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Số file đã tải";
            // 
            // stsTimer
            // 
            this.stsTimer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStatus});
            this.stsTimer.Location = new System.Drawing.Point(0, 562);
            this.stsTimer.Name = "stsTimer";
            this.stsTimer.Size = new System.Drawing.Size(800, 22);
            this.stsTimer.TabIndex = 8;
            this.stsTimer.Text = "statusStrip1";
            // 
            // tsStatus
            // 
            this.tsStatus.Name = "tsStatus";
            this.tsStatus.Size = new System.Drawing.Size(62, 17);
            this.tsStatus.Text = "Trạng thái:";
            // 
            // frmContentPost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 584);
            this.Controls.Add(this.stsTimer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCountFile);
            this.Controls.Add(this.pnView);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.btCheckCookie);
            this.Controls.Add(this.txtUrl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmContentPost";
            this.Text = "Bóc content User";
            this.Load += new System.EventHandler(this.frmContentPost_Load);
            this.stsTimer.ResumeLayout(false);
            this.stsTimer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUrl;
        private ext.Control.RButton btCheckCookie;
        private ext.Control.RButton btStart;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.Panel pnView;
        private System.Windows.Forms.Label lblCountFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip stsTimer;
        private System.Windows.Forms.ToolStripStatusLabel tsStatus;
    }
}