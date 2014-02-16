using ITMCServiceCenter.Web.BLL;
using System.Web.Mvc;
using System.Linq;
using Telerik.Web.Mvc;
using ITMCServiceCenter.Web.Domain;
using System;
using System.Collections.Generic;

namespace ITMCServiceCenter.Web.UI
{
    public class ProjectsController : BaseController
    {
        #region Project
        #region HttpGet
        [HttpGet]
        public ActionResult ListAll()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetNewProjectPartialAjax(short id)
        {
            var project = ProjectBusinessLogic.GetProject(id);
            return PartialView("_NewProjectPartial", GetModel(project));
        }

        [HttpGet]
        public ActionResult Details(short id)
        {
            return View(GetModel(ProjectBusinessLogic.GetProject(id)));
        }
        #endregion

        #region HttpPost
        [HttpPost]
        public bool SaveProject(ProjectModel projectModel)
        {
            var isSaved = false;
            short projectId = projectModel.Project.Id;
            if (projectId <= 0)
            {
                projectId = new ProjectBusinessLogic().SaveProject(projectModel.Project);
                isSaved = projectId > 0;
            }
            if (isSaved)
            {
                isSaved = new TeamBusinessLogic().SaveTeamWithMembers(projectModel.Team.SelectedMembersId, TeamType.Implementation, Types.Project, projectId, projectModel.Team.Team.Id) > 0;
            }
            return isSaved;
        }

        [HttpPost]
        public bool UpdateProject(ProjectModel projectModel)
        {
            var isSaved = false;
            short projectId = projectModel.Project.Id;
            if (projectId > 0)
            {
                isSaved = new ProjectBusinessLogic().UpdateProject(projectModel.Project);
            }
            if (isSaved)
            {
                isSaved = new TeamBusinessLogic().SaveTeamWithMembers(projectModel.Team.SelectedMembersId, TeamType.Implementation, Types.Project, projectModel.Project.Id, projectModel.Team.Team.Id) > 0;
            }

            return isSaved;
        }

        [HttpPost]
        public bool DeleteProject(short projectId)
        {
            return false;
        }
        #endregion

        #region Grid Actions
        [GridAction]
        public ActionResult GetAllProjectsAjax()
        {
            var projects = ProjectBusinessLogic.GetProjects();
            var models = GetModels(projects);
            return View(new GridModel { Data = models });
        }
        #endregion

        #region Private Methods
        private void InitializeProjectModel()
        {
            ProjectModel.Clients = ClientBusinessLogic.GetClients();
            ProjectModel.Users = UserBusinessLogic.GetUsers();
            ProjectModel.Types = new EntityUtility().GetEntitiesByType(Types.ProjectType);
            ProjectModel.Statuses = new EntityUtility().GetEntitiesByType(Types.ProjectStatus);
        }

        private List<ProjectModel> GetModels(List<tbl_Project_DTO> projects)
        {
            InitializeProjectModel();
            ProjectModel projectModel;
            TeamBusinessLogic teamBusinessLogic = new TeamBusinessLogic();
            List<ProjectModel> models = new List<ProjectModel>();
            foreach (tbl_Project_DTO project in projects)
            {
                projectModel = new ProjectModel();
                projectModel.Project = project;
                FillTeams(projectModel);
                models.Add(projectModel);
            }
            return models;
        }

        private ProjectModel GetModel(tbl_Project_DTO project)
        {
            InitializeProjectModel();
            ProjectModel projectModel;
            TeamBusinessLogic teamBusinessLogic = new TeamBusinessLogic();
            projectModel = new ProjectModel();
            projectModel.Project = project;
            FillTeams(projectModel);
            return projectModel;
        }

        private void FillTeams(ProjectModel projectModel)
        {
            if (projectModel.Project.Id > 0)
            {
                projectModel.Team = new TeamModel();
                projectModel.Team.Team = TeamBusinessLogic.GetTeam(Types.Project, projectModel.Project.Id, TeamType.Implementation);
                projectModel.Team.SelectedMembers = MarkupList<tbl_TeamMember_DTO>.Convert(TeamBusinessLogic.GetTeamMembersByTeam(projectModel.Team.Team));
            }
            else
            {
                projectModel.Team = new TeamModel();
            }
        }
        #endregion
        #endregion

        #region Project Documents
        #region Grid Actions
        [GridAction]
        public ActionResult GetAllProjectsDocumentsAjax()
        {
            return View(new GridModel { Data = new ProjectDocumentBusinessLogic().GetProjectDocuments() });
        }
        #endregion

        #region HttpGet
        [HttpGet]
        public ActionResult ListDocuments()
        {
            return View("DocumentsList");
        }
        [HttpGet]
        public ActionResult GetNewProjectDocumentPartialAjax()
        {
            var newProjectDocumentModel = new tbl_ProjectDocument_DTO();
            newProjectDocumentModel.Projects = ProjectBusinessLogic.GetProjects();
            newProjectDocumentModel.Users = UserBusinessLogic.GetUsers();
            return PartialView("_NewProjectDocumentPartial", newProjectDocumentModel);
        }
        #endregion

        #region HttpPost

        #endregion
        #endregion
    }
}