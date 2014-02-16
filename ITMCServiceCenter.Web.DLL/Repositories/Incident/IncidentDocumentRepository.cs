using ITMCServiceCenter.Web.Database;
using ITMCServiceCenter.Web.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ITMCServiceCenter.Web.DLL
{
    public class IncidentDocumentRepository
    {
        #region Methods
        /// <summary>
        /// get list of all incident documents from database.
        /// </summary>
        /// <returns></returns>
        public List<tbl_IncidentDocument_DTO> GetIncidentDocumentsDtoList()
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (

                    from incidentdocument in itmcContext.tbl_IncidentDocument
                    select new tbl_IncidentDocument_DTO()
                    {
                        Id = incidentdocument.Id,
                        CreatedBy = incidentdocument.CreatedBy,
                        Title = incidentdocument.Title,
                        Description = incidentdocument.Description,
                        Path = incidentdocument.Path,
                    }).ToList();
                return result;
            }
        }
        /// <summary>
        /// get details of specific incident doucment based on incident document id.
        /// </summary>
        /// <param name="documentId"></param>
        /// <returns></returns>
        public tbl_IncidentDocument_DTO GetIncidentDocumentDtoById(int documentId)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (

                    from incidentdocument in itmcContext.tbl_IncidentDocument
                    select new tbl_IncidentDocument_DTO()
                    {
                        Id = incidentdocument.Id,
                        IncidentId = incidentdocument.IncidentId,
                        CreatedBy = incidentdocument.CreatedBy,
                        Title = incidentdocument.Title,
                        Description = incidentdocument.Description,
                        Path = incidentdocument.Path,
                    }).FirstOrDefault();
                return result;
            }
        }
        /// <summary>
        /// get list of all incident documents based on incident id.
        /// </summary>
        /// <param name="incidentId"></param>
        /// <returns></returns>
        public List<tbl_IncidentDocument_DTO> GetIncidentDocumentByIncidentId(int incidentId)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (

                    from incidentdocument in itmcContext.tbl_IncidentDocument
                    where incidentdocument.IncidentId == incidentId
                    select new tbl_IncidentDocument_DTO()
                    {
                        Id = incidentdocument.Id,
                        IncidentId = incidentdocument.IncidentId,
                        CreatedBy = incidentdocument.CreatedBy,
                        Title = incidentdocument.Title,
                        Description = incidentdocument.Description,
                        Path = incidentdocument.Path,
                    }).ToList();
                return result;
            }
        }

        #endregion
    }
}
