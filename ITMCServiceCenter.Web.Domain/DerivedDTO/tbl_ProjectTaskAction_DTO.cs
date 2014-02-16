using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITMCServiceCenter.Web.Domain
{
    public class tbl_ProjectTaskAction_DTO : tbl_ProjectTaskActionDTO, IAction
    {

        #region Additional Properties

        [DataMember()]
        public string CreatedByName { get; set; }

        public Types RelatedType
        {
            get { return Types.ProjectTask; }
        }

        public int RelatedToId
        {
            get { return ProjectTaskId; }
        }

        #endregion
    }
}
