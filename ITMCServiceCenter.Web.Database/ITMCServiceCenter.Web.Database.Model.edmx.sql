
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 02/15/2014 12:23:32
-- Generated from EDMX file: D:\Studies\ITMC\Leon\Projects\trunk\Code\ITMCServiceCenter\ITMCServiceCenter.Web.Database\ITMCServiceCenter.Web.Database.Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ITMCServiceCenter];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_tbl_Assignee_tbl_TypeMaster_RelatedTypeId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_Assignee] DROP CONSTRAINT [FK_tbl_Assignee_tbl_TypeMaster_RelatedTypeId];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_Assignee_tbl_UserMaster_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_Assignee] DROP CONSTRAINT [FK_tbl_Assignee_tbl_UserMaster_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_ChangeRequest_tbl_Entity_PriorityId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_ChangeRequest] DROP CONSTRAINT [FK_tbl_ChangeRequest_tbl_Entity_PriorityId];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_ChangeRequest_tbl_Entity_StatusId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_ChangeRequest] DROP CONSTRAINT [FK_tbl_ChangeRequest_tbl_Entity_StatusId];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_ChangeRequest_tbl_Project]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_ChangeRequest] DROP CONSTRAINT [FK_tbl_ChangeRequest_tbl_Project];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_ChangeRequest_tbl_UserMaster_Approver]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_ChangeRequest] DROP CONSTRAINT [FK_tbl_ChangeRequest_tbl_UserMaster_Approver];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_ChangeRequest_tbl_UserMaster_ChangeWriter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_ChangeRequest] DROP CONSTRAINT [FK_tbl_ChangeRequest_tbl_UserMaster_ChangeWriter];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_ChangeRequest_tbl_UserMaster_RequestedBy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_ChangeRequest] DROP CONSTRAINT [FK_tbl_ChangeRequest_tbl_UserMaster_RequestedBy];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_ChangeRequestAction_tbl_ChangeRequest]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_ChangeRequestAction] DROP CONSTRAINT [FK_tbl_ChangeRequestAction_tbl_ChangeRequest];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_ChangeRequestDocument_tbl_ChangeRequest]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_ChangeRequestDocument] DROP CONSTRAINT [FK_tbl_ChangeRequestDocument_tbl_ChangeRequest];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_Engineers_tbl_TypeMaster]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_Engineer] DROP CONSTRAINT [FK_tbl_Engineers_tbl_TypeMaster];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_Engineers_tbl_UserMaster]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_Engineer] DROP CONSTRAINT [FK_tbl_Engineers_tbl_UserMaster];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_Entity_tbl_TypeMaster]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_Entity] DROP CONSTRAINT [FK_tbl_Entity_tbl_TypeMaster];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_Incident_tbl_Entity_StatusId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_Incident] DROP CONSTRAINT [FK_tbl_Incident_tbl_Entity_StatusId];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_Incident_tbl_Project]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_Incident] DROP CONSTRAINT [FK_tbl_Incident_tbl_Project];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_Incident_tbl_UserMaster_RequestedBy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_Incident] DROP CONSTRAINT [FK_tbl_Incident_tbl_UserMaster_RequestedBy];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_IncidentAction_tbl_Incident]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_IncidentAction] DROP CONSTRAINT [FK_tbl_IncidentAction_tbl_Incident];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_IncidentDocument_tbl_Incident]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_IncidentDocument] DROP CONSTRAINT [FK_tbl_IncidentDocument_tbl_Incident];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_IssueTracker_tbl_Entity_CategoryId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_IssueTracker] DROP CONSTRAINT [FK_tbl_IssueTracker_tbl_Entity_CategoryId];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_IssueTracker_tbl_Entity_PriorityId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_IssueTracker] DROP CONSTRAINT [FK_tbl_IssueTracker_tbl_Entity_PriorityId];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_IssueTracker_tbl_Entity_StatusId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_IssueTracker] DROP CONSTRAINT [FK_tbl_IssueTracker_tbl_Entity_StatusId];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_IssueTracker_tbl_Project]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_IssueTracker] DROP CONSTRAINT [FK_tbl_IssueTracker_tbl_Project];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_IssueTrackerAction_tbl_IssueTracker]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_IssueTrackerAction] DROP CONSTRAINT [FK_tbl_IssueTrackerAction_tbl_IssueTracker];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_IssueTrackerDocument_tbl_IssueTracker]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_IssueTrackerDocument] DROP CONSTRAINT [FK_tbl_IssueTrackerDocument_tbl_IssueTracker];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_Project_tbl_Client]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_Project] DROP CONSTRAINT [FK_tbl_Project_tbl_Client];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_Project_tbl_Entities_ProjectType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_Project] DROP CONSTRAINT [FK_tbl_Project_tbl_Entities_ProjectType];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_Project_tbl_Entity_StatusId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_Project] DROP CONSTRAINT [FK_tbl_Project_tbl_Entity_StatusId];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_Project_tbl_UserMaster_Approver]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_Project] DROP CONSTRAINT [FK_tbl_Project_tbl_UserMaster_Approver];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_Project_tbl_UserMaster_Manager]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_Project] DROP CONSTRAINT [FK_tbl_Project_tbl_UserMaster_Manager];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_Project_tbl_UserMaster_QA]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_Project] DROP CONSTRAINT [FK_tbl_Project_tbl_UserMaster_QA];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_ProjectDocument_tbl_Project]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_ProjectDocument] DROP CONSTRAINT [FK_tbl_ProjectDocument_tbl_Project];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_ProjectTask_tbl_Entity_PriorityId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_ProjectTask] DROP CONSTRAINT [FK_tbl_ProjectTask_tbl_Entity_PriorityId];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_ProjectTask_tbl_Entity_StatusId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_ProjectTask] DROP CONSTRAINT [FK_tbl_ProjectTask_tbl_Entity_StatusId];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_ProjectTask_tbl_Project_ProjectId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_ProjectTask] DROP CONSTRAINT [FK_tbl_ProjectTask_tbl_Project_ProjectId];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_ProjectTask_tbl_UserMaster_QA]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_ProjectTask] DROP CONSTRAINT [FK_tbl_ProjectTask_tbl_UserMaster_QA];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_ProjectTaskAction_tbl_ProjectTask]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_ProjectTaskAction] DROP CONSTRAINT [FK_tbl_ProjectTaskAction_tbl_ProjectTask];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_ProjectTaskDocument_tbl_ProjectTask]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_ProjectTaskDocument] DROP CONSTRAINT [FK_tbl_ProjectTaskDocument_tbl_ProjectTask];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_ProjectTaskType_tbl_Project]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_ProjectTaskType] DROP CONSTRAINT [FK_tbl_ProjectTaskType_tbl_Project];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_ServiceRequest_tbl_Entity_PreviousStatusId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_ServiceRequest] DROP CONSTRAINT [FK_tbl_ServiceRequest_tbl_Entity_PreviousStatusId];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_ServiceRequest_tbl_Entity_PriorityId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_ServiceRequest] DROP CONSTRAINT [FK_tbl_ServiceRequest_tbl_Entity_PriorityId];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_ServiceRequest_tbl_Entity_StatusId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_ServiceRequest] DROP CONSTRAINT [FK_tbl_ServiceRequest_tbl_Entity_StatusId];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_ServiceRequest_tbl_Project]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_ServiceRequest] DROP CONSTRAINT [FK_tbl_ServiceRequest_tbl_Project];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_ServiceRequest_tbl_Project_ProjectId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_ServiceRequest] DROP CONSTRAINT [FK_tbl_ServiceRequest_tbl_Project_ProjectId];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_ServiceRequest_tbl_UserMaster_RequestedBy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_ServiceRequest] DROP CONSTRAINT [FK_tbl_ServiceRequest_tbl_UserMaster_RequestedBy];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_ServiceRequestAction_tbl_ServiceRequest]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_ServiceRequestAction] DROP CONSTRAINT [FK_tbl_ServiceRequestAction_tbl_ServiceRequest];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_ServiceRequestDocument_tbl_ServiceRequest]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_ServiceRequestDocument] DROP CONSTRAINT [FK_tbl_ServiceRequestDocument_tbl_ServiceRequest];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_Team_tbl_Entity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_Team] DROP CONSTRAINT [FK_tbl_Team_tbl_Entity];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_Team_tbl_TypeMaster]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_Team] DROP CONSTRAINT [FK_tbl_Team_tbl_TypeMaster];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_TeamMember_tbl_Team]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_TeamMember] DROP CONSTRAINT [FK_tbl_TeamMember_tbl_Team];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_TeamMember_tbl_UserMaster]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_TeamMember] DROP CONSTRAINT [FK_tbl_TeamMember_tbl_UserMaster];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_UserMaster_tbl_Entity_RoleId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_UserMaster] DROP CONSTRAINT [FK_tbl_UserMaster_tbl_Entity_RoleId];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_UserMaster_tbl_UserMaster_DesignationId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_UserMaster] DROP CONSTRAINT [FK_tbl_UserMaster_tbl_UserMaster_DesignationId];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[tbl_Assignee]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_Assignee];
GO
IF OBJECT_ID(N'[dbo].[tbl_ChangeRequest]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_ChangeRequest];
GO
IF OBJECT_ID(N'[dbo].[tbl_ChangeRequestAction]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_ChangeRequestAction];
GO
IF OBJECT_ID(N'[dbo].[tbl_ChangeRequestDocument]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_ChangeRequestDocument];
GO
IF OBJECT_ID(N'[dbo].[tbl_Client]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_Client];
GO
IF OBJECT_ID(N'[dbo].[tbl_Engineer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_Engineer];
GO
IF OBJECT_ID(N'[dbo].[tbl_Entity]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_Entity];
GO
IF OBJECT_ID(N'[dbo].[tbl_Incident]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_Incident];
GO
IF OBJECT_ID(N'[dbo].[tbl_IncidentAction]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_IncidentAction];
GO
IF OBJECT_ID(N'[dbo].[tbl_IncidentDocument]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_IncidentDocument];
GO
IF OBJECT_ID(N'[dbo].[tbl_IssueTracker]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_IssueTracker];
GO
IF OBJECT_ID(N'[dbo].[tbl_IssueTrackerAction]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_IssueTrackerAction];
GO
IF OBJECT_ID(N'[dbo].[tbl_IssueTrackerDocument]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_IssueTrackerDocument];
GO
IF OBJECT_ID(N'[dbo].[tbl_Project]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_Project];
GO
IF OBJECT_ID(N'[dbo].[tbl_ProjectDocument]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_ProjectDocument];
GO
IF OBJECT_ID(N'[dbo].[tbl_ProjectTask]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_ProjectTask];
GO
IF OBJECT_ID(N'[dbo].[tbl_ProjectTaskAction]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_ProjectTaskAction];
GO
IF OBJECT_ID(N'[dbo].[tbl_ProjectTaskDocument]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_ProjectTaskDocument];
GO
IF OBJECT_ID(N'[dbo].[tbl_ProjectTaskType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_ProjectTaskType];
GO
IF OBJECT_ID(N'[dbo].[tbl_RelatedIssue]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_RelatedIssue];
GO
IF OBJECT_ID(N'[dbo].[tbl_ServiceRequest]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_ServiceRequest];
GO
IF OBJECT_ID(N'[dbo].[tbl_ServiceRequestAction]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_ServiceRequestAction];
GO
IF OBJECT_ID(N'[dbo].[tbl_ServiceRequestDocument]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_ServiceRequestDocument];
GO
IF OBJECT_ID(N'[dbo].[tbl_Team]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_Team];
GO
IF OBJECT_ID(N'[dbo].[tbl_TeamMember]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_TeamMember];
GO
IF OBJECT_ID(N'[dbo].[tbl_TypeMaster]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_TypeMaster];
GO
IF OBJECT_ID(N'[dbo].[tbl_UserMaster]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_UserMaster];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'tbl_Assignee'
CREATE TABLE [dbo].[tbl_Assignee] (
    [RelateTypeId] tinyint  NOT NULL,
    [RelatedToId] int  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'tbl_ChangeRequest'
CREATE TABLE [dbo].[tbl_ChangeRequest] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RequestedBy] int  NOT NULL,
    [Approver] int  NULL,
    [ChangeWriter] int  NOT NULL,
    [ProjectId] smallint  NOT NULL,
    [PriorityId] smallint  NOT NULL,
    [StatusId] smallint  NOT NULL,
    [Title] nvarchar(100)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [StartDate] datetime  NOT NULL,
    [EndDate] datetime  NULL,
    [EstimatedHours] smallint  NOT NULL,
    [PercentComplete] tinyint  NOT NULL,
    [Impact] nvarchar(max)  NOT NULL,
    [PoNo] nvarchar(20)  NOT NULL,
    [RequestedOn] datetime  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [ModifiedOn] datetime  NULL,
    [CreatedBy] nvarchar(50)  NOT NULL,
    [ModifiedBy] nvarchar(50)  NULL
);
GO

-- Creating table 'tbl_ChangeRequestAction'
CREATE TABLE [dbo].[tbl_ChangeRequestAction] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ChangeRequestId] int  NOT NULL,
    [Action] nvarchar(max)  NOT NULL,
    [CreatedBy] nvarchar(50)  NOT NULL,
    [CreatedOn] datetime  NOT NULL
);
GO

-- Creating table 'tbl_ChangeRequestDocument'
CREATE TABLE [dbo].[tbl_ChangeRequestDocument] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ChangeRequestId] int  NOT NULL,
    [Title] nvarchar(100)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Path] nvarchar(200)  NOT NULL,
    [CreatedBy] nvarchar(50)  NOT NULL,
    [CreatedOn] datetime  NOT NULL
);
GO

-- Creating table 'tbl_Client'
CREATE TABLE [dbo].[tbl_Client] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Location] nvarchar(100)  NOT NULL,
    [ContactNo] nvarchar(25)  NULL
);
GO

-- Creating table 'tbl_Engineer'
CREATE TABLE [dbo].[tbl_Engineer] (
    [RelateTypeId] tinyint  NOT NULL,
    [RelatedToId] int  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'tbl_Entity'
CREATE TABLE [dbo].[tbl_Entity] (
    [Id] smallint IDENTITY(1,1) NOT NULL,
    [TypeMasterId] tinyint  NOT NULL,
    [Name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'tbl_Incident'
CREATE TABLE [dbo].[tbl_Incident] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RequestedBy] int  NOT NULL,
    [LevelId] smallint  NOT NULL,
    [StatusId] smallint  NOT NULL,
    [ProjectId] smallint  NOT NULL,
    [Title] nvarchar(100)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [StartDate] datetime  NULL,
    [EndDate] datetime  NULL,
    [EstimatedHours] smallint  NULL,
    [PercentComplete] tinyint  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [ModifiedOn] datetime  NULL,
    [IncidentOn] datetime  NOT NULL,
    [CreatedBy] nvarchar(50)  NOT NULL,
    [ModifiedBy] nvarchar(50)  NULL
);
GO

-- Creating table 'tbl_IncidentAction'
CREATE TABLE [dbo].[tbl_IncidentAction] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IncidentId] int  NOT NULL,
    [Action] nvarchar(max)  NOT NULL,
    [CreatedBy] nvarchar(50)  NOT NULL,
    [CreatedOn] datetime  NOT NULL
);
GO

-- Creating table 'tbl_IncidentDocument'
CREATE TABLE [dbo].[tbl_IncidentDocument] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IncidentId] int  NOT NULL,
    [Title] nvarchar(50)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Path] nvarchar(200)  NOT NULL,
    [CreatedBy] nvarchar(50)  NOT NULL,
    [CreatedOn] datetime  NOT NULL
);
GO

-- Creating table 'tbl_IssueTracker'
CREATE TABLE [dbo].[tbl_IssueTracker] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProjectId] smallint  NOT NULL,
    [StatusId] smallint  NOT NULL,
    [PriorityId] smallint  NOT NULL,
    [CategoryId] smallint  NOT NULL,
    [Title] nvarchar(100)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [EndDate] datetime  NULL,
    [CreatedOn] datetime  NOT NULL,
    [ModifiedOn] datetime  NULL,
    [Module] nvarchar(200)  NULL,
    [CreatedBy] nvarchar(50)  NOT NULL,
    [ModifiedBy] nvarchar(50)  NULL
);
GO

-- Creating table 'tbl_IssueTrackerAction'
CREATE TABLE [dbo].[tbl_IssueTrackerAction] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IssueTrackerId] int  NOT NULL,
    [Action] nvarchar(max)  NOT NULL,
    [CreatedBy] nvarchar(50)  NOT NULL,
    [CreatedOn] datetime  NOT NULL
);
GO

-- Creating table 'tbl_IssueTrackerDocument'
CREATE TABLE [dbo].[tbl_IssueTrackerDocument] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IssueTrackerId] int  NOT NULL,
    [Title] nvarchar(50)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Path] nvarchar(200)  NOT NULL,
    [CreatedBy] nvarchar(50)  NOT NULL,
    [CreatedOn] datetime  NOT NULL
);
GO

-- Creating table 'tbl_Project'
CREATE TABLE [dbo].[tbl_Project] (
    [Id] smallint IDENTITY(1,1) NOT NULL,
    [ClientId] int  NOT NULL,
    [StatusId] smallint  NOT NULL,
    [TypeId] smallint  NOT NULL,
    [Manager] int  NULL,
    [Approver] int  NULL,
    [QA] int  NULL,
    [CreatedBy] nvarchar(50)  NOT NULL,
    [ModifiedBy] nvarchar(50)  NULL,
    [Title] nvarchar(100)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [StartDate] datetime  NOT NULL,
    [EndDate] datetime  NULL,
    [EstimatedHours] smallint  NOT NULL,
    [EstimatedCost] int  NULL,
    [PoNo] nvarchar(10)  NOT NULL,
    [Site] nvarchar(max)  NULL,
    [CreatedOn] datetime  NOT NULL,
    [ModifiedOn] datetime  NULL
);
GO

-- Creating table 'tbl_ProjectDocument'
CREATE TABLE [dbo].[tbl_ProjectDocument] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProjectId] smallint  NOT NULL,
    [Title] nvarchar(100)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Path] nvarchar(200)  NOT NULL,
    [CreatedBy] nvarchar(50)  NOT NULL,
    [CreatedOn] datetime  NOT NULL
);
GO

-- Creating table 'tbl_ProjectTask'
CREATE TABLE [dbo].[tbl_ProjectTask] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProjectId] smallint  NOT NULL,
    [StatusId] smallint  NOT NULL,
    [PriorityId] smallint  NOT NULL,
    [TypeId] smallint  NOT NULL,
    [QA] int  NULL,
    [Title] nvarchar(100)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [StartDate] datetime  NOT NULL,
    [EndDate] datetime  NULL,
    [EstimatedHours] smallint  NULL,
    [EstimatedCost] smallint  NULL,
    [PercentComplete] tinyint  NOT NULL,
    [QAStartDate] datetime  NULL,
    [QAEndDate] datetime  NULL,
    [CreatedOn] datetime  NOT NULL,
    [ModifiedOn] datetime  NULL,
    [CreatedBy] nvarchar(50)  NOT NULL,
    [ModifiedBy] nvarchar(50)  NULL
);
GO

-- Creating table 'tbl_ProjectTaskAction'
CREATE TABLE [dbo].[tbl_ProjectTaskAction] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProjectTaskId] int  NOT NULL,
    [Action] nvarchar(max)  NOT NULL,
    [CreatedBy] nvarchar(50)  NOT NULL,
    [CreatedOn] datetime  NOT NULL
);
GO

