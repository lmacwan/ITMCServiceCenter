using ITMCServiceCenter.Web.Database;
using ITMCServiceCenter.Web.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ITMCServiceCenter.Web.DLL
{
    public class ServiceRequestRepository
    {
        #region Data Members
        private UserUtility userUtility = new UserUtility();
        private TypeUtility typeUtility = new TypeUtility();
        private EntityUtility entityUtility = new EntityUtility();
        private ProjectRepository projectRepository = new ProjectRepository();
        #endregion

        #region Methods
        /// <summary>
        /// Gets all service requests for a given project from databse
        /// </summary>
        /// <param name="projectId">Project id</param>
        /// <returns>List of service requests</returns>
        public List<tbl_ServiceRequest_DTO> GetServiceRequestsByProjectId(int projectId)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (
                                from serviceRequest in itmcContext.tbl_ServiceRequest
                                where serviceRequest.ProjectId == projectId     // filter by projectId
                                join srPriority in itmcContext.tbl_Entity
                                    on serviceRequest.PriorityId equals srPriority.Id
                                join srStatus in itmcContext.tbl_Entity
                                    on serviceRequest.StatusId equals srStatus.Id
                                join srPrevStatus in itmcContext.tbl_Entity
                                    on serviceRequest.StatusId equals srPrevStatus.Id

                                join srProject in itmcContext.tbl_Project
                                    on serviceRequest.ProjectId equals srProject.Id
                                select new tbl_ServiceRequest_DTO()
                                {
                                    CreatedBy = serviceRequest.CreatedBy,
                                    CreatedOn = serviceRequest.CreatedOn,
                                    Description = serviceRequest.Description,
                                    EndDate = serviceRequest.EndDate,
                                    EstimatedHours = serviceRequest.EstimatedHours,
                                    Id = serviceRequest.Id,
                                    ModifiedOn = serviceRequest.ModifiedOn,
                                    Title = serviceRequest.Title,
                                    PercentComplete = serviceRequest.PercentComplete,
                                    PoNo = serviceRequest.PoNo,
                                    PreviousStatusId = serviceRequest.PreviousStatusId,
                                    PriorityId = serviceRequest.PriorityId,
                                    ProjectId = serviceRequest.ProjectId,
                                    StartDate = serviceRequest.StartDate,
                                    StatusId = serviceRequest.StatusId,

                                    // joins
                                    Status = srStatus.Name,
                                    Priority = srPriority.Name,
                                    PreviousStatus = srPrevStatus.Name,
                                    ProjectTitle = srProject.Title
                                }
                            ).ToList();
                FillAllServiceRequest(result);
                return result;
            }
        }
        /// <summary>
        /// Gets a single service request from database
        /// </summary>
        /// <param name="actionId">Service request id</param>
        /// <returns>Service request</returns>
        public tbl_ServiceRequest_DTO GetServiceRequest(int id)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (
                                from serviceRequest in itmcContext.tbl_ServiceRequest
                                where serviceRequest.Id == id    //filter by serviceRequestId
                                join srPriority in itmcContext.tbl_Entity
                                    on serviceRequest.PriorityId equals srPriority.Id
                                join srStatus in itmcContext.tbl_Entity
                                    on serviceRequest.StatusId equals srStatus.Id
                                join srPrevStatus in itmcContext.tbl_Entity
                                    on serviceRequest.StatusId equals srPrevStatus.Id
                                join srProject in itmcContext.tbl_Project
                                     on serviceRequest.ProjectId equals srProject.Id
                                select new tbl_ServiceRequest_DTO()
                                {
                                    CreatedBy = serviceRequest.CreatedBy,
                                    CreatedOn = serviceRequest.CreatedOn,
                                    Description = serviceRequest.Description,
                                    EndDate = serviceRequest.EndDate,
                                    EstimatedHours = serviceRequest.EstimatedHours,
                                    Id = serviceRequest.Id,
                                    ModifiedOn = serviceRequest.ModifiedOn,
                                    Title = serviceRequest.Title,
                                    PercentComplete = serviceRequest.PercentComplete,
                                    PoNo = serviceRequest.PoNo,
                                    PreviousStatusId = serviceRequest.PreviousStatusId,
                                    PriorityId = serviceRequest.PriorityId,
                                    ProjectId = serviceRequest.ProjectId,
                                    StartDate = serviceRequest.StartDate,
                                    StatusId = serviceRequest.StatusId,

                                    // joins
                                    Status = srStatus.Name,
                                    Priority = srPriority.Name,
                                    PreviousStatus = srPrevStatus.Name,
                                    ProjectTitle = srProject.Title
                                }
                            ).ToList();
                FillAllServiceRequest(result);
                return result.FirstOrDefault();
            }
        }
        /// <summary>
        /// Gets all service requests from database
        /// </summary>
        /// <returns>List of service requests</returns>
        public List<tbl_ServiceRequest_DTO> GetServiceRequests()
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (
                                from serviceRequest in itmcContext.tbl_ServiceRequest
                                select new tbl_ServiceRequest_DTO()
                                {
                                    CreatedBy = serviceRequest.CreatedBy,
                                    CreatedOn = serviceRequest.CreatedOn,
                                    Description = serviceRequest.Description,
                                    EndDate = serviceRequest.EndDate,
                                    EstimatedHours = serviceRequest.EstimatedHours,
                                    Id = serviceRequest.Id,
                                    ModifiedOn = serviceRequest.ModifiedOn,
                                    Title = serviceRequest.Title,
                                    PercentComplete = serviceRequest.PercentComplete,
                                    PoNo = serviceRequest.PoNo,
                                    PreviousStatusId = serviceRequest.PreviousStatusId,
                                    PriorityId = serviceRequest.PriorityId,
                                    ProjectId = serviceRequest.ProjectId,
                                    StartDate = serviceRequest.StartDate,
                                    StatusId = serviceRequest.StatusId,
                                }
                            ).ToList();
                FillAllServiceRequest(result);
                return result;
            }
        }
        /// <summary>
        /// Saves a new service request into the database
        /// </summary>
        /// <param name="tbl_ServiceRequest_DTO">Service request to save</param>
        /// <returns>Returns the number of records affected, i.e. 1 if the sr was sucessfully saved, otherwise 0</returns>
        public int SaveServiceRequest(tbl_ServiceRequest_DTO tbl_ServiceRequest_DTO)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var serviceRequestEntity = tbl_ServiceRequest_DTO.ToEntity();
                itmcContext.tbl_ServiceRequest.Add(serviceRequestEntity);
                var isSaved = itmcContext.SaveChanges() > 0;
                if (isSaved)
                {
                    return serviceRequestEntity.Id;
                }
                else
                {
                    return -1;
                }
            }
        }
        /// <summary>
        /// Updates an exsisting service request in the database
        /// </summary>
        /// <param name="tbl_ServiceRequest_DTO">service request instance with updated values</param>
        /// <returns>Returns true if the service request was sucessfully updated, otherwise false</returns>
        public bool UpdateServiceRequest(tbl_ServiceRequest_DTO tbl_ServiceRequest_DTO)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                itmcContext.Entry(tbl_ServiceRequest_DTO.ToEntity()).State = System.Data.EntityState.Modified;
                //todo: Handle XXX Users
                return itmcContext.SaveChanges() > 0;
            }
        }
        /// <summary>
        /// Deletes an exsisting service request in the database
        /// </summary>
        /// <param name="tbl_ServiceRequest_DTO">The service request id</param>
        /// <returns>Returns true if the service request was sucessfully deleted, otherwise false</returns>
        public bool DeleteServiceRequest(int serviceRequestId)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var currentServiceRequest = itmcContext.tbl_ServiceRequest.Find(serviceRequestId);
                //todo: Handle XXX Users
                itmcContext.tbl_ServiceRequest.Remove(currentServiceRequest);
                return itmcContext.SaveChanges() > 0;
            }
        }
        #endregion

        #region Private Methods
        private void FillAllServiceRequest(List<tbl_ServiceRequest_DTO> serviceRequest)
        {
            foreach (tbl_ServiceRequest_DTO ServiceRequest in serviceRequest)
            {
                //Fill User Fulll Names
                ServiceRequest.RequestedByName = userUtility.GetUserFullName(ServiceRequest.RequestedBy);

                // Fill Project Title
                ServiceRequest.ProjectTitle = projectRepository.GetProject(ServiceRequest.ProjectId).Title;

                //Fill Entity Names
                ServiceRequest.Priority = entityUtility.GetEntityName(ServiceRequest.PriorityId);
                ServiceRequest.Status = entityUtility.GetEntityName(ServiceRequest.StatusId);
                ServiceRequest.PreviousStatus = entityUtility.GetEntityName(ServiceRequest.PreviousStatusId);
            }
        }
        #endregion
    }
}