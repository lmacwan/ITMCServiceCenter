using ITMCServiceCenter.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITMCServiceCenter.Web.UI
{
    public class IssueModel
    {
        #region Data Members
        private  MarkupList<tbl_Engineer_DTO> engineers;
        private ActionsModel actionsModel;
        #endregion

        #region Static Members
        public static List<tbl_UserMaster_DTO> Users { get; set; }

        public static List<tbl_Project_DTO> Projects { get; set; }

        public static List<tbl_Entity_DTO> Statuses { get; set; }

        public static List<tbl_Entity_DTO> Priorities { get; set; }

        public static List<tbl_Entity_DTO> Categories { get; set; }
        #endregion

        #region Constructor
        public IssueModel()
        {
            Issue = new tbl_IssueTracker_DTO();
            engineers = new MarkupList<tbl_Engineer_DTO>();
            TestingTeam = new TeamModel();
        }
        #endregion

        #region Properties
        public tbl_IssueTracker_DTO Issue { get; set; }
        public ActionsModel ActionsModel { get { return actionsModel; } set { actionsModel = value; actionsModel.RelatedType = Types.Issue; actionsModel.RelateToId = Issue.Id; } }
        public TeamModel TestingTeam { get; set; }
        #endregion
    }
}