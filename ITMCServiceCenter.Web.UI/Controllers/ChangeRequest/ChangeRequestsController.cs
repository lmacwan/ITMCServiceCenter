using ITMCServiceCenter.Web.BLL;
using ITMCServiceCenter.Web.Domain;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Telerik.Web.Mvc;

namespace ITMCServiceCenter.Web.UI
{
    public class ChangeRequestsController : BaseController
    {
        #region HttpGet
        [HttpGet]
        public ActionResult ListAll()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetNewChangeRequestPartialAjax(int id)
        {
            var model = GetModel(ChangeRequestBusinessLogic.GetChangeRequest(id));
            return PartialView("_NewChangeRequestPartial", model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = GetModel(ChangeRequestBusinessLogic.GetChangeRequest(id));
            return View(model);
        }
        #endregion

        #region HttpPost
        [HttpPost]
        public bool SaveChangeRequest(ChangeRequestModel changeRequestModel)
        {
            int changeRequestId = new ChangeRequestBusinessLogic().SaveChangeRequest(changeRequestModel.ChangeRequest, changeRequestModel.AssigneesId);
            SaveAction(new tbl_ChangeRequestActionDTO()
            {
                Action = changeRequestModel.ActionsModel.NewAction.Action,
                ChangeRequestId = changeRequestId,
                CreatedBy = ITMCServiceCenterApplication.CurrentContextUser.UserFullName,
                CreatedOn = DateTime.Now
            });

            new TeamBusinessLogic().SaveTeamWithMembers(changeRequestModel.TestingTeam.SelectedMembersId, TeamType.Testing, Types.ChangeRequest, changeRequestId);
            return changeRequestId > 0;
        }

        [HttpPost]
        public bool UpdateChangeRequest(ChangeRequestModel changeRequestModel)
        {

            int changeRequestId = new ChangeRequestBusinessLogic().UpdateChangeRequest(changeRequestModel.ChangeRequest, changeRequestModel.AssigneesId);
            SaveAction(new tbl_ChangeRequestAction_DTO()
            {
                Action = changeRequestModel.ActionsModel.NewAction.Action,
                ChangeRequestId = changeRequestId,
                CreatedBy = ITMCServiceCenterApplication.CurrentContextUser.UserFullName,
                CreatedOn = DateTime.Now
            });
            new TeamBusinessLogic().SaveTeamWithMembers(changeRequestModel.TestingTeam.SelectedMembersId, TeamType.Testing, Types.ChangeRequest, changeRequestId, changeRequestModel.TestingTeam.Team.Id);
            return changeRequestId > 0;
        }
        #endregion

        #region Grid Actions
        [GridAction]
        public ActionResult GetAllChangeRequestsAjax()
        {
            var changeRequests = ChangeRequestBusinessLogic.GetChangeRequests();
            var models = GetModels(changeRequests);
            return View(new GridModel { Data = models });
        }
        #endregion

        #region Change Request Actions Methods
        [HttpPost]
        public HtmlString SaveAction(FormCollection formCollection)
        {
            var date = DateTime.Now;
            var htmlString = new HtmlString("");
            var actionId = SaveAction(new tbl_ChangeRequestActionDTO()
                                    {
                                        Action = formCollection["NewAction.Action"],
                                        ChangeRequestId = int.Parse(formCollection["RelateToId"]),
                                        CreatedBy = ITMCServiceCenterApplication.CurrentContextUser.UserFullName,
                                        CreatedOn = date
                                    });
            if (actionId > 0)
            {
                htmlString = new HtmlString(string.Concat("<li><div class='h5'>", formCollection["NewAction.Action"], "</div><div class='h6'> Created By : ", ITMCServiceCenterApplication.CurrentContextUser.UserFullName, " On : ", date.ToString(), "</div></li>"));
            }
            return htmlString;
        }
        #endregion

        #region Private Methods
        private void InitializeChangeRequestModel()
        {
            ChangeRequestModel.Users = ChangeRequestModel.Users ?? UserBusinessLogic.GetUsers();
            ChangeRequestModel.Projects = ChangeRequestModel.Projects ?? ProjectBusinessLogic.GetProjects();
            ChangeRequestModel.Priorities = ChangeRequestModel.Priorities ?? new EntityUtility().GetEntitiesByType(Types.ChangeRequestPriority);
            ChangeRequestModel.Statuses = ChangeRequestModel.Statuses ?? new EntityUtility().GetEntitiesByType(Types.ChangeRequestStatus);
        }

        private List<ChangeRequestModel> GetModels(List<tbl_ChangeRequest_DTO> changeRequests)
        {
            //  Initialize Static members
            InitializeChangeRequestModel();

            ChangeRequestModel changeRequestModel;
            TeamBusinessLogic teamBusinessLogic = new TeamBusinessLogic();
            List<ChangeRequestModel> models = new List<ChangeRequestModel>();
            List<IAction> actions;
            foreach (tbl_ChangeRequest_DTO changeRequest in changeRequests)
            {
                changeRequestModel = new ChangeRequestModel();
                changeRequestModel.ChangeRequest = changeRequest;

                //  Fill Testing Team
                changeRequestModel.TestingTeam.Team = TeamBusinessLogic.GetTeam(Types.ChangeRequest, changeRequestModel.ChangeRequest.Id, TeamType.Testing);
                changeRequestModel.TestingTeam.SelectedMembers = MarkupList<tbl_TeamMember_DTO>.Convert(TeamBusinessLogic.GetTeamMembersByTeam(changeRequestModel.TestingTeam.Team));

                //  Fill Actions
                actions = ChangeRequestActionBusinessLogic.GetChangeRequestActionsByRequestId(changeRequest.Id);
                changeRequestModel.ActionsModel = actions.Count > 0 ? ActionsModel.Convert(actions, false) : new ActionsModel();
                models.Add(changeRequestModel);
            }
            return models;
        }

        private ChangeRequestModel GetModel(tbl_ChangeRequest_DTO changeRequest)
        {
            //  Initialize Static members
            InitializeChangeRequestModel();

            ChangeRequestModel changeRequestModel = new ChangeRequestModel();
            TeamBusinessLogic teamBusinessLogic = new TeamBusinessLogic();
            changeRequestModel.ChangeRequest = changeRequest;

            //  Fill Testing Team
            changeRequestModel.TestingTeam.Team = TeamBusinessLogic.GetTeam(Types.ChangeRequest, changeRequestModel.ChangeRequest.Id, TeamType.Testing);
            changeRequestModel.TestingTeam.SelectedMembers = MarkupList<tbl_TeamMember_DTO>.Convert(TeamBusinessLogic.GetTeamMembersByTeam(changeRequestModel.TestingTeam.Team));

            //  Fill Actions
            var actions = ChangeRequestActionBusinessLogic.GetChangeRequestActionsByRequestId(changeRequest.Id);
            changeRequestModel.ActionsModel = actions.Count > 0 ? ActionsModel.Convert(actions) : new ActionsModel();
            return changeRequestModel;
        }

        private int SaveAction(tbl_ChangeRequestActionDTO actionDto)
        {
            return new ChangeRequestActionBusinessLogic().SaveChangeRequestAction(actionDto);
        }
        #endregion
    }
}
