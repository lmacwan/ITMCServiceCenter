using ITMCServiceCenter.Web.BLL;
using ITMCServiceCenter.Web.Domain;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Telerik.Web.Mvc;

namespace ITMCServiceCenter.Web.UI
{
    public class ProjectTasksController : BaseController
    {
        #region Project Task
        #region HttpGet
        [HttpGet]
        public ActionResult ListAll()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetNewProjectTaskPartialAjax(int Id)
        {
            var projectTask = ProjectTaskBusinessLogic.GetProjectTask(Id);
            return PartialView("_NewProjectTaskPartial", GetModel(projectTask));
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = GetModel(ProjectTaskBusinessLogic.GetProjectTask(id));
            return View(model);
        }
        #endregion

        #region HttpPost
        [HttpPost]
        public JsonResult _GetItems(short ProjectTask_ProjectId)
        {
            var Items = EntityUtility.GetProjectTaskTypesByProjectId(ProjectTask_ProjectId);
            return Json(new SelectList(Items, "Id", "Type"));
        }

        [HttpPost]
        public bool SaveProjectTaskType(FormCollection formCollection)
        {
            string id = formCollection["HiddenProjectId"];
            string newtype = formCollection["newType"];
            var result = new ProjectTaskBusinessLogic().SaveProjectTaskType(new tbl_ProjectTaskType_DTO
            {
                ProjectId = Int16.Parse(id),
                Type = newtype
            });
            return result > 0;
        }

        [HttpPost]
        public bool SaveProjectTask(ProjectTaskModel projectTaskModel)
        {
            int projectTaskId = new ProjectTaskBusinessLogic().SaveProjectTask(projectTaskModel.ProjectTask);
            SaveAction(new tbl_ProjectTaskActionDTO()
            {
                Action = projectTaskModel.ActionsModel.NewAction.Action,
                ProjectTaskId = projectTaskId,
                CreatedBy = ITMCServiceCenterApplication.CurrentContextUser.UserFullName,
                CreatedOn = DateTime.Now
            });

            new TeamBusinessLogic().SaveTeamWithMembers(projectTaskModel.TestingTeam.SelectedMembersId, TeamType.Testing, Types.ProjectTask, projectTaskId);
            return projectTaskId > 0;
        }

        [HttpPost]
        public bool UpdateProjectTask(ProjectTaskModel projectTaskModel)
        {
            int projectTaskId = new ProjectTaskBusinessLogic().UpdateProjectTask(projectTaskModel.ProjectTask);
            SaveAction(new tbl_ProjectTaskActionDTO()
            {
                Action = projectTaskModel.ActionsModel.NewAction.Action,
                ProjectTaskId = projectTaskId,
                CreatedBy = ITMCServiceCenterApplication.CurrentContextUser.UserFullName,
                CreatedOn = DateTime.Now
            });

            new TeamBusinessLogic().SaveTeamWithMembers(projectTaskModel.TestingTeam.SelectedMembersId, TeamType.Testing, Types.ProjectTask, projectTaskId);
            return projectTaskId > 0;
        }
        #endregion

        #region Grid Actions
        [GridAction]
        public ActionResult GetAllProjectTasksAjax()
        {
            //return View(new GridModel { Data = ProjectTaskBusinessLogic.GetProjectTasks() });
            var projectTasks = ProjectTaskBusinessLogic.GetProjectTasks();
            var models = GetModels(projectTasks);
            return View(new GridModel { Data = models });
        }
        #endregion

