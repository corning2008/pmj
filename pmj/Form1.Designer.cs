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
            this.tbSend = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panelTest = new System.Windows.Forms.Panel();
            this.btnAddText = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxPmj
            // 
            this.comboBoxPmj.FormattingEnabled = true;
            this.comboBoxPmj.Location = new System.Drawing.Point(22, 22);
            this.comboBoxPmj.Name = "comboBoxPmj";
            this.comboBoxPmj.Size = new System.Drawing.Size(121, 20);
            this.comboBoxPmj.TabIndex = 0;
            // 
            // btnOpenPortPmj
            // 
            this.btnOpenPortPmj.Location = new System.Drawing.Point(175, 22);
            this.btnOpenPortPmj.Name = "btnOpenPortPmj";
            this.btnOpenPortPmj.Size = new System.Drawing.Size(75, 23);
            this.btnOpenPortPmj.TabIndex = 1;
            this.btnOpenPortPmj.Text = "打开串口";
            this.btnOpenPortPmj.UseVisualStyleBackColor = true;
            this.btnOpenPortPmj.Click += new System.EventHandler(this.btnOpenPortPmj_Click);
            // 
            // tbSend
            // 
            this.tbSend.Location = new System.Drawing.Point(22, 77);
            this.tbSend.Name = "tbSend";
            this.tbSend.Size = new System.Drawing.Size(100, 21);
            this.tbSend.TabIndex = 2;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(175, 77);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(389, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label1_MouseMove);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label1_MouseUp);
            // 
            // panelTest
            // 
            this.panelTest.AutoScroll = true;
            this.panelTest.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelTest.Location = new System.Drawing.Point(319, 147);
            this.panelTest.Name = "panelTest";
            this.panelTest.Size = new System.Drawing.Size(1378, 169);
            this.panelTest.TabIndex = 5;
            this.panelTest.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTest_Paint);
            // 
            // btnAddText
            // 
            this.btnAddText.Location = new System.Drawing.Point(682, 106);
            this.btnAddText.Name = "btnAddText";
            this.btnAddText.Size = new System.Drawing.Size(75, 23);
            this.btnAddText.TabIndex = 6;
            this.btnAddText.Text = "文本";
            this.btnAddText.UseVisualStyleBackColor = true;
            this.btnAddText.Click += new System.EventHandler(this.btnAddText_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAddText);
            this.Controls.Add(this.panelTest);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.tbSend);
            this.Controls.Add(this.btnOpenPortPmj);
            this.Controls.Add(this.comboBoxPmj);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.ComboBox comboBoxPmj;
        private System.Windows.Forms.Button btnOpenPortPmj;
        private System.Windows.Forms.TextBox tbSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelTest;
        private System.Windows.Forms.Button btnAddText;
    }
}

