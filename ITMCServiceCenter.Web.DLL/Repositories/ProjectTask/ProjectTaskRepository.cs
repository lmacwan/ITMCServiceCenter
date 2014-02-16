using ITMCServiceCenter.Web.Database;
using ITMCServiceCenter.Web.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ITMCServiceCenter.Web.DLL
{
    public class ProjectTaskRepository
    {
        #region Data Members
        private UserUtility userUtility = new UserUtility();
        private TypeUtility typeUtility = new TypeUtility();
        private EntityUtility entityUtility = new EntityUtility();
        private ProjectRepository projectRepository = new ProjectRepository();
        #endregion

        #region Methods
        /// <summary>
        /// Get list of all Projects Tasks from database
        /// </summary>
        /// <returns></returns>
        public List<tbl_ProjectTask_DTO> GetProjectTasks()
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (

                    from projecttask in itmcContext.tbl_ProjectTask
                    select new tbl_ProjectTask_DTO()
                    {
                        Id = projecttask.Id,
                        ProjectId = projecttask.ProjectId,
                        StatusId = projecttask.StatusId,
                        PriorityId = projecttask.PriorityId,
                        TypeId = projecttask.TypeId,
                        QA = projecttask.QA,
                        Title = projecttask.Title,
                        Description = projecttask.Description,
                        StartDate = projecttask.StartDate,
                        EndDate = projecttask.EndDate,
                        EstimatedCost = projecttask.EstimatedCost,
                        EstimatedHours = projecttask.EstimatedHours,
                        PercentComplete = projecttask.PercentComplete,
                        QAStartDate = projecttask.QAStartDate,
                        QAEndDate = projecttask.QAEndDate,
                        CreatedOn = projecttask.CreatedOn,
                        ModifiedOn = projecttask.ModifiedOn,
                        CreatedBy = projecttask.CreatedBy,
                        ModifiedBy = projecttask.ModifiedBy,
                    }).ToList();
                FillAllIssues(result);
                return result;
            }
        }
        /// <summary>
        /// Get project task details from database based on project task id provided
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public tbl_ProjectTask_DTO GetProjectTask(int Id)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (

                    from projecttask in itmcContext.tbl_ProjectTask
                    where projecttask.Id == Id
                    select new tbl_ProjectTask_DTO()
                    {
                        Id = projecttask.Id,
                        ProjectId = projecttask.ProjectId,
                        StatusId = projecttask.StatusId,
                        PriorityId = projecttask.PriorityId,
                        TypeId = projecttask.TypeId,
                        QA = projecttask.QA,
                        Title = projecttask.Title,
                        Description = projecttask.Description,
                        StartDate = projecttask.StartDate,
                        EndDate = projecttask.EndDate,
                        EstimatedCost = projecttask.EstimatedCost,
                        EstimatedHours = projecttask.EstimatedHours,
                        PercentComplete = projecttask.PercentComplete,
                        QAStartDate = projecttask.QAStartDate,
                        QAEndDate = projecttask.QAEndDate,
                        CreatedOn = projecttask.CreatedOn,
                        ModifiedOn = projecttask.ModifiedOn,
                        CreatedBy = projecttask.CreatedBy,
                        ModifiedBy = projecttask.ModifiedBy,
                    }).ToList();
                FillAllIssues(result);
                return result.FirstOrDefault();
            }
        }
        /// <summary>
        /// get list of all project tasks details from database based on project id provided
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public List<tbl_ProjectTask_DTO> GetProjectTaskByProjectId(short projectId)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (
                    from projecttask in itmcContext.tbl_ProjectTask
                    where projecttask.ProjectId == projectId
                    select new tbl_ProjectTask_DTO()
                    {
                        Id = projecttask.Id,
                        ProjectId = projecttask.ProjectId,
                        StatusId = projecttask.StatusId,
                        PriorityId = projecttask.PriorityId,
                        TypeId = projecttask.TypeId,
                        QA = projecttask.QA,
                        Title = projecttask.Title,
                        Description = projecttask.Description,
                        StartDate = projecttask.StartDate,
                        EndDate = projecttask.EndDate,
                        EstimatedCost = projecttask.EstimatedCost,
                        EstimatedHours = projecttask.EstimatedHours,
                        PercentComplete = projecttask.PercentComplete,
                        QAStartDate = projecttask.QAStartDate,
                        QAEndDate = projecttask.QAEndDate,
                        CreatedOn = projecttask.CreatedOn,
                        ModifiedOn = projecttask.ModifiedOn,
                        CreatedBy = projecttask.CreatedBy,
                        ModifiedBy = projecttask.ModifiedBy,
                    }).ToList();
                FillAllIssues(result);
                return result;
            }
        }
        /// <summary>
        /// Saves a new Project Task into the database
        /// </summary>
        /// <param name="tbl_ProjectTask_DTO">Project Task to save</param>
        /// <returns>Returns the number of records afected, i.e. 1 if the pt was sucessfully saved, otherwise 0</returns>
        public int SaveProjectTask(tbl_ProjectTask_DTO tbl_ProjectTask_DTO)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var projectTaskEntity = tbl_ProjectTask_DTO.ToEntity();
                itmcContext.tbl_ProjectTask.Add(projectTaskEntity);
                var isSaved = itmcContext.SaveChanges() > 0;
                if (isSaved)
                {
                    return projectTaskEntity.Id;
                }
                else
                {
                    return -1;
                }
            }
        }
        /// <summary>
        /// Updates an exsisting project task in the database
        /// </summary>
        /// <param name="tbl_ProjectTask_DTO">project task with updated values</param>
        /// <returns>Returns true if the project task was sucessfully updated, otherwise false</returns>
        public bool UpdateProjectTask(tbl_ProjectTask_DTO tbl_ProjectTask_DTO)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                itmcContext.Entry(tbl_ProjectTask_DTO.ToEntity()).State = System.Data.EntityState.Modified;
                return itmcContext.SaveChanges() > 0;
            }
        }
        /// <summary>
        /// Deletes an exsisting project task in the database
        /// </summary>
        /// <param name="tbl_ProjectTask_DTO">The project task id</param>
        /// <returns>Returns true if the project task was sucessfully deleted, otherwise false</returns>
        public bool DeleteProjectTask(int projectTaskId)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var currentProjectTask = itmcContext.tbl_ProjectTask.Find(projectTaskId);
                itmcContext.tbl_ProjectTask.Remove(currentProjectTask);
                return itmcContext.SaveChanges() > 0;
            }
        }
        #endregion

        #region Private Methods
        private void FillAllIssues(List<tbl_ProjectTask_DTO> projectTask)
        {
            foreach (tbl_ProjectTask_DTO projecttask in projectTask)
            {
                //Fill User Fulll Names
                projecttask.QAName = userUtility.GetUserFullName(projecttask.QA);

                // Fill Project Title
                projecttask.ProjectTitle = projectRepository.GetProject(projecttask.ProjectId).Title;

                //Fill Entity Names
                projecttask.Priority = entityUtility.GetEntityName(projecttask.PriorityId);
                projecttask.Status = entityUtility.GetEntityName(projecttask.StatusId);
                projecttask.Types = EntityUtility.GetProjectTaskTypesByProjectId(projecttask.ProjectId);
            }
        }
        #endregion
    }
}
