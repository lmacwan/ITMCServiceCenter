using ITMCServiceCenter.Web.Domain;
using ITMCServiceCenter.Web.Domain.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITMCServiceCenter.Web.UI
{
    public class ProjectModel : CommonModel
    {
        #region Static Members
        #region Lists
        public static List<tbl_Client_DTO> Clients { get; set; }

        public static List<tbl_Entity_DTO> Statuses { get; set; }

        public static List<tbl_Entity_DTO> Types { get; set; }

        public static List<tbl_UserMaster_DTO> Users { get; set; }
        #endregion
        #endregion

        #region Instance Properties
        public tbl_Project_DTO Project { get; set; }
        public TeamModel Team { get; set; }
        #endregion
    }
}