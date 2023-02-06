namespace VCCorp_Crawler_si_demand_source_INS
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSourcStatus0 = new System.Windows.Forms.Button();
            this.btnFindsourceID = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnCmtINS = new System.Windows.Forms.Button();
            this.btnPostINS = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnINS = new System.Windows.Forms.Button();
            this.btnCrwSidataExcel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSourcStatus0);
            this.groupBox1.Controls.Add(this.btnFindsourceID);
            this.groupBox1.Controls.Add(this.btnLogin);
            this.groupBox1.Controls.Add(this.btnCmtINS);
            this.groupBox1.Controls.Add(this.btnPostINS);
            this.groupBox1.Location = new System.Drawing.Point(110, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(235, 316);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CHỌN CHỨC NĂNG_ Data lquan đến bảng Si_Demand";
            // 
            // btnSourcStatus0
            // 
            this.btnSourcStatus0.Location = new System.Drawing.Point(23, 250);
            this.btnSourcStatus0.Name = "btnSourcStatus0";
            this.btnSourcStatus0.Size = new System.Drawing.Size(190, 49);
            this.btnSourcStatus0.TabIndex = 4;
            this.btnSourcStatus0.Text = "Bóc source mới nhất với status = 0";
            this.btnSourcStatus0.UseVisualStyleBackColor = true;
            this.btnSourcStatus0.Click += new System.EventHandler(this.btnSourcStatus0_Click);
            // 
            // btnFindsourceID
            // 
            this.btnFindsourceID.Location = new System.Drawing.Point(23, 193);
            this.btnFindsourceID.Name = "btnFindsourceID";
            this.btnFindsourceID.Size = new System.Drawing.Size(190, 49);
            this.btnFindsourceID.TabIndex = 3;
            this.btnFindsourceID.Text = "Tìm Source_ID_INS";
            this.btnFindsourceID.UseVisualStyleBackColor = true;
            this.btnFindsourceID.Click += new System.EventHandler(this.btnFindsourceID_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(23, 138);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(190, 49);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Đăng nhập INS";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnCmtINS
            // 
            this.btnCmtINS.Location = new System.Drawing.Point(23, 83);
            this.btnCmtINS.Name = "btnCmtINS";
            this.btnCmtINS.Size = new System.Drawing.Size(190, 49);
            this.btnCmtINS.TabIndex = 1;
            this.btnCmtINS.Text = "Bóc comment";
            this.btnCmtINS.UseVisualStyleBackColor = true;
            this.btnCmtINS.Click += new System.EventHandler(this.btnCmtINS_Click);
            // 
            // btnPostINS
            // 
            this.btnPostINS.Location = new System.Drawing.Point(23, 29);
            this.btnPostINS.Name = "btnPostINS";
            this.btnPostINS.Size = new System.Drawing.Size(190, 49);
            this.btnPostINS.TabIndex = 0;
            this.btnPostINS.Text = "Bóc source";
            this.btnPostINS.UseVisualStyleBackColor = true;
            this.btnPostINS.Click += new System.EventHandler(this.btnPostINS_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnINS);
            this.groupBox2.Controls.Add(this.btnCrwSidataExcel);
            this.groupBox2.Location = new System.Drawing.Point(372, 35);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(235, 316);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CHỌN CHỨC NĂNG_ Data lquan Đến bảng si_crawl_data_excel";
            // 
            // btnINS
            // 
            this.btnINS.Location = new System.Drawing.Point(23, 250);
            this.btnINS.Name = "btnINS";
            this.btnINS.Size = new System.Drawing.Size(190, 49);
            this.btnINS.TabIndex = 1;
            this.btnINS.Text = "Bóc Post INS link bất kì";
            this.btnINS.UseVisualStyleBackColor = true;
            this.btnINS.Click += new System.EventHandler(this.btnINS_Click);
            // 
            // btnCrwSidataExcel
            // 
            this.btnCrwSidataExcel.Location = new System.Drawing.Point(23, 29);
            this.btnCrwSidataExcel.Name = "btnCrwSidataExcel";
            this.btnCrwSidataExcel.Size = new System.Drawing.Size(190, 49);
            this.btnCrwSidataExcel.TabIndex = 0;
            this.btnCrwSidataExcel.Text = "Bóc Post và comment";
            this.btnCrwSidataExcel.UseVisualStyleBackColor = true;
            this.btnCrwSidataExcel.Click += new System.EventHandler(this.btnCrwSidataExcel_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmMain";
            this.Text = "Chức năng";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCmtINS;
        private System.Windows.Forms.Button btnPostINS;
        private System.Windows.Forms.Button btnFindsourceID;
        private System.Windows.Forms.Button btnSourcStatus0;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCrwSidataExcel;
        private System.Windows.Forms.Button btnINS;
    }
}

