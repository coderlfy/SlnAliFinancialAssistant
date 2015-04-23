using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestAliFinancialService
{
    
    class TestAliService
    {
        [Test]
        public void TestGetCurrentRate()
        {
            AliService.AliClient aliclient = new AliService.AliClient();
            Console.WriteLine(aliclient.GetJsonCurrentRate());

        }
        [Test]
        public void TestGetDisableClawlerTime()
        {
            AliService.AliClient aliclient = new AliService.AliClient();
            Console.WriteLine(aliclient.GetJsonClawlerDisableTime());

        }
        [Test]
        public void TestSetDisableClawlerTime()
        {
            AliService.AliClient aliclient = new AliService.AliClient();
            Console.WriteLine(aliclient.SetClawlerDisableTime("", "2015-04-24 09:30:00~5~true"));

        }
    }
}
