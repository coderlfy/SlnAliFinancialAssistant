using Foundation.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AliFinancialService.threads
{
    enum ThreadStatus
    { 
        Started,
        Stopped
    }
    abstract class AbstractThread
    {
        /// <summary>
        /// 构造函数设置线程的常开或常闭
        /// </summary>
        /// <param name="enableStop"></param>
        public AbstractThread(bool enableStop)
        {
            _enableStop = enableStop;
        }
        private readonly bool _enableStop;

        private ThreadStatus _status;
        /// <summary>
        /// 线程的当前状态
        /// </summary>
        public ThreadStatus _Status
        {
            get { return _status; }
            set { _status = value; }
        }
        
        public abstract void Start();

        /// <summary>
        /// 开启循环并执行主体功能
        /// </summary>
        /// <param name="method"></param>
        /// <param name="secondsInterval">执行间隔时间</param>
        public void StartWhile(
    System.Windows.Forms.MethodInvoker method,
    int secondsInterval)
        {
            #region
            while (true)
            {
                if (!_enableStop || 
                    _status == ThreadStatus.Started)
                {
                    try
                    {
                        if (method != null)
                            method();
                    }
                    catch (Exception e)
                    {
                        LogInterface.Write(e.ToString());
                    }
                }
                System.Threading.Thread.Sleep(
                    TimeSpan.FromSeconds(secondsInterval));
            }
            #endregion
        }

    }
}
