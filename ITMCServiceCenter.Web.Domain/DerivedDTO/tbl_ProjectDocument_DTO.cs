using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITMCServiceCenter.Web.Domain
{
    public class tbl_ProjectDocument_DTO : tbl_ProjectDocumentDTO
    {
        #region Properties

        [DataMember()]
        public string ProjectTitle { get; set; }

        [DataMember()]
        public string CreatedByName { get; set; }

        #endregion

        #region Lists
        public List<tbl_Project_DTO> Projects { get; set; }

        public List<tbl_UserMaster_DTO> Users { get; set; }
        #endregion
    }
}
