using ITMCServiceCenter.Web.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ITMCServiceCenter.Web.BLL
{
    public class IssueDocumentBusinessLogic
    {
        #region Methods
        /// <summary>
        /// Calls the service and gets all documents for a given issue from databse
        /// </summary>
        /// <param name="id">Issue id</param>
        /// <returns>List of issue documents</returns>
        public List<tbl_IssueTrackerDocument_DTO> GetIssueDocumentsByIssueId(int issueId)
        {
            var documentDetails = ServiceReference.ITMCServiceClient.GetIssueDocumentsByIssueId(issueId);
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
        /// Calls the service and gets a single issue document from database
        /// </summary>
        /// <param name="actionId">Issue document id</param>
        /// <returns>Issue document</returns>
        public tbl_IssueTrackerDocument_DTO GetIssueTrackerDocument(int documentId)
        {
            var documentDetails = ServiceReference.ITMCServiceClient.GetIssueDocument(documentId);
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
        /// Calls the service and gets all documents for all issues from database
        /// </summary>
        /// <returns>List of issue documents</returns>
        public List<tbl_IssueTrackerDocument_DTO> GetIssueTrackerDocuments()
        {
            var documentDetails = ServiceReference.ITMCServiceClient.GetIssueDocuments();
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
        /// Validates issue document
        /// </summary>
        /// <param name="actionDTO">Issue documnet</param>
        /// <returns>Issue document with additional error data, if present</returns>
        private tbl_IssueTrackerDocument_DTO Validate(tbl_IssueTrackerDocument_DTO documentDTO)
        {
            if (documentDTO == null)
            {
                documentDTO = new tbl_IssueTrackerDocument_DTO();
            }
            return documentDTO;
        }
        #endregion
    }
}
