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
    
    public partial class ProjectTaskAction
    {
        public int ID { get; set; }
        public int ProjectTaskID { get; set; }
        public int CreatedBy { get; set; }
        public string Action { get; set; }
        public System.DateTime CreatedOn { get; set; }
    
        public virtual ProjectTask ProjectTask { get; set; }
        public virtual UserMaster UserMaster { get; set; }
    }
}
