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
    
    public partial class Status
    {
        public Status()
        {
            this.Incidents = new HashSet<Incident>();
            this.IssueTrackers = new HashSet<IssueTracker>();
            this.ProjectTasks = new HashSet<ProjectTask>();
            this.ServiceRequests = new HashSet<ServiceRequest>();
        }
    
        public byte ID { get; set; }
        public string Status1 { get; set; }
    
        public virtual ICollection<Incident> Incidents { get; set; }
        public virtual ICollection<IssueTracker> IssueTrackers { get; set; }
        public virtual ICollection<ProjectTask> ProjectTasks { get; set; }
        public virtual ICollection<ServiceRequest> ServiceRequests { get; set; }
    }
}
