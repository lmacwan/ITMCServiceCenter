using ITMCServiceCenter.Web.Database;
using ITMCServiceCenter.Web.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ITMCServiceCenter.Web.DLL
{
    public class IssueActionRepository
    {
        #region Methods
        /// <summary>
        /// Gets all actions for a given issue from databse
        /// </summary>
        /// <param name="id">Issue id</param>
        /// <returns>List of issue actions</returns>
        public List<tbl_IssueTrackerAction_DTO> GetIssueActionsByIssueId(int id) 
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (
                                from issueAction in itmcContext.tbl_IssueTrackerAction
                                where issueAction.IssueTrackerId == id       //filter by id
                                select new tbl_IssueTrackerAction_DTO()
                                {
                                    Action = issueAction.Action,
                                    IssueTrackerId = issueAction.IssueTrackerId,
                                    CreatedBy = issueAction.CreatedBy,
                                    CreatedOn = issueAction.CreatedOn,
                                    Id = issueAction.Id,
                                }
                            ).ToList();
                return result;
            }
        }

        /// <summary>
        /// Gets a single issue action from database
        /// </summary>
        /// <param name="actionId">Issue action id</param>
        /// <returns>Issue action</returns>
        public tbl_IssueTrackerAction_DTO GetIssueAction(int actionId)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (
                                from issueAction in itmcContext.tbl_IssueTrackerAction
                                where issueAction.Id == actionId       //filter by issueActionId
                                select new tbl_IssueTrackerAction_DTO()
                                {
                                    Action = issueAction.Action,
                                    IssueTrackerId = issueAction.IssueTrackerId,
                                    CreatedBy = issueAction.CreatedBy,
                                    CreatedOn = issueAction.CreatedOn,
                                    Id = issueAction.Id,
                                }
                            ).FirstOrDefault();
                return result;
            }
        }

        /// <summary>
        /// Gets all actions for all issues from database
        /// </summary>
        /// <returns>List of issue actions</returns>
        public List<tbl_IssueTrackerAction_DTO> GetIssueActions()
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (
                                from issueAction in itmcContext.tbl_IssueTrackerAction
                                select new tbl_IssueTrackerAction_DTO()
                                {
                                    Action = issueAction.Action,
                                    IssueTrackerId = issueAction.IssueTrackerId,
                                    CreatedBy = issueAction.CreatedBy,
                                    CreatedOn = issueAction.CreatedOn,
                                    Id = issueAction.Id,
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
        public int SaveIssueAction(tbl_IssueTrackerActionDTO actionDto)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var entity = actionDto.ToEntity();
                itmcContext.tbl_IssueTrackerAction.Add(entity);
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