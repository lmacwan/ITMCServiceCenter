using ITMCServiceCenter.Web.Domain;
using ITMCServiceCenter.Web.DLL;
using System;
using System.Collections.Generic;

namespace ITMCServiceCenter.Web.Services
{
    public class ITMCService : IITMCService
    {
        #region Account
        public ServiceResult<tbl_UserMaster_DTO> AuthenticateUser(tbl_UserMaster_DTO userToAuthenticate)
        {
            var accountRepository = new AccountRepository();
            var accountDetails = new ServiceResult<tbl_UserMaster_DTO>();
            try
            {
                accountDetails.Value = accountRepository.AuthenticateUser(userToAuthenticate);
                accountDetails.Success = true;
            }
            catch (Exception ex)
            {
                accountDetails.Value = null;
                accountDetails.Success = false;
            }
            return accountDetails;
        }

        #endregion

        #region User
        public ServiceResult<List<tbl_UserMaster_DTO>> GetUsersByDesignationId(int designationId)
        {
            var userRepository = new UserRepository();
            var userDetails = new ServiceResult<List<tbl_UserMaster_DTO>>();
            try
            {
                userDetails.Value = userRepository.GetUsersByDesignationId(designationId);
                userDetails.Success = true;
            }
            catch (Exception ex)
            {
                userDetails.Value = null;
                userDetails.Success = false;
            }
            return userDetails;
        }

        public ServiceResult<List<tbl_UserMaster_DTO>> GetUsersByRoleId(int roleId)
        {
            var userRepository = new UserRepository();
            var userDetails = new ServiceResult<List<tbl_UserMaster_DTO>>();
            try
            {
                userDetails.Value = userRepository.GetUsersByRoleId(roleId);
                userDetails.Success = true;
            }
            catch (Exception ex)
            {
                userDetails.Value = null;
                userDetails.Success = false;
            }
            return userDetails;
        }

        public ServiceResult<tbl_UserMaster_DTO> GetUserByUserName(string userName)
        {
            var userRepository = new UserRepository();
            var userDetails = new ServiceResult<tbl_UserMaster_DTO>();
            try
            {
                userDetails.Value = userRepository.GetUserByUserName(userName);
                userDetails.Success = true;
            }
            catch (Exception ex)
            {
                userDetails.Value = null;
                userDetails.Success = false;
            }
            return userDetails;
        }

        public ServiceResult<tbl_UserMaster_DTO> GetUser(int id)
        {
            var userRepository = new UserRepository();
            var userDetails = new ServiceResult<tbl_UserMaster_DTO>();
            try
            {
                userDetails.Value = userRepository.GetUser(id);
                userDetails.Success = true;
            }
            catch (Exception ex)
            {
                userDetails.Value = null;
                userDetails.Success = false;
            }
            return userDetails;
        }

        public ServiceResult<List<tbl_UserMaster_DTO>> GetUsers()
        {
            var userRepository = new UserRepository();
            var userDetails = new ServiceResult<List<tbl_UserMaster_DTO>>();
            try
            {
                userDetails.Value = userRepository.GetUsers();
                userDetails.Success = true;
            }
            catch (Exception ex)
            {
                userDetails.Value = null;
                userDetails.Success = false;
            }
            return userDetails;
        }

        public ServiceResult<int> SaveUser(tbl_UserMaster_DTO tbl_UserMaster_DTO)
        {
            var userRepository = new UserRepository();
            var userDetails = new ServiceResult<int>();
            try
            {
                userDetails.Value = userRepository.SaveUser(tbl_UserMaster_DTO);
                userDetails.Success = true;
            }
            catch (Exception ex)
            {
                userDetails.Value = -1;
                userDetails.Success = false;
            }
            return userDetails;
        }

        public ServiceResult<bool> UpdateUser(tbl_UserMaster_DTO tbl_UserMaster_DTO)
        {
            var userRepository = new UserRepository();
            var userDetails = new ServiceResult<bool>();
            try
            {
                userDetails.Value = userRepository.UpdateUser(tbl_UserMaster_DTO);
                userDetails.Success = true;
            }
            catch (Exception ex)
            {
                userDetails.Value = false;
                userDetails.Success = false;
            }
            return userDetails;
        }

        public ServiceResult<bool> DeleteUser(int userId)
        {
            var userRepository = new UserRepository();
            var userDetails = new ServiceResult<bool>();
            try
            {
                userDetails.Value = userRepository.DeleteUser(userId);
                userDetails.Success = true;
            }
            catch (Exception ex)
            {
                userDetails.Value = false;
                userDetails.Success = false;
            }
            return userDetails;
        }

        #region Engineers
        public ServiceResult<List<tbl_Engineer_DTO>> GetEngineers(Types type, int typeId)
        {
            var engineerRepository = new EngineerRepository();
            var engineerDetails = new ServiceResult<List<tbl_Engineer_DTO>>();
            try
            {
                engineerDetails.Value = engineerRepository.GetEngineers(type, typeId);
                engineerDetails.Success = true;
            }
            catch (Exception ex)
            {
                engineerDetails.Value = null;
                engineerDetails.Success = false;
            }
            return engineerDetails;
        }

        public ServiceResult<bool> SaveEngineers(List<tbl_Engineer_DTO> newEngineers, Types type, int typeId)
        {
            var engineerRepository = new EngineerRepository();
            var engineerDetails = new ServiceResult<bool>();
            try
            {
                engineerDetails.Value = engineerRepository.SaveEngineers(newEngineers, type, typeId);
                engineerDetails.Success = true;
            }
            catch (Exception ex)
            {
                engineerDetails.Value = false;
                engineerDetails.Success = false;
            }
            return engineerDetails;
        }
        #endregion
        #endregion

        #region Project
        public ServiceResult<List<tbl_Project_DTO>> GetProjects()
        {
            var projectRepository = new ProjectRepository();
            var projectsDetails = new ServiceResult<List<tbl_Project_DTO>>();
            try
            {
                projectsDetails.Value = projectRepository.GetProjects();
                projectsDetails.Success = true;
            }
            catch (Exception ex)
            {
                projectsDetails.Value = null;
                projectsDetails.Success = false;
            }
            return projectsDetails;
        }

        public ServiceResult<tbl_Project_DTO> GetProject(short Id)
        {
            var projectRepository = new ProjectRepository();
            var projectsDetails = new ServiceResult<tbl_Project_DTO>();
            try
            {
                projectsDetails.Value = projectRepository.GetProject(Id);
                projectsDetails.Success = true;
            }
            catch (Exception ex)
            {
                projectsDetails.Value = null;
                projectsDetails.Success = false;
            }
            return projectsDetails;
            //throw new NotImplementedException();
        }

        public ServiceResult<short> SaveProject(tbl_Project_DTO tbl_Project_DTO)
        {
            var projectRepository = new ProjectRepository();
            var projectsDetails = new ServiceResult<short>();
            try
            {
                projectsDetails.Value = projectRepository.SaveProject(tbl_Project_DTO);
                projectsDetails.Success = true;
            }
            catch (Exception ex)
            {
                projectsDetails.Value = -1;
                projectsDetails.Success = false;
            }
            return projectsDetails;
        }

