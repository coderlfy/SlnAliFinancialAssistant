using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace AliFinancialService
{
    [ServiceContract]
    interface IAli
    {
        [OperationContract]
        string GetJsonCurrentRate();

        [OperationContract]
        string GetJsonClawlerDisableTime();
        [OperationContract]
        string SetClawlerDisableTime(
            string timeMode1Str, string timeMode2Str);
        [OperationContract]
        string GetRegisterCode(
            string key, string userInfor);
    }
}
