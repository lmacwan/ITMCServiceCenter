using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITMCServiceCenter.Web.Domain
{
    public class TeamMemberEqualityComparer : EqualityComparer<tbl_TeamMember_DTO>
    {
        public override bool Equals(tbl_TeamMember_DTO x, tbl_TeamMember_DTO y)
        {
            if (x == null)
            {
                return false;
            }
            if (y == null)
            {
                return false;
            }
            return (x.TeamId == y.TeamId && x.UserId == y.UserId);
        }

        public override int GetHashCode(tbl_TeamMember_DTO obj)
        {
            return 17 * obj.UserId * obj.TeamId;
        }
    }
}
