using Foundation.Core;
using AliFinancialService.customize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AliFinancialService
{
    public partial class FrmMain
    {
        private void setTitle()
        {
            #region
            string appfullname = string.Format("{0} V{1}",
                CustomConfig._ApplicationName,
                CustomConfig._ApplicationVersion);

            this.Text = appfullname;
            #endregion
        }

        public void InitUI()
        {
            #region
            this.setTitle();
            this.setStatusIcon();

            //this.lbAppStartTime.Text = DateTime.Now.ToString();
            this.ckbAutoStartService.Checked = Convert.ToBoolean(
                CustomConfig._EnableAutoStartService);
            #endregion
        }

        private void setStatusIcon()
        {
            #region
            WinIconStatus statusicon = new WinIconStatus("app.ico");
            statusicon.SetIconStatusMode(IconStatusMode.Normal);
            statusicon.BindToWindow(this);
            #endregion
        }

    }
}
