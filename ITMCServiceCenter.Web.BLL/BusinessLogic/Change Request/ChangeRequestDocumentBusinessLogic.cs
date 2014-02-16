using ITMCServiceCenter.Web.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ITMCServiceCenter.Web.BLL
{
    public class ChangeRequestDocumentBusinessLogic
    {
        #region Methods
        /// <summary>
        /// Calls the service and gets all documents for a given change request from databse
        /// </summary>
        /// <param name="id">Change request id</param>
        /// <returns>List of change request documents</returns>
        public List<tbl_ChangeRequestDocument_DTO> GetChangeRequestDocumentsByRequestId(int requestId)
        {
            var documentDetails = ServiceReference.ITMCServiceClient.GetChangeRequestDocumentsByRequestId(requestId);
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
        /// Calls the service and gets a single change request document from database
        /// </summary>
        /// <param name="actionId">Change request document id</param>
        /// <returns>List of change request documents</returns>
        public tbl_ChangeRequestDocument_DTO GetChangeRequestDocument(int documentId)
        {
            var documentDetails = ServiceReference.ITMCServiceClient.GetChangeRequestDocument(documentId);
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
        /// Calls the service and gets all documents for all change requests from database
        /// </summary>
        /// <returns>List of change request documents</returns>
        public List<tbl_ChangeRequestDocument_DTO> GetChangeRequestDocuments()
        {
            var documentDetails = ServiceReference.ITMCServiceClient.GetChangeRequestDocuments();
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
        /// Validates change request document
        /// </summary>
        /// <param name="actionDTO">Change request documnet</param>
        /// <returns>Change request document with additional error data, if present</returns>
        private tbl_ChangeRequestDocument_DTO Validate(tbl_ChangeRequestDocument_DTO documentDTO)
        {
            if (documentDTO == null)
            {
                documentDTO = new tbl_ChangeRequestDocument_DTO();
            }
            return documentDTO;
        }
        #endregion
    }
}
