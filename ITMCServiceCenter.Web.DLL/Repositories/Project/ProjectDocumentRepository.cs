using ITMCServiceCenter.Web.Database;
using ITMCServiceCenter.Web.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ITMCServiceCenter.Web.DLL
{
    public class ProjectDocumentRepository
    {
        #region Methods
        /// <summary>
        /// get list of all projects documents from database
        /// </summary>
        /// <returns></returns>
        public List<tbl_ProjectDocument_DTO> GetProjectDocuments()
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (

                    from projectdocument in itmcContext.tbl_ProjectDocument
                   
                    join project in itmcContext.tbl_ProjectDocument
                      on projectdocument.ProjectId equals project.Id

                    select new tbl_ProjectDocument_DTO()
                    {
                        Id = projectdocument.Id,
                        CreatedOn = projectdocument.CreatedOn,
                        CreatedBy = projectdocument.CreatedBy,
                        Title = projectdocument.Title,
                        Description = projectdocument.Description,
                        Path = projectdocument.Path,
                        ProjectId = projectdocument.ProjectId,
                        
                        //join
                        ProjectTitle = project.Title,
                        
                        
                    }).ToList();
                return result;
            }
        }

        /// <summary>
        /// get list of all project documents based on project id provided
        /// </summary>
        /// <param name="projectid"></param>
        /// <returns></returns>
        public List<tbl_ProjectDocument_DTO> GetProjectDocumentsByProjectId(short projectid)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (

                    from projectdocument in itmcContext.tbl_ProjectDocument
                    where projectdocument.ProjectId == projectid
                   
                    join project in itmcContext.tbl_ProjectDocument
                      on projectdocument.ProjectId equals project.Id

                    select new tbl_ProjectDocument_DTO()
                    {
                        Id = projectdocument.Id,
                        CreatedOn = projectdocument.CreatedOn,
                        CreatedBy = projectdocument.CreatedBy,
                        Title = projectdocument.Title,
                        Description = projectdocument.Description,
                        Path = projectdocument.Path,
                        ProjectId = projectdocument.ProjectId,

                        //join
                        ProjectTitle = project.Title,

                    }).ToList();
                return result;
            }
        }

        /// <summary>
        /// get project document based on project document id provided
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public tbl_ProjectDocument_DTO GetProjectDocument(int id)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (

                    from projectdocument in itmcContext.tbl_ProjectDocument
                    where projectdocument.Id == id
                    join project in itmcContext.tbl_ProjectDocument
                      on projectdocument.ProjectId equals project.Id

                    select new tbl_ProjectDocument_DTO()
                    {
                        Id = projectdocument.Id,
                        CreatedOn = projectdocument.CreatedOn,
                        CreatedBy = projectdocument.CreatedBy,
                        Title = projectdocument.Title,
                        Description = projectdocument.Description,
                        Path = projectdocument.Path,
                        ProjectId = projectdocument.ProjectId,

                        //join
                        ProjectTitle = project.Title,

                    }).FirstOrDefault();
                return result;
            }
        }

        /// <summary>
        /// Save document for project to database
        /// </summary>
        /// <returns></returns>
        public int SaveProjectDocument(tbl_ProjectDocumentDTO document)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var entity = document.ToEntity();
                itmcContext.tbl_ProjectDocument.Add(entity);
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