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
            int secondsinterval = 60;
            base.StartWhile(() =>
            {
                //爬取ali利率？？
                //若成功爬取，则走以下代码？？
                //if(成功条件)
                //{ 
                List<decimal> data = UtliHelper.PayHelper.GetPayInfo();
                if (data != null)
                {
                    if (AliCache._CurrentRate == null)
                        AliCache._CurrentRate = new Ali.Model.CurrentRate();
                    AliCache._CurrentRate._FetchTime = DateTime.Now;
                    AliCache._CurrentRate._Month1To6 = data[1];
                    AliCache._CurrentRate._Month6To12 = data[2];
                    AliCache._CurrentRate._Month12To24 = data[3];
                }
                //}

            }, secondsinterval);
        }
    }
}