-- Creating table 'tbl_ProjectTaskDocument'
CREATE TABLE [dbo].[tbl_ProjectTaskDocument] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProjectTaskId] int  NOT NULL,
    [Title] nvarchar(100)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Path] nvarchar(200)  NOT NULL,
    [CreatedBy] nvarchar(50)  NOT NULL,
    [CreatedOn] datetime  NOT NULL
);
GO

-- Creating table 'tbl_ProjectTaskType'
CREATE TABLE [dbo].[tbl_ProjectTaskType] (
    [Id] smallint IDENTITY(1,1) NOT NULL,
    [ProjectId] smallint  NOT NULL,
    [Type] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'tbl_RelatedIssue'
CREATE TABLE [dbo].[tbl_RelatedIssue] (
    [Id] int  NOT NULL,
    [RelatedIssueId] int  NOT NULL
);
GO

-- Creating table 'tbl_ServiceRequest'
CREATE TABLE [dbo].[tbl_ServiceRequest] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RequestedBy] int  NOT NULL,
    [ProjectId] smallint  NOT NULL,
    [StatusId] smallint  NOT NULL,
    [PriorityId] smallint  NOT NULL,
    [PreviousStatusId] smallint  NULL,
    [Title] nvarchar(100)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [StartDate] datetime  NULL,
    [EndDate] datetime  NULL,
    [EstimatedHours] smallint  NOT NULL,
    [PercentComplete] tinyint  NOT NULL,
    [PoNo] int  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [ModifiedOn] datetime  NULL,
    [RequestedOn] datetime  NOT NULL,
    [CreatedBy] nvarchar(50)  NOT NULL,
    [ModifiedBy] nvarchar(50)  NULL
);
GO

