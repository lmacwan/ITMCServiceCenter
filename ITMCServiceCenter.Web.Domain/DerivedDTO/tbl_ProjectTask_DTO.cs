using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITMCServiceCenter.Web.Domain
{
    public class tbl_ProjectTask_DTO : tbl_ProjectTaskDTO 
    {

        #region Additional Properties

        [DataMember()]
        public string ProjectTitle { get; set; }

        [DataMember()]
        public string Status { get; set; }

        [DataMember()]
        public string Priority { get; set; }

        [DataMember()]
        public string Type { get; set; }

        [DataMember()]
        public string QAName { get; set; }

        [DataMember()]
        public string CreatedByName { get; set; }

        [DataMember()]
        public string ModifiedByName { get; set; }

        #endregion

        #region Lists

        public List<tbl_Project_DTO> Projects { get; set; }

        public List<tbl_Entity_DTO> Statuses { get; set; }

        public List<tbl_Entity_DTO> Priorities { get; set; }

        public List<tbl_ProjectTaskType_DTO> Types { get; set; }

        public List<tbl_UserMaster_DTO> Users { get; set; }
        #endregion
    }
}
