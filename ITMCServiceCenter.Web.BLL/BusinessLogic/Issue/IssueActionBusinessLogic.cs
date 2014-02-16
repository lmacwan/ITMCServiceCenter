using ITMCServiceCenter.Web.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ITMCServiceCenter.Web.BLL
{
    public class IssueActionBusinessLogic
    {
        #region Methods
        /// <summary>
        /// Calls the service and gets all actions for a given issue
        /// </summary>
        /// <param name="id">Issue id</param>
        /// <returns>List of issue actions</returns>
        public static List<IAction> GetIssueActionsByIssueId(int issueId)
        {
            var actionDetails = ServiceReference.ITMCServiceClient.GetIssueActionsByIssueId(issueId);
            if (actionDetails.Success)
            {
                return (from incident in actionDetails.Value.ToList()
                        select incident as IAction).ToList();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Calls the service and gets a single issue action
        /// </summary>
        /// <param name="actionId">Issue action id</param>
        /// <returns>Issue action</returns>
        public tbl_IssueTrackerAction_DTO GetIssueAction(int actionId)
        {
            var actionDetails = ServiceReference.ITMCServiceClient.GetIssueAction(actionId);
            if (actionDetails.Success)
            {
                return actionDetails.Value;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Calls the service and gets all actions for all issues
        /// </summary>
        /// <returns>List of issue actions</returns>
        public List<tbl_IssueTrackerAction_DTO> GetIssueActions()
        {
            var actionDetails = ServiceReference.ITMCServiceClient.GetIssueActions();
            if (actionDetails.Success)
            {
                return actionDetails.Value.ToList();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// save issue action to database
        /// </summary>
        /// <param name="actionDto"></param>
        /// <returns></returns>
        public int SaveIssueAction(tbl_IssueTrackerActionDTO actionDto)
        {
            var result = -1;
            var actionDetails = ServiceReference.ITMCServiceClient.SaveIssueAction(actionDto);
            if (actionDetails.Success)
            {
                result = actionDetails.Value;
            }
            return result;
        }

        /// <summary>
        /// Validates issue action
        /// </summary>
        /// <param name="actionDTO">Issue action</param>
        /// <returns>Issue action with additional error data, if present</returns>
        private tbl_IssueTrackerAction_DTO Validate(tbl_IssueTrackerAction_DTO actionDTO)
        {
            if (actionDTO == null)
            {
                actionDTO = new tbl_IssueTrackerAction_DTO();
            }
            return actionDTO;
        }
        #endregion
    }
}
