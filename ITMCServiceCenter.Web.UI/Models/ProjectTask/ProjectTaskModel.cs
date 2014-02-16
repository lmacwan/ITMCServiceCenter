using ITMCServiceCenter.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITMCServiceCenter.Web.UI
{
    public class ProjectTaskModel
    {
        #region Data Members
        private MarkupList<tbl_Engineer_DTO> engineers;
        private short project;
        private short type;
        private ActionsModel actionsModel;
        #endregion

        #region Static Members
        public static List<tbl_UserMaster_DTO> Users { get; set; }
        public static List<tbl_Project_DTO> Projects { get; set; }
        public static List<tbl_Entity_DTO> Statuses { get; set; }
        public static List<tbl_Entity_DTO> Priorities { get; set; }
        public static List<tbl_ProjectTaskType_DTO> ProjectTaskTypes { get; set; }
        #endregion

        #region Constructor
        public ProjectTaskModel()
        {
            ProjectTask = new tbl_ProjectTask_DTO();
            engineers = new MarkupList<tbl_Engineer_DTO>();
            TestingTeam = new TeamModel();
        }
        #endregion

        #region Properties
        public tbl_ProjectTask_DTO ProjectTask { get; set; }
        public short selectedProjectId { get { return project; } set { project = value; ProjectTask.ProjectId = project; } }
        public short selectedTypeId { get { return type; } set { type = value; ProjectTask.TypeId = type; } }
        public TeamModel TestingTeam { get; set; }
        public ActionsModel ActionsModel { get { return actionsModel; } set { actionsModel = value; actionsModel.RelatedType = Types.ProjectTask; actionsModel.RelateToId = ProjectTask.Id; } }
        #endregion
    }
}