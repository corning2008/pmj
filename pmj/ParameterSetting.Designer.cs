namespace pmj
{
    partial class ParameterSetting
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btnReadDeviceTime = new System.Windows.Forms.Button();
            this.btnGetSystemTime = new System.Windows.Forms.Button();
            this.tbTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnReadParameter = new System.Windows.Forms.Button();
            this.btnSettingParameter = new System.Windows.Forms.Button();
            this.numberDelay = new System.Windows.Forms.NumericUpDown();
            this.numberColDelay = new System.Windows.Forms.NumericUpDown();
            this.numberCount = new System.Windows.Forms.NumericUpDown();
            this.numberParameter1 = new System.Windows.Forms.NumericUpDown();
            this.cmbGrayList = new System.Windows.Forms.ComboBox();
            this.cmbVList = new System.Windows.Forms.ComboBox();
            this.cmbPrintList = new System.Windows.Forms.ComboBox();
            this.cmbShutdownList = new System.Windows.Forms.ComboBox();
            this.cmbFileList = new System.Windows.Forms.ComboBox();
            this.cmbLeaveTime = new System.Windows.Forms.ComboBox();
            this.cmbPulseWidth = new System.Windows.Forms.ComboBox();
            this.cmbParameter2 = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberColDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberParameter1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btnReadDeviceTime);
            this.panel1.Controls.Add(this.btnGetSystemTime);
            this.panel1.Controls.Add(this.tbTime);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(719, 76);
            this.panel1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(534, 24);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "同步到喷码机";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnReadDeviceTime
            // 
            this.btnReadDeviceTime.Location = new System.Drawing.Point(440, 24);
            this.btnReadDeviceTime.Name = "btnReadDeviceTime";
            this.btnReadDeviceTime.Size = new System.Drawing.Size(88, 23);
            this.btnReadDeviceTime.TabIndex = 3;
            this.btnReadDeviceTime.Text = "读取设备时间";
            this.btnReadDeviceTime.UseVisualStyleBackColor = true;
            this.btnReadDeviceTime.Click += new System.EventHandler(this.btnReadDeviceTime_Click);
            // 
            // btnGetSystemTime
            // 
            this.btnGetSystemTime.Location = new System.Drawing.Point(359, 24);
            this.btnGetSystemTime.Name = "btnGetSystemTime";
            this.btnGetSystemTime.Size = new System.Drawing.Size(75, 23);
            this.btnGetSystemTime.TabIndex = 2;
            this.btnGetSystemTime.Text = "系统时间";
            this.btnGetSystemTime.UseVisualStyleBackColor = true;
            this.btnGetSystemTime.Click += new System.EventHandler(this.btnGetSystemTime_Click);
            // 
            // tbTime
            // 
            this.tbTime.Location = new System.Drawing.Point(84, 27);
            this.tbTime.Name = "tbTime";
            this.tbTime.Size = new System.Drawing.Size(100, 21);
            this.tbTime.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "时间参数:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "喷码机参数";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "开始延时";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(74, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "列间延时";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(74, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "编码器计数";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(74, 265);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "保留参数";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(273, 265);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "自动关机";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(273, 226);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "喷头选择";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(273, 182);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 7;
            this.label9.Text = "喷头电压";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(273, 137);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 6;
            this.label10.Text = "打印灰度";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(476, 265);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 13;
            this.label11.Text = "保留参数";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(476, 226);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 12;
            this.label12.Text = "脉冲宽度";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(476, 182);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 11;
            this.label13.Text = "闲置设置";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(476, 137);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 10;
            this.label14.Text = "打印文件";
            // 
            // btnReadParameter
            // 
            this.btnReadParameter.Location = new System.Drawing.Point(225, 331);
            this.btnReadParameter.Name = "btnReadParameter";
            this.btnReadParameter.Size = new System.Drawing.Size(88, 23);
            this.btnReadParameter.TabIndex = 5;
            this.btnReadParameter.Text = "读取设备参数";
            this.btnReadParameter.UseVisualStyleBackColor = true;
            this.btnReadParameter.Click += new System.EventHandler(this.btnReadParameter_Click);
            // 
            // btnSettingParameter
            // 
            this.btnSettingParameter.Location = new System.Drawing.Point(376, 331);
            this.btnSettingParameter.Name = "btnSettingParameter";
            this.btnSettingParameter.Size = new System.Drawing.Size(88, 23);
            this.btnSettingParameter.TabIndex = 14;
            this.btnSettingParameter.Text = "设置设备参数";
            this.btnSettingParameter.UseVisualStyleBackColor = true;
            this.btnSettingParameter.Click += new System.EventHandler(this.btnSettingParameter_Click);
            // 
            // numberDelay
            // 
            this.numberDelay.Location = new System.Drawing.Point(142, 135);
            this.numberDelay.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numberDelay.Name = "numberDelay";
            this.numberDelay.Size = new System.Drawing.Size(120, 21);
            this.numberDelay.TabIndex = 15;
            this.numberDelay.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numberColDelay
            // 
            this.numberColDelay.Location = new System.Drawing.Point(142, 180);
            this.numberColDelay.Name = "numberColDelay";
            this.numberColDelay.Size = new System.Drawing.Size(120, 21);
            this.numberColDelay.TabIndex = 16;
            this.numberColDelay.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // numberCount
            // 
            this.numberCount.Location = new System.Drawing.Point(142, 224);
            this.numberCount.Name = "numberCount";
            this.numberCount.Size = new System.Drawing.Size(120, 21);
            this.numberCount.TabIndex = 17;
            // 
            // numberParameter1
            // 
            this.numberParameter1.Location = new System.Drawing.Point(142, 265);
            this.numberParameter1.Name = "numberParameter1";
            this.numberParameter1.Size = new System.Drawing.Size(120, 21);
            this.numberParameter1.TabIndex = 18;
            // 
            // cmbGrayList
            // 
            this.cmbGrayList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGrayList.FormattingEnabled = true;
            this.cmbGrayList.Location = new System.Drawing.Point(332, 134);
            this.cmbGrayList.Name = "cmbGrayList";
            this.cmbGrayList.Size = new System.Drawing.Size(121, 20);
            this.cmbGrayList.TabIndex = 19;
            // 
            // cmbVList
            // 
            this.cmbVList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVList.FormattingEnabled = true;
            this.cmbVList.Location = new System.Drawing.Point(332, 180);
            this.cmbVList.Name = "cmbVList";
            this.cmbVList.Size = new System.Drawing.Size(121, 20);
            this.cmbVList.TabIndex = 20;
            // 
            // cmbPrintList
            // 
            this.cmbPrintList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrintList.FormattingEnabled = true;
            this.cmbPrintList.Location = new System.Drawing.Point(332, 226);
            this.cmbPrintList.Name = "cmbPrintList";
            this.cmbPrintList.Size = new System.Drawing.Size(121, 20);
            this.cmbPrintList.TabIndex = 21;
            // 
            // cmbShutdownList
            // 
            this.cmbShutdownList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShutdownList.FormattingEnabled = true;
            this.cmbShutdownList.Location = new System.Drawing.Point(332, 262);
            this.cmbShutdownList.Name = "cmbShutdownList";
            this.cmbShutdownList.Size = new System.Drawing.Size(121, 20);
            this.cmbShutdownList.TabIndex = 22;
            // 
            // cmbFileList
            // 
            this.cmbFileList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFileList.FormattingEnabled = true;
            this.cmbFileList.Location = new System.Drawing.Point(535, 134);
            this.cmbFileList.Name = "cmbFileList";
            this.cmbFileList.Size = new System.Drawing.Size(121, 20);
            this.cmbFileList.TabIndex = 23;
            // 
            // cmbLeaveTime
            // 
            this.cmbLeaveTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLeaveTime.FormattingEnabled = true;
            this.cmbLeaveTime.Location = new System.Drawing.Point(535, 179);
            this.cmbLeaveTime.Name = "cmbLeaveTime";
            this.cmbLeaveTime.Size = new System.Drawing.Size(121, 20);
            this.cmbLeaveTime.TabIndex = 24;
            // 
            // cmbPulseWidth
            // 
            this.cmbPulseWidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPulseWidth.FormattingEnabled = true;
            this.cmbPulseWidth.Location = new System.Drawing.Point(535, 226);
            this.cmbPulseWidth.Name = "cmbPulseWidth";
            this.cmbPulseWidth.Size = new System.Drawing.Size(121, 20);
            this.cmbPulseWidth.TabIndex = 25;
            // 
            // cmbParameter2
            // 
            this.cmbParameter2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParameter2.FormattingEnabled = true;
            this.cmbParameter2.Location = new System.Drawing.Point(535, 266);
            this.cmbParameter2.Name = "cmbParameter2";
            this.cmbParameter2.Size = new System.Drawing.Size(121, 20);
            this.cmbParameter2.TabIndex = 26;
            // 
            // ParameterSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbParameter2);
            this.Controls.Add(this.cmbPulseWidth);
            this.Controls.Add(this.cmbLeaveTime);
            this.Controls.Add(this.cmbFileList);
            this.Controls.Add(this.cmbShutdownList);
            this.Controls.Add(this.cmbPrintList);
            this.Controls.Add(this.cmbVList);
            this.Controls.Add(this.cmbGrayList);
            this.Controls.Add(this.numberParameter1);
            this.Controls.Add(this.numberCount);
            this.Controls.Add(this.numberColDelay);
            this.Controls.Add(this.numberDelay);
            this.Controls.Add(this.btnSettingParameter);
            this.Controls.Add(this.btnReadParameter);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Name = "ParameterSetting";
            this.Size = new System.Drawing.Size(719, 450);
            this.Load += new System.EventHandler(this.ParameterSetting_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberColDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberParameter1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnReadDeviceTime;
        private System.Windows.Forms.Button btnGetSystemTime;
        private System.Windows.Forms.TextBox tbTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnReadParameter;
        private System.Windows.Forms.Button btnSettingParameter;
        private System.Windows.Forms.NumericUpDown numberDelay;
        private System.Windows.Forms.NumericUpDown numberColDelay;
        private System.Windows.Forms.NumericUpDown numberCount;
        private System.Windows.Forms.NumericUpDown numberParameter1;
        private System.Windows.Forms.ComboBox cmbGrayList;
        private System.Windows.Forms.ComboBox cmbVList;
        private System.Windows.Forms.ComboBox cmbPrintList;
        private System.Windows.Forms.ComboBox cmbShutdownList;
        private System.Windows.Forms.ComboBox cmbFileList;
        private System.Windows.Forms.ComboBox cmbLeaveTime;
        private System.Windows.Forms.ComboBox cmbPulseWidth;
        private System.Windows.Forms.ComboBox cmbParameter2;
    }
}
