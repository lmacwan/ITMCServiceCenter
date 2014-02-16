//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class tbl_UserMaster
    {
        public tbl_UserMaster()
        {
            this.tbl_Assignee = new HashSet<tbl_Assignee>();
            this.tbl_ChangeRequest = new HashSet<tbl_ChangeRequest>();
            this.tbl_ChangeRequest1 = new HashSet<tbl_ChangeRequest>();
            this.tbl_ChangeRequest2 = new HashSet<tbl_ChangeRequest>();
            this.tbl_Engineer = new HashSet<tbl_Engineer>();
            this.tbl_Incident = new HashSet<tbl_Incident>();
            this.tbl_Project = new HashSet<tbl_Project>();
            this.tbl_Project1 = new HashSet<tbl_Project>();
            this.tbl_Project2 = new HashSet<tbl_Project>();
            this.tbl_ProjectTask = new HashSet<tbl_ProjectTask>();
            this.tbl_ServiceRequest = new HashSet<tbl_ServiceRequest>();
            this.tbl_TeamMember = new HashSet<tbl_TeamMember>();
        }
    
        public int Id { get; set; }
        public short DesignationId { get; set; }
        public short RoleId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsClient { get; set; }
        public bool IsDisable { get; set; }
    
        public virtual ICollection<tbl_Assignee> tbl_Assignee { get; set; }
        public virtual ICollection<tbl_ChangeRequest> tbl_ChangeRequest { get; set; }
        public virtual ICollection<tbl_ChangeRequest> tbl_ChangeRequest1 { get; set; }
        public virtual ICollection<tbl_ChangeRequest> tbl_ChangeRequest2 { get; set; }
        public virtual ICollection<tbl_Engineer> tbl_Engineer { get; set; }
        public virtual tbl_Entity tbl_Entity { get; set; }
        public virtual tbl_Entity tbl_Entity1 { get; set; }
        public virtual ICollection<tbl_Incident> tbl_Incident { get; set; }
        public virtual ICollection<tbl_Project> tbl_Project { get; set; }
        public virtual ICollection<tbl_Project> tbl_Project1 { get; set; }
        public virtual ICollection<tbl_Project> tbl_Project2 { get; set; }
        public virtual ICollection<tbl_ProjectTask> tbl_ProjectTask { get; set; }
        public virtual ICollection<tbl_ServiceRequest> tbl_ServiceRequest { get; set; }
        public virtual ICollection<tbl_TeamMember> tbl_TeamMember { get; set; }
    }
}