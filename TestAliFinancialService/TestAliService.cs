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
    }
}
