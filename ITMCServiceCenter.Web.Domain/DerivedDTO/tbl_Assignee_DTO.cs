using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITMCServiceCenter.Web.Domain
{
    public class tbl_Assignee_DTO : tbl_AssigneeDTO
    {
        public string UserFullName { get; set; }
        public override string ToString()
        {
            return UserFullName;
        }
    }
}
