using ITMCServiceCenter.Web.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ITMCServiceCenter.Web.BLL
{
    public class ProjectTaskDocumentBusinessLogic
    {
        #region Methods
        /// <summary>
        /// get list of all projects tasks documents from web service.
        /// </summary>
        /// <returns></returns>
        public List<tbl_ProjectTaskDocument_DTO> GetProjectTaskDocuments()
        {
            var projectTaskDocumentDetails = ServiceReference.ITMCServiceClient.GetProjectTaskDocuments();
            if (projectTaskDocumentDetails.Success)
            {
                return projectTaskDocumentDetails.Value.ToList();
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// get details of specific project task document based on document id.
        /// </summary>
        /// <param name="documentId"></param>
        /// <returns></returns>
        public tbl_ProjectTaskDocument_DTO GetProjectTaskDocument(int documentId)
        {
            var projectTaskDocumentDetails = ServiceReference.ITMCServiceClient.GetProjectTaskDocument(documentId);
            if (projectTaskDocumentDetails.Success)
            {
                return projectTaskDocumentDetails.Value;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// get list of all projec task documents based on task id.
        /// </summary>
        /// <param name="projectTaskId"></param>
        /// <returns></returns>
        public List<tbl_ProjectTaskDocument_DTO> GetProjectTaskDocumentByProjectId(int projectTaskId)
        {
            var projectTaskDocumentDetails = ServiceReference.ITMCServiceClient.GetProjectTaskDocumentByProjectTaskId(projectTaskId);
            if (projectTaskDocumentDetails.Success)
            {
                return projectTaskDocumentDetails.Value.ToList();
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// used for validation
        /// </summary>
        /// <param name="issueDTO"></param>
        /// <returns></returns>
        private tbl_ProjectTaskDocument_DTO Validate(tbl_ProjectTaskDocument_DTO issueDTO)
        {
            if (issueDTO == null)
            {
                issueDTO = new tbl_ProjectTaskDocument_DTO();
            }
            return issueDTO;
        }

        #endregion
    }
}
