using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITMCServiceCenter.Web.Domain
{
    public class tbl_IssueTrackerDocument_DTO : tbl_IssueTrackerDocumentDTO
    {
        #region Additonal Properties
        [DataMember()]
        public string CreatedByName { get; set; }
        #endregion
    }
}
