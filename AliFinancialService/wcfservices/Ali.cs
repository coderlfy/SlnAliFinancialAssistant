﻿using Foundation.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AliFinancialService
{
    partial class WCFService : IAli
    {
        public string GetJsonCurrentRate()
        {

            return JsonException.Wrap(() =>
            {
                return new AliBusiness()
                    .GetJsonCurrentRate();
            });

            /*
            Console.Write("接受到的串为：{0}", value);
            return string.Format("{1} 恭喜您测试接口已连通 {0}", value, DateTime.Now);
             * */
        }


        public string GetJsonClawlerDisableTime()
        {
            return JsonException.Wrap(() =>
            {
                return new AliBusiness()
                    .GetJsonClawlerDisableTime();
            });
        }


        public string SetClawlerDisableTime(
            string timeMode1Str, string timeMode2Str)
        {
            return JsonException.Wrap(() =>
            {
                Console.WriteLine("{0}配置了禁止爬取网站参数！", DateTime.Now);
                return new AliBusiness()
                    .SetClawlerDisableTime(timeMode1Str, timeMode2Str);
            });
        }


        public string GetRegisterCode(
            string key, string userInfor)
        {
            return JsonException.Wrap(() =>
            {
                Console.WriteLine("{0}用户生成了key！", DateTime.Now);

                Console.WriteLine("userInfor={0}！", userInfor);
                return new KeyManagerBusiness()
                    .GetJsonRegisterCode(key, userInfor);
            });
        }
    }
}
