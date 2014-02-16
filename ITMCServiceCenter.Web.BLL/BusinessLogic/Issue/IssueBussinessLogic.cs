using ITMCServiceCenter.Web.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;

namespace ITMCServiceCenter.Web.BLL
{
    public class IssueBussinessLogic
    {
        #region Static Methods
        /// <summary>
        /// Calls the service and gets all issues for a given project from databse
        /// </summary>
        /// <param name="projectId">Project id</param>
        /// <returns>List of issues</returns>
        public static List<tbl_IssueTracker_DTO> GetIssuesByProjectId(short projectId)
        {
            List<tbl_IssueTracker_DTO> issuelist = null;
            var issueDetails = ServiceReference.ITMCServiceClient.GetIssuesByProjectId(projectId);
            if (issueDetails.Success)
            {
                issuelist = issueDetails.Value.ToList();
            }
            return issuelist;
        }
       
        /// <summary>
        /// Calls the service and gets a single issue from database
        /// </summary>
        /// <param name="actionId">Issue id</param>
        /// <returns>Issue</returns>
        public static tbl_IssueTracker_DTO GetIssue(int id)
        {
            tbl_IssueTracker_DTO issue = null;
            if (id <= 0)
            {
                issue = new tbl_IssueTracker_DTO();
            }
            else
            {
                var issueDetails = ServiceReference.ITMCServiceClient.GetIssue(id);
                if (issueDetails.Success)
                {
                    issue = issueDetails.Value;
                }
            }
            return issue;
        }
       
        /// <summary>
        /// Calls the service and gets all issues from database
        /// </summary>
        /// <returns>List of issues</returns>
        public static List<tbl_IssueTracker_DTO> GetIssues()
        {
            List<tbl_IssueTracker_DTO> issuelist = null;
            var issueDetails = ServiceReference.ITMCServiceClient.GetIssues();
            if (issueDetails.Success)
            {
                issuelist = issueDetails.Value.ToList();
            }
            return issuelist;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Calls the service and saves a new Issue into the database
        /// </summary>
        /// <param name="tbl_IssueTracker_DTO">Issue to save</param>
        /// <returns>Returns the number of records afffected, i.e. 1 if the issue was sucessfully saved, otherwise 0</returns>
        public int SaveIssue(tbl_IssueTracker_DTO tbl_Issue_DTO)
        {
            int result = -1;
            tbl_Issue_DTO.CreatedBy = ITMCServiceCenterApplication.CurrentContextUser.UserFullName;
            tbl_Issue_DTO.CreatedOn = DateTime.Now;

            var IssueDetails = ServiceReference.ITMCServiceClient.SaveIssue(tbl_Issue_DTO);
            if (IssueDetails.Success)
            {
                result = IssueDetails.Value;
            }
            return result;
        }
       
        /// <summary>
        /// Calls the service and updates an exsisting Issue in the database
        /// </summary>
        /// <param name="tbl_IssueTracker_DTO">Issue instance with updated values</param>
        /// <returns>Returns true if the Issue was sucessfully updated, otherwise false</returns>
        public int UpdateIssue(tbl_IssueTracker_DTO tbl_Issue_DTO)
        {
            tbl_Issue_DTO.ModifiedBy = ITMCServiceCenterApplication.CurrentContextUser.UserFullName;
            tbl_Issue_DTO.ModifiedOn = DateTime.Now;
            int result = -1;
            var IssueDetails = ServiceReference.ITMCServiceClient.UpdateIssue(tbl_Issue_DTO);
            if (IssueDetails.Success)
            {
                result = tbl_Issue_DTO.Id;
            }
            return result;
        }
       
        /// <summary>
        /// Calls the service and deletes an exsisting Issue in the database
        /// </summary>
        /// <param name="tbl_IssueTracker_DTO">The Issue id</param>
        /// <returns>Returns true if the Issue was sucessfully deleted, otherwise false</returns>
        public bool DeleteIssue(int issueId)
        {
            bool result = false;
            var IssueDetails = ServiceReference.ITMCServiceClient.DeleteIssue(issueId);
            if (IssueDetails.Success)
            {
                result = IssueDetails.Value;
            }
            return result;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Validates issue
        /// </summary>
        /// <param name="actionDTO">Issue</param>
        /// <returns>Issue with additional error data, if present</returns>
        private static tbl_IssueTracker_DTO Validate(tbl_IssueTracker_DTO issueDTO)
        {
            if (issueDTO == null)
            {
                issueDTO = new tbl_IssueTracker_DTO();
            }
            return issueDTO;
        }
        #endregion
    }
}
