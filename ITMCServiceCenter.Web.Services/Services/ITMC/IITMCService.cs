using ITMCServiceCenter.Web.Domain;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace ITMCServiceCenter.Web.Services
{
    [ServiceContract]
    interface IITMCService
    {
        #region Account
        [OperationContract]
        ServiceResult<tbl_UserMaster_DTO> AuthenticateUser(tbl_UserMaster_DTO userToAuthenticate);
        #endregion

        #region User
        [OperationContract]
        ServiceResult<List<tbl_UserMaster_DTO>> GetUsersByDesignationId(int designationId);

        [OperationContract]
        ServiceResult<List<tbl_UserMaster_DTO>> GetUsersByRoleId(int roleId);

        [OperationContract]
        ServiceResult<tbl_UserMaster_DTO> GetUserByUserName(string userName);

        [OperationContract]
        ServiceResult<tbl_UserMaster_DTO> GetUser(int id);

        [OperationContract]
        ServiceResult<List<tbl_UserMaster_DTO>> GetUsers();

        [OperationContract]
        ServiceResult<int> SaveUser(tbl_UserMaster_DTO tbl_UserMaster_DTO);

        [OperationContract]
        ServiceResult<bool> UpdateUser(tbl_UserMaster_DTO tbl_UserMaster_DTO);

        [OperationContract]
        ServiceResult<bool> DeleteUser(int userId);

        #region Engineers
        [OperationContract]
        ServiceResult<List<tbl_Engineer_DTO>> GetEngineers(Types type, int typeId);

        [OperationContract]
        ServiceResult<bool> SaveEngineers(List<tbl_Engineer_DTO> newEngineers, Types type, int typeId);
        #endregion
        #endregion

        #region Project
        [OperationContract]
        ServiceResult<List<tbl_Project_DTO>> GetProjects();

        [OperationContract]
        ServiceResult<tbl_Project_DTO> GetProject(short Id);

        [OperationContract]
        ServiceResult<short> SaveProject(tbl_Project_DTO tbl_Project_DTO);

        [OperationContract]
        ServiceResult<bool> UpdateProject(tbl_Project_DTO tbl_Project_DTO);

        [OperationContract]
        ServiceResult<bool> DeleteProject(short projectId);

        #region Project Document
        [OperationContract]
        ServiceResult<List<tbl_ProjectDocument_DTO>> GetProjectDocuments();

        [OperationContract]
        ServiceResult<tbl_ProjectDocument_DTO> GetProjectDocument(int documentId);

        [OperationContract]
        ServiceResult<List<tbl_ProjectDocument_DTO>> GetProjectDocumentByProjectId(short projectId);
        #endregion
        #endregion

        #region Project Task
        [OperationContract]
        ServiceResult<List<tbl_ProjectTask_DTO>> GetProjectTasks();

        [OperationContract]
        ServiceResult<tbl_ProjectTask_DTO> GetProjectTask(int Id);

        [OperationContract]
        ServiceResult<List<tbl_ProjectTask_DTO>> GetProjectTaskByProjectId(short projectId);

        [OperationContract]
        ServiceResult<int> SaveProjectTask(tbl_ProjectTask_DTO tbl_Project_DTO);

        [OperationContract]
        ServiceResult<bool> UpdateProjectTask(tbl_ProjectTask_DTO tbl_Project_DTO);

        [OperationContract]
        ServiceResult<bool> DeleteProjectTask(int projectTaskId);

        #region Project Task Action
        [OperationContract]
        ServiceResult<List<tbl_ProjectTaskAction_DTO>> GetProjectTaskActions();

        [OperationContract]
        ServiceResult<tbl_ProjectTaskAction_DTO> GetProjectTaskAction(int actionId);

        [OperationContract]
        ServiceResult<List<tbl_ProjectTaskAction_DTO>> GetProjectTaskActionByTaskId(int projectTaskId);

        [OperationContract]
        ServiceResult<int> SaveProjectTaskAction(tbl_ProjectTaskActionDTO actionDto);
        #endregion

        #region Project Task Document
        [OperationContract]
        ServiceResult<List<tbl_ProjectTaskDocument_DTO>> GetProjectTaskDocuments();

        [OperationContract]
        ServiceResult<tbl_ProjectTaskDocument_DTO> GetProjectTaskDocument(int documentId);

        [OperationContract]
        ServiceResult<List<tbl_ProjectTaskDocument_DTO>> GetProjectTaskDocumentByProjectTaskId(int projectTaskId);
        #endregion

        #region ProjectTaskType
        [OperationContract]
        ServiceResult<int> SaveProjectTaskType(tbl_ProjectTaskType_DTO tbl_ProjectTaskType_DTO);
        #endregion

        #endregion

        #region Change Request
        [OperationContract]
        ServiceResult<List<tbl_ChangeRequest_DTO>> GetChangeRequestsByProjectId(short projectId);

        [OperationContract]
        ServiceResult<List<tbl_ChangeRequest_DTO>> GetChangeRequests();

        [OperationContract]
        ServiceResult<tbl_ChangeRequest_DTO> GetChangeRequest(int id);

        [OperationContract]
        ServiceResult<int> SaveChangeRequest(tbl_ChangeRequest_DTO tbl_ChangeRequest_DTO);

        [OperationContract]
        ServiceResult<bool> UpdateChangeRequest(tbl_ChangeRequest_DTO tbl_ChangeRequest_DTO);

        [OperationContract]
        ServiceResult<bool> DeleteChangeRequest(int changeRequestId);

        #region Change Request Action
        [OperationContract]
        ServiceResult<List<tbl_ChangeRequestAction_DTO>> GetChangeRequestActionsByRequestId(int requestId);

        [OperationContract]
        ServiceResult<List<tbl_ChangeRequestAction_DTO>> GetChangeRequestActions();

        [OperationContract]
        ServiceResult<tbl_ChangeRequestAction_DTO> GetChangeRequestAction(int actionId);

        [OperationContract]
        ServiceResult<int> SaveChangeRequestAction(tbl_ChangeRequestActionDTO actionDto);
        #endregion

        #region Change Request Document
        [OperationContract]
        ServiceResult<List<tbl_ChangeRequestDocument_DTO>> GetChangeRequestDocumentsByRequestId(int requestId);

        [OperationContract]
        ServiceResult<List<tbl_ChangeRequestDocument_DTO>> GetChangeRequestDocuments();

        [OperationContract]
        ServiceResult<tbl_ChangeRequestDocument_DTO> GetChangeRequestDocument(int documentId);
        #endregion

        #endregion

        #region Service Request
        [OperationContract]
        ServiceResult<List<tbl_ServiceRequest_DTO>> GetServiceRequestsByProjectId(short projectId);

        [OperationContract]
        ServiceResult<List<tbl_ServiceRequest_DTO>> GetServiceRequests();

        [OperationContract]
        ServiceResult<tbl_ServiceRequest_DTO> GetServiceRequest(int id);

        [OperationContract]
        ServiceResult<int> SaveServiceRequest(tbl_ServiceRequest_DTO tbl_ServiceRequest_DTO);

        [OperationContract]
        ServiceResult<bool> UpdateServiceRequest(tbl_ServiceRequest_DTO tbl_ServiceRequest_DTO);

        [OperationContract]
        ServiceResult<bool> DeleteServiceRequest(int serviceRequestId);

        #region Service Request Action

        [OperationContract]
        ServiceResult<List<tbl_ServiceRequestAction_DTO>> GetServiceRequestActionsByRequestId(int requestId);

        [OperationContract]
        ServiceResult<List<tbl_ServiceRequestAction_DTO>> GetServiceRequestActions();

        [OperationContract]
        ServiceResult<tbl_ServiceRequestAction_DTO> GetServiceRequestAction(int actionId);

        [OperationContract]
        ServiceResult<int> SaveServiceRequestAction(tbl_ServiceRequestActionDTO actionDto);
        #endregion

        #region Service Request Document
        [OperationContract]
        ServiceResult<List<tbl_ServiceRequestDocument_DTO>> GetServiceRequestDocumentsByRequestId(int requestId);

        [OperationContract]
        ServiceResult<List<tbl_ServiceRequestDocument_DTO>> GetServiceRequestDocuments();

        [OperationContract]
        ServiceResult<tbl_ServiceRequestDocument_DTO> GetServiceRequestDocument(int documentId);
        #endregion
        #endregion

        #region Issue
        [OperationContract]
        ServiceResult<List<tbl_IssueTracker_DTO>> GetIssuesByProjectId(short projectId);

        [OperationContract]
        ServiceResult<List<tbl_IssueTracker_DTO>> GetIssues();

        [OperationContract]
        ServiceResult<tbl_IssueTracker_DTO> GetIssue(int id);

        [OperationContract]
        ServiceResult<int> SaveIssue(tbl_IssueTracker_DTO tbl_Issue_DTO);

        [OperationContract]
        ServiceResult<bool> UpdateIssue(tbl_IssueTracker_DTO tbl_Issue_DTO);

        [OperationContract]
        ServiceResult<bool> DeleteIssue(int issueId);

        #region Issue Action
        [OperationContract]
        ServiceResult<List<tbl_IssueTrackerAction_DTO>> GetIssueActionsByIssueId(int issueId);

        [OperationContract]
        ServiceResult<List<tbl_IssueTrackerAction_DTO>> GetIssueActions();

        [OperationContract]
        ServiceResult<tbl_IssueTrackerAction_DTO> GetIssueAction(int actionId);

        [OperationContract]
        ServiceResult<int> SaveIssueAction(tbl_IssueTrackerActionDTO actionDto);
        #endregion

        #region Issue Document
        [OperationContract]
        ServiceResult<List<tbl_IssueTrackerDocument_DTO>> GetIssueDocumentsByIssueId(int issueId);

        [OperationContract]
        ServiceResult<List<tbl_IssueTrackerDocument_DTO>> GetIssueDocuments();

        [OperationContract]
        ServiceResult<tbl_IssueTrackerDocument_DTO> GetIssueDocument(int documentId);
        #endregion
        #endregion

        #region Incident
        [OperationContract]
        ServiceResult<List<tbl_Incident_DTO>> GetIncidents();

        [OperationContract]
        ServiceResult<tbl_Incident_DTO> GetIncident(int Id);

        [OperationContract]
        ServiceResult<List<tbl_Incident_DTO>> GetIncidentByProjectId(short projectId);

        [OperationContract]
        ServiceResult<int> SaveIncident(tbl_Incident_DTO tbl_Incident_DTO);

        [OperationContract]
        ServiceResult<bool> UpdateIncident(tbl_Incident_DTO tbl_Incident_DTO);

        [OperationContract]
        ServiceResult<bool> DeleteIncident(int incidentId);

        #region Incident Action

        [OperationContract]
        ServiceResult<List<tbl_IncidentAction_DTO>> GetIncidentActions();

        [OperationContract]
        ServiceResult<tbl_IncidentAction_DTO> GetIncidentAction(int actionId);

        [OperationContract]
        ServiceResult<List<tbl_IncidentAction_DTO>> GetIncidentActionByIncidentId(int incidentId);

        [OperationContract]
        ServiceResult<int> SaveIncidentAction(tbl_IncidentActionDTO actionDto);

        #endregion

        #region Incident Document

        [OperationContract]
        ServiceResult<List<tbl_IncidentDocument_DTO>> GetIncidentDocuments();

        [OperationContract]
        ServiceResult<tbl_IncidentDocument_DTO> GetIncidentDocument(int documentId);

        [OperationContract]
        ServiceResult<List<tbl_IncidentDocument_DTO>> GetIncidentDocumenByIncidentId(int incidentId);

        #endregion
        #endregion

        #region Client

        [OperationContract]
        ServiceResult<List<tbl_Client_DTO>> GetClients();

        [OperationContract]
        ServiceResult<int> SaveClient(tbl_Client_DTO tbl_Client_DTO);

        [OperationContract]
        ServiceResult<bool> UpdateClient(tbl_Client_DTO tbl_Client_DTO);

        [OperationContract]
        ServiceResult<bool> DeleteClient(int clientId);
        #endregion

        #region Team
        [OperationContract]
        ServiceResult<tbl_Team_DTO> GetTeam(Types entity, int entityId, TeamType type);

        [OperationContract]
        ServiceResult<List<tbl_Team_DTO>> GetTeams();

        [OperationContract]
        ServiceResult<int> SaveTeamWithMembers(tbl_Team_DTO tbl_Team_DTO, List<tbl_TeamMember_DTO> tbl_TeamMember_DTOList);

        [OperationContract]
        ServiceResult<bool> UpdateTeam(tbl_Team_DTO tbl_Team_DTO);

        [OperationContract]
        ServiceResult<bool> DeleteTeam(int teamId);

        #region Team Members
        [OperationContract]
        ServiceResult<List<tbl_TeamMember_DTO>> GetTeamMembersByTeamId(int teamId);
        #endregion
        #endregion

        #region Types
        [OperationContract]
        ServiceResult<List<tbl_Entity_DTO>> GetEntitiesByType(Types entity);

        [OperationContract]
        ServiceResult<tbl_Entity_DTO> GetEntityByTeamType(TeamType teamType);

        [OperationContract]
        ServiceResult<tbl_TypeMaster_DTO> GetTypeByEnum(Types entityEnum);

        [OperationContract]
        ServiceResult<List<tbl_ProjectTaskType_DTO>> GetAllProjectTaskTypes();

        [OperationContract]
        ServiceResult<List<tbl_ProjectTaskType_DTO>> GetProjectTaskTypesByProjectId(short projectId);

        [OperationContract]
        ServiceResult<tbl_ProjectTaskType_DTO> GetProjectTaskTypeById(int Id);
        #endregion
    }
}