using Foundation.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AliFinancialService
{
    partial class WCFService : ITest
    {
        public string GetString(string value)
        {
            Console.Write("接受到的串为：{0}", value);
            return string.Format("{1} 恭喜您测试接口已连通 {0}", value, DateTime.Now);
        }
    }
}
