using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AliFinancialService.threads
{
    class TestBusinessThread : AbstractThread
    {
        public TestBusinessThread(bool enableStop)
            : base(enableStop)
        { 
        
        }
        public override void Start()
        {
            #region
            //int i = 0;
            base.StartWhile(() => {
                //Console.WriteLine("work thread value = {0}", i++);
            }, 1);
            #endregion
        }
    }
}
