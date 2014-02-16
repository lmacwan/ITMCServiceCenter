using ITMCServiceCenter.Web.BLL;
using ITMCServiceCenter.Web.Domain;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Telerik.Web.Mvc;

namespace ITMCServiceCenter.Web.UI
{
    public class IncidentsController : BaseController
    {
        #region HttpGet
        [HttpGet]
        public ActionResult ListAll()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = GetModel(IncidentBusinessLogic.GetIncident(id));
            return View(model);
        }

        [HttpGet]
        public ActionResult GetIncidentPartialAjax(int id)
        {
            var incidentModel = IncidentBusinessLogic.GetIncident(id);
            return PartialView("_NewIncidentPartial", GetModel(incidentModel));
        }
        #endregion

        #region HttpPost
        [HttpPost]
        public bool SaveIncident(IncidentModel incidentModel)
        {
            var incidentId = new IncidentBusinessLogic().SaveIncident(incidentModel.Incident);
            SaveAction(new tbl_IncidentAction_DTO()
            {
                Action = incidentModel.ActionsModel.NewAction.Action,
                IncidentId = incidentId,
                CreatedBy = ITMCServiceCenterApplication.CurrentContextUser.UserFullName,
                CreatedOn = DateTime.Now
            });
            new EngineersBusinessLogic().SaveEngineers(incidentModel.SelectedEngineersId, Types.Incident, incidentId);
            new TeamBusinessLogic().SaveTeamWithMembers(incidentModel.TestingTeam.SelectedMembersId, TeamType.Testing, Types.Incident, incidentId);
            return incidentId > 0;
        }

        [HttpPost]
        public bool UpdateIncident(IncidentModel incidentModel)
        {
            var incidentId = new IncidentBusinessLogic().UpdateIncident(incidentModel.Incident);
            SaveAction(new tbl_IncidentAction_DTO()
            {
                Action = incidentModel.ActionsModel.NewAction.Action,
                IncidentId = incidentId,
                CreatedBy = ITMCServiceCenterApplication.CurrentContextUser.UserFullName,
                CreatedOn = DateTime.Now
            });
            new EngineersBusinessLogic().SaveEngineers(incidentModel.SelectedEngineersId, Types.Incident, incidentId);
            new TeamBusinessLogic().SaveTeamWithMembers(incidentModel.TestingTeam.SelectedMembersId, TeamType.Testing, Types.Incident, incidentId);
            return incidentId > 0;
        }
        #endregion

        #region Grid Actions
        [GridAction]
        public ActionResult GetAllIncidentsAjax()
        {
            var incidents = IncidentBusinessLogic.GetIncidents();
            var models = GetModels(incidents);
            return View(new GridModel { Data = models });
        }
        #endregion

        #region Incident Actions Methods
        [HttpPost]
        public HtmlString SaveAction(FormCollection formCollection)
        {
            var date = DateTime.Now;
            int actionId = SaveAction(new tbl_IncidentAction_DTO()
                                    {
                                        Action = formCollection["NewAction.Action"],
                                        IncidentId = int.Parse(formCollection["RelateToId"]),
                                        CreatedBy = ITMCServiceCenterApplication.CurrentContextUser.UserFullName,
                                        CreatedOn = date
                                    });
            if (actionId > 0)
            {
                return new HtmlString(string.Concat("<li><div class='h5'>", formCollection["NewAction.Action"], "</div><div class='h6'> Created By : ", ITMCServiceCenterApplication.CurrentContextUser.UserFullName, " On : ", date.ToString(), "</div></li>"));
            }
            else
            {
                return new HtmlString("");
            }
        }
        #endregion

        #region Private Methods
        private void InitializeIncidentModel()
        {
            IncidentModel.Users = UserBusinessLogic.GetUsers();
            IncidentModel.Projects = ProjectBusinessLogic.GetProjects();
            IncidentModel.Levels = new EntityUtility().GetEntitiesByType(Types.IncidentLevel);
            IncidentModel.Statuses = new EntityUtility().GetEntitiesByType(Types.IncidentStatus);
        }

        private List<IncidentModel> GetModels(List<tbl_Incident_DTO> incidents)
        {
            //  Initialize Static members
            InitializeIncidentModel();

            IncidentModel incidentModel;
            TeamBusinessLogic teamBusinessLogic = new TeamBusinessLogic();
            List<IncidentModel> models = new List<IncidentModel>();
            List<IAction> actions;
            foreach (tbl_Incident_DTO incident in incidents)
            {
                incidentModel = new IncidentModel();
                incidentModel.Incident = incident;

                //  Fill Secondary Engineers
                incidentModel.SelectedEngineers = MarkupList<tbl_Engineer_DTO>.Convert(EngineersBusinessLogic.GetEngineers(Types.Incident, incidentModel.Incident.Id));

                //  Fill Testing Team
                incidentModel.TestingTeam.Team = TeamBusinessLogic.GetTeam(Types.Incident, incidentModel.Incident.Id, TeamType.Testing);
                incidentModel.TestingTeam.SelectedMembers = MarkupList<tbl_TeamMember_DTO>.Convert(TeamBusinessLogic.GetTeamMembersByTeam(incidentModel.TestingTeam.Team));

                //  Fill Actions
                actions = IncidentActionBusinessLogic.GetIncidentActionByIncidentId(incident.Id);
                incidentModel.ActionsModel = actions.Count > 0 ? ActionsModel.Convert(actions) : new ActionsModel();
                models.Add(incidentModel);
            }
            return models;
        }

        private IncidentModel GetModel(tbl_Incident_DTO incident)
        {
            //  Initialize Static members
            InitializeIncidentModel();

            IncidentModel incidentModel = new IncidentModel();
            TeamBusinessLogic teamBusinessLogic = new TeamBusinessLogic();
            incidentModel.Incident = incident;

            //  Fill Secondary Engineers
            incidentModel.SelectedEngineers = MarkupList<tbl_Engineer_DTO>.Convert(EngineersBusinessLogic.GetEngineers(Types.Incident, incidentModel.Incident.Id));

            //  Fill Testing Team
            incidentModel.TestingTeam.Team = TeamBusinessLogic.GetTeam(Types.Incident, incidentModel.Incident.Id, TeamType.Testing);
            incidentModel.TestingTeam.SelectedMembers = MarkupList<tbl_TeamMember_DTO>.Convert(TeamBusinessLogic.GetTeamMembersByTeam(incidentModel.TestingTeam.Team));

            //  Fill Actions
            var actions = IncidentActionBusinessLogic.GetIncidentActionByIncidentId(incident.Id);
            incidentModel.ActionsModel = actions.Count > 0 ? ActionsModel.Convert(actions) : new ActionsModel();
            return incidentModel;
        }

        private int SaveAction(tbl_IncidentAction_DTO actionDto)
        {
            return new IncidentActionBusinessLogic().SaveIncidentAction(actionDto);
        }
        #endregion
    }
}
