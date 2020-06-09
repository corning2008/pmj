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
            this.comboBoxPmj = new System.Windows.Forms.ComboBox();
            this.panelTest = new System.Windows.Forms.Panel();
            this.btnFindDevice = new System.Windows.Forms.Button();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnPmjDelete = new System.Windows.Forms.Button();
            this.lbPmjStatus = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.tbBankSerial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPlcPrint = new System.Windows.Forms.Button();
            this.btnOpenPlc = new System.Windows.Forms.Button();
            this.comboPlcList = new System.Windows.Forms.ComboBox();
            this.btnCleanPrinter = new System.Windows.Forms.Button();
            this.panelRight = new System.Windows.Forms.Panel();
            this.btnBarcode = new System.Windows.Forms.Button();
            this.btnQrcode = new System.Windows.Forms.Button();
            this.btnText = new System.Windows.Forms.Button();
            this.btnSerialNumber = new System.Windows.Forms.Button();
            this.btnTimeSetting = new System.Windows.Forms.Button();
            this.btnPicture = new System.Windows.Forms.Button();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.btnParameter = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelTip = new System.Windows.Forms.Panel();
            this.btnDownloadFile = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.cmbFileList = new System.Windows.Forms.ComboBox();
            this.panelSetting = new System.Windows.Forms.Panel();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.panelBottom.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelTip.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxPmj
            // 
            this.comboBoxPmj.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPmj.FormattingEnabled = true;
            this.comboBoxPmj.Location = new System.Drawing.Point(75, 10);
            this.comboBoxPmj.Name = "comboBoxPmj";
            this.comboBoxPmj.Size = new System.Drawing.Size(121, 20);
            this.comboBoxPmj.TabIndex = 0;
            // 
            // panelTest
            // 
            this.panelTest.BackColor = System.Drawing.Color.Transparent;
            this.panelTest.Location = new System.Drawing.Point(0, 0);
            this.panelTest.Name = "panelTest";
            this.panelTest.Size = new System.Drawing.Size(4000, 100);
            this.panelTest.TabIndex = 5;
            this.panelTest.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTest_Paint);
            // 
            // btnFindDevice
            // 
            this.btnFindDevice.Location = new System.Drawing.Point(325, 8);
            this.btnFindDevice.Name = "btnFindDevice";
            this.btnFindDevice.Size = new System.Drawing.Size(75, 23);
            this.btnFindDevice.TabIndex = 7;
            this.btnFindDevice.Text = "扫描打印机";
            this.btnFindDevice.UseVisualStyleBackColor = true;
            this.btnFindDevice.Click += new System.EventHandler(this.btnFindDevice_Click);
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panelBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBottom.Controls.Add(this.btnPmjDelete);
            this.panelBottom.Controls.Add(this.lbPmjStatus);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 500);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(941, 44);
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
            // panelTop
            // 
            this.panelTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTop.Controls.Add(this.label3);
            this.panelTop.Controls.Add(this.tbBankSerial);
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.btnPlcPrint);
            this.panelTop.Controls.Add(this.btnOpenPlc);
            this.panelTop.Controls.Add(this.comboPlcList);
            this.panelTop.Controls.Add(this.btnCleanPrinter);
            this.panelTop.Controls.Add(this.comboBoxPmj);
            this.panelTop.Controls.Add(this.btnFindDevice);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(941, 137);
            this.panelTop.TabIndex = 10;
            this.panelTop.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTop_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "银行卡号";
            // 
            // tbBankSerial
            // 
            this.tbBankSerial.Location = new System.Drawing.Point(75, 79);
            this.tbBankSerial.Name = "tbBankSerial";
            this.tbBankSerial.Size = new System.Drawing.Size(202, 21);
            this.tbBankSerial.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "PLC串口";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "打印机串口";
            // 
            // btnPlcPrint
            // 
            this.btnPlcPrint.Location = new System.Drawing.Point(313, 77);
            this.btnPlcPrint.Name = "btnPlcPrint";
            this.btnPlcPrint.Size = new System.Drawing.Size(87, 23);
            this.btnPlcPrint.TabIndex = 15;
            this.btnPlcPrint.Text = "PLC打印";
            this.btnPlcPrint.UseVisualStyleBackColor = true;
            this.btnPlcPrint.Click += new System.EventHandler(this.btnPlcPrint_Click);
            // 
            // btnOpenPlc
            // 
            this.btnOpenPlc.Location = new System.Drawing.Point(325, 36);
            this.btnOpenPlc.Name = "btnOpenPlc";
            this.btnOpenPlc.Size = new System.Drawing.Size(75, 23);
            this.btnOpenPlc.TabIndex = 14;
            this.btnOpenPlc.Text = "打开plc串口";
            this.btnOpenPlc.UseVisualStyleBackColor = true;
            this.btnOpenPlc.Click += new System.EventHandler(this.btnOpenPlc_Click);
            // 
            // comboPlcList
            // 
            this.comboPlcList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPlcList.FormattingEnabled = true;
            this.comboPlcList.Location = new System.Drawing.Point(75, 44);
            this.comboPlcList.Name = "comboPlcList";
            this.comboPlcList.Size = new System.Drawing.Size(121, 20);
            this.comboPlcList.TabIndex = 13;
            // 
            // btnCleanPrinter
            // 
            this.btnCleanPrinter.Location = new System.Drawing.Point(849, 13);
            this.btnCleanPrinter.Name = "btnCleanPrinter";
            this.btnCleanPrinter.Size = new System.Drawing.Size(87, 23);
            this.btnCleanPrinter.TabIndex = 12;
            this.btnCleanPrinter.Text = "清洗喷头";
            this.btnCleanPrinter.UseVisualStyleBackColor = true;
            this.btnCleanPrinter.Click += new System.EventHandler(this.btnCleanPrinter_Click);
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
            this.panelRight.Location = new System.Drawing.Point(778, 137);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(163, 363);
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
            // panelLeft
            // 
            this.panelLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLeft.Controls.Add(this.btnParameter);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 137);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(156, 363);
            this.panelLeft.TabIndex = 12;
            // 
            // btnParameter
            // 
            this.btnParameter.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnParameter.Location = new System.Drawing.Point(0, 0);
            this.btnParameter.Name = "btnParameter";
            this.btnParameter.Size = new System.Drawing.Size(154, 48);
            this.btnParameter.TabIndex = 1;
            this.btnParameter.Text = "参数";
            this.btnParameter.UseVisualStyleBackColor = true;
            this.btnParameter.Click += new System.EventHandler(this.btnParameter_Click);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.panelTest);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(156, 137);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(622, 128);
            this.panel2.TabIndex = 13;
            // 
            // panelTip
            // 
            this.panelTip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTip.Controls.Add(this.btnDownloadFile);
            this.panelTip.Controls.Add(this.btnDownload);
            this.panelTip.Controls.Add(this.cmbFileList);
            this.panelTip.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTip.Location = new System.Drawing.Point(156, 265);
            this.panelTip.Name = "panelTip";
            this.panelTip.Size = new System.Drawing.Size(622, 113);
            this.panelTip.TabIndex = 14;
            this.panelTip.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTip_Paint);
            // 
            // btnDownloadFile
            // 
            this.btnDownloadFile.Location = new System.Drawing.Point(293, 69);
            this.btnDownloadFile.Name = "btnDownloadFile";
            this.btnDownloadFile.Size = new System.Drawing.Size(75, 23);
            this.btnDownloadFile.TabIndex = 4;
            this.btnDownloadFile.Text = "下载到PMJ";
            this.btnDownloadFile.UseVisualStyleBackColor = true;
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(133, 25);
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
            this.cmbFileList.Location = new System.Drawing.Point(6, 25);
            this.cmbFileList.Name = "cmbFileList";
            this.cmbFileList.Size = new System.Drawing.Size(121, 20);
            this.cmbFileList.TabIndex = 0;
            // 
            // panelSetting
            // 
            this.panelSetting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSetting.Location = new System.Drawing.Point(156, 378);
            this.panelSetting.Name = "panelSetting";
            this.panelSetting.Size = new System.Drawing.Size(622, 122);
            this.panelSetting.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(941, 544);
            this.Controls.Add(this.panelSetting);
            this.Controls.Add(this.panelTip);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelBottom);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelTip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.ComboBox comboBoxPmj;
        private System.Windows.Forms.Panel panelTest;
        private System.Windows.Forms.Button btnFindDevice;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label lbPmjStatus;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnPicture;
        private System.Windows.Forms.Panel panelTip;
        private System.Windows.Forms.Panel panelSetting;
        private System.Windows.Forms.Button btnPmjDelete;
        private System.Windows.Forms.Button btnTimeSetting;
        private System.Windows.Forms.Button btnSerialNumber;
        private System.Windows.Forms.Button btnText;
        private System.Windows.Forms.Button btnQrcode;
        private System.Windows.Forms.Button btnBarcode;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.ComboBox cmbFileList;
        private System.Windows.Forms.Button btnParameter;
        private System.Windows.Forms.Button btnCleanPrinter;
        private System.Windows.Forms.Button btnOpenPlc;
        private System.Windows.Forms.ComboBox comboPlcList;
        private System.Windows.Forms.Button btnPlcPrint;
        private System.Windows.Forms.Label label1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TextBox tbBankSerial;
        private System.Windows.Forms.Button btnDownloadFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