        public ServiceResult<bool> UpdateProject(tbl_Project_DTO tbl_Project_DTO)
        {
            var projectRepository = new ProjectRepository();
            var projectsDetails = new ServiceResult<bool>();
            try
            {
                projectsDetails.Value = projectRepository.UpdateProject(tbl_Project_DTO);
                projectsDetails.Success = true;
            }
            catch (Exception ex)
            {
                projectsDetails.Value = false;
                projectsDetails.Success = false;
            }
            return projectsDetails;
        }

        public ServiceResult<bool> DeleteProject(short projectId)
        {
            var projectRepository = new ProjectRepository();
            var projectsDetails = new ServiceResult<bool>();
            try
            {
                projectsDetails.Value = projectRepository.DeleteProject(projectId);
                projectsDetails.Success = true;
            }
            catch (Exception ex)
            {
                projectsDetails.Value = false;
                projectsDetails.Success = false;
            }
            return projectsDetails;
        }

        #region Project Document
        public ServiceResult<List<tbl_ProjectDocument_DTO>> GetProjectDocuments()
        {
            var projectDocumentRepository = new ProjectDocumentRepository();
            var projectsDetails = new ServiceResult<List<tbl_ProjectDocument_DTO>>();
            try
            {
                projectsDetails.Value = projectDocumentRepository.GetProjectDocuments();
                projectsDetails.Success = true;
            }
            catch (Exception ex)
            {
                projectsDetails.Value = null;
                projectsDetails.Success = false;
            }
            return projectsDetails;
            //throw new NotImplementedException();
        }

        public ServiceResult<tbl_ProjectDocument_DTO> GetProjectDocument(int documentId)
        {
            var projectDocumentRepository = new ProjectDocumentRepository();
            var projectsDetails = new ServiceResult<tbl_ProjectDocument_DTO>();
            try
            {
                projectsDetails.Value = projectDocumentRepository.GetProjectDocument(documentId);
                projectsDetails.Success = true;
            }
            catch (Exception ex)
            {
                projectsDetails.Value = null;
                projectsDetails.Success = false;
            }
            return projectsDetails;
            //throw new NotImplementedException();

        }

        public ServiceResult<List<tbl_ProjectDocument_DTO>> GetProjectDocumentByProjectId(short projectId)
        {
            var projectDocumentRepository = new ProjectDocumentRepository();
            var projectsDetails = new ServiceResult<List<tbl_ProjectDocument_DTO>>();
            try
            {
                projectsDetails.Value = projectDocumentRepository.GetProjectDocumentsByProjectId(projectId);
                projectsDetails.Success = true;
            }
            catch (Exception ex)
            {
                projectsDetails.Value = null;
                projectsDetails.Success = false;
            }
            return projectsDetails;
            //throw new NotImplementedException();
        }
        #endregion
        #endregion

        #region Project Task
        public ServiceResult<List<tbl_ProjectTask_DTO>> GetProjectTasks()
        {
            var projectTaskRepository = new ProjectTaskRepository();
            var projectsTaskDetails = new ServiceResult<List<tbl_ProjectTask_DTO>>();
            try
            {
                projectsTaskDetails.Value = projectTaskRepository.GetProjectTasks();
                projectsTaskDetails.Success = true;
            }
            catch (Exception ex)
            {
                projectsTaskDetails.Value = null;
                projectsTaskDetails.Success = false;
            }
            return projectsTaskDetails;
            //throw new NotImplementedException();
        }

        public ServiceResult<tbl_ProjectTask_DTO> GetProjectTask(int id)
        {
            var projectTaskRepository = new ProjectTaskRepository();
            var projectsTaskDetails = new ServiceResult<tbl_ProjectTask_DTO>();
            try
            {
                projectsTaskDetails.Value = projectTaskRepository.GetProjectTask(id);
                projectsTaskDetails.Success = true;
            }
            catch (Exception ex)
            {
                projectsTaskDetails.Value = null;
                projectsTaskDetails.Success = false;
            }
            return projectsTaskDetails;
            //throw new NotImplementedException();
        }

        public ServiceResult<List<tbl_ProjectTask_DTO>> GetProjectTaskByProjectId(short projectId)
        {
            var projectTaskRepository = new ProjectTaskRepository();
            var projectsTaskDetails = new ServiceResult<List<tbl_ProjectTask_DTO>>();
            try
            {
                projectsTaskDetails.Value = projectTaskRepository.GetProjectTaskByProjectId(projectId);
                projectsTaskDetails.Success = true;
            }
            catch (Exception ex)
            {
                projectsTaskDetails.Value = null;
                projectsTaskDetails.Success = false;
            }
            return projectsTaskDetails;
            //throw new NotImplementedException();
        }

        public ServiceResult<int> SaveProjectTask(tbl_ProjectTask_DTO tbl_ProjectTask_DTO)
        {
            var projectTaskRepository = new ProjectTaskRepository();
            var projectsTaskDetails = new ServiceResult<int>();
            try
            {
                projectsTaskDetails.Value = projectTaskRepository.SaveProjectTask(tbl_ProjectTask_DTO);
                projectsTaskDetails.Success = true;
            }
            catch (Exception ex)
            {
                projectsTaskDetails.Value = -1;
                projectsTaskDetails.Success = false;
            }
            return projectsTaskDetails;
        }

        public ServiceResult<bool> UpdateProjectTask(tbl_ProjectTask_DTO tbl_ProjectTask_DTO)
        {
            var projectTaskRepository = new ProjectTaskRepository();
            var projectsTaskDetails = new ServiceResult<bool>();
            try
            {
                projectsTaskDetails.Value = projectTaskRepository.UpdateProjectTask(tbl_ProjectTask_DTO);
                projectsTaskDetails.Success = true;
            }
            catch (Exception ex)
            {
                projectsTaskDetails.Value = false;
                projectsTaskDetails.Success = false;
            }
            return projectsTaskDetails;
        }

        public ServiceResult<bool> DeleteProjectTask(int projectTaskId)
        {
            var projectTaskRepository = new ProjectTaskRepository();
            var projectsTaskDetails = new ServiceResult<bool>();
            try
            {
                projectsTaskDetails.Value = projectTaskRepository.DeleteProjectTask(projectTaskId);
                projectsTaskDetails.Success = true;
            }
            catch (Exception ex)
            {
                projectsTaskDetails.Value = false;
                projectsTaskDetails.Success = false;
            }
            return projectsTaskDetails;
        }

        #region Project Task Action
        public ServiceResult<List<tbl_ProjectTaskAction_DTO>> GetProjectTaskActions()
        {
            var projectTaskActionRepository = new ProjectTaskActionRepository();
            var projectsTaskActionDetails = new ServiceResult<List<tbl_ProjectTaskAction_DTO>>();
            try
            {
                projectsTaskActionDetails.Value = projectTaskActionRepository.GetProjectTaskActions();
                projectsTaskActionDetails.Success = true;
            }
            catch (Exception ex)
            {
                projectsTaskActionDetails.Value = null;
                projectsTaskActionDetails.Success = false;
            }
            return projectsTaskActionDetails;
            //throw new NotImplementedException();
        }

        public ServiceResult<tbl_ProjectTaskAction_DTO> GetProjectTaskAction(int actionId)
        {
            var projectTaskActionRepository = new ProjectTaskActionRepository();
            var projectsTaskActionDetails = new ServiceResult<tbl_ProjectTaskAction_DTO>();
            try
            {
                projectsTaskActionDetails.Value = projectTaskActionRepository.GetProjectTaskAction(actionId);
                projectsTaskActionDetails.Success = true;
            }
            catch (Exception ex)
            {
                projectsTaskActionDetails.Value = null;
                projectsTaskActionDetails.Success = false;
            }
            return projectsTaskActionDetails;
            //throw new NotImplementedException();
        }

