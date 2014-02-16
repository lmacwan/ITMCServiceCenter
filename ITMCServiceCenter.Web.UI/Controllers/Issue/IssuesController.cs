using ITMCServiceCenter.Web.BLL;
using ITMCServiceCenter.Web.Domain;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Telerik.Web.Mvc;


namespace ITMCServiceCenter.Web.UI
{
    public class IssuesController : BaseController
    {
        #region HttpGet
        [HttpGet]
        public ActionResult ListAll()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetNewIssuePartialAjax(int id)
        {
            var issueModel = IssueBussinessLogic.GetIssue(id);
            return PartialView("_NewIssuePartial", GetModel(issueModel));
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = GetModel(IssueBussinessLogic.GetIssue(id));
            return View(model);
        }
        #endregion

        #region HttpPost


        [HttpPost]
        public bool SaveIssue(IssueModel issueModel)
        {
            int isuseId = new IssueBussinessLogic().SaveIssue(issueModel.Issue);
            SaveAction(new tbl_IssueTrackerActionDTO()
            {
                Action = issueModel.ActionsModel.NewAction.Action,
                IssueTrackerId = isuseId,
                CreatedBy = ITMCServiceCenterApplication.CurrentContextUser.UserFullName,
                CreatedOn = DateTime.Now
            });

            new TeamBusinessLogic().SaveTeamWithMembers(issueModel.TestingTeam.SelectedMembersId, TeamType.Testing, Types.Issue, isuseId);
            return isuseId > 0;
        }

        [HttpPost]
        public bool UpdateIssue(IssueModel issueModel)
        {
            int isuseId = new IssueBussinessLogic().UpdateIssue(issueModel.Issue);
            SaveAction(new tbl_IssueTrackerActionDTO()
            {
                Action = issueModel.ActionsModel.NewAction.Action,
                IssueTrackerId = isuseId,
                CreatedBy = ITMCServiceCenterApplication.CurrentContextUser.UserFullName,
                CreatedOn = DateTime.Now
            });

            new TeamBusinessLogic().SaveTeamWithMembers(issueModel.TestingTeam.SelectedMembersId, TeamType.Testing, Types.Issue, isuseId);
            return isuseId > 0;
        }
        #endregion

        #region Grid Actions
        [GridAction]
        public ActionResult GetAllIssuesAjax()
        {
            var issues = IssueBussinessLogic.GetIssues();
            var models = GetModels(issues);
            return View(new GridModel { Data = models });
        }
        #endregion

        #region Issue Actions Methods
        [HttpPost]
        public HtmlString SaveAction(FormCollection formCollection)
        {
            var date = DateTime.Now;
            var htmlString = new HtmlString("");
            var actionId = SaveAction(new tbl_IssueTrackerActionDTO()
            {
                Action = formCollection["NewAction.Action"],
                IssueTrackerId = int.Parse(formCollection["RelateToId"]),
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
        private void InitializeIssueModel()
        {
            IssueModel.Priorities = new EntityUtility().GetEntitiesByType(Types.IssuePriority);
            IssueModel.Projects = ProjectBusinessLogic.GetProjects();
            IssueModel.Statuses = new EntityUtility().GetEntitiesByType(Types.IssueStatus);
            IssueModel.Users = UserBusinessLogic.GetUsers();
            IssueModel.Categories = new EntityUtility().GetEntitiesByType(Types.IssueCategory);
        }

        private List<IssueModel> GetModels(List<tbl_IssueTracker_DTO> issues)
        {
            //  Initialize Static members
            InitializeIssueModel();

            IssueModel issueModel;
            TeamBusinessLogic teamBusinessLogic = new TeamBusinessLogic();
            List<IssueModel> models = new List<IssueModel>();
            List<IAction> actions;
            foreach (tbl_IssueTracker_DTO issue in issues)
            {
                issueModel = new IssueModel();
                issueModel.Issue = issue;

                //  Fill Testing Team
                issueModel.TestingTeam.Team = TeamBusinessLogic.GetTeam(Types.Issue, issueModel.Issue.Id, TeamType.Testing);
                issueModel.TestingTeam.SelectedMembers = MarkupList<tbl_TeamMember_DTO>.Convert(TeamBusinessLogic.GetTeamMembersByTeam(issueModel.TestingTeam.Team));

                //  Fill Actions
                actions = IssueActionBusinessLogic.GetIssueActionsByIssueId(issue.Id);
                issueModel.ActionsModel = actions.Count > 0 ? ActionsModel.Convert(actions, false) : new ActionsModel();
                models.Add(issueModel);
            }
            return models;
        }

        private IssueModel GetModel(tbl_IssueTracker_DTO issue)
        {
            //  Initialize Static members
            InitializeIssueModel();

            IssueModel issueModel = new IssueModel();
            TeamBusinessLogic teamBusinessLogic = new TeamBusinessLogic();
            issueModel.Issue = issue;

            //  Fill Testing Team
            issueModel.TestingTeam.Team = TeamBusinessLogic.GetTeam(Types.Issue, issueModel.Issue.Id, TeamType.Testing);
            issueModel.TestingTeam.SelectedMembers = MarkupList<tbl_TeamMember_DTO>.Convert(TeamBusinessLogic.GetTeamMembersByTeam(issueModel.TestingTeam.Team));

            //  Fill Actions
            var actions = IssueActionBusinessLogic.GetIssueActionsByIssueId(issue.Id);
            issueModel.ActionsModel = actions.Count > 0 ? ActionsModel.Convert(actions, false) : new ActionsModel();
            return issueModel;
        }

        private int SaveAction(tbl_IssueTrackerActionDTO actionDto)
        {
            return new IssueActionBusinessLogic().SaveIssueAction(actionDto);
        }
        #endregion
    }
}
