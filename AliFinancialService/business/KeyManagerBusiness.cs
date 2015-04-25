using Foundation.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AliFinancialService
{
    class KeyManagerBusiness
    {

        internal string GetJsonRegisterCode(
            string key, string userInfor)
        {
            JsonHelper jsonhlp = new JsonHelper();
            jsonhlp.AddObjectToJson("success", "true");
            jsonhlp.AddObjectToJson("GenKey", "good");
            return jsonhlp.ToString();
        }
    }
}
