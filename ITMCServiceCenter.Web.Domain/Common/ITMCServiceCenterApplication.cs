using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITMCServiceCenter.Web.Domain
{
    public class ITMCServiceCenterApplication
    {
        public static tbl_UserMaster_DTO CurrentContextUser
        {
            get
            {
                if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null || System.Web.HttpContext.Current.Session["CurrentContextUser"] == null)
                    return null;

                return System.Web.HttpContext.Current.Session["CurrentContextUser"] as tbl_UserMaster_DTO;

            }
            set
            {
                System.Web.HttpContext.Current.Session["CurrentContextUser"] = value;
            }
        }
    }
}
