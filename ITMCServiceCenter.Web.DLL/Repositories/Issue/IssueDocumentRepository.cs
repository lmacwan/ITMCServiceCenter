using ITMCServiceCenter.Web.Database;
using ITMCServiceCenter.Web.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ITMCServiceCenter.Web.DLL
{
    public class IssueDocumentRepository
    {
        #region Methods
        /// <summary>
        /// Gets all documents for a given issue from databse
        /// </summary>
        /// <param name="id">Issue id</param>
        /// <returns>List of issue documents</returns>
        public List<tbl_IssueTrackerDocument_DTO> GetIssueDocumentsByIssueId(int id)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (
                                from issueDocument in itmcContext.tbl_IssueTrackerDocument
                                where issueDocument.IssueTrackerId == id        // filter by id
                                select new tbl_IssueTrackerDocument_DTO()
                                {
                                    CreatedBy = issueDocument.CreatedBy,
                                    CreatedOn = issueDocument.CreatedOn,
                                    Description = issueDocument.Description,
                                    IssueTrackerId = issueDocument.IssueTrackerId,
                                    Id = issueDocument.Id,
                                    Path = issueDocument.Path,
                                    Title = issueDocument.Title,
                                }
                            ).ToList();
                return result;
            }
        }

        /// <summary>
        /// Gets a single issue document from database
        /// </summary>
        /// <param name="actionId">Issue document id</param>
        /// <returns>Issue document</returns>
        public tbl_IssueTrackerDocument_DTO GetIssueDocument(int documentId)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (
                                from issueDocument in itmcContext.tbl_IssueTrackerDocument
                                where issueDocument.Id == documentId   //filter by issueDocumentId
                                select new tbl_IssueTrackerDocument_DTO()
                                {
                                    CreatedBy = issueDocument.CreatedBy,
                                    CreatedOn = issueDocument.CreatedOn,
                                    Description = issueDocument.Description,
                                    IssueTrackerId = issueDocument.IssueTrackerId,
                                    Id = issueDocument.Id,
                                    Path = issueDocument.Path,
                                    Title = issueDocument.Title,
                                }
                            ).FirstOrDefault();
                return result;
            }
        }

        /// <summary>
        /// Gets all documents for all issues from database
        /// </summary>
        /// <returns>List of issue documents</returns>
        public List<tbl_IssueTrackerDocument_DTO> GetIssueDocuments()
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (
                                from issueDocument in itmcContext.tbl_IssueTrackerDocument
                                select new tbl_IssueTrackerDocument_DTO()
                                {
                                    CreatedBy = issueDocument.CreatedBy,
                                    CreatedOn = issueDocument.CreatedOn,
                                    Description = issueDocument.Description,
                                    IssueTrackerId = issueDocument.IssueTrackerId,
                                    Id = issueDocument.Id,
                                    Path = issueDocument.Path,
                                    Title = issueDocument.Title,
                                }
                            ).ToList();
                return result;
            }
        }

        /// <summary>
        /// Save document for issue to database
        /// </summary>
        /// <returns></returns>
        public int SaveIssueDocument(tbl_IssueTrackerDocumentDTO document)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var entity = document.ToEntity();
                itmcContext.tbl_IssueTrackerDocument.Add(entity);
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
