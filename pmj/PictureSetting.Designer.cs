namespace pmj
{
    partial class PictureSetting
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
            this.panelPicSetting = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.picWidth = new System.Windows.Forms.NumericUpDown();
            this.picHeight = new System.Windows.Forms.NumericUpDown();
            this.panelBitmap = new System.Windows.Forms.Panel();
            this.picBitmap = new System.Windows.Forms.PictureBox();
            this.panelBack = new System.Windows.Forms.Panel();
            this.btnSize = new System.Windows.Forms.Button();
            this.panelPicSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHeight)).BeginInit();
            this.panelBitmap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBitmap)).BeginInit();
            this.panelBack.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPicSetting
            // 
            this.panelPicSetting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPicSetting.Controls.Add(this.picHeight);
            this.panelPicSetting.Controls.Add(this.picWidth);
            this.panelPicSetting.Controls.Add(this.label2);
            this.panelPicSetting.Controls.Add(this.label1);
            this.panelPicSetting.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelPicSetting.Location = new System.Drawing.Point(506, 0);
            this.panelPicSetting.Name = "panelPicSetting";
            this.panelPicSetting.Size = new System.Drawing.Size(135, 323);
            this.panelPicSetting.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "图片宽度";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "图片高度";
            // 
            // picWidth
            // 
            this.picWidth.Location = new System.Drawing.Point(16, 42);
            this.picWidth.Name = "picWidth";
            this.picWidth.Size = new System.Drawing.Size(95, 21);
            this.picWidth.TabIndex = 2;
            this.picWidth.ValueChanged += new System.EventHandler(this.picWidth_ValueChanged);
            // 
            // picHeight
            // 
            this.picHeight.Location = new System.Drawing.Point(16, 108);
            this.picHeight.Name = "picHeight";
            this.picHeight.Size = new System.Drawing.Size(95, 21);
            this.picHeight.TabIndex = 3;
            this.picHeight.ValueChanged += new System.EventHandler(this.picHeight_ValueChanged);
            // 
            // panelBitmap
            // 
            this.panelBitmap.AutoScroll = true;
            this.panelBitmap.Controls.Add(this.panelBack);
            this.panelBitmap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBitmap.Location = new System.Drawing.Point(0, 0);
            this.panelBitmap.Name = "panelBitmap";
            this.panelBitmap.Size = new System.Drawing.Size(506, 323);
            this.panelBitmap.TabIndex = 1;
            // 
            // picBitmap
            // 
            this.picBitmap.Location = new System.Drawing.Point(34, 109);
            this.picBitmap.Name = "picBitmap";
            this.picBitmap.Size = new System.Drawing.Size(100, 50);
            this.picBitmap.TabIndex = 0;
            this.picBitmap.TabStop = false;
            // 
            // panelBack
            // 
            this.panelBack.Controls.Add(this.btnSize);
            this.panelBack.Controls.Add(this.picBitmap);
            this.panelBack.Location = new System.Drawing.Point(0, 0);
            this.panelBack.Name = "panelBack";
            this.panelBack.Size = new System.Drawing.Size(220, 203);
            this.panelBack.TabIndex = 2;
            // 
            // btnSize
            // 
            this.btnSize.BackColor = System.Drawing.Color.Transparent;
            this.btnSize.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnSize.ForeColor = System.Drawing.Color.Transparent;
            this.btnSize.Location = new System.Drawing.Point(65, 26);
            this.btnSize.Name = "btnSize";
            this.btnSize.Size = new System.Drawing.Size(50, 50);
            this.btnSize.TabIndex = 3;
            this.btnSize.UseVisualStyleBackColor = false;
            this.btnSize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSize_MouseMove);
            // 
            // PictureSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelBitmap);
            this.Controls.Add(this.panelPicSetting);
            this.Name = "PictureSetting";
            this.Size = new System.Drawing.Size(641, 323);
            this.panelPicSetting.ResumeLayout(false);
            this.panelPicSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHeight)).EndInit();
            this.panelBitmap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBitmap)).EndInit();
            this.panelBack.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPicSetting;
        private System.Windows.Forms.NumericUpDown picHeight;
        private System.Windows.Forms.NumericUpDown picWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelBitmap;
        private System.Windows.Forms.PictureBox picBitmap;
        private System.Windows.Forms.Panel panelBack;
        private System.Windows.Forms.Button btnSize;
    }
}
