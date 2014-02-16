using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITMCServiceCenter.Web.Domain
{
    public class tbl_IssueTracker_DTO : tbl_IssueTrackerDTO
    {
        #region Additional Properties
        [DataMember()]
        public string Status { get; set; }

        [DataMember()]
        public string Priority { get; set; }

        [DataMember()]
        public string Category { get; set; }

        [DataMember()]
        public string ProjectTitle { get; set; }

        [DataMember()]
        public string AssignedToName { get; set; }
        #endregion
    }
}
