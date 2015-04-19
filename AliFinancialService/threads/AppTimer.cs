using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AliFinancialService.threads
{
    class AppTimer : AbstractThread
    {
        private FrmMain _frmMain;

        public FrmMain _FrmMain
        {
            get { return _frmMain; }
            set { _frmMain = value; }
        }

        private static DateTime _currentTime;
        /// <summary>
        /// 数据库服务器的当前时间（此属性只赋值）
        /// </summary>
        public static DateTime _CurrentTime
        {
            set { _currentTime = value; }
        }
        /// <summary>
        /// 获取数据库服务器的当前时间（数据库表在进行保存时调用）
        /// </summary>
        /// <returns></returns>
        public static string GetStringForCurrentTime()
        {
            return _currentTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
        public AppTimer(bool enableStop) 
            : base(enableStop) 
        { 
        
        }

        public override void Start()
        {
            #region
            int secondsinterval = 1;
            base.StartWhile(() => {
                this.controlTimer();
                _currentTime = _currentTime.AddSeconds(secondsinterval);
            }, secondsinterval);
            #endregion
        }

        private void controlTimer()
        {
            #region

            if(_frmMain.InvokeRequired)
            {
                _frmMain.Invoke(new MethodInvoker(() => { 

                    /*
                    _frmMain.lbAppStartTotalSpan.Text 
                        = getSpan(_frmMain.lbAppStartTime);
                        
                    if (base._Status == ThreadStatus.Started)
                        _frmMain.lbCurrentServiceTotalSpan.Text 
                            = getSpan(_frmMain.lbServiceStartTime);
                    */
                }));

            }

            #endregion
        }

        private string getSpan(
            Label startTimeControl)
        {
            #region

            DateTime starttime;
            bool issuccess = DateTime.TryParse(startTimeControl.Text, out starttime);
            //ToDateTime();
            string result = (issuccess) ? new TimeSpan(0, 0, 0,
                            (int)DateTime.Now.Subtract(starttime).TotalSeconds)
                            .ToString() : "未开启";

            return result;

            #endregion
        }
    }
}
