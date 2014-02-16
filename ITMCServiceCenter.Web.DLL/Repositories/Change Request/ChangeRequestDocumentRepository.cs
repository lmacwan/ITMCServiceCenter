using ITMCServiceCenter.Web.Database;
using ITMCServiceCenter.Web.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ITMCServiceCenter.Web.DLL
{
    public class ChangeRequestDocumentRepository
    {
        #region Methods
        /// <summary>
        /// Gets all documents for a given change request from databse
        /// </summary>
        /// <param name="id">Change request id</param>
        /// <returns>List of change request documents</returns>
        public List<tbl_ChangeRequestDocument_DTO> GetChangeRequestDocumentsByRequestId(int id)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (
                                from changeRequestDocument in itmcContext.tbl_ChangeRequestDocument
                                where changeRequestDocument.ChangeRequestId == id       //filter by id
                                select new tbl_ChangeRequestDocument_DTO()
                                {
                                    ChangeRequestId = changeRequestDocument.ChangeRequestId,
                                    CreatedBy = changeRequestDocument.CreatedBy,
                                    CreatedOn = changeRequestDocument.CreatedOn,
                                    Description = changeRequestDocument.Description,
                                    Id = changeRequestDocument.Id,
                                    Path = changeRequestDocument.Path,
                                    Title = changeRequestDocument.Title,
                                }
                            ).ToList();
                return result;
            }
        }

        /// <summary>
        /// Gets a single change request document from database
        /// </summary>
        /// <param name="actionId">Change request document id</param>
        /// <returns>List of change request documents</returns>
        public tbl_ChangeRequestDocument_DTO GetChangeRequestDocument(int documentId)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (
                                from changeRequestDocument in itmcContext.tbl_ChangeRequestDocument
                                where changeRequestDocument.Id == documentId      //filter by crDocumentId
                                select new tbl_ChangeRequestDocument_DTO()
                                {
                                    ChangeRequestId = changeRequestDocument.ChangeRequestId,
                                    CreatedBy = changeRequestDocument.CreatedBy,
                                    CreatedOn = changeRequestDocument.CreatedOn,
                                    Description = changeRequestDocument.Description,
                                    Id = changeRequestDocument.Id,
                                    Path = changeRequestDocument.Path,
                                    Title = changeRequestDocument.Title,
                                }
                            ).FirstOrDefault();
                return result;
            }
        }

        /// <summary>
        /// Gets all documents for all change requests from database
        /// </summary>
        /// <returns>List of change request documents</returns>
        public List<tbl_ChangeRequestDocument_DTO> GetChangeRequestDocuments()
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (
                                from changeRequestDocument in itmcContext.tbl_ChangeRequestDocument
                                select new tbl_ChangeRequestDocument_DTO()
                                {
                                    ChangeRequestId = changeRequestDocument.ChangeRequestId,
                                    CreatedBy = changeRequestDocument.CreatedBy,
                                    CreatedOn = changeRequestDocument.CreatedOn,
                                    Description = changeRequestDocument.Description,
                                    Id = changeRequestDocument.Id,
                                    Path = changeRequestDocument.Path,
                                    Title = changeRequestDocument.Title,
                                }
                            ).ToList();
                return result;
            }
        }
        #endregion
    }
}