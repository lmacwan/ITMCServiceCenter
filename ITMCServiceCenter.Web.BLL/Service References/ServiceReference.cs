using System;
using ITMCServiceCenter.Web.Domain;

namespace ITMCServiceCenter.Web.BLL
{
    public static class ServiceReference
    {
        /// <summary>
        /// Configurable AuthenticationServiceUri (read from calling project (i.e FLSmidth.ICLCom.Web.UI))
        /// </summary>
        private static string ITMCServiceUri
        {
            get
            {
                return Convert.ToString("http://localhost/ITMCServiceCenter.Web.Services/Services/ITMC/ITMCService.svc");
                //return Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["ITMCServiceUri"]);
            }
        }
            
        /// <summary>
        /// Get AuthenticationServiceClient
        /// </summary>
        private static ITMCServiceCenter.Web.BLL.ITMCServiceReference.ITMCServiceClient _ITMCServiceClient;
        public static ITMCServiceCenter.Web.BLL.ITMCServiceReference.ITMCServiceClient ITMCServiceClient
        {
            get
            {
                if (_ITMCServiceClient == null)
                {
                    System.ServiceModel.EndpointAddress address = new System.ServiceModel.EndpointAddress(ITMCServiceUri);
                    System.ServiceModel.BasicHttpBinding binding = new System.ServiceModel.BasicHttpBinding(System.ServiceModel.BasicHttpSecurityMode.None);
                    binding.MaxReceivedMessageSize = Int32.MaxValue;

                    binding.CloseTimeout = new TimeSpan(0, 30, 0);
                    binding.OpenTimeout = new TimeSpan(0, 30, 0);
                    binding.ReceiveTimeout = new TimeSpan(0, 30, 0);
                    binding.SendTimeout = new TimeSpan(0, 30, 0);

                    _ITMCServiceClient = new ITMCServiceCenter.Web.BLL.ITMCServiceReference.ITMCServiceClient(binding, address);
                }
                return _ITMCServiceClient;
            }
        }
    }
}
