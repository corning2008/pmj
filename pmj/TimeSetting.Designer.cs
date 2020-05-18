namespace pmj
{
    partial class TimeSetting
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbStyle = new System.Windows.Forms.ComboBox();
            this.cmbFontSize = new System.Windows.Forms.ComboBox();
            this.cmdFont = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.yearOffset = new System.Windows.Forms.NumericUpDown();
            this.monthOffset = new System.Windows.Forms.NumericUpDown();
            this.dayOffset = new System.Windows.Forms.NumericUpDown();
            this.hourOffset = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.yearOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dayOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hourOffset)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "样式:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "字号:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "字体:";
            // 
            // cmbStyle
            // 
            this.cmbStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStyle.FormattingEnabled = true;
            this.cmbStyle.Location = new System.Drawing.Point(87, 35);
            this.cmbStyle.Name = "cmbStyle";
            this.cmbStyle.Size = new System.Drawing.Size(121, 20);
            this.cmbStyle.TabIndex = 3;
            this.cmbStyle.SelectedIndexChanged += new System.EventHandler(this.cmbStyle_SelectedIndexChanged);
            // 
            // cmbFontSize
            // 
            this.cmbFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFontSize.FormattingEnabled = true;
            this.cmbFontSize.Location = new System.Drawing.Point(87, 79);
            this.cmbFontSize.Name = "cmbFontSize";
            this.cmbFontSize.Size = new System.Drawing.Size(121, 20);
            this.cmbFontSize.TabIndex = 4;
            this.cmbFontSize.SelectedIndexChanged += new System.EventHandler(this.cmbFontSize_SelectedIndexChanged);
            // 
            // cmdFont
            // 
            this.cmdFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdFont.FormattingEnabled = true;
            this.cmdFont.Location = new System.Drawing.Point(87, 126);
            this.cmdFont.Name = "cmdFont";
            this.cmdFont.Size = new System.Drawing.Size(121, 20);
            this.cmdFont.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(364, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "时间偏移量";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(322, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "年";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(322, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "月";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(322, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "日";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(322, 174);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 10;
            this.label8.Text = "时";
            // 
            // yearOffset
            // 
            this.yearOffset.Location = new System.Drawing.Point(366, 35);
            this.yearOffset.Name = "yearOffset";
            this.yearOffset.Size = new System.Drawing.Size(120, 21);
            this.yearOffset.TabIndex = 11;
            // 
            // monthOffset
            // 
            this.monthOffset.Location = new System.Drawing.Point(366, 80);
            this.monthOffset.Name = "monthOffset";
            this.monthOffset.Size = new System.Drawing.Size(120, 21);
            this.monthOffset.TabIndex = 12;
            // 
            // dayOffset
            // 
            this.dayOffset.Location = new System.Drawing.Point(366, 129);
            this.dayOffset.Name = "dayOffset";
            this.dayOffset.Size = new System.Drawing.Size(120, 21);
            this.dayOffset.TabIndex = 13;
            // 
            // hourOffset
            // 
            this.hourOffset.Location = new System.Drawing.Point(366, 172);
            this.hourOffset.Name = "hourOffset";
            this.hourOffset.Size = new System.Drawing.Size(120, 21);
            this.hourOffset.TabIndex = 14;
            // 
            // TimeSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hourOffset);
            this.Controls.Add(this.dayOffset);
            this.Controls.Add(this.monthOffset);
            this.Controls.Add(this.yearOffset);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdFont);
            this.Controls.Add(this.cmbFontSize);
            this.Controls.Add(this.cmbStyle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TimeSetting";
            this.Size = new System.Drawing.Size(606, 343);
            this.Load += new System.EventHandler(this.TimeSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.yearOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dayOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hourOffset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbStyle;
        private System.Windows.Forms.ComboBox cmbFontSize;
        private System.Windows.Forms.ComboBox cmdFont;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown yearOffset;
        private System.Windows.Forms.NumericUpDown monthOffset;
        private System.Windows.Forms.NumericUpDown dayOffset;
        private System.Windows.Forms.NumericUpDown hourOffset;
    }
}
