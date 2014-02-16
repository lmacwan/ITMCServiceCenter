using ITMCServiceCenter.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITMCServiceCenter.Web.BLL
{
    public class ProjectTaskActionBusinessLogic
    {
        #region Static Methods
        /// <summary>
        /// get list of all projects tasks actions 
        /// </summary>
        /// <returns></returns>
        public static List<tbl_ProjectTaskAction_DTO> GetProjectTaskActions()
        {
            var projectTaskActionDetails = ServiceReference.ITMCServiceClient.GetProjectTaskActions();
            if (projectTaskActionDetails.Success)
            {
                return projectTaskActionDetails.Value.ToList();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// get details of specific project task action based on action Id.
        /// </summary>
        /// <param name="actionId"></param>
        /// <returns></returns>
        public static tbl_ProjectTaskAction_DTO GetProjectTaskAction(int actionId)
        {
            var projectTaskActionDetails = ServiceReference.ITMCServiceClient.GetProjectTaskAction(actionId);
            if (projectTaskActionDetails.Success)
            {
                return projectTaskActionDetails.Value;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// get list of project task actions for specific project Task Id
        /// </summary>
        /// <param name="projectTaskId"></param>
        /// <returns></returns>
        public static List<IAction> GetProjectTaskActionByProjectTaskId(int projectTaskId)
        {
            var projectTaskActionDetails = ServiceReference.ITMCServiceClient.GetProjectTaskActionByTaskId(projectTaskId);
            if (projectTaskActionDetails.Success)
            {
                return (from projectTask in projectTaskActionDetails.Value.ToList()
                        select projectTask as IAction).ToList();
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region Instance Methods
         /// <summary>
        /// save project task action into database
        /// </summary>
        /// <param name="actionDto"></param>
        /// <returns></returns>
        public int SaveProjectTaskAction(tbl_ProjectTaskActionDTO actionDto)
        {
            var result = -1;
            var actionDetails = ServiceReference.ITMCServiceClient.SaveProjectTaskAction(actionDto);
            if (actionDetails.Success)
            {
                result = actionDetails.Value;
            }
            return result;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// used for validation
        /// </summary>
        /// <param name="projectTaskActionDTO"></param>
        /// <returns></returns>
        private static tbl_ProjectTaskAction_DTO Validate(tbl_ProjectTaskAction_DTO projectTaskActionDTO)
        {
            if (projectTaskActionDTO == null)
            {
                projectTaskActionDTO = new tbl_ProjectTaskAction_DTO();
            }
            return projectTaskActionDTO;
        }
        #endregion
    }
}
