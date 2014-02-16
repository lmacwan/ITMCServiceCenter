using ITMCServiceCenter.Web.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITMCServiceCenter.Web.BLL
{
    public class ProjectBusinessLogic
    {
        #region Static Methods
        /// <summary>
        /// get list of projects from web service
        /// </summary>
        /// <returns></returns>
        public static List<tbl_Project_DTO> GetProjects()
        {
            var projectDetails = ServiceReference.ITMCServiceClient.GetProjects();
            if (projectDetails.Success)
            {
                return projectDetails.Value.ToList();
            }
            return null;
        }

        /// <summary>
        /// get details of specific project from web service based on project id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static tbl_Project_DTO GetProject(short id)
        {
            tbl_Project_DTO project = null;
            if (id <= 0)
            {
                project = new tbl_Project_DTO();
            }
            else
            {
                var projectDetails = ServiceReference.ITMCServiceClient.GetProject(id);
                if (projectDetails.Success)
                {
                    project = Validate(projectDetails.Value);
                }
            }
            return project;
        }
        #endregion

        #region Methods
        /// <summary>
        ///  Calls the service and saves a new project into the database
        /// </summary>
        /// <param name="tbl_Project_DTO">Project to save</param>
        /// <returns>Returns the number of records afffected, i.e. 1 if the project was sucessfully saved, otherwise 0</returns>
        public short SaveProject(tbl_Project_DTO tbl_Project_DTO)
        {
            tbl_Project_DTO.CreatedBy = ITMCServiceCenterApplication.CurrentContextUser.UserFullName;
            tbl_Project_DTO.CreatedOn = DateTime.Now;
            var projectDetails = ServiceReference.ITMCServiceClient.SaveProject(tbl_Project_DTO);
            short result = -1;
            if (projectDetails.Success)
            {
                result = projectDetails.Value;
            }
            return result;
        }

        /// <summary>
        /// Calls the service and updates an exsisting project in the database
        /// </summary>
        /// <param name="tbl_Project_DTO">Project instance with updated values</param>
        /// <returns>Returns true if the project was sucessfully updated, otherwise false</returns>
        public bool UpdateProject(tbl_Project_DTO tbl_Project_DTO)
        {
            tbl_Project_DTO.ModifiedBy = ITMCServiceCenterApplication.CurrentContextUser.UserFullName;
            tbl_Project_DTO.ModifiedOn = DateTime.Now;
            var projectDetails = ServiceReference.ITMCServiceClient.UpdateProject(tbl_Project_DTO);
            bool result = false;
            if (projectDetails.Success)
            {
                result = projectDetails.Value;
            }
            return result;
        }

        /// <summary>
        ///  Calls the service and deletes an exsisting project in the database
        /// </summary>
        /// <param name="tbl_Project_DTO">The project id</param>
        /// <returns>Returns true if the project was sucessfully deleted, otherwise false</returns>
        public bool DeleteProject(short projectId)
        {
            var projectDetails = ServiceReference.ITMCServiceClient.DeleteProject(projectId);
            bool result = false;
            if (projectDetails.Success)
            {
                result = projectDetails.Value;
            }
            return result;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// used for validation
        /// </summary>
        /// <param name="projectDTO"></param>
        /// <returns></returns>
        private static tbl_Project_DTO Validate(tbl_Project_DTO projectDTO)
        {
            if (projectDTO == null)
            {
                projectDTO = new tbl_Project_DTO();
            }
            return projectDTO;
        }
        #endregion
    }
}
