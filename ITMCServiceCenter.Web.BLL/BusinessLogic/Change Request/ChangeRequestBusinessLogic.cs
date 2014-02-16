using System.Collections.Generic;
using System.Linq;
using ITMCServiceCenter.Web.Domain;
using System;
using System.Data.SqlTypes;

namespace ITMCServiceCenter.Web.BLL
{
    public class ChangeRequestBusinessLogic
    {
        #region Static Methods
        /// <summary>
        /// Calls the service and gets all change requests for a given project from databse
        /// </summary>
        /// <param name="projectId">Project id</param>
        /// <returns>List of change requests</returns>
        public static List<tbl_ChangeRequest_DTO> GetChangeRequestsByProjectId(short projectId)
        {
            List<tbl_ChangeRequest_DTO> changeRequests = null;
            var changeRequestDetails = ServiceReference.ITMCServiceClient.GetChangeRequestsByProjectId(projectId);
            if (changeRequestDetails.Success)
            {
                changeRequests = changeRequestDetails.Value.ToList();
            }
            return changeRequests;
        }

        /// <summary>
        /// Calls the service and gets a single change request action from database
        /// </summary>
        /// <param name="actionId">Change requests action id</param>
        /// <returns>Change request</returns>
        public static tbl_ChangeRequest_DTO GetChangeRequest(int id)
        {
            tbl_ChangeRequest_DTO changeRequest = null;
            if (id <= 0)
            {
                changeRequest = new tbl_ChangeRequest_DTO();
            }
            else
            {
                var changeRequestDetails = ServiceReference.ITMCServiceClient.GetChangeRequest(id);
                if (changeRequestDetails.Success)
                {
                    changeRequest = Validate(changeRequestDetails.Value);
                }
            }
            return changeRequest;
        }

        /// <summary>
        /// Calls the service and gets all change requests from database
        /// </summary>
        /// <returns>List of change requests</returns>
        public static List<tbl_ChangeRequest_DTO> GetChangeRequests()
        {
            List<tbl_ChangeRequest_DTO> changeRequests = null;
            var changeRequestDetails = ServiceReference.ITMCServiceClient.GetChangeRequests();
            if (changeRequestDetails.Success)
            {
                changeRequests = changeRequestDetails.Value.ToList();
            }
            return changeRequests;
        }
        #endregion

        #region Instance Methods
        /// <summary>
        /// Calls the service and saves a new change request into the database
        /// </summary>
        /// <param name="tbl_ChangeRequest_DTO">Change request to save</param>
        /// <returns>Returns the number of records affected, i.e. 1 if the ch was sucessfully saved, otherwise 0</returns>
        public int SaveChangeRequest(tbl_ChangeRequest_DTO tbl_ChangeRequest_DTO, List<int> assigneesIds)
        {
            var result = -1;
            tbl_ChangeRequest_DTO.CreatedBy = ITMCServiceCenterApplication.CurrentContextUser.UserFullName;
            tbl_ChangeRequest_DTO.CreatedOn = DateTime.Now;
            tbl_ChangeRequest_DTO.Assignees = GetAssignees(assigneesIds);
            if (Validate(tbl_ChangeRequest_DTO).IsValid)
            {
                var changeRequestDetails = ServiceReference.ITMCServiceClient.SaveChangeRequest(tbl_ChangeRequest_DTO);
                if (changeRequestDetails.Success)
                {
                    result = changeRequestDetails.Value;
                }
            }
            return result;
        }

        /// <summary>
        /// Calls the service and updates an exsisting change request in the database
        /// </summary>
        /// <param name="tbl_ChangeRequest_DTO">change request instance with updated values</param>
        /// <returns>Returns true if the change request was sucessfully updated, otherwise false</returns>
        public int UpdateChangeRequest(tbl_ChangeRequest_DTO tbl_ChangeRequest_DTO, List<int> assigneesIds)
        {
            var result = -1;
            tbl_ChangeRequest_DTO.ModifiedBy = ITMCServiceCenterApplication.CurrentContextUser.UserFullName;
            tbl_ChangeRequest_DTO.ModifiedOn = DateTime.Now;
            tbl_ChangeRequest_DTO.Assignees = GetAssignees(assigneesIds);
            if (Validate(tbl_ChangeRequest_DTO).IsValid)
            {
                var changeRequestDetails = ServiceReference.ITMCServiceClient.UpdateChangeRequest(tbl_ChangeRequest_DTO);
                if (changeRequestDetails.Success)
                {
                    result = tbl_ChangeRequest_DTO.Id;
                }
            }
            return result;
        }

        /// <summary>
        /// Calls the service and deletes an exsisting change request in the database
        /// </summary>
        /// <param name="tbl_ChangeRequest_DTO">The change request id</param>
        /// <returns>Returns true if the change request was sucessfully deleted, otherwise false</returns>
        public bool DeleteChangeRequest(int changeRequestId)
        {
            var result = false;
            var changeRequestDetails = ServiceReference.ITMCServiceClient.DeleteChangeRequest(changeRequestId);
            if (changeRequestDetails.Success)
            {
                result = changeRequestDetails.Value;
            }
            return result;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Validates change request 
        /// </summary>
        /// <param name="actionDTO">Change request</param>
        /// <returns>Change request with additional error data, if present</returns>
        private static tbl_ChangeRequest_DTO Validate(tbl_ChangeRequest_DTO changeRequestDTO)
        {
            if (changeRequestDTO == null)
            {
                changeRequestDTO = new tbl_ChangeRequest_DTO();
            }
            return changeRequestDTO;
        }

        private static List<tbl_Assignee_DTO> GetAssignees(List<int> assigneesIds)
        {
            return (from userId in assigneesIds
                    select new tbl_Assignee_DTO()
                    {
                        UserId = userId,
                    }).ToList();
        }
        #endregion
    }
}