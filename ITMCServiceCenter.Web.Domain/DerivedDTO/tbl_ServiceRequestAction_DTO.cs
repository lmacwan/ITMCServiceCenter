using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITMCServiceCenter.Web.Domain
{
    public class tbl_ServiceRequestAction_DTO : tbl_ServiceRequestActionDTO , IAction
    {
        #region Additonal Properties
        [DataMember()]
        public string CreatedByName { get; set; }
        #endregion

        public int RelatedToId
        {
            get
            {
                return ServiceRequestId;
            }
        }


        public Types RelatedType
        {
            get
            {
                return Types.ServiceRequest;
            }
        }
    }
}
