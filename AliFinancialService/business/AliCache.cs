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

        public static object _CrawlerDisableRuntimeMode1 = null;
        public static object _CrawlerDisableRuntimeMode2 = null;

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
    }
}
