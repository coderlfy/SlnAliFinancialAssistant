using AliFinancialService.customize;
using Foundation.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AliFinancialService
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            OSProcess.HasSingle();
            CustomConfig.Init();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LogInterface.Listen(CustomConfig._LogDirectoryName.ToString());
 
            Application.Run(new FrmMain());
        }
    }
}
