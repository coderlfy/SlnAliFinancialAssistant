using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace AliFinancialService
{
    [ServiceContract]
    interface ITest
    {
        [OperationContract]
        string GetString(string value);
    }
}