-- Creating table 'tbl_ServiceRequestAction'
CREATE TABLE [dbo].[tbl_ServiceRequestAction] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ServiceRequestId] int  NOT NULL,
    [Action] nvarchar(max)  NOT NULL,
    [CreatedBy] nvarchar(50)  NOT NULL,
    [CreatedOn] datetime  NOT NULL
);
GO

-- Creating table 'tbl_ServiceRequestDocument'
CREATE TABLE [dbo].[tbl_ServiceRequestDocument] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ServiceRequestId] int  NOT NULL,
    [Title] nvarchar(50)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Path] nvarchar(200)  NOT NULL,
    [CreatedBy] nvarchar(50)  NOT NULL,
    [CreatedOn] datetime  NOT NULL
);
GO

-- Creating table 'tbl_Team'
CREATE TABLE [dbo].[tbl_Team] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RelatedTypeId] tinyint  NOT NULL,
    [RelatedToId] int  NOT NULL,
    [TypeId] smallint  NOT NULL
);
GO

-- Creating table 'tbl_TeamMember'
CREATE TABLE [dbo].[tbl_TeamMember] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [TeamId] int  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'tbl_TypeMaster'
CREATE TABLE [dbo].[tbl_TypeMaster] (
    [Id] tinyint IDENTITY(1,1) NOT NULL,
    [Type] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'tbl_UserMaster'
CREATE TABLE [dbo].[tbl_UserMaster] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DesignationId] smallint  NOT NULL,
    [RoleId] smallint  NOT NULL,
    [UserName] nvarchar(50)  NOT NULL,
    [Password] nvarchar(20)  NOT NULL,
    [FirstName] nvarchar(50)  NOT NULL,
    [LastName] nvarchar(50)  NOT NULL,
    [IsClient] bit  NOT NULL,
    [IsDisable] bit  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [RelateTypeId], [RelatedToId], [UserId] in table 'tbl_Assignee'
