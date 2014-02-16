using ITMCServiceCenter.Web.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;

namespace ITMCServiceCenter.Web.BLL
{
    public class ServiceRequestBusinessLogic
    {
        #region Static Methods
        /// <summary>
        /// Calls the service and gets all service requests for a given project from databse
        /// </summary>
        /// <param name="projectId">Project id</param>
        /// <returns>List of service requests</returns>
        public static List<tbl_ServiceRequest_DTO> GetServiceRequestsByProjectId(short projectId)
        {
            List<tbl_ServiceRequest_DTO> serviceRequests = null;
            var serviceRequestDetails = ServiceReference.ITMCServiceClient.GetServiceRequestsByProjectId(projectId);
            if (serviceRequestDetails.Success)
            {
                serviceRequests = serviceRequestDetails.Value.ToList();
            }
            return serviceRequests;
        }
       
        /// <summary>
        /// Calls the service and gets a single service request from database
        /// </summary>
        /// <param name="actionId">Service request id</param>
        /// <returns>Service request</returns>
        public static tbl_ServiceRequest_DTO GetServiceRequest(int id)
        {
            tbl_ServiceRequest_DTO serviceRequest = null;
            if (id <= 0)
            {
                serviceRequest = new tbl_ServiceRequest_DTO();
            }
            else
            {
                var serviceRequestDetails = ServiceReference.ITMCServiceClient.GetServiceRequest(id);
                if (serviceRequestDetails.Success)
                {
                    serviceRequest = serviceRequestDetails.Value;
                }
            }
            return serviceRequest;
        }
       
        /// <summary>
        /// Calls the service and gets all service requests from database
        /// </summary>
        /// <returns>List of service requests</returns>
        public static List<tbl_ServiceRequest_DTO> GetServiceRequests()
        {
            List<tbl_ServiceRequest_DTO> serviceRequestList = null;
            var serviceRequestDetails = ServiceReference.ITMCServiceClient.GetServiceRequests();
            if (serviceRequestDetails.Success)
            {
                serviceRequestList = serviceRequestDetails.Value.ToList();
            }
            return serviceRequestList;
        }
        #endregion

        #region Methods
        /// </summary>
        /// <param name="tbl_ServiceRequest_DTO">Service request to save</param>
        /// <returns>Returns the number of records affected, i.e. 1 if the sr was sucessfully saved, otherwise 0</returns>
        public int SaveServiceRequest(tbl_ServiceRequest_DTO tbl_ServiceRequest_DTO)
        {
            tbl_ServiceRequest_DTO.CreatedBy = ITMCServiceCenterApplication.CurrentContextUser.UserFullName;
            tbl_ServiceRequest_DTO.CreatedOn = DateTime.Now;
            var serviceRequestDetails = ServiceReference.ITMCServiceClient.SaveServiceRequest(tbl_ServiceRequest_DTO);
            int result = -1;
            if (serviceRequestDetails.Success)
            {
                result = serviceRequestDetails.Value;
            }
            return result;
        }
       
        /// <summary>
        /// Calls the service and updates an exsisting service request in the database
        /// </summary>
        /// <param name="tbl_ServiceRequest_DTO">service request instance with updated values</param>
        /// <returns>Returns true if the service request was sucessfully updated, otherwise false</returns>
        public int UpdateServiceRequest(tbl_ServiceRequest_DTO tbl_ServiceRequest_DTO)
        {
            tbl_ServiceRequest_DTO.ModifiedBy = ITMCServiceCenterApplication.CurrentContextUser.UserFullName;
            tbl_ServiceRequest_DTO.ModifiedOn = DateTime.Now;
            var serviceRequestDetails = ServiceReference.ITMCServiceClient.UpdateServiceRequest(tbl_ServiceRequest_DTO);
            var result = -1;
            if (serviceRequestDetails.Success)
            {
                result = tbl_ServiceRequest_DTO.Id;
            }
            return result;
        }
        
        /// <summary>
        /// Calls the service and deletes an exsisting service request in the database
        /// </summary>
        /// <param name="tbl_ServiceRequest_DTO">The service request id</param>
        /// <returns>Returns true if the service request was sucessfully deleted, otherwise false</returns>
        public bool DeleteServiceRequest(int serviceRequestId)
        {
            var serviceRequestDetails = ServiceReference.ITMCServiceClient.DeleteServiceRequest(serviceRequestId);
            bool result = false;
            if (serviceRequestDetails.Success)
            {
                result = serviceRequestDetails.Value;
            }
            return result;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Validates service request 
        /// </summary>
        /// <param name="actionDTO">Service request</param>
        /// <returns>Service request with additional error data, if present</returns>
        private static tbl_ServiceRequest_DTO Validate(tbl_ServiceRequest_DTO serviceRequestDTO)
        {
            if (serviceRequestDTO == null)
            {
                serviceRequestDTO = new tbl_ServiceRequest_DTO();
            }
            return serviceRequestDTO;
        }        
        #endregion
    }
}
