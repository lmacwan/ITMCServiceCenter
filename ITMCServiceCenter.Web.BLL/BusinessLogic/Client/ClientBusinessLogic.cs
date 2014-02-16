using ITMCServiceCenter.Web.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ITMCServiceCenter.Web.BLL
{
    public class ClientBusinessLogic
    {
        #region Data Members
        private static List<tbl_Client_DTO> AllClients { get; set; }
        #endregion

        #region Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<tbl_Client_DTO> GetClients()
        {
            return AllClients ?? _GetAllClients();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static tbl_Client_DTO GetClient(int clientId)
        {
            var allClients = AllClients ?? _GetAllClients();
            return allClients.Find(client => client.Id == clientId);
        }
        #endregion

        #region Instance Methods
        /// <summary>
        /// Save New Client Details to Web Service.
        /// </summary>
        /// <param name="tbl_Client_DTO"></param>
        /// <returns></returns>
        public int SaveClient(tbl_Client_DTO tbl_Client_DTO)
        {
            var clientId = -1;
            if (Validate(tbl_Client_DTO))
            {
                var clientDetails = ServiceReference.ITMCServiceClient.SaveClient(tbl_Client_DTO);
                if (clientDetails.Success)
                {
                    AllClients.Add(tbl_Client_DTO);
                    clientId = clientDetails.Value;
                }
            }
            return clientId;
        }

        /// <summary>
        /// send updated values of client to webservice for storing into database.
        /// </summary>
        /// <param name="tbl_Client_DTO"></param>
        /// <returns>returns true if values updated successfully else false.</returns>
        public bool UpdateClient(tbl_Client_DTO tbl_Client_DTO)
        {
            var isUpdated = false;
            if (Validate(tbl_Client_DTO))
            {
                var clientDetails = ServiceReference.ITMCServiceClient.UpdateClient(tbl_Client_DTO);
                if (clientDetails.Success)
                {
                    AllClients.Remove(AllClients.Find(client => client.Id == tbl_Client_DTO.Id));
                    AllClients.Add(tbl_Client_DTO);
                    isUpdated = clientDetails.Value;
                }
            }
            return isUpdated;
        }

        /// <summary>
        /// send client id that is to be deleted to webservice so that it can delete client record from database.
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public bool DeleteClient(int clientId)
        {
            var isDeleted = false;
            var clientDetails = ServiceReference.ITMCServiceClient.DeleteClient(clientId);
            if (clientDetails.Success)
            {
                isDeleted = clientDetails.Value;
                if (isDeleted)
                {
                    AllClients.Remove(AllClients.Find(client => client.Id == clientId));
                }
            }
            return isDeleted;
        }

        /// <summary>
        /// used for validation
        /// </summary>
        /// <param name="clientDto"></param>
        /// <returns></returns>
        private bool Validate(tbl_Client_DTO clientDto)
        {
            if (clientDto == null)
            {
                clientDto = new tbl_Client_DTO();
            }
            return clientDto.IsValid;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Returns list of clients from web service.
        /// </summary>
        /// <returns></returns>
        private static List<tbl_Client_DTO> _GetAllClients()
        {
            List<tbl_Client_DTO> result = new List<tbl_Client_DTO>();
            var clientDetails = ServiceReference.ITMCServiceClient.GetClients();
            if (clientDetails.Success)
            {
                result = clientDetails.Value.ToList();
                if (AllClients == null && result.Count > 0)
                {
                    AllClients = result;
                }
            }
            return result;
        }
        #endregion
    }
}