ALTER TABLE [dbo].[tbl_Assignee]
ADD CONSTRAINT [PK_tbl_Assignee]
    PRIMARY KEY CLUSTERED ([RelateTypeId], [RelatedToId], [UserId] ASC);
GO

-- Creating primary key on [Id] in table 'tbl_ChangeRequest'
ALTER TABLE [dbo].[tbl_ChangeRequest]
ADD CONSTRAINT [PK_tbl_ChangeRequest]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tbl_ChangeRequestAction'
ALTER TABLE [dbo].[tbl_ChangeRequestAction]
ADD CONSTRAINT [PK_tbl_ChangeRequestAction]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tbl_ChangeRequestDocument'
ALTER TABLE [dbo].[tbl_ChangeRequestDocument]
ADD CONSTRAINT [PK_tbl_ChangeRequestDocument]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tbl_Client'
ALTER TABLE [dbo].[tbl_Client]
ADD CONSTRAINT [PK_tbl_Client]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [RelateTypeId], [RelatedToId], [UserId] in table 'tbl_Engineer'
ALTER TABLE [dbo].[tbl_Engineer]
ADD CONSTRAINT [PK_tbl_Engineer]
    PRIMARY KEY CLUSTERED ([RelateTypeId], [RelatedToId], [UserId] ASC);
GO

-- Creating primary key on [Id] in table 'tbl_Entity'
ALTER TABLE [dbo].[tbl_Entity]
ADD CONSTRAINT [PK_tbl_Entity]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tbl_Incident'
ALTER TABLE [dbo].[tbl_Incident]
ADD CONSTRAINT [PK_tbl_Incident]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tbl_IncidentAction'
ALTER TABLE [dbo].[tbl_IncidentAction]
ADD CONSTRAINT [PK_tbl_IncidentAction]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tbl_IncidentDocument'
ALTER TABLE [dbo].[tbl_IncidentDocument]
ADD CONSTRAINT [PK_tbl_IncidentDocument]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tbl_IssueTracker'
ALTER TABLE [dbo].[tbl_IssueTracker]
ADD CONSTRAINT [PK_tbl_IssueTracker]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tbl_IssueTrackerAction'
ALTER TABLE [dbo].[tbl_IssueTrackerAction]
ADD CONSTRAINT [PK_tbl_IssueTrackerAction]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tbl_IssueTrackerDocument'
ALTER TABLE [dbo].[tbl_IssueTrackerDocument]
ADD CONSTRAINT [PK_tbl_IssueTrackerDocument]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tbl_Project'
ALTER TABLE [dbo].[tbl_Project]
ADD CONSTRAINT [PK_tbl_Project]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tbl_ProjectDocument'
ALTER TABLE [dbo].[tbl_ProjectDocument]
ADD CONSTRAINT [PK_tbl_ProjectDocument]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tbl_ProjectTask'
ALTER TABLE [dbo].[tbl_ProjectTask]
ADD CONSTRAINT [PK_tbl_ProjectTask]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tbl_ProjectTaskAction'
ALTER TABLE [dbo].[tbl_ProjectTaskAction]
ADD CONSTRAINT [PK_tbl_ProjectTaskAction]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tbl_ProjectTaskDocument'
ALTER TABLE [dbo].[tbl_ProjectTaskDocument]
ADD CONSTRAINT [PK_tbl_ProjectTaskDocument]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tbl_ProjectTaskType'
ALTER TABLE [dbo].[tbl_ProjectTaskType]
ADD CONSTRAINT [PK_tbl_ProjectTaskType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id], [RelatedIssueId] in table 'tbl_RelatedIssue'
ALTER TABLE [dbo].[tbl_RelatedIssue]
ADD CONSTRAINT [PK_tbl_RelatedIssue]
    PRIMARY KEY CLUSTERED ([Id], [RelatedIssueId] ASC);
GO

-- Creating primary key on [Id] in table 'tbl_ServiceRequest'
ALTER TABLE [dbo].[tbl_ServiceRequest]
ADD CONSTRAINT [PK_tbl_ServiceRequest]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tbl_ServiceRequestAction'
ALTER TABLE [dbo].[tbl_ServiceRequestAction]
ADD CONSTRAINT [PK_tbl_ServiceRequestAction]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tbl_ServiceRequestDocument'
ALTER TABLE [dbo].[tbl_ServiceRequestDocument]
ADD CONSTRAINT [PK_tbl_ServiceRequestDocument]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tbl_Team'
ALTER TABLE [dbo].[tbl_Team]
ADD CONSTRAINT [PK_tbl_Team]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tbl_TeamMember'
ALTER TABLE [dbo].[tbl_TeamMember]
ADD CONSTRAINT [PK_tbl_TeamMember]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tbl_TypeMaster'
ALTER TABLE [dbo].[tbl_TypeMaster]
ADD CONSTRAINT [PK_tbl_TypeMaster]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tbl_UserMaster'
ALTER TABLE [dbo].[tbl_UserMaster]
ADD CONSTRAINT [PK_tbl_UserMaster]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [RelateTypeId] in table 'tbl_Assignee'
ALTER TABLE [dbo].[tbl_Assignee]
ADD CONSTRAINT [FK_tbl_Assignee_tbl_TypeMaster_RelatedTypeId]
    FOREIGN KEY ([RelateTypeId])
    REFERENCES [dbo].[tbl_TypeMaster]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UserId] in table 'tbl_Assignee'
