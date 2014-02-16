using ITMCServiceCenter.Web.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITMCServiceCenter.Web.BLL
{
    public class ProjectTaskBusinessLogic
    {

        #region Static Methods
        /// <summary>
        /// get list of all projects tasks from webservice.
        /// </summary>
        /// <returns></returns>
        public static List<tbl_ProjectTask_DTO> GetProjectTasks()
        {
            List<tbl_ProjectTask_DTO> projectTaskList = new List<tbl_ProjectTask_DTO>();
            var projectTaskDetails = ServiceReference.ITMCServiceClient.GetProjectTasks();
            if (projectTaskDetails.Success)
            {
                projectTaskList = projectTaskDetails.Value.ToList();
            }
            return projectTaskList;
        }

        /// <summary>
        /// get details of specific project task based on project Task id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static tbl_ProjectTask_DTO GetProjectTask(int id)
        {
            tbl_ProjectTask_DTO projectTask = null;
            if (id <= 0)
            {
                projectTask = new tbl_ProjectTask_DTO();
            }
            else
            {
                var projectTaskDetails = ServiceReference.ITMCServiceClient.GetProjectTask(id);
                if (projectTaskDetails.Success)
                {
                    projectTask = projectTaskDetails.Value;
                }
            }
            return projectTask;
        }

        /// <summary>
        /// get list of all project tasks for specific projectId provided.
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public static List<tbl_ProjectTask_DTO> GetProjectTaskByProjectId(short projectId)
        {
            List<tbl_ProjectTask_DTO> projectTaskList = null;
            var projectTaskDetails = ServiceReference.ITMCServiceClient.GetProjectTaskByProjectId(projectId);
            if (projectTaskDetails.Success)
            {
                projectTaskList = projectTaskDetails.Value.ToList();
            }
            return projectTaskList;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Calls the service and saves a new Issue Project Task into the database
        /// </summary>
        /// <param name="tbl_ProjectTask_DTO">Issue to save</param>
        /// <returns>Returns the number of records affected, i.e. 1 if the pt was sucessfully saved, otherwise 0</returns>
        public int SaveProjectTask(tbl_ProjectTask_DTO tbl_ProjectTask_DTO)
        {
            tbl_ProjectTask_DTO.CreatedBy = ITMCServiceCenterApplication.CurrentContextUser.UserFullName;
            tbl_ProjectTask_DTO.CreatedOn = DateTime.Now;
            var projectTaskDetails = ServiceReference.ITMCServiceClient.SaveProjectTask(tbl_ProjectTask_DTO);
            if (projectTaskDetails.Success)
            {
                return projectTaskDetails.Value;
            }
            return -1;
        }
        /// <summary>
        /// Calls the service and updates an exsisting project task in the database
        /// </summary>
        /// <param name="tbl_ProjectTask_DTO">project task instance with updated values</param>
        /// <returns>Returns true if the pt was sucessfully updated, otherwise false</returns>
        public int UpdateProjectTask(tbl_ProjectTask_DTO tbl_ProjectTask_DTO)
        {
            tbl_ProjectTask_DTO.ModifiedBy = ITMCServiceCenterApplication.CurrentContextUser.UserFullName;
            tbl_ProjectTask_DTO.ModifiedOn = DateTime.Now;
            var projectTaskDetails = ServiceReference.ITMCServiceClient.UpdateProjectTask(tbl_ProjectTask_DTO);
            int result = -1;
            if (projectTaskDetails.Success)
            {
                result = tbl_ProjectTask_DTO.Id;
            }
            return result;
        }
        /// <summary>
        /// Calls the service and deletes an exsisting pt in the database
        /// </summary>
        /// <param name="tbl_ProjectTask_DTO">The project task id</param>
        /// <returns>Returns true if the pt was sucessfully deleted, otherwise false</returns>
        public bool DeleteProjectTask(int projectTaskId)
        {
            var projectTaskDetails = ServiceReference.ITMCServiceClient.DeleteProjectTask(projectTaskId);
            if (projectTaskDetails.Success)
            {
                return projectTaskDetails.Value;
            }
            return false;
        }
        /// <summary>
        /// Calls the service and saves a new Project Task Type into the database
        /// </summary>
        /// <param name="tbl_ProjectTaskType_DTO"></param>
        /// <returns></returns>
        public int SaveProjectTaskType(tbl_ProjectTaskType_DTO tbl_ProjectTaskType_DTO)
        {
            var projectTaskTypeDetails = ServiceReference.ITMCServiceClient.SaveProjectTaskType(tbl_ProjectTaskType_DTO);
            if (projectTaskTypeDetails.Success)
            {
                return projectTaskTypeDetails.Value;
            }
            return -1;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// used for validation
        /// </summary>
        /// <param name="projectDTO"></param>
        /// <returns></returns>
        private static tbl_ProjectTask_DTO Validate(tbl_ProjectTask_DTO projectDTO)
        {
            if (projectDTO == null)
            {
                projectDTO = new tbl_ProjectTask_DTO();
            }
            return projectDTO;
        }
        #endregion
    }
}