        public ServiceResult<List<tbl_ProjectTaskAction_DTO>> GetProjectTaskActionByTaskId(int taskId)
        {
            var projectTaskActionRepository = new ProjectTaskActionRepository();
            var projectsTaskActionDetails = new ServiceResult<List<tbl_ProjectTaskAction_DTO>>();
            try
            {
                projectsTaskActionDetails.Value = projectTaskActionRepository.GetProjectTaskActionsByTaskId(taskId);
                projectsTaskActionDetails.Success = true;
            }
            catch (Exception ex)
            {
                projectsTaskActionDetails.Value = null;
                projectsTaskActionDetails.Success = false;
            }
            return projectsTaskActionDetails;
            //throw new NotImplementedException();
        }

        public ServiceResult<int> SaveProjectTaskAction(tbl_ProjectTaskActionDTO actionDto)
        {
            var projectTaskActiontRepository = new ProjectTaskActionRepository();
            var projectTaskActionDetails = new ServiceResult<int>();
            try
            {
                projectTaskActionDetails.Value = projectTaskActiontRepository.SaveProjectTaskAction(actionDto);
                projectTaskActionDetails.Success = true;
            }
            catch (Exception ex)
            {
                projectTaskActionDetails.Value = -1;
                projectTaskActionDetails.Success = false;
            }
            return projectTaskActionDetails;
        }
        #endregion

        #region Project Task Document
        public ServiceResult<List<tbl_ProjectTaskDocument_DTO>> GetProjectTaskDocuments()
        {
            var projectTaskDocumentRepository = new ProjectTaskDocumentRepository();
            var projectsTaskDocumentDetails = new ServiceResult<List<tbl_ProjectTaskDocument_DTO>>();
            try
            {
                projectsTaskDocumentDetails.Value = projectTaskDocumentRepository.GetProjectTaskDocuments();
                projectsTaskDocumentDetails.Success = true;
            }
            catch (Exception ex)
            {
                projectsTaskDocumentDetails.Value = null;
                projectsTaskDocumentDetails.Success = false;
            }
            return projectsTaskDocumentDetails;
        }

        public ServiceResult<tbl_ProjectTaskDocument_DTO> GetProjectTaskDocument(int documentId)
        {
            var projectTaskDocumentRepository = new ProjectTaskDocumentRepository();
            var projectsTaskDocumentDetails = new ServiceResult<tbl_ProjectTaskDocument_DTO>();
            try
            {
                projectsTaskDocumentDetails.Value = projectTaskDocumentRepository.GetProjectTaskDocument(documentId);
                projectsTaskDocumentDetails.Success = true;
            }
            catch (Exception ex)
            {
                projectsTaskDocumentDetails.Value = null;
                projectsTaskDocumentDetails.Success = false;
            }
            return projectsTaskDocumentDetails;
        }

        public ServiceResult<List<tbl_ProjectTaskDocument_DTO>> GetProjectTaskDocumentByProjectTaskId(int taskId)
        {
            var projectTaskDocumentRepository = new ProjectTaskDocumentRepository();
            var projectsTaskDocumentDetails = new ServiceResult<List<tbl_ProjectTaskDocument_DTO>>();
            try
            {
                projectsTaskDocumentDetails.Value = projectTaskDocumentRepository.GetProjectTaskDocumentByTaskId(taskId);
                projectsTaskDocumentDetails.Success = true;
            }
            catch (Exception ex)
            {
                projectsTaskDocumentDetails.Value = null;
                projectsTaskDocumentDetails.Success = false;
            }
            return projectsTaskDocumentDetails;
        }

        #endregion

        #region Project Task Type
        public ServiceResult<int> SaveProjectTaskType(tbl_ProjectTaskType_DTO tbl_ProjectTaskType_DTO)
        {
            var projectTaskTypeRepository = new ProjectTaskTypeRepository();
            var projectsTaskTypeDetails = new ServiceResult<int>();
            try
            {
                projectsTaskTypeDetails.Value = projectTaskTypeRepository.SaveProjectTaskType(tbl_ProjectTaskType_DTO);
                projectsTaskTypeDetails.Success = true;
            }
            catch (Exception ex)
            {
                projectsTaskTypeDetails.Value = -1;
                projectsTaskTypeDetails.Success = false;
            }
            return projectsTaskTypeDetails;
        }
        #endregion
        #endregion

        #region Change Request
        public ServiceResult<List<tbl_ChangeRequest_DTO>> GetChangeRequests()
        {
            var changeRequestRepository = new ChangeRequestRepository();
            var changeRequestDetails = new ServiceResult<List<tbl_ChangeRequest_DTO>>();
            try
            {
                changeRequestDetails.Value = changeRequestRepository.GetChangeRequests();
                changeRequestDetails.Success = true;
            }
            catch (Exception ex)
            {
                changeRequestDetails.Value = null;
                changeRequestDetails.Success = false;
            }
            return changeRequestDetails;
        }

        public ServiceResult<tbl_ChangeRequest_DTO> GetChangeRequest(int id)
        {
            var changeRequestRepository = new ChangeRequestRepository();
            var changeRequestDetails = new ServiceResult<tbl_ChangeRequest_DTO>();
            try
            {
                changeRequestDetails.Value = changeRequestRepository.GetChangeRequest(id);
                changeRequestDetails.Success = true;
            }
            catch (Exception ex)
            {
                changeRequestDetails.Value = null;
                changeRequestDetails.Success = false;
            }
            return changeRequestDetails;
        }

        public ServiceResult<List<tbl_ChangeRequest_DTO>> GetChangeRequestsByProjectId(short projectId)
        {
            var changeRequestRepository = new ChangeRequestRepository();
            var changeRequestDetails = new ServiceResult<List<tbl_ChangeRequest_DTO>>();
            try
            {
                changeRequestDetails.Value = changeRequestRepository.GetChangeRequestsByProjectId(projectId);
                changeRequestDetails.Success = true;
            }
            catch (Exception ex)
            {
                changeRequestDetails.Value = null;
                changeRequestDetails.Success = false;
            }
            return changeRequestDetails;
        }

        public ServiceResult<int> SaveChangeRequest(tbl_ChangeRequest_DTO tbl_ChangeRequest_DTO)
        {
            var changeRequestRepository = new ChangeRequestRepository();
            var changeRequestDetails = new ServiceResult<int>();
            try
            {
                changeRequestDetails.Value = changeRequestRepository.SaveChangeRequest(tbl_ChangeRequest_DTO);
                changeRequestDetails.Success = true;
            }
            catch (Exception ex)
            {
                changeRequestDetails.Value = -1;
                changeRequestDetails.Success = false;
            }
            return changeRequestDetails;
        }

        public ServiceResult<bool> UpdateChangeRequest(tbl_ChangeRequest_DTO tbl_ChangeRequest_DTO)
        {
            var changeRequestRepository = new ChangeRequestRepository();
            var changeRequestDetails = new ServiceResult<bool>();
            try
            {
                changeRequestDetails.Value = changeRequestRepository.UpdateChangeRequest(tbl_ChangeRequest_DTO);
                changeRequestDetails.Success = true;
            }
            catch (Exception ex)
            {
                changeRequestDetails.Value = false;
                changeRequestDetails.Success = false;
            }
            return changeRequestDetails;
        }

