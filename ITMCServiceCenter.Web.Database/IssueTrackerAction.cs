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
    
    public partial class IssueTrackerAction
    {
        public int ID { get; set; }
        public int IssueTrackerID { get; set; }
        public int CreatedBy { get; set; }
        public string Action { get; set; }
        public System.DateTime CreatedOn { get; set; }
    
        public virtual IssueTracker IssueTracker { get; set; }
        public virtual UserMaster UserMaster { get; set; }
    }
}
