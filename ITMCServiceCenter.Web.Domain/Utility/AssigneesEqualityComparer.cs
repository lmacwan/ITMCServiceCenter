using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITMCServiceCenter.Web.Domain
{
    public class AssigneesEqualityComparer : EqualityComparer<tbl_Assignee_DTO>
    {
        public override bool Equals(tbl_Assignee_DTO x, tbl_Assignee_DTO y)
        {
            if (x == null)
            {
                return false;
            }
            if (y == null)
            {
                return false;
            }
            return (x.RelatedToId == y.RelatedToId && x.RelateTypeId == y.RelateTypeId && x.UserId == y.UserId);
        }

        public override int GetHashCode(tbl_Assignee_DTO obj)
        {
            return 17 * obj.UserId * obj.RelatedToId * obj.RelateTypeId;
        }
    }
}