        public ServiceResult<bool> DeleteChangeRequest(int changeRequestId)
        {
            var changeRequestRepository = new ChangeRequestRepository();
            var changeRequestDetails = new ServiceResult<bool>();
            try
            {
                changeRequestDetails.Value = changeRequestRepository.DeleteChangeRequest(changeRequestId);
                changeRequestDetails.Success = true;
            }
            catch (Exception ex)
            {
                changeRequestDetails.Value = false;
                changeRequestDetails.Success = false;
            }
            return changeRequestDetails;
        }

        #region Change Request Action
        public ServiceResult<List<tbl_ChangeRequestAction_DTO>> GetChangeRequestActions()
        {
            var changeRequesActiontRepository = new ChangeRequestActionRepository();
            var changeRequestActionDetails = new ServiceResult<List<tbl_ChangeRequestAction_DTO>>();
            try
            {
                changeRequestActionDetails.Value = changeRequesActiontRepository.GetChangeRequestActions();
                changeRequestActionDetails.Success = true;
            }
            catch (Exception ex)
            {
                changeRequestActionDetails.Value = null;
                changeRequestActionDetails.Success = false;
            }
            return changeRequestActionDetails;
        }

        public ServiceResult<tbl_ChangeRequestAction_DTO> GetChangeRequestAction(int actionId)
        {
            var changeRequesActiontRepository = new ChangeRequestActionRepository();
            var changeRequestActionDetails = new ServiceResult<tbl_ChangeRequestAction_DTO>();
            try
            {
                changeRequestActionDetails.Value = changeRequesActiontRepository.GetChangeRequestAction(actionId);
                changeRequestActionDetails.Success = true;
            }
            catch (Exception ex)
            {
                changeRequestActionDetails.Value = null;
                changeRequestActionDetails.Success = false;
            }
            return changeRequestActionDetails;
        }

        public ServiceResult<List<tbl_ChangeRequestAction_DTO>> GetChangeRequestActionsByRequestId(int requestId)
        {
            var changeRequesActiontRepository = new ChangeRequestActionRepository();
            var changeRequestActionDetails = new ServiceResult<List<tbl_ChangeRequestAction_DTO>>();
            try
            {
                changeRequestActionDetails.Value = changeRequesActiontRepository.GetChangeRequestActionsByRequestId(requestId);
                changeRequestActionDetails.Success = true;
            }
            catch (Exception ex)
            {
                changeRequestActionDetails.Value = null;
                changeRequestActionDetails.Success = false;
            }
            return changeRequestActionDetails;
        }

        public ServiceResult<int> SaveChangeRequestAction(tbl_ChangeRequestActionDTO actionDto)
        {
            var changeRequesActiontRepository = new ChangeRequestActionRepository();
            var changeRequestActionDetails = new ServiceResult<int>();
            try
            {
                changeRequestActionDetails.Value = changeRequesActiontRepository.SaveChangeRequestAction(actionDto);
                changeRequestActionDetails.Success = true;
            }
            catch (Exception ex)
            {
                changeRequestActionDetails.Value = -1;
                changeRequestActionDetails.Success = false;
            }
            return changeRequestActionDetails;
        }
        #endregion

        #region Change Request Document
        public ServiceResult<List<tbl_ChangeRequestDocument_DTO>> GetChangeRequestDocuments()
        {
            var changeRequestDocumentRepository = new ChangeRequestDocumentRepository();
            var changeRequestDocumentDetails = new ServiceResult<List<tbl_ChangeRequestDocument_DTO>>();
            try
            {
                changeRequestDocumentDetails.Value = changeRequestDocumentRepository.GetChangeRequestDocuments();
                changeRequestDocumentDetails.Success = true;
            }
            catch (Exception ex)
            {
                changeRequestDocumentDetails.Value = null;
                changeRequestDocumentDetails.Success = false;
            }
            return changeRequestDocumentDetails;
        }

        public ServiceResult<tbl_ChangeRequestDocument_DTO> GetChangeRequestDocument(int documentId)
        {
            var changeRequestDocumentRepository = new ChangeRequestDocumentRepository();
            var changeRequestDocumentDetails = new ServiceResult<tbl_ChangeRequestDocument_DTO>();
            try
            {
                changeRequestDocumentDetails.Value = changeRequestDocumentRepository.GetChangeRequestDocument(documentId);
                changeRequestDocumentDetails.Success = true;
            }
            catch (Exception ex)
            {
                changeRequestDocumentDetails.Value = null;
                changeRequestDocumentDetails.Success = false;
            }
            return changeRequestDocumentDetails;
        }

        public ServiceResult<List<tbl_ChangeRequestDocument_DTO>> GetChangeRequestDocumentsByRequestId(int requestId)
        {
            var changeRequestDocumentRepository = new ChangeRequestDocumentRepository();
            var changeRequestDocumentDetails = new ServiceResult<List<tbl_ChangeRequestDocument_DTO>>();
            try
            {
                changeRequestDocumentDetails.Value = changeRequestDocumentRepository.GetChangeRequestDocumentsByRequestId(requestId);
                changeRequestDocumentDetails.Success = true;
            }
            catch (Exception ex)
            {
                changeRequestDocumentDetails.Value = null;
                changeRequestDocumentDetails.Success = false;
            }
            return changeRequestDocumentDetails;
        }
        #endregion
        #endregion

        #region Service Request

        public ServiceResult<List<tbl_ServiceRequest_DTO>> GetServiceRequests()
        {
            var serviceRequestRepository = new ServiceRequestRepository();
            var serviceRequestDetails = new ServiceResult<List<tbl_ServiceRequest_DTO>>();
            try
            {
                serviceRequestDetails.Value = serviceRequestRepository.GetServiceRequests();
                serviceRequestDetails.Success = true;
            }
            catch (Exception ex)
            {
                serviceRequestDetails.Value = null;
                serviceRequestDetails.Success = false;
            }
            return serviceRequestDetails;
        }

        public ServiceResult<tbl_ServiceRequest_DTO> GetServiceRequest(int id)
        {
            var serviceRequestRepository = new ServiceRequestRepository();
            var serviceRequestDetails = new ServiceResult<tbl_ServiceRequest_DTO>();
            try
            {
                serviceRequestDetails.Value = serviceRequestRepository.GetServiceRequest(id);
                serviceRequestDetails.Success = true;
            }
            catch (Exception ex)
            {
                serviceRequestDetails.Value = null;
                serviceRequestDetails.Success = false;
            }
            return serviceRequestDetails;
        }

        public ServiceResult<List<tbl_ServiceRequest_DTO>> GetServiceRequestsByProjectId(short projectId)
        {
            var serviceRequestRepository = new ServiceRequestRepository();
            var serviceRequestDetails = new ServiceResult<List<tbl_ServiceRequest_DTO>>();
            try
            {
                serviceRequestDetails.Value = serviceRequestRepository.GetServiceRequestsByProjectId(projectId);
                serviceRequestDetails.Success = true;
            }
            catch (Exception ex)
            {
                serviceRequestDetails.Value = null;
                serviceRequestDetails.Success = false;
            }
            return serviceRequestDetails;
        }

