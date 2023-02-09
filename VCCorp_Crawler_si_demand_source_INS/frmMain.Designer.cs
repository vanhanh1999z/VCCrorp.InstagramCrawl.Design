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
            this.grSiDataExcel = new System.Windows.Forms.GroupBox();
            this.pnLogin = new System.Windows.Forms.Panel();
            this.grSiDemand = new System.Windows.Forms.GroupBox();
            this.btINS = new VCCorp_Crawler_si_demand_source_INS.ext.Control.RButton();
            this.btCrwSidataExcel = new VCCorp_Crawler_si_demand_source_INS.ext.Control.RButton();
            this.btGetId = new VCCorp_Crawler_si_demand_source_INS.ext.Control.RButton();
            this.btFindsourceID = new VCCorp_Crawler_si_demand_source_INS.ext.Control.RButton();
            this.btPostUser = new VCCorp_Crawler_si_demand_source_INS.ext.Control.RButton();
            this.btSourcStatus0 = new VCCorp_Crawler_si_demand_source_INS.ext.Control.RButton();
            this.btCmtINS = new VCCorp_Crawler_si_demand_source_INS.ext.Control.RButton();
            this.btPostINS = new VCCorp_Crawler_si_demand_source_INS.ext.Control.RButton();
            this.grSiDataExcel.SuspendLayout();
            this.grSiDemand.SuspendLayout();
            this.SuspendLayout();
            // 
            // grSiDataExcel
            // 
            this.grSiDataExcel.Controls.Add(this.btINS);
            this.grSiDataExcel.Controls.Add(this.btCrwSidataExcel);
            this.grSiDataExcel.Location = new System.Drawing.Point(787, 25);
            this.grSiDataExcel.Name = "grSiDataExcel";
            this.grSiDataExcel.Size = new System.Drawing.Size(398, 112);
            this.grSiDataExcel.TabIndex = 5;
            this.grSiDataExcel.TabStop = false;
            this.grSiDataExcel.Text = "CHỌN CHỨC NĂNG_ Data lquan Đến bảng si_crawl_data_excel";
            // 
            // pnLogin
            // 
            this.pnLogin.Location = new System.Drawing.Point(12, 143);
            this.pnLogin.Name = "pnLogin";
            this.pnLogin.Size = new System.Drawing.Size(1173, 618);
            this.pnLogin.TabIndex = 6;
            // 
            // grSiDemand
            // 
            this.grSiDemand.Controls.Add(this.btGetId);
            this.grSiDemand.Controls.Add(this.btFindsourceID);
            this.grSiDemand.Controls.Add(this.btPostUser);
            this.grSiDemand.Controls.Add(this.btSourcStatus0);
            this.grSiDemand.Controls.Add(this.btCmtINS);
            this.grSiDemand.Controls.Add(this.btPostINS);
            this.grSiDemand.Location = new System.Drawing.Point(12, 25);
            this.grSiDemand.Name = "grSiDemand";
            this.grSiDemand.Size = new System.Drawing.Size(762, 110);
            this.grSiDemand.TabIndex = 3;
            this.grSiDemand.TabStop = false;
            this.grSiDemand.Text = "CHỌN CHỨC NĂNG_ Data lquan đến bảng Si_Demand";
            // 
            // btINS
            // 
            this.btINS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(73)))), ((int)(((byte)(101)))));
            this.btINS.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(73)))), ((int)(((byte)(101)))));
            this.btINS.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btINS.BorderRadius = 7;
            this.btINS.BorderSize = 0;
            this.btINS.FlatAppearance.BorderSize = 0;
            this.btINS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btINS.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btINS.Location = new System.Drawing.Point(208, 33);
            this.btINS.Name = "btINS";
            this.btINS.Size = new System.Drawing.Size(161, 50);
            this.btINS.TabIndex = 0;
            this.btINS.Text = "Bóc Post INS link bất kì";
            this.btINS.TextColor = System.Drawing.SystemColors.HighlightText;
            this.btINS.UseVisualStyleBackColor = false;
            this.btINS.Click += new System.EventHandler(this.btINS_Click);
            // 
            // btCrwSidataExcel
            // 
            this.btCrwSidataExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(129)))), ((int)(((byte)(137)))));
            this.btCrwSidataExcel.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(129)))), ((int)(((byte)(137)))));
            this.btCrwSidataExcel.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btCrwSidataExcel.BorderRadius = 7;
            this.btCrwSidataExcel.BorderSize = 0;
            this.btCrwSidataExcel.FlatAppearance.BorderSize = 0;
            this.btCrwSidataExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCrwSidataExcel.ForeColor = System.Drawing.Color.White;
            this.btCrwSidataExcel.Location = new System.Drawing.Point(25, 33);
            this.btCrwSidataExcel.Name = "btCrwSidataExcel";
            this.btCrwSidataExcel.Size = new System.Drawing.Size(165, 50);
            this.btCrwSidataExcel.TabIndex = 0;
            this.btCrwSidataExcel.Text = "Bóc Post và comment";
            this.btCrwSidataExcel.TextColor = System.Drawing.Color.White;
            this.btCrwSidataExcel.UseVisualStyleBackColor = false;
            this.btCrwSidataExcel.Click += new System.EventHandler(this.btCrwSidataExcel_Click);
            // 
            // btGetId
            // 
            this.btGetId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(169)))), ((int)(((byte)(140)))));
            this.btGetId.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(169)))), ((int)(((byte)(140)))));
            this.btGetId.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btGetId.BorderRadius = 7;
            this.btGetId.BorderSize = 0;
            this.btGetId.FlatAppearance.BorderSize = 0;
            this.btGetId.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btGetId.ForeColor = System.Drawing.Color.White;
            this.btGetId.Location = new System.Drawing.Point(507, 33);
            this.btGetId.Name = "btGetId";
            this.btGetId.Size = new System.Drawing.Size(94, 50);
            this.btGetId.TabIndex = 1;
            this.btGetId.Text = "GetID";
            this.btGetId.TextColor = System.Drawing.Color.White;
            this.btGetId.UseVisualStyleBackColor = false;
            this.btGetId.Click += new System.EventHandler(this.btGetId_Click);
            // 
            // btFindsourceID
            // 
            this.btFindsourceID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(169)))), ((int)(((byte)(140)))));
            this.btFindsourceID.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(169)))), ((int)(((byte)(140)))));
            this.btFindsourceID.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btFindsourceID.BorderRadius = 7;
            this.btFindsourceID.BorderSize = 0;
            this.btFindsourceID.FlatAppearance.BorderSize = 0;
            this.btFindsourceID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btFindsourceID.ForeColor = System.Drawing.Color.White;
            this.btFindsourceID.Location = new System.Drawing.Point(400, 33);
            this.btFindsourceID.Name = "btFindsourceID";
            this.btFindsourceID.Size = new System.Drawing.Size(101, 50);
            this.btFindsourceID.TabIndex = 0;
            this.btFindsourceID.Text = "Tìm Source ID Ins";
            this.btFindsourceID.TextColor = System.Drawing.Color.White;
            this.btFindsourceID.UseVisualStyleBackColor = false;
            this.btFindsourceID.Click += new System.EventHandler(this.btFindsourceID_Click);
            // 
            // btPostUser
            // 
            this.btPostUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(121)))), ((int)(((byte)(111)))));
            this.btPostUser.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(121)))), ((int)(((byte)(111)))));
            this.btPostUser.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btPostUser.BorderRadius = 7;
            this.btPostUser.BorderSize = 0;
            this.btPostUser.FlatAppearance.BorderSize = 0;
            this.btPostUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPostUser.ForeColor = System.Drawing.Color.White;
            this.btPostUser.Location = new System.Drawing.Point(607, 33);
            this.btPostUser.Name = "btPostUser";
            this.btPostUser.Size = new System.Drawing.Size(137, 50);
            this.btPostUser.TabIndex = 0;
            this.btPostUser.Text = "Bóc post 1 User";
            this.btPostUser.TextColor = System.Drawing.Color.White;
            this.btPostUser.UseVisualStyleBackColor = false;
            this.btPostUser.Click += new System.EventHandler(this.btPostUser_Click);
            // 
            // btSourcStatus0
            // 
            this.btSourcStatus0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(121)))), ((int)(((byte)(111)))));
            this.btSourcStatus0.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(121)))), ((int)(((byte)(111)))));
            this.btSourcStatus0.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btSourcStatus0.BorderRadius = 7;
            this.btSourcStatus0.BorderSize = 0;
            this.btSourcStatus0.FlatAppearance.BorderSize = 0;
            this.btSourcStatus0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSourcStatus0.ForeColor = System.Drawing.Color.White;
            this.btSourcStatus0.Location = new System.Drawing.Point(215, 33);
            this.btSourcStatus0.Name = "btSourcStatus0";
            this.btSourcStatus0.Size = new System.Drawing.Size(179, 50);
            this.btSourcStatus0.TabIndex = 0;
            this.btSourcStatus0.Text = "Bóc source mới nhất với status = 0";
            this.btSourcStatus0.TextColor = System.Drawing.Color.White;
            this.btSourcStatus0.UseVisualStyleBackColor = false;
            this.btSourcStatus0.Click += new System.EventHandler(this.btSourcStatus0_Click);
            // 
            // btCmtINS
            // 
            this.btCmtINS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(79)))), ((int)(((byte)(82)))));
            this.btCmtINS.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(79)))), ((int)(((byte)(82)))));
            this.btCmtINS.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btCmtINS.BorderRadius = 7;
            this.btCmtINS.BorderSize = 0;
            this.btCmtINS.FlatAppearance.BorderSize = 0;
            this.btCmtINS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCmtINS.ForeColor = System.Drawing.Color.White;
            this.btCmtINS.Location = new System.Drawing.Point(120, 33);
            this.btCmtINS.Name = "btCmtINS";
            this.btCmtINS.Size = new System.Drawing.Size(89, 50);
            this.btCmtINS.TabIndex = 0;
            this.btCmtINS.Text = "Bóc comment";
            this.btCmtINS.TextColor = System.Drawing.Color.White;
            this.btCmtINS.UseVisualStyleBackColor = false;
            this.btCmtINS.Click += new System.EventHandler(this.btCmtINS_Click);
            // 
            // btPostINS
            // 
            this.btPostINS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.btPostINS.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.btPostINS.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btPostINS.BorderRadius = 7;
            this.btPostINS.BorderSize = 0;
            this.btPostINS.FlatAppearance.BorderSize = 0;
            this.btPostINS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPostINS.ForeColor = System.Drawing.Color.White;
            this.btPostINS.Location = new System.Drawing.Point(23, 33);
            this.btPostINS.Name = "btPostINS";
            this.btPostINS.Size = new System.Drawing.Size(91, 50);
            this.btPostINS.TabIndex = 0;
            this.btPostINS.Text = "Bóc source";
            this.btPostINS.TextColor = System.Drawing.Color.White;
            this.btPostINS.UseVisualStyleBackColor = false;
            this.btPostINS.Click += new System.EventHandler(this.btPostINS_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1203, 773);
            this.Controls.Add(this.pnLogin);
            this.Controls.Add(this.grSiDataExcel);
            this.Controls.Add(this.grSiDemand);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmMain_LoadAsync);
            this.grSiDataExcel.ResumeLayout(false);
            this.grSiDemand.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private VCCorp_Crawler_si_demand_source_INS.ext.Control.RButton btPostUser;

        private VCCorp_Crawler_si_demand_source_INS.ext.Control.RButton btGetId;

        private VCCorp_Crawler_si_demand_source_INS.ext.Control.RButton btCrwSidataExcel;
        private VCCorp_Crawler_si_demand_source_INS.ext.Control.RButton btINS;
        private System.Windows.Forms.GroupBox grSiDataExcel;
        private System.Windows.Forms.Panel pnLogin;
        private VCCorp_Crawler_si_demand_source_INS.ext.Control.RButton btPostINS;
        private VCCorp_Crawler_si_demand_source_INS.ext.Control.RButton btCmtINS;
        private VCCorp_Crawler_si_demand_source_INS.ext.Control.RButton btSourcStatus0;
        private VCCorp_Crawler_si_demand_source_INS.ext.Control.RButton btFindsourceID;
        private System.Windows.Forms.GroupBox grSiDemand;

        #endregion
    }
}

