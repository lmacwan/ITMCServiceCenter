using ITMCServiceCenter.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITMCServiceCenter.Web.BLL
{
    public class IncidentActionBusinessLogic
    {
        #region Methods
        /// <summary>
        /// get list of all incidents actions from web service.
        /// </summary>
        /// <returns></returns>
        public static List<tbl_IncidentAction_DTO> GetIncidentActions()
        {
            var incidentDetails = ServiceReference.ITMCServiceClient.GetIncidentActions();
            if (incidentDetails.Success)
            {
                return incidentDetails.Value.ToList();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// get details of specific incident action based on incident action Id.
        /// </summary>
        /// <param name="actionId"></param>
        /// <returns></returns>
        public static tbl_IncidentAction_DTO GetIncidentAction(int actionId)
        {
            var incidentDetails = ServiceReference.ITMCServiceClient.GetIncidentAction(actionId);
            if (incidentDetails.Success)
            {
                return incidentDetails.Value;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// get list of all incident actions based on Incident Id provided.
        /// </summary>
        /// <param name="incidentId"></param>
        /// <returns></returns>
        public static List<IAction> GetIncidentActionByIncidentId(int incidentId)
        {
            var incidentDetails = ServiceReference.ITMCServiceClient.GetIncidentActionByIncidentId(incidentId);
            if (incidentDetails.Success)
            {
                return (from incident in incidentDetails.Value.ToList()
                        select incident as IAction).ToList();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// save incident action into database
        /// </summary>
        /// <param name="actionDto"></param>
        /// <returns></returns>
        public int SaveIncidentAction(tbl_IncidentActionDTO actionDto)
        {
            var result = -1;
            var actionDetails = ServiceReference.ITMCServiceClient.SaveIncidentAction(actionDto);
            if (actionDetails.Success)
            {
                result = actionDetails.Value;
            }
            return result;
        }

        /// <summary>
        /// used for validation
        /// </summary>
        /// <param name="incidentActionDTO"></param>
        /// <returns></returns>
        private static tbl_IncidentAction_DTO Validate(tbl_IncidentAction_DTO incidentActionDTO)
        {
            if (incidentActionDTO == null)
            {
                incidentActionDTO = new tbl_IncidentAction_DTO();
            }
            return incidentActionDTO;
        }

        #endregion
    }
}