        public ServiceResult<int> SaveServiceRequest(tbl_ServiceRequest_DTO tbl_ServiceRequest_DTO)
        {
            var serviceRequestRepository = new ServiceRequestRepository();
            var serviceRequestDetails = new ServiceResult<int>();
            try
            {
                serviceRequestDetails.Value = serviceRequestRepository.SaveServiceRequest(tbl_ServiceRequest_DTO);
                serviceRequestDetails.Success = true;
            }
            catch (Exception ex)
            {
                serviceRequestDetails.Value = -1;
                serviceRequestDetails.Success = false;
            }
            return serviceRequestDetails;
        }

        public ServiceResult<bool> UpdateServiceRequest(tbl_ServiceRequest_DTO tbl_ServiceRequest_DTO)
        {
            var serviceRequestRepository = new ServiceRequestRepository();
            var serviceRequestDetails = new ServiceResult<bool>();
            try
            {
                serviceRequestDetails.Value = serviceRequestRepository.UpdateServiceRequest(tbl_ServiceRequest_DTO);
                serviceRequestDetails.Success = true;
            }
            catch (Exception ex)
            {
                serviceRequestDetails.Value = false;
                serviceRequestDetails.Success = false;
            }
            return serviceRequestDetails;
        }

        public ServiceResult<bool> DeleteServiceRequest(int serviceRequestId)
        {
            var serviceRequestRepository = new ServiceRequestRepository();
            var serviceRequestDetails = new ServiceResult<bool>();
            try
            {
                serviceRequestDetails.Value = serviceRequestRepository.DeleteServiceRequest(serviceRequestId);
                serviceRequestDetails.Success = true;
            }
            catch (Exception ex)
            {
                serviceRequestDetails.Value = false;
                serviceRequestDetails.Success = false;
            }
            return serviceRequestDetails;
        }


        #region Service Request Action
        public ServiceResult<List<tbl_ServiceRequestAction_DTO>> GetServiceRequestActions()
        {
            var serviceRequestActionRepository = new ServiceRequestActionRepository();
            var serviceRequestActionDetails = new ServiceResult<List<tbl_ServiceRequestAction_DTO>>();
            try
            {
                serviceRequestActionDetails.Value = serviceRequestActionRepository.GetServiceRequestActions();
                serviceRequestActionDetails.Success = true;
            }
            catch (Exception ex)
            {
                serviceRequestActionDetails.Value = null;
                serviceRequestActionDetails.Success = false;
            }
            return serviceRequestActionDetails;
        }

        public ServiceResult<tbl_ServiceRequestAction_DTO> GetServiceRequestAction(int actionId)
        {
            var serviceRequestActionRepository = new ServiceRequestActionRepository();
            var serviceRequestActionDetails = new ServiceResult<tbl_ServiceRequestAction_DTO>();
            try
            {
                serviceRequestActionDetails.Value = serviceRequestActionRepository.GetServiceRequestAction(actionId);
                serviceRequestActionDetails.Success = true;
            }
            catch (Exception ex)
            {
                serviceRequestActionDetails.Value = null;
                serviceRequestActionDetails.Success = false;
            }
            return serviceRequestActionDetails;
        }

        public ServiceResult<List<tbl_ServiceRequestAction_DTO>> GetServiceRequestActionsByRequestId(int requestId)
        {
            var serviceRequestActionRepository = new ServiceRequestActionRepository();
            var serviceRequestActionDetails = new ServiceResult<List<tbl_ServiceRequestAction_DTO>>();
            try
            {
                serviceRequestActionDetails.Value = serviceRequestActionRepository.GetServiceRequestActionsByRequestId(requestId);
                serviceRequestActionDetails.Success = true;
            }
            catch (Exception ex)
            {
                serviceRequestActionDetails.Value = null;
                serviceRequestActionDetails.Success = false;
            }
            return serviceRequestActionDetails;
        }

        public ServiceResult<int> SaveServiceRequestAction(tbl_ServiceRequestActionDTO actionDto)
        {
            var serviceRequesActiontRepository = new ServiceRequestActionRepository();
            var serviceRequestActionDetails = new ServiceResult<int>();
            try
            {
                serviceRequestActionDetails.Value = serviceRequesActiontRepository.SaveServiceRequestAction(actionDto);
                serviceRequestActionDetails.Success = true;
            }
            catch (Exception ex)
            {
                serviceRequestActionDetails.Value = -1;
                serviceRequestActionDetails.Success = false;
            }
            return serviceRequestActionDetails;
        }
        #endregion

        #region Service Request Document
        public ServiceResult<List<tbl_ServiceRequestDocument_DTO>> GetServiceRequestDocuments()
        {
            var serviceRequestDocumentRepository = new ServiceRequestDocumentRepository();
            var serviceRequestDetails = new ServiceResult<List<tbl_ServiceRequestDocument_DTO>>();
            try
            {
                serviceRequestDetails.Value = serviceRequestDocumentRepository.GetServiceRequestDocuments();
                serviceRequestDetails.Success = true;
            }
            catch (Exception ex)
            {
                serviceRequestDetails.Value = null;
                serviceRequestDetails.Success = false;
            }
            return serviceRequestDetails;
        }

        public ServiceResult<tbl_ServiceRequestDocument_DTO> GetServiceRequestDocument(int documentId)
        {
            var serviceRequestDocumentRepository = new ServiceRequestDocumentRepository();
            var serviceRequestDetails = new ServiceResult<tbl_ServiceRequestDocument_DTO>();
            try
            {
                serviceRequestDetails.Value = serviceRequestDocumentRepository.GetServiceRequestDocument(documentId);
                serviceRequestDetails.Success = true;
            }
            catch (Exception ex)
            {
                serviceRequestDetails.Value = null;
                serviceRequestDetails.Success = false;
            }
            return serviceRequestDetails;
        }

        public ServiceResult<List<tbl_ServiceRequestDocument_DTO>> GetServiceRequestDocumentsByRequestId(int requestId)
        {
            var serviceRequestDocumentRepository = new ServiceRequestDocumentRepository();
            var serviceRequestDetails = new ServiceResult<List<tbl_ServiceRequestDocument_DTO>>();
            try
            {
                serviceRequestDetails.Value = serviceRequestDocumentRepository.GetServiceRequestDocumentsByRequestId(requestId);
                serviceRequestDetails.Success = true;
            }
            catch (Exception ex)
            {
                serviceRequestDetails.Value = null;
                serviceRequestDetails.Success = false;
            }
            return serviceRequestDetails;
        }
        #endregion
        #endregion

        #region Issue
        public ServiceResult<List<tbl_IssueTracker_DTO>> GetIssues()
        {
            var issueRepository = new IssueRepository();
            var issueDetails = new ServiceResult<List<tbl_IssueTracker_DTO>>();
            try
            {
                issueDetails.Value = issueRepository.GetIssues();
                issueDetails.Success = true;
            }
            catch (Exception ex)
            {
                issueDetails.Value = null;
                issueDetails.Success = false;
            }
            return issueDetails;
        }

