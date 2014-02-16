using ITMCServiceCenter.Web.Database;
using ITMCServiceCenter.Web.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ITMCServiceCenter.Web.DLL
{
    public class ChangeRequestRepository
    {
        #region Data Members
        private UserUtility userUtility = new UserUtility();
        private TypeUtility typeUtility = new TypeUtility();
        private EntityUtility entityUtility = new EntityUtility();
        private ProjectRepository projectRepository = new ProjectRepository();
        private List<tbl_ChangeRequest_DTO> testChangeRequests = new List<tbl_ChangeRequest_DTO>();
        private AssigneeRepository assineeRepository = new AssigneeRepository();
        #endregion

        #region Methods
        /// <summary>
        /// Gets all change requests for a given project from databse
        /// </summary>
        /// <param name="projectId">Project id</param>
        /// <returns>List of change requests</returns>
        public List<tbl_ChangeRequest_DTO> GetChangeRequestsByProjectId(short projectId)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (
                               from changeRequest in itmcContext.tbl_ChangeRequest
                               where changeRequest.ProjectId == projectId    //filter by projectId
                               select new tbl_ChangeRequest_DTO()
                               {
                                   ChangeWriter = changeRequest.ChangeWriter,
                                   CreatedBy = changeRequest.CreatedBy,
                                   CreatedOn = changeRequest.CreatedOn,
                                   Description = changeRequest.Description,
                                   EndDate = changeRequest.EndDate,
                                   EstimatedHours = changeRequest.EstimatedHours,
                                   Id = changeRequest.Id,
                                   Impact = changeRequest.Impact,
                                   ModifiedOn = changeRequest.ModifiedOn,
                                   PercentComplete = changeRequest.PercentComplete,
                                   PoNo = changeRequest.PoNo,
                                   PriorityId = changeRequest.PriorityId,
                                   ProjectId = changeRequest.ProjectId,
                                   RequestedOn = changeRequest.RequestedOn,
                                   StartDate = changeRequest.StartDate,
                                   StatusId = changeRequest.StatusId,
                                   Title = changeRequest.Title,
                                   Approver = changeRequest.Approver,
                                   ModifiedBy = changeRequest.ModifiedBy,
                                   RequestedBy = changeRequest.RequestedBy
                               }
                            ).ToList();
                FillAllChangeRequests(result);
                return result;
            }
        }

        /// <summary>
        /// Gets a single change request action from database
        /// </summary>
        /// <param name="actionId">Change requests action id</param>
        /// <returns>Change request</returns>
        public tbl_ChangeRequest_DTO GetChangeRequest(int id)
        {

            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (

                              from changeRequest in itmcContext.tbl_ChangeRequest
                              where changeRequest.Id == id      //filter by id
                              select new tbl_ChangeRequest_DTO()
                              {
                                  ChangeWriter = changeRequest.ChangeWriter,
                                  CreatedBy = changeRequest.CreatedBy,
                                  CreatedOn = changeRequest.CreatedOn,
                                  Description = changeRequest.Description,
                                  EndDate = changeRequest.EndDate,
                                  EstimatedHours = changeRequest.EstimatedHours,
                                  Id = changeRequest.Id,
                                  Impact = changeRequest.Impact,
                                  ModifiedOn = changeRequest.ModifiedOn,
                                  PercentComplete = changeRequest.PercentComplete,
                                  PoNo = changeRequest.PoNo,
                                  PriorityId = changeRequest.PriorityId,
                                  ProjectId = changeRequest.ProjectId,
                                  RequestedOn = changeRequest.RequestedOn,
                                  StartDate = changeRequest.StartDate,
                                  StatusId = changeRequest.StatusId,
                                  Title = changeRequest.Title,
                                  Approver = changeRequest.Approver,
                                  ModifiedBy = changeRequest.ModifiedBy,
                                  RequestedBy = changeRequest.RequestedBy,
                              }
                           ).ToList();
                FillAllChangeRequests(result);
                return result.FirstOrDefault();
            }
        }

        /// <summary>
        /// Gets all change requests from database
        /// </summary>
        /// <returns>List of change requests</returns>
        public List<tbl_ChangeRequest_DTO> GetChangeRequests()
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (
                              from changeRequest in itmcContext.tbl_ChangeRequest
                              select new tbl_ChangeRequest_DTO()
                              {
                                  ChangeWriter = changeRequest.ChangeWriter,
                                  CreatedBy = changeRequest.CreatedBy,
                                  CreatedOn = changeRequest.CreatedOn,
                                  Description = changeRequest.Description,
                                  EndDate = changeRequest.EndDate,
                                  EstimatedHours = changeRequest.EstimatedHours,
                                  Id = changeRequest.Id,
                                  Impact = changeRequest.Impact,
                                  ModifiedOn = changeRequest.ModifiedOn,
                                  PercentComplete = changeRequest.PercentComplete,
                                  PoNo = changeRequest.PoNo,
                                  PriorityId = changeRequest.PriorityId,
                                  ProjectId = changeRequest.ProjectId,
                                  RequestedOn = changeRequest.RequestedOn,
                                  StartDate = changeRequest.StartDate,
                                  StatusId = changeRequest.StatusId,
                                  Title = changeRequest.Title,
                                  Approver = changeRequest.Approver,
                                  ModifiedBy = changeRequest.ModifiedBy,
                                  RequestedBy = changeRequest.RequestedBy,
                              }
                           ).ToList();
                FillAllChangeRequests(result);
                return result;
            }
        }

        /// <summary>
        /// Saves a new change request into the database
        /// </summary>
        /// <param name="tbl_Project_DTO">Change request to save</param>
        /// <returns>Returns the number of records afffected, i.e. 1 if the change request was sucessfully saved, otherwise 0</returns>
        public int SaveChangeRequest(tbl_ChangeRequest_DTO tbl_ChangeRequest_DTO)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var newChangeRequestId = -1;
                var changeRequestEntity = tbl_ChangeRequest_DTO.ToEntity();
                itmcContext.tbl_ChangeRequest.Add(changeRequestEntity);
                if (itmcContext.SaveChanges() > 0)
                {
                    if (SaveAssignees(tbl_ChangeRequest_DTO.Assignees, changeRequestEntity.Id))
                    {
                        newChangeRequestId = changeRequestEntity.Id;
                    }
                    else
                    {
                        DeleteChangeRequest(newChangeRequestId);
                    }
                }
                return newChangeRequestId;
            }
        }

        /// <summary>
        /// Updates an exsisting change request in the database
        /// </summary>
        /// <param name="tbl_Project_DTO">change request instance with updated values</param>
        /// <returns>Returns true if the change request was sucessfully updated, otherwise false</returns>
        public bool UpdateChangeRequest(tbl_ChangeRequest_DTO tbl_ChangeRequest_DTO)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var isSaved = false;
                itmcContext.Entry(tbl_ChangeRequest_DTO.ToEntity()).State = System.Data.EntityState.Modified;
                if (itmcContext.SaveChanges() > 0)
                {
                    isSaved= SaveAssignees(tbl_ChangeRequest_DTO.Assignees, tbl_ChangeRequest_DTO.Id);
                }
                return isSaved;
            }
        }

        /// <summary>
        /// Deletes an exsisting change request in the database
        /// </summary>
        /// <param name="tbl_Project_DTO">The change request id</param>
        /// <returns>Returns true if the change request was sucessfully deleted, otherwise false</returns>
        public bool DeleteChangeRequest(int changeRequestId)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var currentChangeRequest = itmcContext.tbl_ChangeRequest.Find(changeRequestId);
                itmcContext.tbl_ChangeRequest.Remove(currentChangeRequest);
                return itmcContext.SaveChanges() > 0;
            }
        }
        #endregion

        #region Private Methods
        private void FillAllChangeRequests(List<tbl_ChangeRequest_DTO> changeRequests)
        {
            foreach (tbl_ChangeRequest_DTO changeRequest in changeRequests)
            {
                //Fill Assignees
                changeRequest.Assignees = assineeRepository.GetList(typeUtility.GetTypeByEnum(Types.ChangeRequest).Id, changeRequest.Id);

                //Fill User Fulll Names
                changeRequest.ChangeWriterName = userUtility.GetUserFullName(changeRequest.ChangeWriter);
                changeRequest.RequestedByName = userUtility.GetUserFullName(changeRequest.RequestedBy);
                changeRequest.ApproverName = userUtility.GetUserFullName(changeRequest.Approver);

                // Fill Project Title
                changeRequest.ProjectTitle = projectRepository.GetProject(changeRequest.ProjectId).Title;

                //Fill Entity Names
                changeRequest.Priority = entityUtility.GetEntityName(changeRequest.PriorityId);
                changeRequest.Status = entityUtility.GetEntityName(changeRequest.StatusId);
            }
        }
        #endregion

        public bool SaveAssignees(List<tbl_Assignee_DTO> assignees, int id)
        {
            return assineeRepository.Save(assignees, typeUtility.GetTypeByEnum(Types.ChangeRequest).Id, id);
        }
    }
}