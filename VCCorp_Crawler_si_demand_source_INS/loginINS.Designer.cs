namespace VCCorp_Crawler_si_demand_source_INS
{
    partial class loginINS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loginINS));
            this.label3 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btLoad = new System.Windows.Forms.Button();
            this.groupLeft = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 264;
            this.label3.Text = "Url:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(55, 25);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(719, 20);
            this.txtAddress.TabIndex = 262;
            this.txtAddress.Text = "https://www.instagram.com/";
            // 
            // btLoad
            // 
            this.btLoad.Location = new System.Drawing.Point(780, 21);
            this.btLoad.Name = "btLoad";
            this.btLoad.Size = new System.Drawing.Size(125, 26);
            this.btLoad.TabIndex = 263;
            this.btLoad.Text = "Load";
            this.btLoad.UseVisualStyleBackColor = true;
            this.btLoad.Click += new System.EventHandler(this.btLoad_Click);
            // 
            // groupLeft
            // 
            this.groupLeft.Location = new System.Drawing.Point(12, 51);
            this.groupLeft.Name = "groupLeft";
            this.groupLeft.Size = new System.Drawing.Size(902, 545);
            this.groupLeft.TabIndex = 265;
            this.groupLeft.TabStop = false;
            // 
            // loginINS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 608);
            this.Controls.Add(this.groupLeft);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.btLoad);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "loginINS";
            this.Text = "loginINS";
            this.Load += new System.EventHandler(this.loginINS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btLoad;
        private System.Windows.Forms.GroupBox groupLeft;
    }
}