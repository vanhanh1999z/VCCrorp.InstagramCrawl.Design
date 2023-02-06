namespace VCCorp_Crawler_si_demand_source_INS
{
    partial class frmSourcesdemainNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSourcesdemainNew));
            this.timerStart = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbToolStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupLeft = new System.Windows.Forms.GroupBox();
            this.lblSourcErr = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbSaveSuccess = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbLinkIndexCurr = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbTotalLink = new System.Windows.Forms.Label();
            this.btPause = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btLoad = new System.Windows.Forms.Button();
            this.btStart = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.groupLeft.SuspendLayout();
            this.SuspendLayout();
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
            this.statusStrip1.Location = new System.Drawing.Point(3, 424);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(941, 22);
            this.statusStrip1.TabIndex = 285;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbToolStripStatus
            // 
            this.lbToolStripStatus.Name = "lbToolStripStatus";
            this.lbToolStripStatus.Size = new System.Drawing.Size(39, 17);
            this.lbToolStripStatus.Text = "Status";
            // 
            // groupLeft
            // 
            this.groupLeft.Controls.Add(this.statusStrip1);
            this.groupLeft.Location = new System.Drawing.Point(13, 62);
            this.groupLeft.Name = "groupLeft";
            this.groupLeft.Size = new System.Drawing.Size(947, 449);
            this.groupLeft.TabIndex = 313;
            this.groupLeft.TabStop = false;
            // 
            // lblSourcErr
            // 
            this.lblSourcErr.AutoSize = true;
            this.lblSourcErr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSourcErr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(35)))), ((int)(((byte)(60)))));
            this.lblSourcErr.Location = new System.Drawing.Point(721, 46);
            this.lblSourcErr.Name = "lblSourcErr";
            this.lblSourcErr.Size = new System.Drawing.Size(13, 13);
            this.lblSourcErr.TabIndex = 312;
            this.lblSourcErr.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(609, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 311;
            this.label2.Text = "Source lỗi ko bóc đc:";
            // 
            // lbSaveSuccess
            // 
            this.lbSaveSuccess.AutoSize = true;
            this.lbSaveSuccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSaveSuccess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(35)))), ((int)(((byte)(60)))));
            this.lbSaveSuccess.Location = new System.Drawing.Point(550, 46);
            this.lbSaveSuccess.Name = "lbSaveSuccess";
            this.lbSaveSuccess.Size = new System.Drawing.Size(13, 13);
            this.lbSaveSuccess.TabIndex = 310;
            this.lbSaveSuccess.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(425, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 13);
            this.label4.TabIndex = 309;
            this.label4.Text = "Đã bóc và lưu vào DB:";
            // 
            // lbLinkIndexCurr
            // 
            this.lbLinkIndexCurr.AutoSize = true;
            this.lbLinkIndexCurr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLinkIndexCurr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(35)))), ((int)(((byte)(60)))));
            this.lbLinkIndexCurr.Location = new System.Drawing.Point(344, 46);
            this.lbLinkIndexCurr.Name = "lbLinkIndexCurr";
            this.lbLinkIndexCurr.Size = new System.Drawing.Size(13, 13);
            this.lbLinkIndexCurr.TabIndex = 308;
            this.lbLinkIndexCurr.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(246, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 307;
            this.label7.Text = "Đang bóc đến link:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(41, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 13);
            this.label8.TabIndex = 306;
            this.label8.Text = "Tổng số link bóc post:";
            // 
            // lbTotalLink
            // 
            this.lbTotalLink.AutoSize = true;
            this.lbTotalLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalLink.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(35)))), ((int)(((byte)(60)))));
            this.lbTotalLink.Location = new System.Drawing.Point(159, 46);
            this.lbTotalLink.Name = "lbTotalLink";
            this.lbTotalLink.Size = new System.Drawing.Size(13, 13);
            this.lbTotalLink.TabIndex = 305;
            this.lbTotalLink.Text = "0";
            // 
            // btPause
            // 
            this.btPause.Location = new System.Drawing.Point(730, 10);
            this.btPause.Name = "btPause";
            this.btPause.Size = new System.Drawing.Size(129, 26);
            this.btPause.TabIndex = 303;
            this.btPause.Text = "Tạm dừng Bóc tách";
            this.btPause.UseVisualStyleBackColor = true;
            this.btPause.Click += new System.EventHandler(this.btPause_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 302;
            this.label3.Text = "Url:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(39, 14);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(621, 20);
            this.txtAddress.TabIndex = 300;
            // 
            // btLoad
            // 
            this.btLoad.Location = new System.Drawing.Point(666, 10);
            this.btLoad.Name = "btLoad";
            this.btLoad.Size = new System.Drawing.Size(63, 26);
            this.btLoad.TabIndex = 301;
            this.btLoad.Text = "Load";
            this.btLoad.UseVisualStyleBackColor = true;
            this.btLoad.Click += new System.EventHandler(this.btLoad_Click);
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(858, 10);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(102, 26);
            this.btStart.TabIndex = 304;
            this.btStart.Text = "Bóc tách";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // frmSourcesdemainNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 521);
            this.Controls.Add(this.groupLeft);
            this.Controls.Add(this.lblSourcErr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbSaveSuccess);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbLinkIndexCurr);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbTotalLink);
            this.Controls.Add(this.btPause);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.btLoad);
            this.Controls.Add(this.btStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSourcesdemainNew";
            this.Text = "frmSourcesdemainNew";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupLeft.ResumeLayout(false);
            this.groupLeft.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerStart;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbToolStripStatus;
        private System.Windows.Forms.GroupBox groupLeft;
        private System.Windows.Forms.Label lblSourcErr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbSaveSuccess;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbLinkIndexCurr;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbTotalLink;
        private System.Windows.Forms.Button btPause;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btLoad;
        private System.Windows.Forms.Button btStart;
    }
}