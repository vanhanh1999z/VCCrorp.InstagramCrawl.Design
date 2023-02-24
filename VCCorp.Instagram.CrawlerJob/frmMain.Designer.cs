namespace VCCorp.Instagram.CrawlerJob
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnResult = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPost = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblComment = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblErr = new System.Windows.Forms.Label();
            this.ni = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnHide = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnResult
            // 
            this.pnResult.Location = new System.Drawing.Point(12, 28);
            this.pnResult.Name = "pnResult";
            this.pnResult.Size = new System.Drawing.Size(1438, 581);
            this.pnResult.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 628);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tổng số bài viết đã cào:";
            // 
            // lblPost
            // 
            this.lblPost.AutoSize = true;
            this.lblPost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPost.Location = new System.Drawing.Point(138, 628);
            this.lblPost.Name = "lblPost";
            this.lblPost.Size = new System.Drawing.Size(13, 13);
            this.lblPost.TabIndex = 2;
            this.lblPost.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(177, 628);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tổng số comment đã cào:";
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblComment.Location = new System.Drawing.Point(315, 628);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(13, 13);
            this.lblComment.TabIndex = 2;
            this.lblComment.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(364, 628);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Tổng số comment cào thất bại: ";
            // 
            // lblErr
            // 
            this.lblErr.AutoSize = true;
            this.lblErr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblErr.Location = new System.Drawing.Point(527, 628);
            this.lblErr.Name = "lblErr";
            this.lblErr.Size = new System.Drawing.Size(13, 13);
            this.lblErr.TabIndex = 2;
            this.lblErr.Text = "0";
            // 
            // ni
            // 
            this.ni.Icon = ((System.Drawing.Icon)(resources.GetObject("ni.Icon")));
            this.ni.Text = "fbExcel";
            this.ni.Visible = true;
            this.ni.DoubleClick += new System.EventHandler(this.ni_DoubleClick);
            // 
            // btnHide
            // 
            this.btnHide.Location = new System.Drawing.Point(578, 623);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(75, 23);
            this.btnHide.TabIndex = 3;
            this.btnHide.Text = "Hide";
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1462, 650);
            this.Controls.Add(this.btnHide);
            this.Controls.Add(this.lblErr);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.lblPost);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnResult);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmExcel";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeEnd += new System.EventHandler(this.frmMain_ResizeEnd);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPost;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblErr;
        private System.Windows.Forms.NotifyIcon ni;
        private System.Windows.Forms.Button btnHide;
    }
}

