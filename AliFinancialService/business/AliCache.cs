using Ali.Model;
using Foundation.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AliFinancialService
{
    class AliCache
    {
        public const string _KeyNameCrawlerDisableRuntimeMode1 = "CrawlerDisableRuntimeMode1";
        public const string _KeyNameCrawlerDisableRuntimeMode2 = "CrawlerDisableRuntimeMode2";

        public static CurrentRate _CurrentRate = null;

        public static CrawlerRuntime _CrawlerRuntime = null;

        public static object _CrawlerDisableRuntimeMode1 = "2015-4-24 09:30:00~2015-4-24 09:50:00~true";
        public static object _CrawlerDisableRuntimeMode2 = "";

        public static void Get()
        {
            #region
            Config.Get(_KeyNameCrawlerDisableRuntimeMode1, ref _CrawlerDisableRuntimeMode1);
            Config.Get(_KeyNameCrawlerDisableRuntimeMode2, ref _CrawlerDisableRuntimeMode2);

            if (_CrawlerRuntime == null)
            {
                _CrawlerRuntime = new CrawlerRuntime();
                _CrawlerRuntime.GetRuntime(_CrawlerDisableRuntimeMode1, _CrawlerDisableRuntimeMode2);
            }
            #endregion
        }

        public static void Update(
            object disableModeTime1, 
            object disableModeTime2)
        {
            #region            
            Config.Update(_KeyNameCrawlerDisableRuntimeMode1, ref disableModeTime1);
            _CrawlerDisableRuntimeMode1 = disableModeTime1;
            Config.Update(_KeyNameCrawlerDisableRuntimeMode2, ref disableModeTime2);
            _CrawlerDisableRuntimeMode2 = disableModeTime2;
            #endregion
        }
    }
}