        #region Project Task Actions Methods
        [HttpPost]
        public HtmlString SaveAction(FormCollection formCollection)
        {
            var date = DateTime.Now;
            var htmlString = new HtmlString("");
            var actionId = SaveAction(new tbl_ProjectTaskActionDTO()
            {
                Action = formCollection["NewAction.Action"],
                ProjectTaskId = int.Parse(formCollection["RelateToId"]),
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
        private void InitializeProjectTaskModel()
        {
            ProjectTaskModel.Users = ProjectTaskModel.Users ?? UserBusinessLogic.GetUsers();
            ProjectTaskModel.Projects = ProjectTaskModel.Projects ?? ProjectBusinessLogic.GetProjects();
            ProjectTaskModel.Priorities = ProjectTaskModel.Priorities ?? new EntityUtility().GetEntitiesByType(Types.Priority);
            ProjectTaskModel.Statuses = ProjectTaskModel.Statuses ?? new EntityUtility().GetEntitiesByType(Types.ProjectStatus);
        }

        private List<ProjectTaskModel> GetModels(List<tbl_ProjectTask_DTO> projectTasks)
        {
            //  Initialize Static members
            InitializeProjectTaskModel();

            ProjectTaskModel projectTaskModel;
            TeamBusinessLogic teamBusinessLogic = new TeamBusinessLogic();
            List<ProjectTaskModel> models = new List<ProjectTaskModel>();
            List<IAction> actions;
            foreach (tbl_ProjectTask_DTO projectTask in projectTasks)
            {
                projectTaskModel = new ProjectTaskModel();
                projectTaskModel.ProjectTask = projectTask;

                //  Fill Project Task Type
                projectTaskModel.ProjectTask.Type = EntityUtility.GetProjectTaskTypeById(projectTaskModel.ProjectTask.TypeId).Type;
                
                //  Fill Testing Team
                projectTaskModel.TestingTeam.Team = TeamBusinessLogic.GetTeam(Types.ChangeRequest, projectTaskModel.ProjectTask.Id, TeamType.Testing);
                projectTaskModel.TestingTeam.SelectedMembers = MarkupList<tbl_TeamMember_DTO>.Convert(TeamBusinessLogic.GetTeamMembersByTeam(projectTaskModel.TestingTeam.Team));

                //  Fill Actions
                actions = ProjectTaskActionBusinessLogic.GetProjectTaskActionByProjectTaskId(projectTask.Id);
                projectTaskModel.ActionsModel = actions.Count > 0 ? ActionsModel.Convert(actions, false) : new ActionsModel();
                models.Add(projectTaskModel);
            }
            return models;
        }

        private ProjectTaskModel GetModel(tbl_ProjectTask_DTO projectTask)
        {
            //  Initialize Static members
            InitializeProjectTaskModel();

            ProjectTaskModel projectTaskModel = new ProjectTaskModel();
            TeamBusinessLogic teamBusinessLogic = new TeamBusinessLogic();
            projectTaskModel.ProjectTask = projectTask;

            //  Fill Project Task Type
            projectTaskModel.ProjectTask.Type = EntityUtility.GetProjectTaskTypeById(projectTaskModel.ProjectTask.TypeId).Type;

            //  Fill Testing Team
            projectTaskModel.TestingTeam.Team = TeamBusinessLogic.GetTeam(Types.ChangeRequest, projectTaskModel.ProjectTask.Id, TeamType.Testing);
            projectTaskModel.TestingTeam.SelectedMembers = MarkupList<tbl_TeamMember_DTO>.Convert(TeamBusinessLogic.GetTeamMembersByTeam(projectTaskModel.TestingTeam.Team));

            //  Fill Actions
            var actions = ChangeRequestActionBusinessLogic.GetChangeRequestActionsByRequestId(projectTask.Id);
            projectTaskModel.ActionsModel = actions.Count > 0 ? ActionsModel.Convert(actions, false) : new ActionsModel();
            return projectTaskModel;
        }

        private int SaveAction(tbl_ProjectTaskActionDTO actionDto)
        {
            return new ProjectTaskActionBusinessLogic().SaveProjectTaskAction(actionDto);
        }
        #endregion
        #endregion

        #region Project Task Type
        #region Http Get
        [HttpGet]
        public ActionResult GetNewProjectTaskTypePartialAjax()
        {
            return PartialView("_AddNewTypePartial");
        }
        #endregion
        #endregion
    }
}