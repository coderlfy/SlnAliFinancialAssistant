namespace AliFinancialService
{
    partial class FrmMain
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.ckbAutoStartService = new System.Windows.Forms.CheckBox();
            this.btnStartService = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ckbAutoStartService
            // 
            this.ckbAutoStartService.AutoSize = true;
            this.ckbAutoStartService.Dock = System.Windows.Forms.DockStyle.Top;
            this.ckbAutoStartService.Location = new System.Drawing.Point(0, 0);
            this.ckbAutoStartService.Name = "ckbAutoStartService";
            this.ckbAutoStartService.Size = new System.Drawing.Size(228, 16);
            this.ckbAutoStartService.TabIndex = 0;
            this.ckbAutoStartService.Text = "程序启动即启动服务";
            this.ckbAutoStartService.UseVisualStyleBackColor = true;
            this.ckbAutoStartService.CheckedChanged += new System.EventHandler(this.ckbAutoStartService_CheckedChanged);
            // 
            // btnStartService
            // 
            this.btnStartService.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStartService.Location = new System.Drawing.Point(0, 16);
            this.btnStartService.Name = "btnStartService";
            this.btnStartService.Size = new System.Drawing.Size(228, 47);
            this.btnStartService.TabIndex = 1;
            this.btnStartService.Text = "开启服务";
            this.btnStartService.UseVisualStyleBackColor = true;
            this.btnStartService.Click += new System.EventHandler(this.btnStartService_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 63);
            this.Controls.Add(this.btnStartService);
            this.Controls.Add(this.ckbAutoStartService);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ckbAutoStartService;
        private System.Windows.Forms.Button btnStartService;
    }
}