        public ServiceResult<tbl_IssueTracker_DTO> GetIssue(int id)
        {
            var issueRepository = new IssueRepository();
            var issueDetails = new ServiceResult<tbl_IssueTracker_DTO>();
            try
            {
                issueDetails.Value = issueRepository.GetIssue(id);
                issueDetails.Success = true;
            }
            catch (Exception ex)
            {
                issueDetails.Value = null;
                issueDetails.Success = false;
            }
            return issueDetails;
        }

        public ServiceResult<List<tbl_IssueTracker_DTO>> GetIssuesByProjectId(short projectId)
        {
            var issueRepository = new IssueRepository();
            var issueDetails = new ServiceResult<List<tbl_IssueTracker_DTO>>();
            try
            {
                issueDetails.Value = issueRepository.GetIssuesByProjectId(projectId);
                issueDetails.Success = true;
            }
            catch (Exception ex)
            {
                issueDetails.Value = null;
                issueDetails.Success = false;
            }
            return issueDetails;
        }

        public ServiceResult<int> SaveIssue(tbl_IssueTracker_DTO tbl_Issue_DTO)
        {
            var issueRepository = new IssueRepository();
            var issueDetails = new ServiceResult<int>();
            try
            {
                issueDetails.Value = issueRepository.SaveIssueTracker(tbl_Issue_DTO);
                issueDetails.Success = true;
            }
            catch (Exception ex)
            {
                issueDetails.Value = -1;
                issueDetails.Success = false;
            }
            return issueDetails;
        }

        public ServiceResult<bool> UpdateIssue(tbl_IssueTracker_DTO tbl_Issue_DTO)
        {
            var issueRepository = new IssueRepository();
            var issueDetails = new ServiceResult<bool>();
            try
            {
                issueDetails.Value = issueRepository.UpdateIssueTracker(tbl_Issue_DTO);
                issueDetails.Success = true;
            }
            catch (Exception ex)
            {
                issueDetails.Value = false;
                issueDetails.Success = false;
            }
            return issueDetails;
        }

        public ServiceResult<bool> DeleteIssue(int issueId)
        {
            var issueRepository = new IssueRepository();
            var issueDetails = new ServiceResult<bool>();
            try
            {
                issueDetails.Value = issueRepository.DeleteIssueTracker(issueId);
                issueDetails.Success = true;
            }
            catch (Exception ex)
            {
                issueDetails.Value = false;
                issueDetails.Success = false;
            }
            return issueDetails;
        }

        #region Issue Action

        public ServiceResult<List<tbl_IssueTrackerAction_DTO>> GetIssueActions()
        {
            var issueActionRepository = new IssueActionRepository();
            var issueActionDetails = new ServiceResult<List<tbl_IssueTrackerAction_DTO>>();
            try
            {
                issueActionDetails.Value = issueActionRepository.GetIssueActions();
                issueActionDetails.Success = true;
            }
            catch (Exception ex)
            {
                issueActionDetails.Value = null;
                issueActionDetails.Success = false;
            }
            return issueActionDetails;
        }

        public ServiceResult<tbl_IssueTrackerAction_DTO> GetIssueAction(int actionId)
        {
            var issueActionRepository = new IssueActionRepository();
            var issueActionDetails = new ServiceResult<tbl_IssueTrackerAction_DTO>();
            try
            {
                issueActionDetails.Value = issueActionRepository.GetIssueAction(actionId);
                issueActionDetails.Success = true;
            }
            catch (Exception ex)
            {
                issueActionDetails.Value = null;
                issueActionDetails.Success = false;
            }
            return issueActionDetails;
        }

        public ServiceResult<List<tbl_IssueTrackerAction_DTO>> GetIssueActionsByIssueId(int issueId)
        {
            var issueActionRepository = new IssueActionRepository();
            var issueActionDetails = new ServiceResult<List<tbl_IssueTrackerAction_DTO>>();
            try
            {
                issueActionDetails.Value = issueActionRepository.GetIssueActionsByIssueId(issueId);
                issueActionDetails.Success = true;
            }
            catch (Exception ex)
            {
                issueActionDetails.Value = null;
                issueActionDetails.Success = false;
            }
            return issueActionDetails;
        }

        public ServiceResult<int> SaveIssueAction(tbl_IssueTrackerActionDTO actionDto)
        {
            var serviceRequesActiontRepository = new IssueActionRepository();
            var serviceRequestActionDetails = new ServiceResult<int>();
            try
            {
                serviceRequestActionDetails.Value = serviceRequesActiontRepository.SaveIssueAction(actionDto);
                serviceRequestActionDetails.Success = true;
            }
            catch (Exception ex)
            {
                serviceRequestActionDetails.Value = -1;
                serviceRequestActionDetails.Success = false;
            }
            return serviceRequestActionDetails;
        }

        #endregion

        #region Issue Document
        public ServiceResult<List<tbl_IssueTrackerDocument_DTO>> GetIssueDocuments()
        {
            var issueDocumentsRepository = new IssueDocumentRepository();
            var issueDocumentDetails = new ServiceResult<List<tbl_IssueTrackerDocument_DTO>>();
            try
            {
                issueDocumentDetails.Value = issueDocumentsRepository.GetIssueDocuments();
                issueDocumentDetails.Success = true;
            }
            catch (Exception ex)
            {
                issueDocumentDetails.Value = null;
                issueDocumentDetails.Success = false;
            }
            return issueDocumentDetails;
        }

        public ServiceResult<tbl_IssueTrackerDocument_DTO> GetIssueDocument(int documentId)
        {
            var issueDocumentsRepository = new IssueDocumentRepository();
            var issueDocumentDetails = new ServiceResult<tbl_IssueTrackerDocument_DTO>();
            try
            {
                issueDocumentDetails.Value = issueDocumentsRepository.GetIssueDocument(documentId);
                issueDocumentDetails.Success = true;
            }
            catch (Exception ex)
            {
                issueDocumentDetails.Value = null;
                issueDocumentDetails.Success = false;
            }
            return issueDocumentDetails;
        }

        public ServiceResult<List<tbl_IssueTrackerDocument_DTO>> GetIssueDocumentsByIssueId(int issueId)
        {
            var issueDocumentsRepository = new IssueDocumentRepository();
            var issueDocumentDetails = new ServiceResult<List<tbl_IssueTrackerDocument_DTO>>();
            try
            {
                issueDocumentDetails.Value = issueDocumentsRepository.GetIssueDocumentsByIssueId(issueId);
                issueDocumentDetails.Success = true;
            }
            catch (Exception ex)
            {
                issueDocumentDetails.Value = null;
                issueDocumentDetails.Success = false;
            }
            return issueDocumentDetails;
        }
        #endregion
        #endregion

        #region Incident

        public ServiceResult<List<tbl_Incident_DTO>> GetIncidents()
        {
            var incidentRepository = new IncidentRepository();
            var incidentDetails = new ServiceResult<List<tbl_Incident_DTO>>();
            try
            {
                incidentDetails.Value = incidentRepository.GetIncidents();
                incidentDetails.Success = true;
            }
            catch (Exception ex)
            {
                incidentDetails.Value = null;
                incidentDetails.Success = false;
            }
            return incidentDetails;
        }

        public ServiceResult<tbl_Incident_DTO> GetIncident(int Id)
        {
            var incidentRepository = new IncidentRepository();
            var incidentDetails = new ServiceResult<tbl_Incident_DTO>();
            try
            {
                incidentDetails.Value = incidentRepository.GetIncident(Id);
                incidentDetails.Success = true;
            }
            catch (Exception ex)
            {
                incidentDetails.Value = null;
                incidentDetails.Success = false;
            }
            return incidentDetails;
        }

