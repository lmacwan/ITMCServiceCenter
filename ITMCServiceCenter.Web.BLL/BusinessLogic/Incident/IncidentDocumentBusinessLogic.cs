using ITMCServiceCenter.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITMCServiceCenter.Web.BLL
{
    public class IncidentDocumentBusinessLogic
    {
        #region Methods
        /// <summary>
        /// get list of all incidents documents from webservice.
        /// </summary>
        /// <returns></returns>
        public List<tbl_IncidentDocument_DTO> GetIncidentDocuments()
        {
            var incidentDocumentDetails = ServiceReference.ITMCServiceClient.GetIncidentDocuments();
            if (incidentDocumentDetails.Success)
            {
                return incidentDocumentDetails.Value.ToList();
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// get details of specific Incident document based on Incident Document Id provided.
        /// </summary>
        /// <param name="documentId"></param>
        /// <returns></returns>
        public tbl_IncidentDocument_DTO GetIncidentDocument(int documentId)
        {
            var incidentDocumentDetails = ServiceReference.ITMCServiceClient.GetIncidentDocument(documentId);
            if (incidentDocumentDetails.Success)
            {
                return incidentDocumentDetails.Value;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// get list of all Incident documents based on Incident Id provided.
        /// </summary>
        /// <param name="incidentId"></param>
        /// <returns></returns>
        public List<tbl_IncidentDocument_DTO> GetIncidentDocumentDtoByIncidentId(int incidentId)
        {
            var incidentDocumentDetails = ServiceReference.ITMCServiceClient.GetIncidentDocumenByIncidentId(incidentId);
            if (incidentDocumentDetails.Success)
            {
                return incidentDocumentDetails.Value.ToList();
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// used for validation
        /// </summary>
        /// <param name="incidentDocumentDTO"></param>
        /// <returns></returns>
        private tbl_IncidentDocument_DTO Validate(tbl_IncidentDocument_DTO incidentDocumentDTO)
        {
            if (incidentDocumentDTO == null)
            {
                incidentDocumentDTO = new tbl_IncidentDocument_DTO();
            }
            return incidentDocumentDTO;
        }
        #endregion
    }
}
