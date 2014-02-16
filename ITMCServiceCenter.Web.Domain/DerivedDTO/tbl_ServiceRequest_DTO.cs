using ITMCServiceCenter.Web.Domain.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITMCServiceCenter.Web.Domain
{
    public class tbl_ServiceRequest_DTO : tbl_ServiceRequestDTO
    {
        #region Additional Properties

        [DataMember()]
        public string CreatedByName { get; set; }

        [DataMember()]
        public string Priority { get; set; }

        [DataMember()]
        public string Status { get; set; }

        [DataMember()]
        public string PreviousStatus { get; set; }
                
        [DataMember()]
        public string ProjectTitle { get; set; }

        [DataMember()]
        public string ModifiedByName { get; set; }
        
        [DataMember()]
        public string AssignedToName { get; set; }

        [DataMember()]
        public string RequestedByName { get; set; }

        [DataMember()]
        public string ChangeWriterName { get; set; }
        #endregion
    }
}
