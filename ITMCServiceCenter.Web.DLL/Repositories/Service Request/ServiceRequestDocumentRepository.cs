using ITMCServiceCenter.Web.Database;
using ITMCServiceCenter.Web.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ITMCServiceCenter.Web.DLL
{
    public class ServiceRequestDocumentRepository
    {
        #region Methods
        /// <summary>
        /// Gets all documents for a given service request from databse
        /// </summary>
        /// <param name="id">Service request id</param>
        /// <returns>List of service request documents</returns>
        public List<tbl_ServiceRequestDocument_DTO> GetServiceRequestDocumentsByRequestId(int id)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (
                                from serviceRequestDocument in itmcContext.tbl_ServiceRequestDocument
                                where serviceRequestDocument.ServiceRequestId == id     // filter by id
                                select new tbl_ServiceRequestDocument_DTO()
                                {

                                    CreatedBy = serviceRequestDocument.CreatedBy,
                                    CreatedOn = serviceRequestDocument.CreatedOn,
                                    Description = serviceRequestDocument.Description,
                                    Id = serviceRequestDocument.Id,
                                    Path = serviceRequestDocument.Path,
                                    ServiceRequestId = serviceRequestDocument.ServiceRequestId,
                                    Title = serviceRequestDocument.Title,
                                }
                            ).ToList();
                return result;
            }
        }

        /// <summary>
        /// Gets a single service request document from database
        /// </summary>
        /// <param name="actionId">Service request document id</param>
        /// <returns>List of service request documents</returns>
        public tbl_ServiceRequestDocument_DTO GetServiceRequestDocument(int documentId)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (
                                from serviceRequestDocument in itmcContext.tbl_ServiceRequestDocument
                                where serviceRequestDocument.Id == documentId      //filter by srDocumentId
                                select new tbl_ServiceRequestDocument_DTO()
                                {

                                    CreatedBy = serviceRequestDocument.CreatedBy,
                                    CreatedOn = serviceRequestDocument.CreatedOn,
                                    Description = serviceRequestDocument.Description,
                                    Id = serviceRequestDocument.Id,
                                    Path = serviceRequestDocument.Path,
                                    ServiceRequestId = serviceRequestDocument.ServiceRequestId,
                                    Title = serviceRequestDocument.Title,
                                }
                            ).FirstOrDefault();
                return result;
            }
        }

        /// <summary>
        /// Gets all documents for all service requests from database
        /// </summary>
        /// <returns>List of service request documents</returns>
        public List<tbl_ServiceRequestDocument_DTO> GetServiceRequestDocuments()
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (
                                from serviceRequestDocument in itmcContext.tbl_ServiceRequestDocument
                                select new tbl_ServiceRequestDocument_DTO()
                                {

                                    CreatedBy = serviceRequestDocument.CreatedBy,
                                    CreatedOn = serviceRequestDocument.CreatedOn,
                                    Description = serviceRequestDocument.Description,
                                    Id = serviceRequestDocument.Id,
                                    Path = serviceRequestDocument.Path,
                                    ServiceRequestId = serviceRequestDocument.ServiceRequestId,
                                    Title = serviceRequestDocument.Title,
                                }
                            ).ToList();
                return result;
            }
        }

        /// <summary>
        /// Save document for service request to database
        /// </summary>
        /// <returns></returns>
        public int SaveServiceRequestDocument(tbl_ServiceRequestDocumentDTO document)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var entity = document.ToEntity();
                itmcContext.tbl_ServiceRequestDocument.Add(entity);
                if (itmcContext.SaveChanges() > 0)
                {
                    return entity.Id;
                }
                return -1;
            }
        }
        #endregion
    }
}