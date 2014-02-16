using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITMCServiceCenter.Web.Domain
{
    public class tbl_ProjectTaskDocument_DTO : tbl_ProjectTaskDocumentDTO
    {
        #region Additional Properties

        [DataMember()]
        public string CreatedByName { get; set; }
        #endregion
    }
}
