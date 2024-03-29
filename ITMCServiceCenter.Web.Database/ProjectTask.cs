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
    
    public partial class ProjectTask
    {
        public ProjectTask()
        {
            this.ProjectTaskActions = new HashSet<ProjectTaskAction>();
            this.ProjectTaskDocuments = new HashSet<ProjectTaskDocument>();
        }
    
        public int ID { get; set; }
        public short ProjectID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public short EstimateHours { get; set; }
        public short EstimateCost { get; set; }
        public Nullable<int> AssignedTo { get; set; }
        public Nullable<int> QA { get; set; }
        public Nullable<System.DateTime> QAStartDate { get; set; }
        public Nullable<System.DateTime> QAEndDate { get; set; }
        public Nullable<int> Approver { get; set; }
        public byte StatusID { get; set; }
        public byte PriorityID { get; set; }
        public byte PercentComplete { get; set; }
        public byte TypeID { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
    
        public virtual Priority Priority { get; set; }
        public virtual Project Project { get; set; }
        public virtual ProjectTaskType ProjectTaskType { get; set; }
        public virtual Status Status { get; set; }
        public virtual UserMaster UserMaster { get; set; }
        public virtual UserMaster UserMaster1 { get; set; }
        public virtual UserMaster UserMaster2 { get; set; }
        public virtual UserMaster UserMaster3 { get; set; }
        public virtual UserMaster UserMaster4 { get; set; }
        public virtual ICollection<ProjectTaskAction> ProjectTaskActions { get; set; }
        public virtual ICollection<ProjectTaskDocument> ProjectTaskDocuments { get; set; }
    }
}