ALTER TABLE [dbo].[tbl_Assignee]
ADD CONSTRAINT [FK_tbl_Assignee_tbl_UserMaster_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[tbl_UserMaster]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_Assignee_tbl_UserMaster_UserId'
CREATE INDEX [IX_FK_tbl_Assignee_tbl_UserMaster_UserId]
ON [dbo].[tbl_Assignee]
    ([UserId]);
GO

-- Creating foreign key on [PriorityId] in table 'tbl_ChangeRequest'
ALTER TABLE [dbo].[tbl_ChangeRequest]
ADD CONSTRAINT [FK_tbl_ChangeRequest_tbl_Entity_PriorityId]
    FOREIGN KEY ([PriorityId])
    REFERENCES [dbo].[tbl_Entity]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_ChangeRequest_tbl_Entity_PriorityId'
CREATE INDEX [IX_FK_tbl_ChangeRequest_tbl_Entity_PriorityId]
ON [dbo].[tbl_ChangeRequest]
    ([PriorityId]);
GO

-- Creating foreign key on [StatusId] in table 'tbl_ChangeRequest'
ALTER TABLE [dbo].[tbl_ChangeRequest]
ADD CONSTRAINT [FK_tbl_ChangeRequest_tbl_Entity_StatusId]
    FOREIGN KEY ([StatusId])
    REFERENCES [dbo].[tbl_Entity]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_ChangeRequest_tbl_Entity_StatusId'
CREATE INDEX [IX_FK_tbl_ChangeRequest_tbl_Entity_StatusId]
ON [dbo].[tbl_ChangeRequest]
    ([StatusId]);
GO

-- Creating foreign key on [ProjectId] in table 'tbl_ChangeRequest'
ALTER TABLE [dbo].[tbl_ChangeRequest]
ADD CONSTRAINT [FK_tbl_ChangeRequest_tbl_Project]
    FOREIGN KEY ([ProjectId])
    REFERENCES [dbo].[tbl_Project]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_ChangeRequest_tbl_Project'
CREATE INDEX [IX_FK_tbl_ChangeRequest_tbl_Project]
ON [dbo].[tbl_ChangeRequest]
    ([ProjectId]);
GO

-- Creating foreign key on [Approver] in table 'tbl_ChangeRequest'
ALTER TABLE [dbo].[tbl_ChangeRequest]
ADD CONSTRAINT [FK_tbl_ChangeRequest_tbl_UserMaster_Approver]
    FOREIGN KEY ([Approver])
    REFERENCES [dbo].[tbl_UserMaster]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_ChangeRequest_tbl_UserMaster_Approver'
CREATE INDEX [IX_FK_tbl_ChangeRequest_tbl_UserMaster_Approver]
ON [dbo].[tbl_ChangeRequest]
    ([Approver]);
GO

-- Creating foreign key on [ChangeWriter] in table 'tbl_ChangeRequest'
ALTER TABLE [dbo].[tbl_ChangeRequest]
ADD CONSTRAINT [FK_tbl_ChangeRequest_tbl_UserMaster_ChangeWriter]
    FOREIGN KEY ([ChangeWriter])
    REFERENCES [dbo].[tbl_UserMaster]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_ChangeRequest_tbl_UserMaster_ChangeWriter'
CREATE INDEX [IX_FK_tbl_ChangeRequest_tbl_UserMaster_ChangeWriter]
ON [dbo].[tbl_ChangeRequest]
    ([ChangeWriter]);
GO

-- Creating foreign key on [RequestedBy] in table 'tbl_ChangeRequest'
ALTER TABLE [dbo].[tbl_ChangeRequest]
ADD CONSTRAINT [FK_tbl_ChangeRequest_tbl_UserMaster_RequestedBy]
    FOREIGN KEY ([RequestedBy])
    REFERENCES [dbo].[tbl_UserMaster]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_ChangeRequest_tbl_UserMaster_RequestedBy'
CREATE INDEX [IX_FK_tbl_ChangeRequest_tbl_UserMaster_RequestedBy]
ON [dbo].[tbl_ChangeRequest]
    ([RequestedBy]);
GO

-- Creating foreign key on [ChangeRequestId] in table 'tbl_ChangeRequestAction'
ALTER TABLE [dbo].[tbl_ChangeRequestAction]
ADD CONSTRAINT [FK_tbl_ChangeRequestAction_tbl_ChangeRequest]
    FOREIGN KEY ([ChangeRequestId])
    REFERENCES [dbo].[tbl_ChangeRequest]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_ChangeRequestAction_tbl_ChangeRequest'
CREATE INDEX [IX_FK_tbl_ChangeRequestAction_tbl_ChangeRequest]
ON [dbo].[tbl_ChangeRequestAction]
    ([ChangeRequestId]);
GO

-- Creating foreign key on [ChangeRequestId] in table 'tbl_ChangeRequestDocument'
ALTER TABLE [dbo].[tbl_ChangeRequestDocument]
ADD CONSTRAINT [FK_tbl_ChangeRequestDocument_tbl_ChangeRequest]
    FOREIGN KEY ([ChangeRequestId])
    REFERENCES [dbo].[tbl_ChangeRequest]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_ChangeRequestDocument_tbl_ChangeRequest'
CREATE INDEX [IX_FK_tbl_ChangeRequestDocument_tbl_ChangeRequest]
ON [dbo].[tbl_ChangeRequestDocument]
    ([ChangeRequestId]);
GO

-- Creating foreign key on [ClientId] in table 'tbl_Project'
ALTER TABLE [dbo].[tbl_Project]
ADD CONSTRAINT [FK_tbl_Project_tbl_Client]
    FOREIGN KEY ([ClientId])
    REFERENCES [dbo].[tbl_Client]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_Project_tbl_Client'
CREATE INDEX [IX_FK_tbl_Project_tbl_Client]
ON [dbo].[tbl_Project]
    ([ClientId]);
GO

-- Creating foreign key on [RelateTypeId] in table 'tbl_Engineer'
ALTER TABLE [dbo].[tbl_Engineer]
ADD CONSTRAINT [FK_tbl_Engineers_tbl_TypeMaster]
    FOREIGN KEY ([RelateTypeId])
    REFERENCES [dbo].[tbl_TypeMaster]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UserId] in table 'tbl_Engineer'
ALTER TABLE [dbo].[tbl_Engineer]
ADD CONSTRAINT [FK_tbl_Engineers_tbl_UserMaster]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[tbl_UserMaster]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_Engineers_tbl_UserMaster'
CREATE INDEX [IX_FK_tbl_Engineers_tbl_UserMaster]
ON [dbo].[tbl_Engineer]
    ([UserId]);
GO

-- Creating foreign key on [TypeMasterId] in table 'tbl_Entity'
ALTER TABLE [dbo].[tbl_Entity]
ADD CONSTRAINT [FK_tbl_Entity_tbl_TypeMaster]
    FOREIGN KEY ([TypeMasterId])
    REFERENCES [dbo].[tbl_TypeMaster]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_Entity_tbl_TypeMaster'
CREATE INDEX [IX_FK_tbl_Entity_tbl_TypeMaster]
ON [dbo].[tbl_Entity]
    ([TypeMasterId]);
GO

