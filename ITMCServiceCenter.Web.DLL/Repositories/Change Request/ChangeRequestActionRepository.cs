using ITMCServiceCenter.Web.Database;
using ITMCServiceCenter.Web.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ITMCServiceCenter.Web.DLL
{
    public class ChangeRequestActionRepository
    {
        #region Methods
        /// <summary>
        /// Gets all actions for a given change request from databse
        /// </summary>
        /// <param name="id">Change request id</param>
        /// <returns>List of change request actions</returns>
        public List<tbl_ChangeRequestAction_DTO> GetChangeRequestActionsByRequestId(int id)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (
                                from changeRequestAction in itmcContext.tbl_ChangeRequestAction
                                where changeRequestAction.ChangeRequestId == id      //filter by id
                                select new tbl_ChangeRequestAction_DTO()
                                {
                                    Action = changeRequestAction.Action,
                                    ChangeRequestId = changeRequestAction.ChangeRequestId,
                                    CreatedBy = changeRequestAction.CreatedBy,
                                    CreatedOn = changeRequestAction.CreatedOn,
                                    Id = changeRequestAction.Id,
                                }
                            ).ToList();
                return result;
            }
        }

        /// <summary>
        /// Gets a single change request action from database
        /// </summary>
        /// <param name="actionId">Change request action id</param>
        /// <returns>Change request action</returns>
        public tbl_ChangeRequestAction_DTO GetChangeRequestAction(int actionId)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (
                                from changeRequestAction in itmcContext.tbl_ChangeRequestAction
                                where changeRequestAction.Id == actionId      //filter by crActionId
                                select new tbl_ChangeRequestAction_DTO()
                                {
                                    Action = changeRequestAction.Action,
                                    ChangeRequestId = changeRequestAction.ChangeRequestId,
                                    CreatedBy = changeRequestAction.CreatedBy,
                                    CreatedOn = changeRequestAction.CreatedOn,
                                    Id = changeRequestAction.Id,
                                }
                            ).FirstOrDefault();
                return result;
            }
        }

        /// <summary>
        /// Gets all actions for all change requests from database
        /// </summary>
        /// <returns>List of change request actions</returns>
        public List<tbl_ChangeRequestAction_DTO> GetChangeRequestActions()
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (
                                from changeRequestAction in itmcContext.tbl_ChangeRequestAction
                                select new tbl_ChangeRequestAction_DTO()
                                {
                                    Action = changeRequestAction.Action,
                                    ChangeRequestId = changeRequestAction.ChangeRequestId,
                                    CreatedBy = changeRequestAction.CreatedBy,
                                    CreatedOn = changeRequestAction.CreatedOn,
                                    Id = changeRequestAction.Id,
                                }
                            ).ToList();
                return result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionDto"></param>
        /// <returns></returns>
        public int SaveChangeRequestAction(tbl_ChangeRequestActionDTO actionDto)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer()) {
                var entity = actionDto.ToEntity();
                itmcContext.tbl_ChangeRequestAction.Add(entity);
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