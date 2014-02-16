using ITMCServiceCenter.Web.Database;
using ITMCServiceCenter.Web.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ITMCServiceCenter.Web.DLL
{
    public class IncidentActionRepository
    {
        #region Methods
        /// <summary>
        /// get list of all incidents actions from database.
        /// </summary>
        /// <returns></returns>
        public List<tbl_IncidentAction_DTO> GetIncidentActions()
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (

                    from incidentaction in itmcContext.tbl_IncidentAction
                    join incident in itmcContext.tbl_ProjectTask
                      on incidentaction.IncidentId equals incident.Id

                    select new tbl_IncidentAction_DTO()
                    {
                        Id = incidentaction.Id,
                        IncidentId = incidentaction.IncidentId,
                        CreatedBy = incidentaction.CreatedBy,
                        Action = incidentaction.Action,
                        CreatedOn = incidentaction.CreatedOn,
                        //joins
                    }).ToList();

                return result;
            }
        }
       
        /// <summary>
        /// get specific incident action details based on action id. 
        /// </summary>
        /// <param name="actionId"></param>
        /// <returns></returns>
        public tbl_IncidentAction_DTO GetIncidentAction(int actionId)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (

                    from incidentaction in itmcContext.tbl_IncidentAction
                    where incidentaction.Id == actionId
                    join incident in itmcContext.tbl_ProjectTask
                      on incidentaction.IncidentId equals incident.Id

                    select new tbl_IncidentAction_DTO()
                    {
                        Id = incidentaction.Id,
                        IncidentId = incidentaction.IncidentId,
                        CreatedBy = incidentaction.CreatedBy,
                        Action = incidentaction.Action,
                        CreatedOn = incidentaction.CreatedOn,
                        //joins
                    }).FirstOrDefault();

                return result;
            }
        }
       
        /// <summary>
        /// get list of all incident actions based on incident id.
        /// </summary>
        /// <param name="incidentId"></param>
        /// <returns></returns>
        public List<tbl_IncidentAction_DTO> GetIncidentActionByIncidentId(int incidentId)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (

                    from incidentaction in itmcContext.tbl_IncidentAction
                    where incidentaction.IncidentId == incidentId
                    select new tbl_IncidentAction_DTO()
                    {
                        Id = incidentaction.Id,
                        IncidentId = incidentaction.IncidentId,
                        CreatedBy = incidentaction.CreatedBy,
                        Action = incidentaction.Action,
                        CreatedOn = incidentaction.CreatedOn,
                        //joins
                    }).ToList();

                return result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionDto"></param>
        /// <returns></returns>
        public int SaveIncidentAction(tbl_IncidentActionDTO actionDto)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var entity = actionDto.ToEntity();
                itmcContext.tbl_IncidentAction.Add(entity);
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
