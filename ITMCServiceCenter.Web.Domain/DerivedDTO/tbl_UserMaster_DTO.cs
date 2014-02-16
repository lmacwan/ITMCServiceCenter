using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITMCServiceCenter.Web.Domain
{
    public class tbl_UserMaster_DTO : tbl_UserMasterDTO
    {
        [DataMember()]
        public string Role { get; set; }

        [DataMember()]
        public string Designation { get; set; }

        [DataMember()]
        public string UserFullName { get { return string.Concat(FirstName, " ", LastName); } private set { value = string.Concat(FirstName, " ", LastName); } }
    }
}
