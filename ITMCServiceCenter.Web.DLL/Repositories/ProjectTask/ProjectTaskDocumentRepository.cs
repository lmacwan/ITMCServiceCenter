using ITMCServiceCenter.Web.Database;
using ITMCServiceCenter.Web.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ITMCServiceCenter.Web.DLL
{
    public class ProjectTaskDocumentRepository
    {
        #region Methods
        /// <summary>
        /// get list of all project task documents from database
        /// </summary>
        /// <returns></returns>
        public List<tbl_ProjectTaskDocument_DTO> GetProjectTaskDocuments()
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (

                    from projecttaskdocument in itmcContext.tbl_ProjectTaskDocument
                    select new tbl_ProjectTaskDocument_DTO()
                    {
                        Id = projecttaskdocument.Id,
                        ProjectTaskId = projecttaskdocument.ProjectTaskId,
                        CreatedBy = projecttaskdocument.CreatedBy,
                        Title = projecttaskdocument.Title,
                        Description = projecttaskdocument.Description,
                        Path = projecttaskdocument.Path,
                    }).ToList();
                return result;
            }
        }

        /// <summary>
        /// get list of all project task documents based on project task id.
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public List<tbl_ProjectTaskDocument_DTO> GetProjectTaskDocumentByTaskId(int taskId)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (

                    from projecttaskdocument in itmcContext.tbl_ProjectTaskDocument
                    where projecttaskdocument.ProjectTaskId == taskId
                    select new tbl_ProjectTaskDocument_DTO()
                    {
                        Id = projecttaskdocument.Id,
                        ProjectTaskId = projecttaskdocument.ProjectTaskId,
                        CreatedBy = projecttaskdocument.CreatedBy,
                        Title = projecttaskdocument.Title,
                        Description = projecttaskdocument.Description,
                        Path = projecttaskdocument.Path,
                    }).ToList();
                return result;
            }
        }

        /// <summary>
        /// get specific project task document based on project task document id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public tbl_ProjectTaskDocument_DTO GetProjectTaskDocument(int id)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (

                    from projecttaskdocument in itmcContext.tbl_ProjectTaskDocument
                    where projecttaskdocument.Id == id
                    select new tbl_ProjectTaskDocument_DTO()
                    {
                        Id = projecttaskdocument.Id,
                        ProjectTaskId = projecttaskdocument.ProjectTaskId,
                        CreatedBy = projecttaskdocument.CreatedBy,
                        Title = projecttaskdocument.Title,
                        Description = projecttaskdocument.Description,
                        Path = projecttaskdocument.Path,
                    }).FirstOrDefault();
                return result;
            }
        }

        /// <summary>
        /// Save document for project task to database
        /// </summary>
        /// <returns></returns>
        public int SaveProjectTaskDocument(tbl_ProjectTaskDocumentDTO document)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var entity = document.ToEntity();
                itmcContext.tbl_ProjectTaskDocument.Add(entity);
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
