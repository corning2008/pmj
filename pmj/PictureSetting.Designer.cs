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
            this.numberScale = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.picHeight = new System.Windows.Forms.NumericUpDown();
            this.picWidth = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelBitmap = new System.Windows.Forms.Panel();
            this.panelBack = new System.Windows.Forms.Panel();
            this.btnSize = new System.Windows.Forms.Button();
            this.picBitmap = new System.Windows.Forms.PictureBox();
            this.panelPicSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWidth)).BeginInit();
            this.panelBitmap.SuspendLayout();
            this.panelBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBitmap)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPicSetting
            // 
            this.panelPicSetting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPicSetting.Controls.Add(this.numberScale);
            this.panelPicSetting.Controls.Add(this.label3);
            this.panelPicSetting.Controls.Add(this.picHeight);
            this.panelPicSetting.Controls.Add(this.picWidth);
            this.panelPicSetting.Controls.Add(this.label2);
            this.panelPicSetting.Controls.Add(this.label1);
            this.panelPicSetting.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelPicSetting.Location = new System.Drawing.Point(506, 0);
            this.panelPicSetting.Name = "panelPicSetting";
            this.panelPicSetting.Size = new System.Drawing.Size(135, 323);
            this.panelPicSetting.TabIndex = 0;
            this.panelPicSetting.Paint += new System.Windows.Forms.PaintEventHandler(this.panelPicSetting_Paint);
            // 
            // numberScale
            // 
            this.numberScale.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numberScale.Location = new System.Drawing.Point(16, 181);
            this.numberScale.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numberScale.Name = "numberScale";
            this.numberScale.Size = new System.Drawing.Size(95, 21);
            this.numberScale.TabIndex = 5;
            this.numberScale.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numberScale.ValueChanged += new System.EventHandler(this.numberScale_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "百分比";
            // 
            // picHeight
            // 
            this.picHeight.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.picHeight.Location = new System.Drawing.Point(16, 108);
            this.picHeight.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.picHeight.Name = "picHeight";
            this.picHeight.Size = new System.Drawing.Size(95, 21);
            this.picHeight.TabIndex = 3;
            this.picHeight.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.picHeight.ValueChanged += new System.EventHandler(this.picHeight_ValueChanged);
            // 
            // picWidth
            // 
            this.picWidth.Location = new System.Drawing.Point(16, 42);
            this.picWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.picWidth.Name = "picWidth";
            this.picWidth.Size = new System.Drawing.Size(95, 21);
            this.picWidth.TabIndex = 2;
            this.picWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.picWidth.ValueChanged += new System.EventHandler(this.picWidth_ValueChanged);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "图片宽度";
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
            this.btnSize.Size = new System.Drawing.Size(32, 32);
            this.btnSize.TabIndex = 3;
            this.btnSize.UseVisualStyleBackColor = false;
            this.btnSize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSize_MouseMove);
            // 
            // picBitmap
            // 
            this.picBitmap.Location = new System.Drawing.Point(34, 109);
            this.picBitmap.Name = "picBitmap";
            this.picBitmap.Size = new System.Drawing.Size(100, 50);
            this.picBitmap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBitmap.TabIndex = 0;
            this.picBitmap.TabStop = false;
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
            ((System.ComponentModel.ISupportInitialize)(this.numberScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWidth)).EndInit();
            this.panelBitmap.ResumeLayout(false);
            this.panelBack.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBitmap)).EndInit();
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
        private System.Windows.Forms.NumericUpDown numberScale;
        private System.Windows.Forms.Label label3;
    }
}
