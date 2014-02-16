using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITMCServiceCenter.Web.Domain
{
    public class tbl_Engineer_DTO : tbl_EngineerDTO
    {
        [DataMember()]
        public string UserFullName { get; set; }
        
        public override string ToString()
        {
            return UserFullName;
        }
    }
}
