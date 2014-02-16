using ITMCServiceCenter.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITMCServiceCenter.Web.UI
{
    public class IncidentModel
    {
        #region Data Members
        private  MarkupList<tbl_Engineer_DTO> engineers;
        private ActionsModel actionsModel;
        #endregion

        #region Static Members
        public static List<tbl_UserMaster_DTO> Users { get; set; }

        public static List<tbl_Project_DTO> Projects { get; set; }

        public static List<tbl_Entity_DTO> Statuses { get; set; }

        public static List<tbl_Entity_DTO> Levels { get; set; }
        #endregion

        #region Constructor
        public IncidentModel()
        {
            Incident = new tbl_Incident_DTO();
            engineers = new MarkupList<tbl_Engineer_DTO>();
            SelectedEngineersId = new List<int>();
            TestingTeam = new TeamModel();
        }
        #endregion

        #region Properties
        public tbl_Incident_DTO Incident { get; set; }
        public MarkupList<tbl_Engineer_DTO> SelectedEngineers
        {
            get { return engineers; }
            set
            {
                engineers = value;
                SelectedEngineersId = (from engineer in engineers
                                       select engineer.UserId).ToList();
            }
        }
        public List<int> SelectedEngineersId { get; set; }
        public ActionsModel ActionsModel { get { return actionsModel; } set { actionsModel = value; actionsModel.RelatedType = Types.Incident; actionsModel.RelateToId = Incident.Id; } }
        public TeamModel TestingTeam { get; set; }
        public string EngineersString { get { return SelectedEngineers.ToString(); } }
        #endregion
    }
}