-- Creating foreign key on [StatusId] in table 'tbl_Incident'
ALTER TABLE [dbo].[tbl_Incident]
ADD CONSTRAINT [FK_tbl_Incident_tbl_Entity_StatusId]
    FOREIGN KEY ([StatusId])
    REFERENCES [dbo].[tbl_Entity]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_Incident_tbl_Entity_StatusId'
CREATE INDEX [IX_FK_tbl_Incident_tbl_Entity_StatusId]
ON [dbo].[tbl_Incident]
    ([StatusId]);
GO

-- Creating foreign key on [CategoryId] in table 'tbl_IssueTracker'
ALTER TABLE [dbo].[tbl_IssueTracker]
ADD CONSTRAINT [FK_tbl_IssueTracker_tbl_Entity_CategoryId]
    FOREIGN KEY ([CategoryId])
    REFERENCES [dbo].[tbl_Entity]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_IssueTracker_tbl_Entity_CategoryId'
CREATE INDEX [IX_FK_tbl_IssueTracker_tbl_Entity_CategoryId]
ON [dbo].[tbl_IssueTracker]
    ([CategoryId]);
GO

-- Creating foreign key on [PriorityId] in table 'tbl_IssueTracker'
ALTER TABLE [dbo].[tbl_IssueTracker]
ADD CONSTRAINT [FK_tbl_IssueTracker_tbl_Entity_PriorityId]
    FOREIGN KEY ([PriorityId])
    REFERENCES [dbo].[tbl_Entity]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_IssueTracker_tbl_Entity_PriorityId'
CREATE INDEX [IX_FK_tbl_IssueTracker_tbl_Entity_PriorityId]
ON [dbo].[tbl_IssueTracker]
    ([PriorityId]);
GO

-- Creating foreign key on [StatusId] in table 'tbl_IssueTracker'
ALTER TABLE [dbo].[tbl_IssueTracker]
ADD CONSTRAINT [FK_tbl_IssueTracker_tbl_Entity_StatusId]
    FOREIGN KEY ([StatusId])
    REFERENCES [dbo].[tbl_Entity]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_IssueTracker_tbl_Entity_StatusId'
CREATE INDEX [IX_FK_tbl_IssueTracker_tbl_Entity_StatusId]
ON [dbo].[tbl_IssueTracker]
    ([StatusId]);
GO

-- Creating foreign key on [TypeId] in table 'tbl_Project'
ALTER TABLE [dbo].[tbl_Project]
ADD CONSTRAINT [FK_tbl_Project_tbl_Entities_ProjectType]
    FOREIGN KEY ([TypeId])
    REFERENCES [dbo].[tbl_Entity]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_Project_tbl_Entities_ProjectType'
CREATE INDEX [IX_FK_tbl_Project_tbl_Entities_ProjectType]
ON [dbo].[tbl_Project]
    ([TypeId]);
GO

-- Creating foreign key on [StatusId] in table 'tbl_Project'
ALTER TABLE [dbo].[tbl_Project]
ADD CONSTRAINT [FK_tbl_Project_tbl_Entity_StatusId]
    FOREIGN KEY ([StatusId])
    REFERENCES [dbo].[tbl_Entity]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_Project_tbl_Entity_StatusId'
CREATE INDEX [IX_FK_tbl_Project_tbl_Entity_StatusId]
ON [dbo].[tbl_Project]
    ([StatusId]);
GO

-- Creating foreign key on [PriorityId] in table 'tbl_ProjectTask'
ALTER TABLE [dbo].[tbl_ProjectTask]
ADD CONSTRAINT [FK_tbl_ProjectTask_tbl_Entity_PriorityId]
    FOREIGN KEY ([PriorityId])
    REFERENCES [dbo].[tbl_Entity]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_ProjectTask_tbl_Entity_PriorityId'
CREATE INDEX [IX_FK_tbl_ProjectTask_tbl_Entity_PriorityId]
ON [dbo].[tbl_ProjectTask]
    ([PriorityId]);
GO

-- Creating foreign key on [StatusId] in table 'tbl_ProjectTask'
ALTER TABLE [dbo].[tbl_ProjectTask]
ADD CONSTRAINT [FK_tbl_ProjectTask_tbl_Entity_StatusId]
    FOREIGN KEY ([StatusId])
    REFERENCES [dbo].[tbl_Entity]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_ProjectTask_tbl_Entity_StatusId'
CREATE INDEX [IX_FK_tbl_ProjectTask_tbl_Entity_StatusId]
ON [dbo].[tbl_ProjectTask]
    ([StatusId]);
GO

-- Creating foreign key on [PreviousStatusId] in table 'tbl_ServiceRequest'
ALTER TABLE [dbo].[tbl_ServiceRequest]
ADD CONSTRAINT [FK_tbl_ServiceRequest_tbl_Entity_PreviousStatusId]
    FOREIGN KEY ([PreviousStatusId])
    REFERENCES [dbo].[tbl_Entity]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_ServiceRequest_tbl_Entity_PreviousStatusId'
CREATE INDEX [IX_FK_tbl_ServiceRequest_tbl_Entity_PreviousStatusId]
ON [dbo].[tbl_ServiceRequest]
    ([PreviousStatusId]);
GO

-- Creating foreign key on [PriorityId] in table 'tbl_ServiceRequest'
ALTER TABLE [dbo].[tbl_ServiceRequest]
ADD CONSTRAINT [FK_tbl_ServiceRequest_tbl_Entity_PriorityId]
    FOREIGN KEY ([PriorityId])
    REFERENCES [dbo].[tbl_Entity]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_ServiceRequest_tbl_Entity_PriorityId'
CREATE INDEX [IX_FK_tbl_ServiceRequest_tbl_Entity_PriorityId]
ON [dbo].[tbl_ServiceRequest]
    ([PriorityId]);
GO

-- Creating foreign key on [StatusId] in table 'tbl_ServiceRequest'
ALTER TABLE [dbo].[tbl_ServiceRequest]
ADD CONSTRAINT [FK_tbl_ServiceRequest_tbl_Entity_StatusId]
    FOREIGN KEY ([StatusId])
    REFERENCES [dbo].[tbl_Entity]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_ServiceRequest_tbl_Entity_StatusId'
CREATE INDEX [IX_FK_tbl_ServiceRequest_tbl_Entity_StatusId]
ON [dbo].[tbl_ServiceRequest]
    ([StatusId]);
GO

-- Creating foreign key on [TypeId] in table 'tbl_Team'
ALTER TABLE [dbo].[tbl_Team]
ADD CONSTRAINT [FK_tbl_Team_tbl_Entity]
    FOREIGN KEY ([TypeId])
    REFERENCES [dbo].[tbl_Entity]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_Team_tbl_Entity'
CREATE INDEX [IX_FK_tbl_Team_tbl_Entity]
ON [dbo].[tbl_Team]
    ([TypeId]);
GO

-- Creating foreign key on [RoleId] in table 'tbl_UserMaster'
ALTER TABLE [dbo].[tbl_UserMaster]
ADD CONSTRAINT [FK_tbl_UserMaster_tbl_Entity_RoleId]
    FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[tbl_Entity]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_UserMaster_tbl_Entity_RoleId'
CREATE INDEX [IX_FK_tbl_UserMaster_tbl_Entity_RoleId]
ON [dbo].[tbl_UserMaster]
    ([RoleId]);
