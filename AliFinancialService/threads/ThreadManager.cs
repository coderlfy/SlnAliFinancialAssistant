﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AliFinancialService.threads
{
    class ThreadManager
    {
        private static IList<AbstractThread> _threads = null;
        /*
        private static TcpServerEx _tcpFlashAuthServer = null;
        public static TcpServerEx _tcpMsgServer = null;
        */
        /// <summary>
        /// 
        /// </summary>
        public static void StartAll()
        {
            #region
            foreach (AbstractThread thd in _threads)
                thd._Status = ThreadStatus.Started;


            #endregion
        }
        public static void StopAll()
        {
            #region
            foreach (AbstractThread thd in _threads)
                thd._Status = ThreadStatus.Stopped;
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        public static void InitThreads(FrmMain frmMain)
        {
            #region
            if (_threads == null)
            {
                _threads = new List<AbstractThread>();

                /*
                _threads.Add(new AppTimer(false)
                {
                    _FrmMain = frmMain
                });
                _threads.Add(new DBTimerThread(false));
                 * */

                _threads.Add(new AliThread(false));
                foreach (AbstractThread thd in _threads)
                {
                    Thread temp = new Thread(new ThreadStart(thd.Start));
                    temp.IsBackground = true;
                    temp.Start();
                }
            }
            /*
            if (_tcpFlashAuthServer == null)
            {
                _tcpFlashAuthServer = new TcpServerEx();
                _tcpFlashAuthServer._Receiver = new FlashAuthSwitcher();
            }
            if (_tcpMsgServer == null)
            {
                _tcpMsgServer = new TcpServerEx();
                _tcpMsgServer._Receiver = new WSServerSwitcher();
            }
             * */
            #endregion
        }
    }
}
