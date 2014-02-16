using ITMCServiceCenter.Web.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ITMCServiceCenter.Web.BLL
{
    public class ChangeRequestActionBusinessLogic
    {
        #region Static Methods
        /// <summary>
        /// Calls the service and gets all actions for a given change request
        /// </summary>
        /// <param name="id">Change request id</param>
        /// <returns>List of change request actions</returns>
        public static List<IAction> GetChangeRequestActionsByRequestId(int requestId)
        {
            var actionDetails = ServiceReference.ITMCServiceClient.GetChangeRequestActionsByRequestId(requestId);
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
        /// Calls the service and gets a single change request action
        /// </summary>
        /// <param name="actionId">Change request action id</param>
        /// <returns>Change request action</returns>
        public static tbl_ChangeRequestAction_DTO GetChangeRequestAction(int actionId)
        {
            var actionDetails = ServiceReference.ITMCServiceClient.GetChangeRequestAction(actionId);
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
        /// Calls the service and gets all actions for all change requests
        /// </summary>
        /// <returns>List of change request actions</returns>
        public static List<tbl_ChangeRequestAction_DTO> GetChangeRequestActions()
        {
            var actionDetails = ServiceReference.ITMCServiceClient.GetChangeRequestActions();
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
        public int SaveChangeRequestAction(tbl_ChangeRequestActionDTO actionDto)
        {
            var result = -1;
            var validatedDto = Validate(actionDto);
            if (validatedDto.IsValid)
            {
                var actionDetails = ServiceReference.ITMCServiceClient.SaveChangeRequestAction(validatedDto);
                if (actionDetails.Success)
                {
                    result = actionDetails.Value;
                }
            }
            return result;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Validates change request action
        /// </summary>
        /// <param name="actionDTO">Change request action</param>
        /// <returns>Change request action with additional error data, if present</returns>
        private static tbl_ChangeRequestActionDTO Validate(tbl_ChangeRequestActionDTO actionDTO)
        {
            if (actionDTO == null)
            {
                actionDTO = new tbl_ChangeRequestAction_DTO();
            }
            else if (actionDTO.ChangeRequestId == -1)
            {
                //todo: Validate related to id equals -1
            }
            actionDTO.IsValid = true;
            return actionDTO;
        }
        #endregion
    }
}