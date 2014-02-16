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
    [DataContract]
    public class tbl_ChangeRequest_DTO : tbl_ChangeRequestDTO, IAssignable
    {
        #region Constructor
        public tbl_ChangeRequest_DTO() : base()
        {
            Assignees = new List<tbl_Assignee_DTO>();
        }
        #endregion

        #region Instance Properties
        [DataMember()]
        public string CreatedByName { get; set; }

        [DataMember()]
        public string ProjectTitle { get; set; }

        [DataMember()]
        public string Status { get; set; }

        [DataMember()]
        public string Priority { get; set; }

        [DataMember()]
        public string ChangeWriterName { get; set; }

        [DataMember()]
        public string RequestedByName { get; set; }

        [DataMember()]
        public string AssignedToName { get; set; }

        [DataMember()]
        public string ApproverName { get; set; }

        [DataMember()]
        public string ModifiedByName { get; set; }
        #endregion

        [DataMember()]
        public List<tbl_Assignee_DTO> Assignees
        {
            get;
            set;
        }

    }
}
