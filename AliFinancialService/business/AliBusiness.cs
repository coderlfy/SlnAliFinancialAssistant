using Ali.Model;
using Foundation.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AliFinancialService
{
    class AliBusiness
    {

        internal string GetJsonCurrentRate()
        {
            #region
            JsonHelper jsonhlp = new JsonHelper();
            if (AliCache._CurrentRate != null)
            {
                //我这加个注释
                jsonhlp.AddObjectToJson("success", "true");
                //ceshi tijiaott
                CurrentRate rate = AliCache._CurrentRate;
                jsonhlp.AddObjectToJson(CurrentRate.KeyNameFetchTime, rate._FetchTime.ToString("yyyy-MM-dd HH:mm:ss"));
                jsonhlp.AddObjectToJson(CurrentRate.KeyNameMonth1To6, getMonthRate(rate._Month1To6));
                jsonhlp.AddObjectToJson(CurrentRate.KeyNameMonth6To12, getMonthRate(rate._Month6To12));
                jsonhlp.AddObjectToJson(CurrentRate.KeyNameMonth12To24, getMonthRate(rate._Month12To24));
                return jsonhlp.ToString();
            }
            else
                return JsonHelper.GetErrorJson("服务器暂未获取成功阿里招财宝利率！");
            #endregion

        }

        private string getMonthRate(decimal rate)
        {
            #region
            return string.Format("{0}%", rate);
            #endregion
        }

        internal string GetJsonClawlerDisableTime()
        {
            #region
            JsonHelper jsonhlp = new JsonHelper();
            jsonhlp.AddObjectToJson("success", "true");
            jsonhlp.AddObjectToJson(AliCache._KeyNameCrawlerDisableRuntimeMode1,
                AliCache._CrawlerDisableRuntimeMode1 == null ? "" : AliCache._CrawlerDisableRuntimeMode1.ToString());
            jsonhlp.AddObjectToJson(AliCache._KeyNameCrawlerDisableRuntimeMode2,
                AliCache._CrawlerDisableRuntimeMode2 == null ? "" : AliCache._CrawlerDisableRuntimeMode2.ToString());
            return jsonhlp.ToString();
            #endregion
        }

        internal string SetClawlerDisableTime(
            string timeMode1Str, string timeMode2Str)
        {
            #region
            AliCache.Update(timeMode1Str, timeMode2Str);
            AliCache._CrawlerRuntime.GetRuntime(timeMode1Str, timeMode2Str);
            Console.WriteLine("这都成功了");
            return JsonHelper.GetOnlySucessJson(true);
            #endregion
        }
    }
}
