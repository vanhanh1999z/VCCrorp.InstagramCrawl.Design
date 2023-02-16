namespace VCCorp_Crawler_si_demand_source_INS
{
    partial class frmFindlSourceID_INS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFindlSourceID_INS));
            this.groupLeft = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btLoad = new System.Windows.Forms.Button();
            this.timerStart = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbToolStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnTestSrcIDINS = new System.Windows.Forms.Button();
            this.lbSaveSuccess = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbLinkIndexCurr = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbTotalLink = new System.Windows.Forms.Label();
            this.btnsource = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupLeft
            // 
            this.groupLeft.Location = new System.Drawing.Point(7, 74);
            this.groupLeft.Name = "groupLeft";
            this.groupLeft.Size = new System.Drawing.Size(902, 518);
            this.groupLeft.TabIndex = 269;
            this.groupLeft.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 268;
            this.label3.Text = "Url:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(50, 21);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(618, 20);
            this.txtAddress.TabIndex = 266;
            this.txtAddress.Text = "https://www.google.com/";
            // 
            // btLoad
            // 
            this.btLoad.Location = new System.Drawing.Point(674, 18);
            this.btLoad.Name = "btLoad";
            this.btLoad.Size = new System.Drawing.Size(63, 26);
            this.btLoad.TabIndex = 267;
            this.btLoad.Text = "Load";
            this.btLoad.UseVisualStyleBackColor = true;
            this.btLoad.Click += new System.EventHandler(this.btLoad_Click);
            // 
            // timerStart
            // 
            this.timerStart.Interval = 1000;
            this.timerStart.Tick += new System.EventHandler(this.timerStart_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbToolStripStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 586);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(917, 22);
            this.statusStrip1.TabIndex = 286;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbToolStripStatus
            // 
            this.lbToolStripStatus.Name = "lbToolStripStatus";
            this.lbToolStripStatus.Size = new System.Drawing.Size(39, 17);
            this.lbToolStripStatus.Text = "Status";
            // 
            // btnTestSrcIDINS
            // 
            this.btnTestSrcIDINS.Location = new System.Drawing.Point(743, 18);
            this.btnTestSrcIDINS.Name = "btnTestSrcIDINS";
            this.btnTestSrcIDINS.Size = new System.Drawing.Size(160, 26);
            this.btnTestSrcIDINS.TabIndex = 287;
            this.btnTestSrcIDINS.Text = "Test lấy sourceID INS";
            this.btnTestSrcIDINS.UseVisualStyleBackColor = true;
            // 
            // lbSaveSuccess
            // 
            this.lbSaveSuccess.AutoSize = true;
            this.lbSaveSuccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSaveSuccess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(35)))), ((int)(((byte)(60)))));
            this.lbSaveSuccess.Location = new System.Drawing.Point(547, 58);
            this.lbSaveSuccess.Name = "lbSaveSuccess";
            this.lbSaveSuccess.Size = new System.Drawing.Size(13, 13);
            this.lbSaveSuccess.TabIndex = 302;
            this.lbSaveSuccess.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(431, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 13);
            this.label4.TabIndex = 301;
            this.label4.Text = "Đã bóc và lưu vào DB:";
            // 
            // lbLinkIndexCurr
            // 
            this.lbLinkIndexCurr.AutoSize = true;
            this.lbLinkIndexCurr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLinkIndexCurr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(35)))), ((int)(((byte)(60)))));
            this.lbLinkIndexCurr.Location = new System.Drawing.Point(349, 58);
            this.lbLinkIndexCurr.Name = "lbLinkIndexCurr";
            this.lbLinkIndexCurr.Size = new System.Drawing.Size(13, 13);
            this.lbLinkIndexCurr.TabIndex = 300;
            this.lbLinkIndexCurr.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(252, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 299;
            this.label7.Text = "Đang bóc đến link:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(47, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 13);
            this.label8.TabIndex = 298;
            this.label8.Text = "Tổng số link bóc post:";
            // 
            // lbTotalLink
            // 
            this.lbTotalLink.AutoSize = true;
            this.lbTotalLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalLink.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(35)))), ((int)(((byte)(60)))));
            this.lbTotalLink.Location = new System.Drawing.Point(160, 58);
            this.lbTotalLink.Name = "lbTotalLink";
            this.lbTotalLink.Size = new System.Drawing.Size(13, 13);
            this.lbTotalLink.TabIndex = 297;
            this.lbTotalLink.Text = "0";
            // 
            // btnsource
            // 
            this.btnsource.Location = new System.Drawing.Point(674, 51);
            this.btnsource.Name = "btnsource";
            this.btnsource.Size = new System.Drawing.Size(229, 26);
            this.btnsource.TabIndex = 303;
            this.btnsource.Text = "Getsourrce";
            this.btnsource.UseVisualStyleBackColor = true;
            this.btnsource.Click += new System.EventHandler(this.btnsource_Click);
            // 
            // frmFindlSourceID_INS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 608);
            this.Controls.Add(this.btnsource);
            this.Controls.Add(this.lbSaveSuccess);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbLinkIndexCurr);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbTotalLink);
            this.Controls.Add(this.btnTestSrcIDINS);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupLeft);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.btLoad);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFindlSourceID_INS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmFindlSourceID_INS";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupLeft;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btLoad;
        private System.Windows.Forms.Timer timerStart;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbToolStripStatus;
        private System.Windows.Forms.Button btnTestSrcIDINS;
        private System.Windows.Forms.Label lbSaveSuccess;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbLinkIndexCurr;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbTotalLink;
        private System.Windows.Forms.Button btnsource;
    }
}