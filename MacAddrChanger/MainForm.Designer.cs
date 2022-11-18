namespace MacAddrChanger
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Btn_Refresh = new System.Windows.Forms.Button();
            this.Btn_Clear = new System.Windows.Forms.Button();
            this.Btn_Update = new System.Windows.Forms.Button();
            this.Cmb_Adapter = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_ChangedMac = new System.Windows.Forms.TextBox();
            this.Btn_RandomGen = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Txt_CurrentMac = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Btn_Refresh
            // 
            this.Btn_Refresh.Location = new System.Drawing.Point(388, 52);
            this.Btn_Refresh.Name = "Btn_Refresh";
            this.Btn_Refresh.Size = new System.Drawing.Size(81, 26);
            this.Btn_Refresh.TabIndex = 16;
            this.Btn_Refresh.Text = "刷新";
            this.Btn_Refresh.UseVisualStyleBackColor = true;
            this.Btn_Refresh.Click += new System.EventHandler(this.Btn_Refresh_Click);
            // 
            // Btn_Clear
            // 
            this.Btn_Clear.Location = new System.Drawing.Point(268, 131);
            this.Btn_Clear.Name = "Btn_Clear";
            this.Btn_Clear.Size = new System.Drawing.Size(201, 29);
            this.Btn_Clear.TabIndex = 15;
            this.Btn_Clear.Text = "清除";
            this.Btn_Clear.UseVisualStyleBackColor = true;
            this.Btn_Clear.Click += new System.EventHandler(this.Btn_Clear_Click);
            // 
            // Btn_Update
            // 
            this.Btn_Update.Location = new System.Drawing.Point(15, 131);
            this.Btn_Update.Name = "Btn_Update";
            this.Btn_Update.Size = new System.Drawing.Size(212, 29);
            this.Btn_Update.TabIndex = 14;
            this.Btn_Update.Text = "应用";
            this.Btn_Update.UseVisualStyleBackColor = true;
            this.Btn_Update.Click += new System.EventHandler(this.Btn_Update_Click);
            // 
            // Cmb_Adapter
            // 
            this.Cmb_Adapter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_Adapter.FormattingEnabled = true;
            this.Cmb_Adapter.Location = new System.Drawing.Point(83, 10);
            this.Cmb_Adapter.Name = "Cmb_Adapter";
            this.Cmb_Adapter.Size = new System.Drawing.Size(386, 25);
            this.Cmb_Adapter.TabIndex = 13;
            this.Cmb_Adapter.SelectedIndexChanged += new System.EventHandler(this.Cmb_Adapter_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "MAC地址（修改）：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "MAC地址（当前）：";
            // 
            // Txt_ChangedMac
            // 
            this.Txt_ChangedMac.Location = new System.Drawing.Point(138, 88);
            this.Txt_ChangedMac.Name = "Txt_ChangedMac";
            this.Txt_ChangedMac.Size = new System.Drawing.Size(231, 23);
            this.Txt_ChangedMac.TabIndex = 10;
            // 
            // Btn_RandomGen
            // 
            this.Btn_RandomGen.Location = new System.Drawing.Point(388, 86);
            this.Btn_RandomGen.Name = "Btn_RandomGen";
            this.Btn_RandomGen.Size = new System.Drawing.Size(81, 26);
            this.Btn_RandomGen.TabIndex = 9;
            this.Btn_RandomGen.Text = "随机生成";
            this.Btn_RandomGen.UseVisualStyleBackColor = true;
            this.Btn_RandomGen.Click += new System.EventHandler(this.Btn_RandomGen_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "网卡：";
            // 
            // Txt_CurrentMac
            // 
            this.Txt_CurrentMac.Location = new System.Drawing.Point(138, 55);
            this.Txt_CurrentMac.Name = "Txt_CurrentMac";
            this.Txt_CurrentMac.ReadOnly = true;
            this.Txt_CurrentMac.Size = new System.Drawing.Size(231, 23);
            this.Txt_CurrentMac.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 184);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Btn_Refresh);
            this.Controls.Add(this.Btn_Clear);
            this.Controls.Add(this.Btn_Update);
            this.Controls.Add(this.Cmb_Adapter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Txt_CurrentMac);
            this.Controls.Add(this.Txt_ChangedMac);
            this.Controls.Add(this.Btn_RandomGen);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mac地址切换工具";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Refresh;
        private System.Windows.Forms.Button Btn_Clear;
        private System.Windows.Forms.Button Btn_Update;
        private System.Windows.Forms.ComboBox Cmb_Adapter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txt_ChangedMac;
        private System.Windows.Forms.Button Btn_RandomGen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Txt_CurrentMac;
    }
}

