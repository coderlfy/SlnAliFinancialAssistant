using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fundation.Core
{
    public class AutoStartInformation
    {
        //操作系统用户名
        public string Username = "";
        //操作系统用户密码
        public string Password = "";
        //自动登录标识
        public AutoLogonSystemState AutologonState 
            = AutoLogonSystemState.notStart;
        //程序执行文件路径
        public string exefilepath = "";

        //注册表里 跳过系统登录，系统用户名用户密码的位置
        public const string RegistAutoLogonPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon";
        //系统登录后，自启动程序的位置
        public const string RegistAutoLoadExePath = @"Software\Microsoft\Windows\CurrentVersion\Run";

        //写入注册表的键值
        public const string KeyAutoLogon = "AutoAdminLogon";
        public const string KeyDefaultUserName = "DefaultUserName";
        public const string KeyDefaultPassword = "DefaultPassword";
        public const string KeyAutoloadPath = "CenterServices";


    }
}
