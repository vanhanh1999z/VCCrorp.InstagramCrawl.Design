namespace VCCorp_Crawler_si_demand_source_INS
{
    partial class frmOneINS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOneINS));
            this.groupLeft = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbToolStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btLoad = new System.Windows.Forms.Button();
            this.btStart = new System.Windows.Forms.Button();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.groupLeft.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupLeft
            // 
            this.groupLeft.Controls.Add(this.statusStrip1);
            this.groupLeft.Location = new System.Drawing.Point(32, 64);
            this.groupLeft.Name = "groupLeft";
            this.groupLeft.Size = new System.Drawing.Size(824, 456);
            this.groupLeft.TabIndex = 327;
            this.groupLeft.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbToolStripStatus});
            this.statusStrip1.Location = new System.Drawing.Point(3, 431);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(818, 22);
            this.statusStrip1.TabIndex = 285;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbToolStripStatus
            // 
            this.lbToolStripStatus.Name = "lbToolStripStatus";
            this.lbToolStripStatus.Size = new System.Drawing.Size(39, 17);
            this.lbToolStripStatus.Text = "Status";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 316;
            this.label3.Text = "Url:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(58, 25);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(621, 20);
            this.txtAddress.TabIndex = 314;
            // 
            // btLoad
            // 
            this.btLoad.Location = new System.Drawing.Point(685, 21);
            this.btLoad.Name = "btLoad";
            this.btLoad.Size = new System.Drawing.Size(63, 26);
            this.btLoad.TabIndex = 315;
            this.btLoad.Text = "Load";
            this.btLoad.UseVisualStyleBackColor = true;
            this.btLoad.Click += new System.EventHandler(this.btLoad_Click);
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(754, 22);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(102, 26);
            this.btStart.TabIndex = 318;
            this.btStart.Text = "Bóc tách";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // statusStrip2
            // 
            this.statusStrip2.Location = new System.Drawing.Point(0, 517);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(890, 22);
            this.statusStrip2.TabIndex = 328;
            this.statusStrip2.Text = "statusStrip2";
            this.statusStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip2_ItemClicked);
            // 
            // frmOneINS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 539);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.groupLeft);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.btLoad);
            this.Controls.Add(this.btStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOneINS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmINS";
            this.Load += new System.EventHandler(this.frmOneINS_Load);
            this.groupLeft.ResumeLayout(false);
            this.groupLeft.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupLeft;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbToolStripStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btLoad;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.StatusStrip statusStrip2;
    }
}