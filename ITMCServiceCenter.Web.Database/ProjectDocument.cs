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
    
    public partial class ProjectDocument
    {
        public int ID { get; set; }
        public short ProjectID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
    
        public virtual Project Project { get; set; }
        public virtual UserMaster UserMaster { get; set; }
    }
}
