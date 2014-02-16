using ITMCServiceCenter.Web.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ITMCServiceCenter.Web.BLL
{
    public class ServiceRequestActionBusinessLogic
    {
        #region Static Methods
        /// <summary>
        /// Calls the service and gets all actions for a given service request from databse
        /// </summary>
        /// <param name="id">Service request id</param>
        /// <returns>List of service request actions</returns>
        public static List<IAction> GetServiceRequestActionsByRequestId(int requestId)
        {
            var actionDetails = ServiceReference.ITMCServiceClient.GetServiceRequestActionsByRequestId(requestId);
            if (actionDetails.Success)
            {
                return (from action in actionDetails.Value.ToList()
                        select action as IAction).ToList();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Calls the service and gets a single service request action from database
        /// </summary>
        /// <param name="actionId">Service request action id</param>
        /// <returns>Service request action</returns>
        public static tbl_ServiceRequestAction_DTO GetServiceRequestAction(int actionId)
        {
            var actionDetails = ServiceReference.ITMCServiceClient.GetServiceRequestAction(actionId);
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
        /// Calls the service and gets a list of actions for all service requests from database
        /// </summary>
        /// <returns>List of service request actions</returns>
        public static List<tbl_ServiceRequestAction_DTO> GetServiceRequestActions()
        {
            var actionDetails = ServiceReference.ITMCServiceClient.GetServiceRequestActions();
            if (actionDetails.Success)
            {
                return actionDetails.Value.ToList();
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region Instance Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionDto"></param>
        /// <returns></returns>
        public int SaveServiceRequestAction(tbl_ServiceRequestActionDTO actionDto)
        {
            var result = -1;
            var actionDetails = ServiceReference.ITMCServiceClient.SaveServiceRequestAction(actionDto);
            if (actionDetails.Success)
            {
                result = actionDetails.Value;
            }
            return result;
        }
        #endregion

        #region Private Methods
         /// <summary>
        /// Validates service request action
        /// </summary>
        /// <param name="actionDTO">Service request action</param>
        /// <returns>Service request action with additional error data, if present</returns>
        private static tbl_ServiceRequestAction_DTO Validate(tbl_ServiceRequestAction_DTO actionActionDTO)
        {
            if (actionActionDTO == null)
            {
                actionActionDTO = new tbl_ServiceRequestAction_DTO();
            }
            return actionActionDTO;
        }
        #endregion
    }
}
