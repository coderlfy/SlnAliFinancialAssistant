using CustomSpring.Core;
using NormalDocumentOffice.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AliFinancialService.threads
{
    class DBTimerThread : AbstractThread
    {
        public DBTimerThread(bool enableStop)
            : base(enableStop)
        { 
        
        }

        private IDBManagerService _dbManagerService
    = (IDBManagerService)SpringManager.GetObject(SpringKeys.DBManagerService);


        public override void Start()
        {
            #region
            int minutesinterval = 10;
            base.StartWhile(() =>
            {
                AppTimer._CurrentTime = this._dbManagerService.GetDBCurrentTime();
            }, minutesinterval);
            #endregion
        }
    }
}
