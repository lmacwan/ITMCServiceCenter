using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITMCServiceCenter.Web.Domain
{
    public class tbl_IssueTrackerAction_DTO : tbl_IssueTrackerActionDTO, IAction
    {
        public Types RelatedType
        {
            get { return Types.Issue; }
        }

        public int RelatedToId
        {
            get { return IssueTrackerId; }
        }
    }
}
