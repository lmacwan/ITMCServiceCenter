using ITMCServiceCenter.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITMCServiceCenter.Web.UI
{
    public class ChangeRequestModel
    {
        #region Data Members
        private tbl_ChangeRequest_DTO changeRequest;
        private ActionsModel actionsModel;
        #endregion

        #region Constructor
        public ChangeRequestModel()
        {
            changeRequest = new tbl_ChangeRequest_DTO();
            AssigneesId = new List<int>();
            TestingTeam = new TeamModel();
            ActionsModel = new ActionsModel();
        }
        #endregion

        #region Static Members
        public static List<tbl_UserMaster_DTO> Users { get; set; }
        public static List<tbl_Project_DTO> Projects { get; set; }
        public static List<tbl_Entity_DTO> Statuses { get; set; }
        public static List<tbl_Entity_DTO> Priorities { get; set; }
        #endregion

        #region Properties
        public tbl_ChangeRequest_DTO ChangeRequest
        {
            get { return changeRequest; }
            set
            {
                changeRequest = value;
                AssigneesId = (from assignee in changeRequest.Assignees
                             select assignee.UserId).ToList();
            }
        }
        public ActionsModel ActionsModel { get { return actionsModel; } set { actionsModel = value; actionsModel.RelatedType = Types.ChangeRequest; actionsModel.RelateToId = changeRequest.Id; } }
        public List<int> AssigneesId { get; set; }
        public string AssigneeMarkupString { get { return MarkupList<tbl_Assignee_DTO>.Convert(changeRequest.Assignees).ToString(); } }
        public TeamModel TestingTeam { get; set; }
        #endregion
    }
}