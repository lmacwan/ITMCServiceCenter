using ITMCServiceCenter.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITMCServiceCenter.Web.UI
{
    public class ServiceRequestModel
    {
        #region Data Members
        private MarkupList<tbl_Engineer_DTO> engineers;
        private ActionsModel actionsModel;
        #endregion

        #region Constructor
        public ServiceRequestModel()
        {
            ServiceRequest = new tbl_ServiceRequest_DTO();
            engineers = new MarkupList<tbl_Engineer_DTO>();
            SelectedEngineersId = new List<int>();
            TestingTeam = new TeamModel();
        }
        #endregion

        #region Static Members
        public static List<tbl_UserMaster_DTO> Users { get; set; }

        public static List<tbl_Project_DTO> Projects { get; set; }

        public static List<tbl_Entity_DTO> Statuses { get; set; }

        public static List<tbl_Entity_DTO> Priorities { get; set; }
        #endregion

        #region Properties
        public ActionsModel ActionsModel { get { return actionsModel; } set { actionsModel = value; actionsModel.RelatedType = Types.ServiceRequest; actionsModel.RelateToId = ServiceRequest.Id; } }

        public tbl_ServiceRequest_DTO ServiceRequest { get; set; }
       
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
       
        public List<string> EngineersString
        {
            get
            {
                return (from engineer in SelectedEngineers
                        select engineer.UserFullName).ToList();
            }
        }

        public TeamModel TestingTeam { get; set; }
        #endregion
    }
}
