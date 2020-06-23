namespace pmj
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnPmjDelete = new System.Windows.Forms.Button();
            this.lbPmjStatus = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.参数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.page1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbBankSerial = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboPlcList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxPmj = new System.Windows.Forms.ComboBox();
            this.btnDownloadFile = new System.Windows.Forms.Button();
            this.btnFindDevice = new System.Windows.Forms.Button();
            this.btnPlcPrint = new System.Windows.Forms.Button();
            this.btnOpenPlc = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelSetting = new System.Windows.Forms.Panel();
            this.panelTip = new System.Windows.Forms.Panel();
            this.btnDownload = new System.Windows.Forms.Button();
            this.cmbFileList = new System.Windows.Forms.ComboBox();
            this.panelTest = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.btnBarcode = new System.Windows.Forms.Button();
            this.btnQrcode = new System.Windows.Forms.Button();
            this.btnText = new System.Windows.Forms.Button();
            this.btnSerialNumber = new System.Windows.Forms.Button();
            this.btnTimeSetting = new System.Windows.Forms.Button();
            this.btnPicture = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelBottom.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.page1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelTip.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panelBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBottom.Controls.Add(this.btnPmjDelete);
            this.panelBottom.Controls.Add(this.lbPmjStatus);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 421);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(936, 44);
            this.panelBottom.TabIndex = 8;
            // 
            // btnPmjDelete
            // 
            this.btnPmjDelete.Location = new System.Drawing.Point(155, 8);
            this.btnPmjDelete.Name = "btnPmjDelete";
            this.btnPmjDelete.Size = new System.Drawing.Size(75, 23);
            this.btnPmjDelete.TabIndex = 1;
            this.btnPmjDelete.Text = "删除";
            this.btnPmjDelete.UseVisualStyleBackColor = true;
            this.btnPmjDelete.Click += new System.EventHandler(this.btnPmjDelete_Click);
            // 
            // lbPmjStatus
            // 
            this.lbPmjStatus.AutoSize = true;
            this.lbPmjStatus.Location = new System.Drawing.Point(4, 20);
            this.lbPmjStatus.Name = "lbPmjStatus";
            this.lbPmjStatus.Size = new System.Drawing.Size(41, 12);
            this.lbPmjStatus.TabIndex = 0;
            this.lbPmjStatus.Text = "未连接";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.参数ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(936, 25);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 参数ToolStripMenuItem
            // 
            this.参数ToolStripMenuItem.Name = "参数ToolStripMenuItem";
            this.参数ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.参数ToolStripMenuItem.Text = "参数设置";
            this.参数ToolStripMenuItem.Click += new System.EventHandler(this.参数ToolStripMenuItem_Click);
            // 
            // page1
            // 
            this.page1.Controls.Add(this.tabPage1);
            this.page1.Controls.Add(this.tabPage2);
            this.page1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.page1.Location = new System.Drawing.Point(0, 0);
            this.page1.Name = "page1";
            this.page1.SelectedIndex = 0;
            this.page1.Size = new System.Drawing.Size(934, 394);
            this.page1.TabIndex = 18;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.btnDownloadFile);
            this.tabPage1.Controls.Add(this.btnFindDevice);
            this.tabPage1.Controls.Add(this.btnPlcPrint);
            this.tabPage1.Controls.Add(this.btnOpenPlc);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(926, 368);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "首页";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tbBankSerial);
            this.groupBox2.Location = new System.Drawing.Point(467, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(334, 100);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "打印信息";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "银行卡号";
            // 
            // tbBankSerial
            // 
            this.tbBankSerial.Location = new System.Drawing.Point(65, 34);
            this.tbBankSerial.Name = "tbBankSerial";
            this.tbBankSerial.Size = new System.Drawing.Size(202, 21);
            this.tbBankSerial.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboPlcList);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxPmj);
            this.groupBox1.Location = new System.Drawing.Point(199, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 100);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "端口选择";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "打印机串口";
            // 
            // comboPlcList
            // 
            this.comboPlcList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPlcList.FormattingEnabled = true;
            this.comboPlcList.Location = new System.Drawing.Point(77, 62);
            this.comboPlcList.Name = "comboPlcList";
            this.comboPlcList.Size = new System.Drawing.Size(95, 20);
            this.comboPlcList.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "PLC串口";
            // 
            // comboBoxPmj
            // 
            this.comboBoxPmj.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPmj.FormattingEnabled = true;
            this.comboBoxPmj.Location = new System.Drawing.Point(77, 28);
            this.comboBoxPmj.Name = "comboBoxPmj";
            this.comboBoxPmj.Size = new System.Drawing.Size(95, 20);
            this.comboBoxPmj.TabIndex = 0;
            // 
            // btnDownloadFile
            // 
            this.btnDownloadFile.Location = new System.Drawing.Point(679, 363);
            this.btnDownloadFile.Name = "btnDownloadFile";
            this.btnDownloadFile.Size = new System.Drawing.Size(75, 23);
            this.btnDownloadFile.TabIndex = 4;
            this.btnDownloadFile.Text = "test";
            this.btnDownloadFile.UseVisualStyleBackColor = true;
            this.btnDownloadFile.Click += new System.EventHandler(this.btnDownloadFile_Click);
            // 
            // btnFindDevice
            // 
            this.btnFindDevice.Location = new System.Drawing.Point(458, 206);
            this.btnFindDevice.Name = "btnFindDevice";
            this.btnFindDevice.Size = new System.Drawing.Size(75, 23);
            this.btnFindDevice.TabIndex = 7;
            this.btnFindDevice.Text = "扫描打印机";
            this.btnFindDevice.UseVisualStyleBackColor = true;
            this.btnFindDevice.Click += new System.EventHandler(this.btnFindDevice_Click);
            // 
            // btnPlcPrint
            // 
            this.btnPlcPrint.Location = new System.Drawing.Point(284, 206);
            this.btnPlcPrint.Name = "btnPlcPrint";
            this.btnPlcPrint.Size = new System.Drawing.Size(87, 23);
            this.btnPlcPrint.TabIndex = 15;
            this.btnPlcPrint.Text = "PLC打印";
            this.btnPlcPrint.UseVisualStyleBackColor = true;
            this.btnPlcPrint.Click += new System.EventHandler(this.btnPlcPrint_Click);
            // 
            // btnOpenPlc
            // 
            this.btnOpenPlc.Location = new System.Drawing.Point(377, 206);
            this.btnOpenPlc.Name = "btnOpenPlc";
            this.btnOpenPlc.Size = new System.Drawing.Size(75, 23);
            this.btnOpenPlc.TabIndex = 14;
            this.btnOpenPlc.Text = "打开plc串口";
            this.btnOpenPlc.UseVisualStyleBackColor = true;
            this.btnOpenPlc.Click += new System.EventHandler(this.btnOpenPlc_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.panelTest);
            this.tabPage2.Controls.Add(this.panelRight);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1035, 447);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "喷码机";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelSetting);
            this.panel1.Controls.Add(this.panelTip);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 103);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(866, 341);
            this.panel1.TabIndex = 15;
            // 
            // panelSetting
            // 
            this.panelSetting.AutoScroll = true;
            this.panelSetting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSetting.Location = new System.Drawing.Point(0, 26);
            this.panelSetting.Name = "panelSetting";
            this.panelSetting.Size = new System.Drawing.Size(866, 315);
            this.panelSetting.TabIndex = 15;
            // 
            // panelTip
            // 
            this.panelTip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTip.Controls.Add(this.btnDownload);
            this.panelTip.Controls.Add(this.cmbFileList);
            this.panelTip.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTip.Location = new System.Drawing.Point(0, 0);
            this.panelTip.Name = "panelTip";
            this.panelTip.Size = new System.Drawing.Size(866, 26);
            this.panelTip.TabIndex = 14;
           
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(126, 1);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 1;
            this.btnDownload.Text = "下载";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // cmbFileList
            // 
            this.cmbFileList.FormattingEnabled = true;
            this.cmbFileList.Location = new System.Drawing.Point(-1, 3);
            this.cmbFileList.Name = "cmbFileList";
            this.cmbFileList.Size = new System.Drawing.Size(121, 20);
            this.cmbFileList.TabIndex = 0;
            // 
            // panelTest
            // 
            this.panelTest.AutoScroll = true;
            this.panelTest.BackColor = System.Drawing.Color.Transparent;
            this.panelTest.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTest.Location = new System.Drawing.Point(3, 3);
            this.panelTest.Name = "panelTest";
            this.panelTest.Size = new System.Drawing.Size(866, 100);
            this.panelTest.TabIndex = 5;
            this.panelTest.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTest_Paint);
            // 
            // panelRight
            // 
            this.panelRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRight.Controls.Add(this.btnBarcode);
            this.panelRight.Controls.Add(this.btnQrcode);
            this.panelRight.Controls.Add(this.btnText);
            this.panelRight.Controls.Add(this.btnSerialNumber);
            this.panelRight.Controls.Add(this.btnTimeSetting);
            this.panelRight.Controls.Add(this.btnPicture);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(869, 3);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(163, 441);
            this.panelRight.TabIndex = 11;
            // 
            // btnBarcode
            // 
            this.btnBarcode.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBarcode.Location = new System.Drawing.Point(0, 240);
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.Size = new System.Drawing.Size(161, 48);
            this.btnBarcode.TabIndex = 5;
            this.btnBarcode.Text = "条码";
            this.btnBarcode.UseVisualStyleBackColor = true;
            this.btnBarcode.Click += new System.EventHandler(this.btnBarcode_Click);
            // 
            // btnQrcode
            // 
            this.btnQrcode.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQrcode.Location = new System.Drawing.Point(0, 192);
            this.btnQrcode.Name = "btnQrcode";
            this.btnQrcode.Size = new System.Drawing.Size(161, 48);
            this.btnQrcode.TabIndex = 4;
            this.btnQrcode.Text = "二维码";
            this.btnQrcode.UseVisualStyleBackColor = true;
            this.btnQrcode.Click += new System.EventHandler(this.btnQrcode_Click);
            // 
            // btnText
            // 
            this.btnText.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnText.Location = new System.Drawing.Point(0, 144);
            this.btnText.Name = "btnText";
            this.btnText.Size = new System.Drawing.Size(161, 48);
            this.btnText.TabIndex = 3;
            this.btnText.Text = "文本";
            this.btnText.UseVisualStyleBackColor = true;
            this.btnText.Click += new System.EventHandler(this.btnText_Click);
            // 
            // btnSerialNumber
            // 
            this.btnSerialNumber.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSerialNumber.Location = new System.Drawing.Point(0, 96);
            this.btnSerialNumber.Name = "btnSerialNumber";
            this.btnSerialNumber.Size = new System.Drawing.Size(161, 48);
            this.btnSerialNumber.TabIndex = 2;
            this.btnSerialNumber.Text = "序号";
            this.btnSerialNumber.UseVisualStyleBackColor = true;
            this.btnSerialNumber.Click += new System.EventHandler(this.btnSerialNumber_Click);
            // 
            // btnTimeSetting
            // 
            this.btnTimeSetting.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTimeSetting.Location = new System.Drawing.Point(0, 48);
            this.btnTimeSetting.Name = "btnTimeSetting";
            this.btnTimeSetting.Size = new System.Drawing.Size(161, 48);
            this.btnTimeSetting.TabIndex = 1;
            this.btnTimeSetting.Text = "时间";
            this.btnTimeSetting.UseVisualStyleBackColor = true;
            this.btnTimeSetting.Click += new System.EventHandler(this.btnTimeSetting_Click);
            // 
            // btnPicture
            // 
            this.btnPicture.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPicture.Location = new System.Drawing.Point(0, 0);
            this.btnPicture.Name = "btnPicture";
            this.btnPicture.Size = new System.Drawing.Size(161, 48);
            this.btnPicture.TabIndex = 0;
            this.btnPicture.Text = "图片";
            this.btnPicture.UseVisualStyleBackColor = true;
            this.btnPicture.Click += new System.EventHandler(this.btnPicture_Click);
            // 
            // panelTop
            // 
            this.panelTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTop.Controls.Add(this.page1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(0, 25);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(936, 396);
            this.panelTop.TabIndex = 10;
          
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(936, 465);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "pmj";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.page1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelTip.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label lbPmjStatus;
        private System.Windows.Forms.Button btnPmjDelete;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 参数ToolStripMenuItem;
        private System.Windows.Forms.TabControl page1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnDownloadFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFindDevice;
        private System.Windows.Forms.TextBox tbBankSerial;
        private System.Windows.Forms.ComboBox comboBoxPmj;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboPlcList;
        private System.Windows.Forms.Button btnPlcPrint;
        private System.Windows.Forms.Button btnOpenPlc;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panelTest;
        private System.Windows.Forms.Panel panelTip;
        private System.Windows.Forms.Panel panelSetting;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.ComboBox cmbFileList;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Button btnBarcode;
        private System.Windows.Forms.Button btnQrcode;
        private System.Windows.Forms.Button btnText;
        private System.Windows.Forms.Button btnSerialNumber;
        private System.Windows.Forms.Button btnTimeSetting;
        private System.Windows.Forms.Button btnPicture;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

