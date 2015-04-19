using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;

namespace AliFinancialService
{
    class CustomBehavior
    {
        public static void Add(ServiceHost host)
        {
            #region
            ServiceMetadataBehavior smb = host.Description.Behaviors.Find<ServiceMetadataBehavior>();
            if (smb == null)
            {
                Console.WriteLine("smb = null");
                host.Description.Behaviors.Add(new ServiceMetadataBehavior() { 
                    HttpGetEnabled = true,
                HttpsGetEnabled = true});
}
            host.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), "mex");
            #endregion
        }
    }
}
