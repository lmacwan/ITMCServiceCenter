﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ITMCServiceCenter.Web.Database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ITMCServiceCenter_SQLServer : DbContext
    {
        public ITMCServiceCenter_SQLServer()
            : base("name=ITMCServiceCenter_SQLServer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<tbl_Assignee> tbl_Assignee { get; set; }
        public DbSet<tbl_ChangeRequest> tbl_ChangeRequest { get; set; }
        public DbSet<tbl_ChangeRequestAction> tbl_ChangeRequestAction { get; set; }
        public DbSet<tbl_ChangeRequestDocument> tbl_ChangeRequestDocument { get; set; }
        public DbSet<tbl_Client> tbl_Client { get; set; }
        public DbSet<tbl_Engineer> tbl_Engineer { get; set; }
        public DbSet<tbl_Entity> tbl_Entity { get; set; }
        public DbSet<tbl_Incident> tbl_Incident { get; set; }
        public DbSet<tbl_IncidentAction> tbl_IncidentAction { get; set; }
        public DbSet<tbl_IncidentDocument> tbl_IncidentDocument { get; set; }
        public DbSet<tbl_IssueTracker> tbl_IssueTracker { get; set; }
        public DbSet<tbl_IssueTrackerAction> tbl_IssueTrackerAction { get; set; }
        public DbSet<tbl_IssueTrackerDocument> tbl_IssueTrackerDocument { get; set; }
        public DbSet<tbl_Project> tbl_Project { get; set; }
        public DbSet<tbl_ProjectDocument> tbl_ProjectDocument { get; set; }
        public DbSet<tbl_ProjectTask> tbl_ProjectTask { get; set; }
        public DbSet<tbl_ProjectTaskAction> tbl_ProjectTaskAction { get; set; }
        public DbSet<tbl_ProjectTaskDocument> tbl_ProjectTaskDocument { get; set; }
        public DbSet<tbl_ProjectTaskType> tbl_ProjectTaskType { get; set; }
        public DbSet<tbl_RelatedIssue> tbl_RelatedIssue { get; set; }
        public DbSet<tbl_ServiceRequest> tbl_ServiceRequest { get; set; }
        public DbSet<tbl_ServiceRequestAction> tbl_ServiceRequestAction { get; set; }
        public DbSet<tbl_ServiceRequestDocument> tbl_ServiceRequestDocument { get; set; }
        public DbSet<tbl_Team> tbl_Team { get; set; }
        public DbSet<tbl_TeamMember> tbl_TeamMember { get; set; }
        public DbSet<tbl_TypeMaster> tbl_TypeMaster { get; set; }
        public DbSet<tbl_UserMaster> tbl_UserMaster { get; set; }
    }
}
