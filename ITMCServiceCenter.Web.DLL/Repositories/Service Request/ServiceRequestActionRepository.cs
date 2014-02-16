using ITMCServiceCenter.Web.Database;
using ITMCServiceCenter.Web.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ITMCServiceCenter.Web.DLL
{
    public class ServiceRequestActionRepository
    {
        #region Methods
        /// <summary>
        /// Gets all actions for a given service request from databse
        /// </summary>
        /// <param name="id">Service request id</param>
        /// <returns>List of service request actions</returns>
        public List<tbl_ServiceRequestAction_DTO> GetServiceRequestActionsByRequestId(int id)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (
                                from serviceRequestAction in itmcContext.tbl_ServiceRequestAction
                                where serviceRequestAction.ServiceRequestId == id   // filter by id
                                select new tbl_ServiceRequestAction_DTO()
                                {
                                    Action = serviceRequestAction.Action,
                                    ServiceRequestId = serviceRequestAction.ServiceRequestId,
                                    CreatedBy = serviceRequestAction.CreatedBy,
                                    CreatedOn = serviceRequestAction.CreatedOn,
                                    Id = serviceRequestAction.Id,
                                }
                            ).ToList();
                return result;
            }
        }

        /// <summary>
        /// Gets a single service request action from database
        /// </summary>
        /// <param name="actionId">Service request action id</param>
        /// <returns>Service request action</returns>
        public List<tbl_ServiceRequestAction_DTO> GetServiceRequestActions()
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (
                                from serviceRequestAction in itmcContext.tbl_ServiceRequestAction
                                select new tbl_ServiceRequestAction_DTO()
                                {
                                    Action = serviceRequestAction.Action,
                                    ServiceRequestId = serviceRequestAction.ServiceRequestId,
                                    CreatedBy = serviceRequestAction.CreatedBy,
                                    CreatedOn = serviceRequestAction.CreatedOn,
                                    Id = serviceRequestAction.Id,
                                }
                            ).ToList();
                return result;
            }
        }

        /// <summary>
        /// Gets a list of actions for all service requests from database
        /// </summary>
        /// <returns>List of service request actions</returns>
        public tbl_ServiceRequestAction_DTO GetServiceRequestAction(int actionId)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (
                               from serviceRequestAction in itmcContext.tbl_ServiceRequestAction
                               where serviceRequestAction.Id == actionId      //filter by srActionId
                               select new tbl_ServiceRequestAction_DTO()
                               {
                                   Action = serviceRequestAction.Action,
                                   ServiceRequestId = serviceRequestAction.ServiceRequestId,
                                   CreatedBy = serviceRequestAction.CreatedBy,
                                   CreatedOn = serviceRequestAction.CreatedOn,
                                   Id = serviceRequestAction.Id,
                               }
                            ).FirstOrDefault();
                return result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionDto"></param>
        /// <returns></returns>
        public int SaveServiceRequestAction(tbl_ServiceRequestActionDTO actionDto)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var entity = actionDto.ToEntity();
                itmcContext.tbl_ServiceRequestAction.Add(entity);
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