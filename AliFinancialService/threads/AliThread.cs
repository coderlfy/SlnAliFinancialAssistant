using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AliFinancialService.threads
{
    class AliThread : AbstractThread
    {
        public AliThread(bool enableStop)
            : base(enableStop)
        { 
        
        }
        public override void Start()
        {
            int secondsinterval = 1;
            base.StartWhile(() =>
            {
                //爬取ali利率？？
                //若成功爬取，则走以下代码？？

                if (AliCache._CurrentRate == null)
                    AliCache._CurrentRate = new Ali.Model.CurrentRate();


                
            }, secondsinterval);
        }
    }
}
