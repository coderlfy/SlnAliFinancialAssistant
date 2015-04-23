using Foundation.Core;
/****************************************
***创建人：李峰艳
***公司：龙浩通信公司
***内容：自定义系统配置
*****************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AliFinancialService.customize
{
    public class CustomConfig
    {
        public const string _KeyNameServiceURL = "ServiceURL";
        public const string _KeyNameLogDirectory = "LogDirectory";
        public const string _KeyNameEnableAutoStartService = "EnableAutoStartService";
        public const string _IconStatusResourceName = "App.ico";

        public const string _DevCompanyName = "";
        public const string _Developer = "";
        public const string _HelpTelephone = "";
        public const string _DevStartDate = "";
        public const string _AboutSoftware = "";

        private static object _defaultServiceURL = "http://localhost:8733/WCFLibrary/TestService/";
        private static object _logDirectoryName = "logs";
        private static string _appName = "招财宝助手服务";
        private static object _enableAutoStartService = false;

        public static object _ServiceURL
        {
            get { return _defaultServiceURL; }
            set { _defaultServiceURL = value; }
        }

        public static object _EnableAutoStartService
        {
            get { return _enableAutoStartService; }
            set { _enableAutoStartService = value; }
        }

        public static object _LogDirectoryName
        {
            get { return _logDirectoryName; }
            set { _logDirectoryName = value; }
        }
        public static object _ApplicationName
        {
            get { return _appName; }
        }

        public static string _ApplicationVersion
        {
            get { return Assembly.GetExecutingAssembly().GetName().Version.ToString(); }
        }





        public static void Init()
        {
            //Config.Get(_KeyNameServiceURL, ref _defaultServiceURL);
            Config.Get(_KeyNameLogDirectory, ref _logDirectoryName);
            Config.Get(_KeyNameEnableAutoStartService, ref _enableAutoStartService);

            AliCache.Get();
        }
    }
}
