using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ITMCServiceCenter.Web.Domain.Resources;

namespace ITMCServiceCenter.Web.Domain
{
    public class tbl_Project_DTO : tbl_ProjectDTO
    {
        #region Properties
        [DataMember()]
        public string ModifiedByName { get; set; }

        [DataMember()]
        public string ClientName { get; set; }

        [DataMember()]
        public string ManagerName { get; set; }

        [DataMember()]
        public string ApproverName { get; set; }

        [DataMember()]
        public string QAName { get; set; }

        [DataMember()]
        public string Status { get; set; }

        [DataMember()]
        public string Type { get; set; }

        [DataMember()]
        public string CreatedByName { get; set; }
        #endregion
    }
}
