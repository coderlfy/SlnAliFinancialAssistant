using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AliFinancialService.threads
{
    class IndexThread : AbstractThread
    {
        public IndexThread(bool enableStop)
            : base(enableStop)
        {

        }

        public override void Start()
        {
            int secondsinterval = 3600 * 1/36;
            base.StartWhile(() =>
            {
                LuceneNetHelper.GlobalInfo.ResetIndex();
                AliFinancialService.Index.IndexOpery.CreateIndex();
            }, secondsinterval);
            #region

            #endregion
        }
    }
}
