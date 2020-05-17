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
            this.btnOpenPortPmj = new System.Windows.Forms.Button();
            this.panelTest = new System.Windows.Forms.Panel();
            this.btnFindDevice = new System.Windows.Forms.Button();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnPmjDelete = new System.Windows.Forms.Button();
            this.lbPmjStatus = new System.Windows.Forms.Label();
            this.btnPrintOnce = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnWriteBuffer = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.btnBarcode = new System.Windows.Forms.Button();
            this.btnQrcode = new System.Windows.Forms.Button();
            this.btnText = new System.Windows.Forms.Button();
            this.btnSerialNumber = new System.Windows.Forms.Button();
            this.btnTimeSetting = new System.Windows.Forms.Button();
            this.btnPicture = new System.Windows.Forms.Button();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelTip = new System.Windows.Forms.Panel();
            this.btnDownload = new System.Windows.Forms.Button();
            this.cmbFileList = new System.Windows.Forms.ComboBox();
            this.panelSetting = new System.Windows.Forms.Panel();
            this.panelBottom.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelTip.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxPmj
            // 
            this.comboBoxPmj.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPmj.FormattingEnabled = true;
            this.comboBoxPmj.Location = new System.Drawing.Point(12, 12);
            this.comboBoxPmj.Name = "comboBoxPmj";
            this.comboBoxPmj.Size = new System.Drawing.Size(121, 20);
            this.comboBoxPmj.TabIndex = 0;
            // 
            // btnOpenPortPmj
            // 
            this.btnOpenPortPmj.Location = new System.Drawing.Point(151, 12);
            this.btnOpenPortPmj.Name = "btnOpenPortPmj";
            this.btnOpenPortPmj.Size = new System.Drawing.Size(75, 23);
            this.btnOpenPortPmj.TabIndex = 1;
            this.btnOpenPortPmj.Text = "打开串口";
            this.btnOpenPortPmj.UseVisualStyleBackColor = true;
            this.btnOpenPortPmj.Click += new System.EventHandler(this.btnOpenPortPmj_Click);
            // 
            // panelTest
            // 
            this.panelTest.BackColor = System.Drawing.Color.Transparent;
            this.panelTest.Location = new System.Drawing.Point(0, 0);
            this.panelTest.Name = "panelTest";
            this.panelTest.Size = new System.Drawing.Size(2000, 50);
            this.panelTest.TabIndex = 5;
            this.panelTest.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTest_Paint);
            // 
            // btnFindDevice
            // 
            this.btnFindDevice.Location = new System.Drawing.Point(232, 12);
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
            this.panelBottom.Location = new System.Drawing.Point(0, 410);
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
            // btnPrintOnce
            // 
            this.btnPrintOnce.Location = new System.Drawing.Point(313, 12);
            this.btnPrintOnce.Name = "btnPrintOnce";
            this.btnPrintOnce.Size = new System.Drawing.Size(87, 23);
            this.btnPrintOnce.TabIndex = 9;
            this.btnPrintOnce.Text = "执行一次打印";
            this.btnPrintOnce.UseVisualStyleBackColor = true;
            this.btnPrintOnce.Click += new System.EventHandler(this.btnPrintOnce_Click);
            // 
            // panelTop
            // 
            this.panelTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTop.Controls.Add(this.button1);
            this.panelTop.Controls.Add(this.btnWriteBuffer);
            this.panelTop.Controls.Add(this.panel1);
            this.panelTop.Controls.Add(this.comboBoxPmj);
            this.panelTop.Controls.Add(this.btnOpenPortPmj);
            this.panelTop.Controls.Add(this.btnFindDevice);
            this.panelTop.Controls.Add(this.btnPrintOnce);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(941, 48);
            this.panelTop.TabIndex = 10;
            this.panelTop.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTop_Paint);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(723, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnWriteBuffer
            // 
            this.btnWriteBuffer.Location = new System.Drawing.Point(581, 12);
            this.btnWriteBuffer.Name = "btnWriteBuffer";
            this.btnWriteBuffer.Size = new System.Drawing.Size(75, 23);
            this.btnWriteBuffer.TabIndex = 12;
            this.btnWriteBuffer.Text = "下发缓存";
            this.btnWriteBuffer.UseVisualStyleBackColor = true;
            this.btnWriteBuffer.Click += new System.EventHandler(this.btnWriteBuffer_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(866, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 11;
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
            this.panelRight.Location = new System.Drawing.Point(778, 48);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(163, 362);
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
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 48);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(156, 362);
            this.panelLeft.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.panelTest);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(156, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(622, 128);
            this.panel2.TabIndex = 13;
            // 
            // panelTip
            // 
            this.panelTip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTip.Controls.Add(this.btnDownload);
            this.panelTip.Controls.Add(this.cmbFileList);
            this.panelTip.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTip.Location = new System.Drawing.Point(156, 176);
            this.panelTip.Name = "panelTip";
            this.panelTip.Size = new System.Drawing.Size(622, 64);
            this.panelTip.TabIndex = 14;
            this.panelTip.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTip_Paint);
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
            this.panelSetting.Location = new System.Drawing.Point(156, 240);
            this.panelSetting.Name = "panelSetting";
            this.panelSetting.Size = new System.Drawing.Size(622, 170);
            this.panelSetting.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(941, 454);
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
            this.panelRight.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelTip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.ComboBox comboBoxPmj;
        private System.Windows.Forms.Button btnOpenPortPmj;
        private System.Windows.Forms.Panel panelTest;
        private System.Windows.Forms.Button btnFindDevice;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label lbPmjStatus;
        private System.Windows.Forms.Button btnPrintOnce;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnPicture;
        private System.Windows.Forms.Panel panelTip;
        private System.Windows.Forms.Panel panelSetting;
        private System.Windows.Forms.Button btnPmjDelete;
        private System.Windows.Forms.Button btnWriteBuffer;
        private System.Windows.Forms.Button btnTimeSetting;
        private System.Windows.Forms.Button btnSerialNumber;
        private System.Windows.Forms.Button btnText;
        private System.Windows.Forms.Button btnQrcode;
        private System.Windows.Forms.Button btnBarcode;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.ComboBox cmbFileList;
    }
}