        public ServiceResult<List<tbl_Incident_DTO>> GetIncidentByProjectId(short projectId)
        {
            var incidentRepository = new IncidentRepository();
            var incidentDetails = new ServiceResult<List<tbl_Incident_DTO>>();
            try
            {
                incidentDetails.Value = incidentRepository.GetIncidentByProjectId(projectId);
                incidentDetails.Success = true;
            }
            catch (Exception ex)
            {
                incidentDetails.Value = null;
                incidentDetails.Success = false;
            }
            return incidentDetails;
        }

        public ServiceResult<int> SaveIncident(tbl_Incident_DTO tbl_Incident_DTO)
        {
            var incidentRepository = new IncidentRepository();
            var incidentDetails = new ServiceResult<int>();
            try
            {
                incidentDetails.Value = incidentRepository.SaveIncident(tbl_Incident_DTO);
                incidentDetails.Success = true;
            }
            catch (Exception ex)
            {
                incidentDetails.Value = -1;
                incidentDetails.Success = false;
            }
            return incidentDetails;
        }

        public ServiceResult<bool> UpdateIncident(tbl_Incident_DTO tbl_Incident_DTO)
        {
            var incidentRepository = new IncidentRepository();
            var incidentDetails = new ServiceResult<bool>();
            try
            {
                incidentDetails.Value = incidentRepository.UpdateIncident(tbl_Incident_DTO);
                incidentDetails.Success = true;
            }
            catch (Exception ex)
            {
                incidentDetails.Value = false;
                incidentDetails.Success = false;
            }
            return incidentDetails;
        }

        public ServiceResult<bool> DeleteIncident(int incidentId)
        {
            var incidentRepository = new IncidentRepository();
            var incidentDetails = new ServiceResult<bool>();
            try
            {
                incidentDetails.Value = incidentRepository.DeleteIncident(incidentId);
                incidentDetails.Success = true;
            }
            catch (Exception ex)
            {
                incidentDetails.Value = false;
                incidentDetails.Success = false;
            }
            return incidentDetails;
        }

        #region Incident Action

        public ServiceResult<List<tbl_IncidentAction_DTO>> GetIncidentActions()
        {
            var incidentActionRepository = new IncidentActionRepository();
            var incidentActionDetails = new ServiceResult<List<tbl_IncidentAction_DTO>>();
            try
            {
                incidentActionDetails.Value = incidentActionRepository.GetIncidentActions();
                incidentActionDetails.Success = true;
            }
            catch (Exception ex)
            {
                incidentActionDetails.Value = null;
                incidentActionDetails.Success = false;
            }
            return incidentActionDetails;
        }

        public ServiceResult<tbl_IncidentAction_DTO> GetIncidentAction(int actionId)
        {
            var incidentActionRepository = new IncidentActionRepository();
            var incidentActionDetails = new ServiceResult<tbl_IncidentAction_DTO>();
            try
            {
                incidentActionDetails.Value = incidentActionRepository.GetIncidentAction(actionId);
                incidentActionDetails.Success = true;
            }
            catch (Exception ex)
            {
                incidentActionDetails.Value = null;
                incidentActionDetails.Success = false;
            }
            return incidentActionDetails;
        }

        public ServiceResult<List<tbl_IncidentAction_DTO>> GetIncidentActionByIncidentId(int incidentId)
        {
            var incidentActionRepository = new IncidentActionRepository();
            var incidentActionDetails = new ServiceResult<List<tbl_IncidentAction_DTO>>();
            try
            {
                incidentActionDetails.Value = incidentActionRepository.GetIncidentActionByIncidentId(incidentId);
                incidentActionDetails.Success = true;
            }
            catch (Exception ex)
            {
                incidentActionDetails.Value = null;
                incidentActionDetails.Success = false;
            }
            return incidentActionDetails;
        }

        public ServiceResult<int> SaveIncidentAction(tbl_IncidentActionDTO actionDto)
        {
            var serviceRequesActiontRepository = new IncidentActionRepository();
            var serviceRequestActionDetails = new ServiceResult<int>();
            try
            {
                serviceRequestActionDetails.Value = serviceRequesActiontRepository.SaveIncidentAction(actionDto);
                serviceRequestActionDetails.Success = true;
            }
            catch (Exception ex)
            {
                serviceRequestActionDetails.Value = -1;
                serviceRequestActionDetails.Success = false;
            }
            return serviceRequestActionDetails;
        }


        #endregion

        #region Incident Document

        public ServiceResult<List<tbl_IncidentDocument_DTO>> GetIncidentDocuments()
        {
            var incidentDocumentRepository = new IncidentDocumentRepository();
            var incidentDocumentDetails = new ServiceResult<List<tbl_IncidentDocument_DTO>>();
            try
            {
                incidentDocumentDetails.Value = incidentDocumentRepository.GetIncidentDocumentsDtoList();
                incidentDocumentDetails.Success = true;
            }
            catch (Exception ex)
            {
                incidentDocumentDetails.Value = null;
                incidentDocumentDetails.Success = false;
            }
            return incidentDocumentDetails;
        }

        public ServiceResult<tbl_IncidentDocument_DTO> GetIncidentDocument(int documentId)
        {
            var incidentDocumentRepository = new IncidentDocumentRepository();
            var incidentDocumentDetails = new ServiceResult<tbl_IncidentDocument_DTO>();
            try
            {
                incidentDocumentDetails.Value = incidentDocumentRepository.GetIncidentDocumentDtoById(documentId);
                incidentDocumentDetails.Success = true;
            }
            catch (Exception ex)
            {
                incidentDocumentDetails.Value = null;
                incidentDocumentDetails.Success = false;
            }
            return incidentDocumentDetails;
        }

        public ServiceResult<List<tbl_IncidentDocument_DTO>> GetIncidentDocumenByIncidentId(int incidentId)
        {
            var incidentDocumentRepository = new IncidentDocumentRepository();
            var incidentDocumentDetails = new ServiceResult<List<tbl_IncidentDocument_DTO>>();
            try
            {
                incidentDocumentDetails.Value = incidentDocumentRepository.GetIncidentDocumentByIncidentId(incidentId);
                incidentDocumentDetails.Success = true;
            }
            catch (Exception ex)
            {
                incidentDocumentDetails.Value = null;
                incidentDocumentDetails.Success = false;
            }
            return incidentDocumentDetails;
        }

        #endregion

        #endregion

        #region Client

        public ServiceResult<List<tbl_Client_DTO>> GetClients()
        {
            var clientRepository = new ClientRepository();
            var clientDetails = new ServiceResult<List<tbl_Client_DTO>>();
            try
            {
                clientDetails.Value = clientRepository.GetClients();
                clientDetails.Success = true;
            }
            catch (Exception ex)
            {
                clientDetails.Value = null;
                clientDetails.Success = false;
            }
            return clientDetails;
        }

        public ServiceResult<int> SaveClient(tbl_Client_DTO tbl_Client_DTO)
        {
            var clientRepository = new ClientRepository();
            var clientDetails = new ServiceResult<int>();
            try
            {
                clientDetails.Value = clientRepository.SaveClient(tbl_Client_DTO);
                clientDetails.Success = true;
            }
            catch (Exception ex)
            {
                clientDetails.Value = -1;
                clientDetails.Success = false;
            }
            return clientDetails;
        }

