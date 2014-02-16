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
    
    public partial class IssueTracker
    {
        public IssueTracker()
        {
            this.IssueTrackerActions = new HashSet<IssueTrackerAction>();
            this.IssueTrackerDocuments = new HashSet<IssueTrackerDocument>();
            this.UserMasters = new HashSet<UserMaster>();
            this.IssueTracker1 = new HashSet<IssueTracker>();
            this.IssueTrackers = new HashSet<IssueTracker>();
        }
    
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Nullable<int> AssignedTo { get; set; }
        public Nullable<short> ProjectID { get; set; }
        public byte PriorityID { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<byte> StatusID { get; set; }
        public Nullable<byte> CategoryID { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual Project Project { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<IssueTrackerAction> IssueTrackerActions { get; set; }
        public virtual ICollection<IssueTrackerDocument> IssueTrackerDocuments { get; set; }
        public virtual ICollection<UserMaster> UserMasters { get; set; }
        public virtual ICollection<IssueTracker> IssueTracker1 { get; set; }
        public virtual ICollection<IssueTracker> IssueTrackers { get; set; }
    }
}
