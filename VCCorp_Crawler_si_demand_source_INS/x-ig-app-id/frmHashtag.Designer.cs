namespace VCCorp_Crawler_si_demand_source_INS.x_ig_app_id
{
    partial class frmHashtag
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
            this.grChrome = new System.Windows.Forms.GroupBox();
            this.pnResult = new System.Windows.Forms.Panel();
            this.grResult = new System.Windows.Forms.GroupBox();
            this.rtbResult = new System.Windows.Forms.RichTextBox();
            this.grBtn = new System.Windows.Forms.GroupBox();
            this.grState = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblErr = new System.Windows.Forms.Label();
            this.lblSuccess = new System.Windows.Forms.Label();
            this.lblCurr = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timerStart = new System.Windows.Forms.Timer(this.components);
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.stStatus2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblQuery = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.btnStart = new VCCorp_Crawler_si_demand_source_INS.ext.Control.RButton();
            this.btnCheckCookir = new VCCorp_Crawler_si_demand_source_INS.ext.Control.RButton();
            this.btnShowDevtool = new VCCorp_Crawler_si_demand_source_INS.ext.Control.RButton();
            this.clHashtag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grChrome.SuspendLayout();
            this.grResult.SuspendLayout();
            this.grBtn.SuspendLayout();
            this.grState.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // grChrome
            // 
            this.grChrome.Controls.Add(this.pnResult);
            this.grChrome.Location = new System.Drawing.Point(197, 41);
            this.grChrome.Name = "grChrome";
            this.grChrome.Size = new System.Drawing.Size(875, 375);
            this.grChrome.TabIndex = 0;
            this.grChrome.TabStop = false;
            this.grChrome.Text = "Hashtag";
            // 
            // pnResult
            // 
            this.pnResult.Location = new System.Drawing.Point(7, 20);
            this.pnResult.Name = "pnResult";
            this.pnResult.Size = new System.Drawing.Size(862, 378);
            this.pnResult.TabIndex = 0;
            // 
            // grResult
            // 
            this.grResult.Controls.Add(this.rtbResult);
            this.grResult.Location = new System.Drawing.Point(197, 422);
            this.grResult.Name = "grResult";
            this.grResult.Size = new System.Drawing.Size(875, 188);
            this.grResult.TabIndex = 1;
            this.grResult.TabStop = false;
            this.grResult.Text = "Dữ liệu...";
            // 
            // rtbResult
            // 
            this.rtbResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbResult.Location = new System.Drawing.Point(7, 20);
            this.rtbResult.Name = "rtbResult";
            this.rtbResult.Size = new System.Drawing.Size(862, 162);
            this.rtbResult.TabIndex = 0;
            this.rtbResult.Text = "";
            // 
            // grBtn
            // 
            this.grBtn.Controls.Add(this.grState);
            this.grBtn.Controls.Add(this.btnStart);
            this.grBtn.Controls.Add(this.btnCheckCookir);
            this.grBtn.Controls.Add(this.btnShowDevtool);
            this.grBtn.Location = new System.Drawing.Point(13, 12);
            this.grBtn.Name = "grBtn";
            this.grBtn.Size = new System.Drawing.Size(178, 598);
            this.grBtn.TabIndex = 2;
            this.grBtn.TabStop = false;
            this.grBtn.Text = "Các chức năng";
            // 
            // grState
            // 
            this.grState.Controls.Add(this.statusStrip1);
            this.grState.Controls.Add(this.lblErr);
            this.grState.Controls.Add(this.lblSuccess);
            this.grState.Controls.Add(this.lblCurr);
            this.grState.Controls.Add(this.label5);
            this.grState.Controls.Add(this.label3);
            this.grState.Controls.Add(this.label2);
            this.grState.Controls.Add(this.lblTotal);
            this.grState.Controls.Add(this.label1);
            this.grState.Location = new System.Drawing.Point(7, 228);
            this.grState.Name = "grState";
            this.grState.Size = new System.Drawing.Size(165, 148);
            this.grState.TabIndex = 1;
            this.grState.TabStop = false;
            this.grState.Text = "Trạng thái:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stStatus});
            this.statusStrip1.Location = new System.Drawing.Point(3, 123);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(159, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // stStatus
            // 
            this.stStatus.Name = "stStatus";
            this.stStatus.Size = new System.Drawing.Size(74, 17);
            this.stStatus.Text = "Trạng thái: ...";
            // 
            // lblErr
            // 
            this.lblErr.AutoSize = true;
            this.lblErr.ForeColor = System.Drawing.Color.Red;
            this.lblErr.Location = new System.Drawing.Point(97, 93);
            this.lblErr.Name = "lblErr";
            this.lblErr.Size = new System.Drawing.Size(13, 13);
            this.lblErr.TabIndex = 0;
            this.lblErr.Text = "0";
            // 
            // lblSuccess
            // 
            this.lblSuccess.AutoSize = true;
            this.lblSuccess.ForeColor = System.Drawing.Color.Red;
            this.lblSuccess.Location = new System.Drawing.Point(97, 67);
            this.lblSuccess.Name = "lblSuccess";
            this.lblSuccess.Size = new System.Drawing.Size(13, 13);
            this.lblSuccess.TabIndex = 0;
            this.lblSuccess.Text = "0";
            // 
            // lblCurr
            // 
            this.lblCurr.AutoSize = true;
            this.lblCurr.ForeColor = System.Drawing.Color.Red;
            this.lblCurr.Location = new System.Drawing.Point(62, 46);
            this.lblCurr.Name = "lblCurr";
            this.lblCurr.Size = new System.Drawing.Size(13, 13);
            this.lblCurr.TabIndex = 0;
            this.lblCurr.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Lấy thất bại:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Lấy thành công:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Hiện tại:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.ForeColor = System.Drawing.Color.Red;
            this.lblTotal.Location = new System.Drawing.Point(62, 24);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(13, 13);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tổng số:";
            // 
            // timerStart
            // 
            this.timerStart.Interval = 1000;
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stStatus2});
            this.statusStrip2.Location = new System.Drawing.Point(0, 618);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(1351, 22);
            this.statusStrip2.TabIndex = 3;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // stStatus2
            // 
            this.stStatus2.Name = "stStatus2";
            this.stStatus2.Size = new System.Drawing.Size(74, 17);
            this.stStatus2.Text = "Trạng thái: ...";
            // 
            // lblQuery
            // 
            this.lblQuery.Location = new System.Drawing.Point(272, 15);
            this.lblQuery.Name = "lblQuery";
            this.lblQuery.Size = new System.Drawing.Size(794, 20);
            this.lblQuery.TabIndex = 4;
            this.lblQuery.TextChanged += new System.EventHandler(this.lblQuery_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(211, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Query";
            // 
            // dgvMain
            // 
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clHashtag,
            this.clId});
            this.dgvMain.Location = new System.Drawing.Point(1079, 18);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.Size = new System.Drawing.Size(260, 592);
            this.dgvMain.TabIndex = 6;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(92)))));
            this.btnStart.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(92)))));
            this.btnStart.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnStart.BorderRadius = 5;
            this.btnStart.BorderSize = 0;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(13, 154);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(150, 40);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Bắt đầu";
            this.btnStart.TextColor = System.Drawing.Color.White;
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnCheckCookir
            // 
            this.btnCheckCookir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(216)))));
            this.btnCheckCookir.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(216)))));
            this.btnCheckCookir.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnCheckCookir.BorderRadius = 5;
            this.btnCheckCookir.BorderSize = 0;
            this.btnCheckCookir.FlatAppearance.BorderSize = 0;
            this.btnCheckCookir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckCookir.ForeColor = System.Drawing.Color.White;
            this.btnCheckCookir.Location = new System.Drawing.Point(13, 108);
            this.btnCheckCookir.Name = "btnCheckCookir";
            this.btnCheckCookir.Size = new System.Drawing.Size(150, 40);
            this.btnCheckCookir.TabIndex = 0;
            this.btnCheckCookir.Text = "Check Cookie";
            this.btnCheckCookir.TextColor = System.Drawing.Color.White;
            this.btnCheckCookir.UseVisualStyleBackColor = false;
            this.btnCheckCookir.Click += new System.EventHandler(this.btnCheckCookir_Click);
            // 
            // btnShowDevtool
            // 
            this.btnShowDevtool.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(119)))), ((int)(((byte)(182)))));
            this.btnShowDevtool.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(119)))), ((int)(((byte)(182)))));
            this.btnShowDevtool.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnShowDevtool.BorderRadius = 5;
            this.btnShowDevtool.BorderSize = 0;
            this.btnShowDevtool.FlatAppearance.BorderSize = 0;
            this.btnShowDevtool.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowDevtool.ForeColor = System.Drawing.Color.White;
            this.btnShowDevtool.Location = new System.Drawing.Point(13, 62);
            this.btnShowDevtool.Name = "btnShowDevtool";
            this.btnShowDevtool.Size = new System.Drawing.Size(150, 40);
            this.btnShowDevtool.TabIndex = 0;
            this.btnShowDevtool.Text = "Show DevTool";
            this.btnShowDevtool.TextColor = System.Drawing.Color.White;
            this.btnShowDevtool.UseVisualStyleBackColor = false;
            this.btnShowDevtool.Click += new System.EventHandler(this.btnShowDevtool_Click);
            // 
            // clHashtag
            // 
            this.clHashtag.DataPropertyName = "hashtag";
            this.clHashtag.HeaderText = "Hastag";
            this.clHashtag.Name = "clHashtag";
            // 
            // clId
            // 
            this.clId.DataPropertyName = "id";
            this.clId.HeaderText = "Id";
            this.clId.Name = "clId";
            // 
            // frmHashtag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1351, 640);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblQuery);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.grBtn);
            this.Controls.Add(this.grResult);
            this.Controls.Add(this.grChrome);
            this.Name = "frmHashtag";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmHashtag";
            this.Load += new System.EventHandler(this.frmHashtag_Load);
            this.grChrome.ResumeLayout(false);
            this.grResult.ResumeLayout(false);
            this.grBtn.ResumeLayout(false);
            this.grState.ResumeLayout(false);
            this.grState.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grChrome;
        private System.Windows.Forms.GroupBox grResult;
        private System.Windows.Forms.RichTextBox rtbResult;
        private System.Windows.Forms.GroupBox grBtn;
        private ext.Control.RButton btnStart;
        private ext.Control.RButton btnCheckCookir;
        private ext.Control.RButton btnShowDevtool;
        private System.Windows.Forms.GroupBox grState;
        private System.Windows.Forms.Label lblErr;
        private System.Windows.Forms.Label lblSuccess;
        private System.Windows.Forms.Label lblCurr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnResult;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel stStatus;
        private System.Windows.Forms.Timer timerStart;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel stStatus2;
        private System.Windows.Forms.TextBox lblQuery;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn clHashtag;
        private System.Windows.Forms.DataGridViewTextBoxColumn clId;
    }
}