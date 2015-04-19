using AliFinancialService.customize;
using AliFinancialService.threads;
using AliFinancialService.wcfhost;
using Foundation.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AliFinancialService
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(
            object sender, EventArgs e)
        {
            this.InitUI();
            ThreadManager.InitThreads(this);

            if (this.ckbAutoStartService.Checked)
                btnStartService_Click(null, null);
            else
                setControls(false);

        }

        private void setControls(bool p)
        {
            this.btnStartService.Enabled = (!p);
        }

        private void btnStartService_Click(
            object sender, EventArgs e)
        {
            ThreadManager.StartAll();
            Host.Start();
            this.btnStartService.Enabled = false;
        }

        private void ckbAutoStartService_CheckedChanged(
            object sender, EventArgs e)
        {
            object enable = this.ckbAutoStartService.Checked;
            Config.Update(CustomConfig._KeyNameEnableAutoStartService, ref enable);
            CustomConfig._EnableAutoStartService = enable;

        }
    }
}
