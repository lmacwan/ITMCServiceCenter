using ITMCServiceCenter.Web.Database;
using ITMCServiceCenter.Web.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ITMCServiceCenter.Web.DLL
{
    public class ProjectRepository
    {
        #region Data Memebers
        private UserUtility userUtility = new UserUtility();
        private TypeUtility typeUtility = new TypeUtility();
        private EntityUtility entityUtility = new EntityUtility();
        #endregion

        #region Methods
        /// <summary>
        /// get list of all projects details from database
        /// </summary>
        /// <returns></returns>
        public List<tbl_Project_DTO> GetProjects()
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (
                    from project in itmcContext.tbl_Project
                        select new tbl_Project_DTO()
                        {
                            Approver = project.Approver,
                            ClientId = project.ClientId,
                            CreatedBy = project.CreatedBy,
                            CreatedOn = project.CreatedOn,
                            Description = project.Description,
                            EndDate = project.EndDate,
                            EstimatedCost = project.EstimatedCost,
                            EstimatedHours = project.EstimatedHours,
                            Id = project.Id,
                            Manager = project.Manager,
                            ModifiedBy = project.ModifiedBy,
                            ModifiedOn = project.ModifiedOn,
                            PoNo = project.PoNo,
                            QA = project.QA,
                            Site = project.Site,
                            StartDate = project.StartDate,
                            StatusId = project.StatusId,
                            Title = project.Title,
                            TypeId = project.TypeId,
                        }).ToList();
                FillAllProjects(result);
                return result;
            }
        }
        
        /// <summary>
        /// get specific project details from database based on project id provided
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public tbl_Project_DTO GetProject(short id)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (
                     from project in itmcContext.tbl_Project
                     where project.Id == id     //  filter by projectId
                     select new tbl_Project_DTO()
                     {
                         Approver = project.Approver,
                         ClientId = project.ClientId,
                         CreatedBy = project.CreatedBy,
                         CreatedOn = project.CreatedOn,
                         Description = project.Description,
                         EndDate = project.EndDate,
                         EstimatedCost = project.EstimatedCost,
                         EstimatedHours = project.EstimatedHours,
                         Id = project.Id,
                         Manager = project.Manager,
                         ModifiedBy = project.ModifiedBy,
                         ModifiedOn = project.ModifiedOn,
                         PoNo = project.PoNo,
                         QA = project.QA,
                         Site = project.Site,
                         StartDate = project.StartDate,
                         StatusId = project.StatusId,
                         Title = project.Title,
                         TypeId = project.TypeId,
                     }).ToList();
                FillAllProjects(result);
                return result.FirstOrDefault();
            }
        }
        
        /// <summary>
        /// Saves a new project into the database
        /// </summary>
        /// <param name="tbl_Project_DTO">Project to save</param>
        /// <returns>Returns the number of records affected, i.e. 1 if the project was sucessfully saved, otherwise 0</returns>
        public short SaveProject(tbl_Project_DTO tbl_Project_DTO)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var projectEntity = tbl_Project_DTO.ToEntity();
                itmcContext.tbl_Project.Add(projectEntity);
                var isSaved = itmcContext.SaveChanges() > 0;
                if (isSaved)
                {
                    return projectEntity.Id;
                }
                else
                {
                    return -1;
                }
            }
        }
        
        /// <summary>
        /// Updates an exsisting project in the database
        /// </summary>
        /// <param name="tbl_Project_DTO">Project instance with updated values</param>
        /// <returns>Returns true if the project was sucessfully updated, otherwise false</returns>
        public bool UpdateProject(tbl_Project_DTO tbl_Project_DTO)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                itmcContext.Entry(tbl_Project_DTO.ToEntity()).State = System.Data.EntityState.Modified;
                return itmcContext.SaveChanges() > 0;
            }
        }
        
        /// <summary>
        /// Deletes an exsisting project in the database
        /// </summary>
        /// <param name="tbl_Project_DTO">The project id</param>
        /// <returns>Returns true if the project was sucessfully deleted, otherwise false</returns>
        public bool DeleteProject(short projectId)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var currentProject = itmcContext.tbl_Project.Find(projectId);
                itmcContext.tbl_Project.Remove(currentProject);
                return itmcContext.SaveChanges() > 0;
            }
        }
        #endregion

        #region Private Methods
        private void FillAllProjects(List<tbl_Project_DTO> projects)
        {
            foreach (tbl_Project_DTO project in projects)
            {
                //Fill User Fulll Names
                project.ApproverName = userUtility.GetUserFullName(project.Approver);
                project.ClientName = new ClientRepository().GetClient(project.ClientId).Name;
                project.ManagerName = userUtility.GetUserFullName(project.Manager);
                project.QAName = userUtility.GetUserFullName(project.QA);

                //Fill Entity Names
                project.Status = entityUtility.GetEntityName(project.StatusId);
                project.Type = typeUtility.GetTypeName(Types.Project);
            }
        }
        #endregion
    }
}