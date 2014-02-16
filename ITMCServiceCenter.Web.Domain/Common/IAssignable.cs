using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITMCServiceCenter.Web.Domain
{
    public interface IAssignable
    {
        List<tbl_Assignee_DTO> Assignees { get; set; }
    }
}
