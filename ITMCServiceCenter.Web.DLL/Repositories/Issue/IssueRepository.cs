using ITMCServiceCenter.Web.Database;
using ITMCServiceCenter.Web.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ITMCServiceCenter.Web.DLL
{
    public class IssueRepository
    {
        #region Data Members
        private UserUtility userUtility = new UserUtility();
        private TypeUtility typeUtility = new TypeUtility();
        private EntityUtility entityUtility = new EntityUtility();
        private ProjectRepository projectRepository = new ProjectRepository();
        #endregion

        #region Methods
        /// <summary>
        /// Gets all issues for a given project from databse
        /// </summary>
        /// <param name="projectId">Project id</param>
        /// <returns>List of issues</returns>
        public List<tbl_IssueTracker_DTO> GetIssuesByProjectId(short projectId)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (from issue in itmcContext.tbl_IssueTracker
                        where issue.ProjectId == projectId      // filter by projectId
                        select new tbl_IssueTracker_DTO()
                        {
                            CategoryId = issue.CategoryId,
                            CreatedBy = issue.CreatedBy,
                            CreatedOn = issue.CreatedOn,
                            Description = issue.Description,
                            EndDate = issue.EndDate,
                            Id = issue.Id,
                            ModifiedOn = issue.ModifiedOn,
                            PriorityId = issue.PriorityId,
                            ProjectId = issue.ProjectId,
                            StatusId = issue.StatusId,
                            Title = issue.Title,
                            ModifiedBy = issue.ModifiedBy,
                            Module = issue.Module
                        }
                        ).ToList();
                FillAllIssues(result);
                return result;
            }
        }
        /// <summary>
        /// Gets a single issue from database
        /// </summary>
        /// <param name="actionId">Issue id</param>
        /// <returns>Issue</returns>
        public tbl_IssueTracker_DTO GetIssue(int id)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (from issue in itmcContext.tbl_IssueTracker
                        where issue.Id == id   // filter by issueId
                        select new tbl_IssueTracker_DTO()
                        {
                            CategoryId = issue.CategoryId,
                            CreatedBy = issue.CreatedBy,
                            CreatedOn = issue.CreatedOn,
                            Description = issue.Description,
                            EndDate = issue.EndDate,
                            Id = issue.Id,
                            ModifiedOn = issue.ModifiedOn,
                            PriorityId = issue.PriorityId,
                            ProjectId = issue.ProjectId,
                            StatusId = issue.StatusId,
                            Title = issue.Title,
                            ModifiedBy = issue.ModifiedBy,
                            Module = issue.Module
                        }
                      ).ToList();
                FillAllIssues(result);
                return result.FirstOrDefault();
            }
        }
        /// <summary>
        /// Gets all issues from database
        /// </summary>
        /// <returns>List of issues</returns>
        public List<tbl_IssueTracker_DTO> GetIssues()
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (from issue in itmcContext.tbl_IssueTracker
                        select new tbl_IssueTracker_DTO()
                        {
                            CategoryId = issue.CategoryId,
                            CreatedBy = issue.CreatedBy,
                            CreatedOn = issue.CreatedOn,
                            Description = issue.Description,
                            EndDate = issue.EndDate,
                            Id = issue.Id,
                            ModifiedOn = issue.ModifiedOn,
                            PriorityId = issue.PriorityId,
                            ProjectId = issue.ProjectId,
                            StatusId = issue.StatusId,
                            Title = issue.Title,
                            ModifiedBy = issue.ModifiedBy,
                            Module = issue.Module
                        }
                        ).ToList();
                FillAllIssues(result);
                return result;
            }
        }
        /// <summary>
        /// Saves a new Issue Tracker into the database
        /// </summary>
        /// <param name="tbl_IssueTracker_DTO">Issue Tracker to save</param>
        /// <returns>Returns the number of records affected, i.e. 1 if the issue was sucessfully saved, otherwise 0</returns>
        public int SaveIssueTracker(tbl_IssueTracker_DTO tbl_IssueTracker_DTO)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var issueEntity = tbl_IssueTracker_DTO.ToEntity();
                itmcContext.tbl_IssueTracker.Add(issueEntity);
                var isSaved = itmcContext.SaveChanges() > 0;
                if (isSaved)
                {
                    return issueEntity.Id;
                }
                else
                {
                    return -1;
                }
            }
        }
        /// <summary>
        /// Updates an exsisting IssueTracker in the database
        /// </summary>
        /// <param name="tbl_IssueTracker_DTO">IssueTracker instance with updated values</param>
        /// <returns>Returns true if the IssueTracker was sucessfully updated, otherwise false</returns>
        public bool UpdateIssueTracker(tbl_IssueTracker_DTO tbl_IssueTracker_DTO)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                itmcContext.Entry(tbl_IssueTracker_DTO.ToEntity()).State = System.Data.EntityState.Modified;
                return itmcContext.SaveChanges() > 0;
            }
        }
        /// <summary>
        /// Deletes an exsisting IssueTracker in the database
        /// </summary>
        /// <param name="tbl_IssueTracker_DTO">The IssueTracker id</param>
        /// <returns>Returns true if the IssueTracker was sucessfully deleted, otherwise false</returns>
        public bool DeleteIssueTracker(int IssueTrackerId)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var currentIssueTracker = itmcContext.tbl_IssueTracker.Find(IssueTrackerId);
                itmcContext.tbl_IssueTracker.Remove(currentIssueTracker);
                return itmcContext.SaveChanges() > 0;
            }
        }
        #endregion

        #region Private Methods
        private void FillAllIssues(List<tbl_IssueTracker_DTO> issue)
        {
            foreach (tbl_IssueTracker_DTO issueTracker in issue)
            {
                // Fill Project Title
                issueTracker.ProjectTitle = projectRepository.GetProject(issueTracker.ProjectId).Title;

                //Fill Entity Names
                issueTracker.Priority = entityUtility.GetEntityName(issueTracker.PriorityId);
                issueTracker.Status = entityUtility.GetEntityName(issueTracker.StatusId);
                issueTracker.Category = entityUtility.GetEntityName(issueTracker.CategoryId);
            }
        }
        #endregion
    }
}