GO

-- Creating foreign key on [DesignationId] in table 'tbl_UserMaster'
ALTER TABLE [dbo].[tbl_UserMaster]
ADD CONSTRAINT [FK_tbl_UserMaster_tbl_UserMaster_DesignationId]
    FOREIGN KEY ([DesignationId])
    REFERENCES [dbo].[tbl_Entity]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_UserMaster_tbl_UserMaster_DesignationId'
CREATE INDEX [IX_FK_tbl_UserMaster_tbl_UserMaster_DesignationId]
ON [dbo].[tbl_UserMaster]
    ([DesignationId]);
GO

-- Creating foreign key on [ProjectId] in table 'tbl_Incident'
ALTER TABLE [dbo].[tbl_Incident]
ADD CONSTRAINT [FK_tbl_Incident_tbl_Project]
    FOREIGN KEY ([ProjectId])
    REFERENCES [dbo].[tbl_Project]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_Incident_tbl_Project'
CREATE INDEX [IX_FK_tbl_Incident_tbl_Project]
ON [dbo].[tbl_Incident]
    ([ProjectId]);
GO

-- Creating foreign key on [RequestedBy] in table 'tbl_Incident'
ALTER TABLE [dbo].[tbl_Incident]
ADD CONSTRAINT [FK_tbl_Incident_tbl_UserMaster_RequestedBy]
    FOREIGN KEY ([RequestedBy])
    REFERENCES [dbo].[tbl_UserMaster]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_Incident_tbl_UserMaster_RequestedBy'
CREATE INDEX [IX_FK_tbl_Incident_tbl_UserMaster_RequestedBy]
ON [dbo].[tbl_Incident]
    ([RequestedBy]);
GO

-- Creating foreign key on [IncidentId] in table 'tbl_IncidentAction'
ALTER TABLE [dbo].[tbl_IncidentAction]
ADD CONSTRAINT [FK_tbl_IncidentAction_tbl_Incident]
    FOREIGN KEY ([IncidentId])
    REFERENCES [dbo].[tbl_Incident]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_IncidentAction_tbl_Incident'
CREATE INDEX [IX_FK_tbl_IncidentAction_tbl_Incident]
ON [dbo].[tbl_IncidentAction]
    ([IncidentId]);
GO

-- Creating foreign key on [IncidentId] in table 'tbl_IncidentDocument'
ALTER TABLE [dbo].[tbl_IncidentDocument]
ADD CONSTRAINT [FK_tbl_IncidentDocument_tbl_Incident]
    FOREIGN KEY ([IncidentId])
    REFERENCES [dbo].[tbl_Incident]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_IncidentDocument_tbl_Incident'
CREATE INDEX [IX_FK_tbl_IncidentDocument_tbl_Incident]
ON [dbo].[tbl_IncidentDocument]
    ([IncidentId]);
GO

-- Creating foreign key on [ProjectId] in table 'tbl_IssueTracker'
ALTER TABLE [dbo].[tbl_IssueTracker]
ADD CONSTRAINT [FK_tbl_IssueTracker_tbl_Project]
    FOREIGN KEY ([ProjectId])
    REFERENCES [dbo].[tbl_Project]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_IssueTracker_tbl_Project'
CREATE INDEX [IX_FK_tbl_IssueTracker_tbl_Project]
ON [dbo].[tbl_IssueTracker]
    ([ProjectId]);
GO

-- Creating foreign key on [IssueTrackerId] in table 'tbl_IssueTrackerAction'
ALTER TABLE [dbo].[tbl_IssueTrackerAction]
ADD CONSTRAINT [FK_tbl_IssueTrackerAction_tbl_IssueTracker]
    FOREIGN KEY ([IssueTrackerId])
    REFERENCES [dbo].[tbl_IssueTracker]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_IssueTrackerAction_tbl_IssueTracker'
CREATE INDEX [IX_FK_tbl_IssueTrackerAction_tbl_IssueTracker]
ON [dbo].[tbl_IssueTrackerAction]
    ([IssueTrackerId]);
GO

-- Creating foreign key on [IssueTrackerId] in table 'tbl_IssueTrackerDocument'
ALTER TABLE [dbo].[tbl_IssueTrackerDocument]
ADD CONSTRAINT [FK_tbl_IssueTrackerDocument_tbl_IssueTracker]
    FOREIGN KEY ([IssueTrackerId])
    REFERENCES [dbo].[tbl_IssueTracker]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_IssueTrackerDocument_tbl_IssueTracker'
CREATE INDEX [IX_FK_tbl_IssueTrackerDocument_tbl_IssueTracker]
ON [dbo].[tbl_IssueTrackerDocument]
    ([IssueTrackerId]);
GO

-- Creating foreign key on [Approver] in table 'tbl_Project'
ALTER TABLE [dbo].[tbl_Project]
ADD CONSTRAINT [FK_tbl_Project_tbl_UserMaster_Approver]
    FOREIGN KEY ([Approver])
    REFERENCES [dbo].[tbl_UserMaster]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_Project_tbl_UserMaster_Approver'
CREATE INDEX [IX_FK_tbl_Project_tbl_UserMaster_Approver]
ON [dbo].[tbl_Project]
    ([Approver]);
GO

-- Creating foreign key on [Manager] in table 'tbl_Project'
ALTER TABLE [dbo].[tbl_Project]
ADD CONSTRAINT [FK_tbl_Project_tbl_UserMaster_Manager]
    FOREIGN KEY ([Manager])
    REFERENCES [dbo].[tbl_UserMaster]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_Project_tbl_UserMaster_Manager'
CREATE INDEX [IX_FK_tbl_Project_tbl_UserMaster_Manager]
ON [dbo].[tbl_Project]
    ([Manager]);
GO

-- Creating foreign key on [QA] in table 'tbl_Project'
ALTER TABLE [dbo].[tbl_Project]
ADD CONSTRAINT [FK_tbl_Project_tbl_UserMaster_QA]
    FOREIGN KEY ([QA])
    REFERENCES [dbo].[tbl_UserMaster]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_Project_tbl_UserMaster_QA'
CREATE INDEX [IX_FK_tbl_Project_tbl_UserMaster_QA]
ON [dbo].[tbl_Project]
    ([QA]);
GO

-- Creating foreign key on [ProjectId] in table 'tbl_ProjectDocument'
ALTER TABLE [dbo].[tbl_ProjectDocument]
ADD CONSTRAINT [FK_tbl_ProjectDocument_tbl_Project]
    FOREIGN KEY ([ProjectId])
    REFERENCES [dbo].[tbl_Project]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_ProjectDocument_tbl_Project'
CREATE INDEX [IX_FK_tbl_ProjectDocument_tbl_Project]
ON [dbo].[tbl_ProjectDocument]
    ([ProjectId]);
GO

-- Creating foreign key on [ProjectId] in table 'tbl_ProjectTask'
ALTER TABLE [dbo].[tbl_ProjectTask]
ADD CONSTRAINT [FK_tbl_ProjectTask_tbl_Project_ProjectId]
    FOREIGN KEY ([ProjectId])
    REFERENCES [dbo].[tbl_Project]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_ProjectTask_tbl_Project_ProjectId'
