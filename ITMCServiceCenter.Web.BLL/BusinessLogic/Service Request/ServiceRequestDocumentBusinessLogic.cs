using ITMCServiceCenter.Web.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ITMCServiceCenter.Web.BLL
{
    public class ServiceRequestDocumentBusinessLogic
    {
        #region Methods
        /// <summary>
        /// Calls the service and gets all documents for a given service request from databse
        /// </summary>
        /// <param name="id">Service request id</param>
        /// <returns>List of service request documents</returns>
        public List<tbl_ServiceRequestDocument_DTO> GetServiceRequestDocuments(int requestId)
        {
            var documentDetails = ServiceReference.ITMCServiceClient.GetServiceRequestDocumentsByRequestId(requestId);
            if (documentDetails.Success)
            {
                return documentDetails.Value.ToList();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Calls the service and gets a single service request document from database
        /// </summary>
        /// <param name="actionId">Service request document id</param>
        /// <returns>List of service request documents</returns>
        public tbl_ServiceRequestDocument_DTO GetServiceRequestDocument(int documentId)
        {
            var documentDetails = ServiceReference.ITMCServiceClient.GetServiceRequestDocument(documentId);
            if (documentDetails.Success)
            {
                return documentDetails.Value;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Calls the service and gets all documents for all service requests from database
        /// </summary>
        /// <returns>List of service request documents</returns>
        public List<tbl_ServiceRequestDocument_DTO> GetServiceRequestDocuments()
        {
            var documentDetails = ServiceReference.ITMCServiceClient.GetServiceRequestDocuments();
            if (documentDetails.Success)
            {
                return documentDetails.Value.ToList();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Validates service request document
        /// </summary>
        /// <param name="actionDTO">Service request documnet</param>
        /// <returns>Service request document with additional error data, if present</returns>
        private tbl_ServiceRequestDocument_DTO Validate(tbl_ServiceRequestDocument_DTO documentDTO)
        {
            if (documentDTO == null)
            {
                documentDTO = new tbl_ServiceRequestDocument_DTO();
            }
            return documentDTO;
        }
        #endregion
    }
}