using ITMCServiceCenter.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITMCServiceCenter.Web.BLL
{
    public class ProjectDocumentBusinessLogic
    {
        #region Methods
        /// <summary>
        /// get list of all projects documents from webservice.
        /// </summary>
        /// <returns></returns>
        public List<tbl_ProjectDocument_DTO> GetProjectDocuments()
        {
            var projectDocumentDetails = ServiceReference.ITMCServiceClient.GetProjectDocuments();
            if (projectDocumentDetails.Success)
            {
                return projectDocumentDetails.Value.ToList();
            }
            return null;
        }
        /// <summary>
        /// get specific document details based on document id.
        /// </summary>
        /// <param name="documentId"></param>
        /// <returns></returns>
        public tbl_ProjectDocument_DTO GetProjectDocument(int documentId)
        {
            var projectDocumentDetails = ServiceReference.ITMCServiceClient.GetProjectDocument(documentId);
            if (projectDocumentDetails.Success)
            {
                return projectDocumentDetails.Value;
            }
            return null;
        }
        /// <summary>
        /// get list of project documents based on project id.
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public List<tbl_ProjectDocument_DTO> GetProjectDocumentByProjectId(short projectId)
        {
            var projectDocumentDetails = ServiceReference.ITMCServiceClient.GetProjectDocumentByProjectId(projectId);
            if (projectDocumentDetails.Success)
            {
                return projectDocumentDetails.Value.ToList();
            }
            return null;
        }
        /// <summary>
        /// used for validation
        /// </summary>
        /// <param name="projectDocumentDTO"></param>
        /// <returns></returns>
        private tbl_ProjectDocument_DTO Validate(tbl_ProjectDocument_DTO projectDocumentDTO)
        {
            if (projectDocumentDTO == null)
            {
                projectDocumentDTO = new tbl_ProjectDocument_DTO();
            }
            return projectDocumentDTO;
        }
        
        #endregion
    }
}