CREATE INDEX [IX_FK_tbl_ProjectTask_tbl_Project_ProjectId]
ON [dbo].[tbl_ProjectTask]
    ([ProjectId]);
GO

-- Creating foreign key on [ProjectId] in table 'tbl_ProjectTaskType'
ALTER TABLE [dbo].[tbl_ProjectTaskType]
ADD CONSTRAINT [FK_tbl_ProjectTaskType_tbl_Project]
    FOREIGN KEY ([ProjectId])
    REFERENCES [dbo].[tbl_Project]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_ProjectTaskType_tbl_Project'
CREATE INDEX [IX_FK_tbl_ProjectTaskType_tbl_Project]
ON [dbo].[tbl_ProjectTaskType]
    ([ProjectId]);
GO

-- Creating foreign key on [ProjectId] in table 'tbl_ServiceRequest'
ALTER TABLE [dbo].[tbl_ServiceRequest]
ADD CONSTRAINT [FK_tbl_ServiceRequest_tbl_Project]
    FOREIGN KEY ([ProjectId])
    REFERENCES [dbo].[tbl_Project]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_ServiceRequest_tbl_Project'
CREATE INDEX [IX_FK_tbl_ServiceRequest_tbl_Project]
ON [dbo].[tbl_ServiceRequest]
    ([ProjectId]);
GO

-- Creating foreign key on [ProjectId] in table 'tbl_ServiceRequest'
ALTER TABLE [dbo].[tbl_ServiceRequest]
ADD CONSTRAINT [FK_tbl_ServiceRequest_tbl_Project_ProjectId]
    FOREIGN KEY ([ProjectId])
    REFERENCES [dbo].[tbl_Project]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_ServiceRequest_tbl_Project_ProjectId'
CREATE INDEX [IX_FK_tbl_ServiceRequest_tbl_Project_ProjectId]
ON [dbo].[tbl_ServiceRequest]
    ([ProjectId]);
GO

-- Creating foreign key on [QA] in table 'tbl_ProjectTask'
ALTER TABLE [dbo].[tbl_ProjectTask]
ADD CONSTRAINT [FK_tbl_ProjectTask_tbl_UserMaster_QA]
    FOREIGN KEY ([QA])
    REFERENCES [dbo].[tbl_UserMaster]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_ProjectTask_tbl_UserMaster_QA'
CREATE INDEX [IX_FK_tbl_ProjectTask_tbl_UserMaster_QA]
ON [dbo].[tbl_ProjectTask]
    ([QA]);
GO

-- Creating foreign key on [ProjectTaskId] in table 'tbl_ProjectTaskAction'
ALTER TABLE [dbo].[tbl_ProjectTaskAction]
ADD CONSTRAINT [FK_tbl_ProjectTaskAction_tbl_ProjectTask]
    FOREIGN KEY ([ProjectTaskId])
    REFERENCES [dbo].[tbl_ProjectTask]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_ProjectTaskAction_tbl_ProjectTask'
CREATE INDEX [IX_FK_tbl_ProjectTaskAction_tbl_ProjectTask]
ON [dbo].[tbl_ProjectTaskAction]
    ([ProjectTaskId]);
GO

-- Creating foreign key on [ProjectTaskId] in table 'tbl_ProjectTaskDocument'
ALTER TABLE [dbo].[tbl_ProjectTaskDocument]
ADD CONSTRAINT [FK_tbl_ProjectTaskDocument_tbl_ProjectTask]
    FOREIGN KEY ([ProjectTaskId])
    REFERENCES [dbo].[tbl_ProjectTask]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_ProjectTaskDocument_tbl_ProjectTask'
CREATE INDEX [IX_FK_tbl_ProjectTaskDocument_tbl_ProjectTask]
ON [dbo].[tbl_ProjectTaskDocument]
    ([ProjectTaskId]);
GO

-- Creating foreign key on [RequestedBy] in table 'tbl_ServiceRequest'
ALTER TABLE [dbo].[tbl_ServiceRequest]
ADD CONSTRAINT [FK_tbl_ServiceRequest_tbl_UserMaster_RequestedBy]
    FOREIGN KEY ([RequestedBy])
    REFERENCES [dbo].[tbl_UserMaster]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_ServiceRequest_tbl_UserMaster_RequestedBy'
CREATE INDEX [IX_FK_tbl_ServiceRequest_tbl_UserMaster_RequestedBy]
ON [dbo].[tbl_ServiceRequest]
    ([RequestedBy]);
GO

-- Creating foreign key on [ServiceRequestId] in table 'tbl_ServiceRequestAction'
ALTER TABLE [dbo].[tbl_ServiceRequestAction]
ADD CONSTRAINT [FK_tbl_ServiceRequestAction_tbl_ServiceRequest]
    FOREIGN KEY ([ServiceRequestId])
    REFERENCES [dbo].[tbl_ServiceRequest]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_ServiceRequestAction_tbl_ServiceRequest'
CREATE INDEX [IX_FK_tbl_ServiceRequestAction_tbl_ServiceRequest]
ON [dbo].[tbl_ServiceRequestAction]
    ([ServiceRequestId]);
GO

-- Creating foreign key on [ServiceRequestId] in table 'tbl_ServiceRequestDocument'
ALTER TABLE [dbo].[tbl_ServiceRequestDocument]
ADD CONSTRAINT [FK_tbl_ServiceRequestDocument_tbl_ServiceRequest]
    FOREIGN KEY ([ServiceRequestId])
    REFERENCES [dbo].[tbl_ServiceRequest]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_ServiceRequestDocument_tbl_ServiceRequest'
CREATE INDEX [IX_FK_tbl_ServiceRequestDocument_tbl_ServiceRequest]
ON [dbo].[tbl_ServiceRequestDocument]
    ([ServiceRequestId]);
GO

-- Creating foreign key on [RelatedTypeId] in table 'tbl_Team'
ALTER TABLE [dbo].[tbl_Team]
ADD CONSTRAINT [FK_tbl_Team_tbl_TypeMaster]
    FOREIGN KEY ([RelatedTypeId])
    REFERENCES [dbo].[tbl_TypeMaster]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_Team_tbl_TypeMaster'
CREATE INDEX [IX_FK_tbl_Team_tbl_TypeMaster]
ON [dbo].[tbl_Team]
    ([RelatedTypeId]);
GO

-- Creating foreign key on [TeamId] in table 'tbl_TeamMember'
ALTER TABLE [dbo].[tbl_TeamMember]
ADD CONSTRAINT [FK_tbl_TeamMember_tbl_Team]
    FOREIGN KEY ([TeamId])
    REFERENCES [dbo].[tbl_Team]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_TeamMember_tbl_Team'
CREATE INDEX [IX_FK_tbl_TeamMember_tbl_Team]
ON [dbo].[tbl_TeamMember]
    ([TeamId]);
GO

-- Creating foreign key on [UserId] in table 'tbl_TeamMember'
ALTER TABLE [dbo].[tbl_TeamMember]
ADD CONSTRAINT [FK_tbl_TeamMember_tbl_UserMaster]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[tbl_UserMaster]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_TeamMember_tbl_UserMaster'
CREATE INDEX [IX_FK_tbl_TeamMember_tbl_UserMaster]
ON [dbo].[tbl_TeamMember]
    ([UserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------