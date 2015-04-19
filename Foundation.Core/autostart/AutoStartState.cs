using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fundation.Core
{

    public class AutoStartState
    {
        private static AutoStartInformation _autoStartInfor
            = new AutoStartInformation();
        /// <summary>
        /// 得到程序自启动的状态
        /// </summary>
        /// <param name="validuser"></param>
        /// <param name="autologin"></param>
        /// <param name="Existfile"></param>
        /// <returns></returns>
        public static String GetAutoLogonStateName(
            AutoStartInformation autoStartInfor)
        {
            #region
            AutoLogonSystemState state;
            _autoStartInfor = autoStartInfor;

            bool validuser = osUserIsValid();
            bool autologin = isAutoLogin();
            bool appexeisexist = isExistExeFile();

            if (autologin && validuser && appexeisexist)
                state = AutoLogonSystemState.isStart;
            else if (!autologin)
                state = AutoLogonSystemState.notStart;
            else if (autologin && (!validuser))
                state = AutoLogonSystemState.Authfaild;
            else
                state = AutoLogonSystemState.registrationfailed;

            return getAutoLogonState(state);
            #endregion
        }

        /// <summary>
        /// 自启动程序状态转换
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        private static string getAutoLogonState(
            AutoLogonSystemState autologonsystemstate)
        {
            #region
            switch (autologonsystemstate)
            {
                case AutoLogonSystemState.isStart:
                    return "已启用";
                case AutoLogonSystemState.notStart:
                    return "未启用";
                case AutoLogonSystemState.Authfaild:
                    return "认证失败";
                case AutoLogonSystemState.registrationfailed:
                    return "自启动注册失败";
                default:
                    return "状态未明";
            }
            #endregion
        }

        /// <summary>
        /// 用注册表信息的用户名密码验证其合法性
        /// </summary>
        /// <returns></returns>
        private static bool osUserIsValid()
        {
            #region
            return (OS.IsValidateCredentials(
                _autoStartInfor.Username,
                _autoStartInfor.Password));
            #endregion
        }

        /// <summary>
        /// 判断操作系统是否自登录
        /// </summary>
        /// <returns></returns>
        private static bool isAutoLogin()
        {
            #region
            return (_autoStartInfor.AutologonState == AutoLogonSystemState.isStart);
            #endregion
        }

        /// <summary>
        /// 判断自启动程序文件是否存在
        /// </summary>
        /// <returns></returns>
        private static bool isExistExeFile()
        {
            #region
            bool fileExist = false;
            string filepath = _autoStartInfor.exefilepath;
            //去掉路径两边的双引号
            if (!string.IsNullOrEmpty(filepath))
                filepath = filepath.Substring(1, filepath.Length - 2);
            if (System.IO.File.Exists(filepath))
                fileExist = true;
            return fileExist;
            #endregion
        }

        /// <summary>
        /// 获取“是否启用自动服务”的描述
        /// </summary>
        /// <param name="isAutoStart"></param>
        /// <returns></returns>
        public static string GetAutoStartServiceStateName
            (bool isAutoStart)
        {
            #region
            return (isAutoStart) ? "已启用" : "未启用";
            #endregion
        }

        /// <summary>
        /// 根据字符串转化自登录状态枚举
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static AutoLogonSystemState GetAutoLogonState(string value)
        {
            #region
            return (value == "1") ? AutoLogonSystemState.isStart : AutoLogonSystemState.notStart;
            #endregion
        }
    }
}
