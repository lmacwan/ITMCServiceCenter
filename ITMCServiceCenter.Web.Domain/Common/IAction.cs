using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITMCServiceCenter.Web.Domain
{
    public interface IAction
    {
        int Id { get; set; }
        string Action { get; set; }
        string CreatedBy { get; set; }
        DateTime CreatedOn { get; set; }
    }
}