        public ServiceResult<bool> UpdateClient(tbl_Client_DTO tbl_Client_DTO)
        {
            var clientRepository = new ClientRepository();
            var clientDetails = new ServiceResult<bool>();
            try
            {
                clientDetails.Value = clientRepository.UpdateClient(tbl_Client_DTO);
                clientDetails.Success = true;
            }
            catch (Exception ex)
            {
                clientDetails.Value = false;
                clientDetails.Success = false;
            }
            return clientDetails;
        }

        public ServiceResult<bool> DeleteClient(int clientId)
        {
            var clientRepository = new ClientRepository();
            var clientDetails = new ServiceResult<bool>();
            try
            {
                clientDetails.Value = clientRepository.DeleteClient(clientId);
                clientDetails.Success = true;
            }
            catch (Exception ex)
            {
                clientDetails.Value = false;
                clientDetails.Success = false;
            }
            return clientDetails;
        }

        #endregion

        #region Team
        public ServiceResult<tbl_Team_DTO> GetTeam(Types entity, int entityId, TeamType type)
        {
            var teamRepository = new TeamRepository();
            var teamDetails = new ServiceResult<tbl_Team_DTO>();
            try
            {
                teamDetails.Value = teamRepository.GetTeam(entity, entityId, type);
                teamDetails.Success = true;
            }
            catch (Exception ex)
            {
                teamDetails.Value = null;
                teamDetails.Success = false;
            }
            return teamDetails;
        }

        public ServiceResult<List<tbl_Team_DTO>> GetTeams()
        {

            var teamRepository = new TeamRepository();
            var teamDetails = new ServiceResult<List<tbl_Team_DTO>>();
            try
            {
                teamDetails.Value = teamRepository.GetTeams();
                teamDetails.Success = true;
            }
            catch (Exception ex)
            {
                teamDetails.Value = null;
                teamDetails.Success = false;
            }
            return teamDetails;
        }

        public ServiceResult<int> SaveTeamWithMembers(tbl_Team_DTO tbl_Team_DTO, List<tbl_TeamMember_DTO> tbl_TeamMember_DTOList)
        {
            var teamRepository = new TeamRepository();
            var teamDetails = new ServiceResult<int>();
            try
            {
                teamDetails.Value = teamRepository.SaveTeamWithMembers(tbl_Team_DTO, tbl_TeamMember_DTOList);
                teamDetails.Success = true;
            }
            catch (Exception ex)
            {
                teamDetails.Value = -1;
                teamDetails.Success = false;
            }
            return teamDetails;
        }

        public ServiceResult<bool> UpdateTeam(tbl_Team_DTO tbl_Team_DTO)
        {
            var teamRepository = new TeamRepository();
            var teamDetails = new ServiceResult<bool>();
            try
            {
                teamDetails.Value = teamRepository.UpdateTeam(tbl_Team_DTO);
                teamDetails.Success = true;
            }
            catch (Exception ex)
            {
                teamDetails.Value = false;
                teamDetails.Success = false;
            }
            return teamDetails;
        }

        public ServiceResult<bool> DeleteTeam(int teamId)
        {
            var teamRepository = new TeamRepository();
            var teamDetails = new ServiceResult<bool>();
            try
            {
                teamDetails.Value = teamRepository.DeleteTeam(teamId);
                teamDetails.Success = true;
            }
            catch (Exception ex)
            {
                teamDetails.Value = false;
                teamDetails.Success = false;
            }
            return teamDetails;
        }

        #region Team Members
        public ServiceResult<List<tbl_TeamMember_DTO>> GetTeamMembersByTeamId(int teamId)
        {
            var teamRepository = new TeamRepository();
            var teamMemberDetails = new ServiceResult<List<tbl_TeamMember_DTO>>();
            try
            {
                teamMemberDetails.Value = teamRepository.GetTeamMembersByTeamId(teamId);
                teamMemberDetails.Success = true;
            }
            catch (Exception ex)
            {
                teamMemberDetails.Value = null;
                teamMemberDetails.Success = false;
            }
            return teamMemberDetails;
        }
        #endregion
        #endregion

        #region Utilities
        public ServiceResult<List<tbl_Entity_DTO>> GetEntitiesByType(Types entity)
        {
            var entityDetails = new ServiceResult<List<tbl_Entity_DTO>>();
            try
            {
                entityDetails.Value = (List<tbl_Entity_DTO>)new EntityUtility().GetEntitiesByType(entity);
                entityDetails.Success = true;
            }
            catch (Exception ex)
            {
                entityDetails.Value = null;
                entityDetails.Success = false;
            }
            return entityDetails;
        }

        public ServiceResult<List<tbl_ProjectTaskType_DTO>> GetAllProjectTaskTypes()
        {
            var entityDetails = new ServiceResult<List<tbl_ProjectTaskType_DTO>>();
            try
            {
                entityDetails.Value = (List<tbl_ProjectTaskType_DTO>)EntityUtility.GetAllProjectTaskTypes();
                entityDetails.Success = true;
            }
            catch (Exception ex)
            {
                entityDetails.Value = null;
                entityDetails.Success = false;
            }
            return entityDetails;
        }

        public ServiceResult<List<tbl_ProjectTaskType_DTO>> GetProjectTaskTypesByProjectId(short projectId)
        {
            var entityDetails = new ServiceResult<List<tbl_ProjectTaskType_DTO>>();
            try
            {
                entityDetails.Value = (List<tbl_ProjectTaskType_DTO>)EntityUtility.GetProjectTaskTypesByProjectId(projectId);
                entityDetails.Success = true;
            }
            catch (Exception ex)
            {
                entityDetails.Value = null;
                entityDetails.Success = false;
            }
            return entityDetails;
        }

        public ServiceResult<tbl_ProjectTaskType_DTO> GetProjectTaskTypeById(int Id)
        {
            var entityDetails = new ServiceResult<tbl_ProjectTaskType_DTO>();
            try
            {
                entityDetails.Value = (tbl_ProjectTaskType_DTO)EntityUtility.GetProjectTaskTypeById(Id);
                entityDetails.Success = true;
            }
            catch (Exception ex)
            {
                entityDetails.Value = null;
                entityDetails.Success = false;
            }
            return entityDetails;
        }

        public ServiceResult<tbl_TypeMaster_DTO> GetTypeByEnum(Types entityEnum)
        {
            var entityDetails = new ServiceResult<tbl_TypeMaster_DTO>();
            try
            {
                entityDetails.Value = new TypeUtility().GetTypeByEnum(entityEnum);
                entityDetails.Success = true;
            }
            catch (Exception ex)
            {
                entityDetails.Value = null;
                entityDetails.Success = false;
            }
            return entityDetails;
        }

        public ServiceResult<tbl_Entity_DTO> GetEntityByTeamType(TeamType teamType)
        {
            var entityDetails = new ServiceResult<tbl_Entity_DTO>();
            try
            {
                entityDetails.Value = new EntityUtility().GetEntityByTeamType(teamType);
                entityDetails.Success = true;
            }
            catch (Exception ex)
            {
                entityDetails.Value = null;
                entityDetails.Success = false;
            }
            return entityDetails;
        }
        #endregion
    }
}