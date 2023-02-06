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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.grSiDemand = new System.Windows.Forms.GroupBox();
            this.btnSourcStatus0 = new System.Windows.Forms.Button();
            this.btnFindsourceID = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnCmtINS = new System.Windows.Forms.Button();
            this.btnPostINS = new System.Windows.Forms.Button();
            this.grSiDataExcel = new System.Windows.Forms.GroupBox();
            this.btnINS = new System.Windows.Forms.Button();
            this.btnCrwSidataExcel = new System.Windows.Forms.Button();
            this.pnLogin = new System.Windows.Forms.Panel();
            this.grSiDemand.SuspendLayout();
            this.grSiDataExcel.SuspendLayout();
            this.SuspendLayout();
            // 
            // grSiDemand
            // 
            this.grSiDemand.Controls.Add(this.btnSourcStatus0);
            this.grSiDemand.Controls.Add(this.btnFindsourceID);
            this.grSiDemand.Controls.Add(this.btnLogin);
            this.grSiDemand.Controls.Add(this.btnCmtINS);
            this.grSiDemand.Controls.Add(this.btnPostINS);
            this.grSiDemand.Location = new System.Drawing.Point(12, 25);
            this.grSiDemand.Name = "grSiDemand";
            this.grSiDemand.Size = new System.Drawing.Size(762, 110);
            this.grSiDemand.TabIndex = 3;
            this.grSiDemand.TabStop = false;
            this.grSiDemand.Text = "CHỌN CHỨC NĂNG_ Data lquan đến bảng Si_Demand";
            this.grSiDemand.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnSourcStatus0
            // 
            this.btnSourcStatus0.Location = new System.Drawing.Point(421, 29);
            this.btnSourcStatus0.Name = "btnSourcStatus0";
            this.btnSourcStatus0.Size = new System.Drawing.Size(190, 49);
            this.btnSourcStatus0.TabIndex = 4;
            this.btnSourcStatus0.Text = "Bóc source mới nhất với status = 0";
            this.btnSourcStatus0.UseVisualStyleBackColor = true;
            this.btnSourcStatus0.Click += new System.EventHandler(this.btnSourcStatus0_Click);
            // 
            // btnFindsourceID
            // 
            this.btnFindsourceID.Location = new System.Drawing.Point(617, 29);
            this.btnFindsourceID.Name = "btnFindsourceID";
            this.btnFindsourceID.Size = new System.Drawing.Size(125, 49);
            this.btnFindsourceID.TabIndex = 3;
            this.btnFindsourceID.Text = "Tìm Source_ID_INS";
            this.btnFindsourceID.UseVisualStyleBackColor = true;
            this.btnFindsourceID.Click += new System.EventHandler(this.btnFindsourceID_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(272, 29);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(143, 49);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Đăng nhập INS";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnCmtINS
            // 
            this.btnCmtINS.Location = new System.Drawing.Point(136, 29);
            this.btnCmtINS.Name = "btnCmtINS";
            this.btnCmtINS.Size = new System.Drawing.Size(130, 49);
            this.btnCmtINS.TabIndex = 1;
            this.btnCmtINS.Text = "Bóc comment";
            this.btnCmtINS.UseVisualStyleBackColor = true;
            this.btnCmtINS.Click += new System.EventHandler(this.btnCmtINS_Click);
            // 
            // btnPostINS
            // 
            this.btnPostINS.BackColor = System.Drawing.Color.White;
            this.btnPostINS.Location = new System.Drawing.Point(23, 29);
            this.btnPostINS.Name = "btnPostINS";
            this.btnPostINS.Size = new System.Drawing.Size(107, 49);
            this.btnPostINS.TabIndex = 0;
            this.btnPostINS.Text = "Bóc source";
            this.btnPostINS.UseVisualStyleBackColor = false;
            this.btnPostINS.Click += new System.EventHandler(this.btnPostINS_Click);
            // 
            // grSiDataExcel
            // 
            this.grSiDataExcel.Controls.Add(this.btnINS);
            this.grSiDataExcel.Controls.Add(this.btnCrwSidataExcel);
            this.grSiDataExcel.Location = new System.Drawing.Point(787, 25);
            this.grSiDataExcel.Name = "grSiDataExcel";
            this.grSiDataExcel.Size = new System.Drawing.Size(443, 112);
            this.grSiDataExcel.TabIndex = 5;
            this.grSiDataExcel.TabStop = false;
            this.grSiDataExcel.Text = "CHỌN CHỨC NĂNG_ Data lquan Đến bảng si_crawl_data_excel";
            // 
            // btnINS
            // 
            this.btnINS.Location = new System.Drawing.Point(219, 29);
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
            // pnLogin
            // 
            this.pnLogin.Location = new System.Drawing.Point(12, 143);
            this.pnLogin.Name = "pnLogin";
            this.pnLogin.Size = new System.Drawing.Size(1218, 618);
            this.pnLogin.TabIndex = 6;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 773);
            this.Controls.Add(this.pnLogin);
            this.Controls.Add(this.grSiDataExcel);
            this.Controls.Add(this.grSiDemand);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crawl Data Instaram";
            this.Load += new System.EventHandler(this.frmMain_LoadAsync);
            this.grSiDemand.ResumeLayout(false);
            this.grSiDataExcel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grSiDemand;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCmtINS;
        private System.Windows.Forms.Button btnPostINS;
        private System.Windows.Forms.Button btnFindsourceID;
        private System.Windows.Forms.Button btnSourcStatus0;
        private System.Windows.Forms.GroupBox grSiDataExcel;
        private System.Windows.Forms.Button btnCrwSidataExcel;
        private System.Windows.Forms.Button btnINS;
        private System.Windows.Forms.Panel pnLogin;
    }
}

