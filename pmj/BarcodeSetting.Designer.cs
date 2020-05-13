namespace pmj
{
    partial class BarcodeSetting
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
            this.tbContent = new System.Windows.Forms.TextBox();
            this.cmbTypeList = new System.Windows.Forms.ComboBox();
            this.cmbSizeList = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbContent
            // 
            this.tbContent.Location = new System.Drawing.Point(103, 48);
            this.tbContent.Name = "tbContent";
            this.tbContent.Size = new System.Drawing.Size(121, 21);
            this.tbContent.TabIndex = 24;
            this.tbContent.Text = "12345";
            this.tbContent.TextChanged += new System.EventHandler(this.ValueChange);
            // 
            // cmbTypeList
            // 
            this.cmbTypeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeList.FormattingEnabled = true;
            this.cmbTypeList.Location = new System.Drawing.Point(103, 136);
            this.cmbTypeList.Name = "cmbTypeList";
            this.cmbTypeList.Size = new System.Drawing.Size(121, 20);
            this.cmbTypeList.TabIndex = 23;
            this.cmbTypeList.SelectedIndexChanged += new System.EventHandler(this.ValueChange);
            // 
            // cmbSizeList
            // 
            this.cmbSizeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSizeList.FormattingEnabled = true;
            this.cmbSizeList.Location = new System.Drawing.Point(103, 89);
            this.cmbSizeList.Name = "cmbSizeList";
            this.cmbSizeList.Size = new System.Drawing.Size(121, 20);
            this.cmbSizeList.TabIndex = 22;
            this.cmbSizeList.SelectedIndexChanged += new System.EventHandler(this.ValueChange);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 21;
            this.label3.Text = "类型:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "大小:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "文本";
            // 
            // BarcodeSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbContent);
            this.Controls.Add(this.cmbTypeList);
            this.Controls.Add(this.cmbSizeList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "BarcodeSetting";
            this.Size = new System.Drawing.Size(589, 370);
            this.Load += new System.EventHandler(this.BarcodeSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbContent;
        private System.Windows.Forms.ComboBox cmbTypeList;
        private System.Windows.Forms.ComboBox cmbSizeList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
