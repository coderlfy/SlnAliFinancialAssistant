using AliFinancialService.customize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;

namespace AliFinancialService.wcfhost
{
    public class Host
    {
        private static ServiceHost _host = null;
        private static List<Uri> getUris()
        {
            List<Uri> uris = new List<Uri>();
            string[] interfacenames = new string[2] { "Test", "OfficeDocumentType" };

            foreach (string i in interfacenames)
                uris.Add(new Uri(string.Format("{0}{1}", CustomConfig._ServiceURL, i)));
            return uris;
        }
        public static void Start()
        {
            #region
            if (_host == null)
            {

                Uri[] uris = getUris().ToArray();

                _host = new ServiceHost(typeof(WCFService));

                //addServiceEndPoint(typeof(ITest), uris[0]);
                //addServiceEndPoint(typeof(IOfficeDocumentType), uris[1]);
                //CustomBehavior.Add(_host);
            }

            if(_host.State != CommunicationState.Opened)
            {
                _host.Open();
                Console.WriteLine("WCF Service开启成功！当前时间：{0}", DateTime.Now);

            }
            #endregion
        }

        private static void addServiceEndPoint(
            Type interfaceType, Uri interfaceName)
        {
            #region
            _host.AddServiceEndpoint(
                interfaceType,
                getHttpBinding(),
                interfaceName);
            #endregion
        }

        private static WSHttpBinding getWebHttpBinding()
        {
            #region
            
            WSHttpBinding httpbinding = new WSHttpBinding();

            WSHttpSecurity security = new WSHttpSecurity();
            security.Mode = SecurityMode.None;
            httpbinding.Security = security;
            httpbinding.MaxBufferPoolSize = 2147483647;
            httpbinding.MaxReceivedMessageSize = 2147483647;

            return httpbinding;
            #endregion
        }

        private static BasicHttpBinding getHttpBinding()
        {
            #region
            BasicHttpBinding httpbinding = new BasicHttpBinding();
            BasicHttpSecurity security = new BasicHttpSecurity();
            security.Mode = BasicHttpSecurityMode.None;
            httpbinding.Security = security;
            httpbinding.MaxBufferSize = 2147483647;
            httpbinding.MaxReceivedMessageSize = 2147483647;

            return httpbinding;
            #endregion
        }

        private static NetTcpBinding getTcpBinding()
        {
            #region
            NetTcpBinding tcpbinding = new NetTcpBinding();
            NetTcpSecurity security = new NetTcpSecurity();
            security.Mode = SecurityMode.None;
            tcpbinding.Security = security;
            tcpbinding.MaxBufferSize = 2147483647;
            tcpbinding.MaxReceivedMessageSize = 2147483647;

            return tcpbinding;
            #endregion
        }

        public static void Stop()
        {
            #region
            if(_host != null)
            { 
                if (_host.State == CommunicationState.Opened)
                {
                    _host.Close();
                    Console.WriteLine("WCF Service停止运行！当前时间：{0}", DateTime.Now);
                }
                _host = null;
            }
            #endregion
        }
    }
}
