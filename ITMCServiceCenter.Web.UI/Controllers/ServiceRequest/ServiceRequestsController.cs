using ITMCServiceCenter.Web.BLL;
using ITMCServiceCenter.Web.Domain;
using System;
using System.Web.Mvc;
using Telerik.Web.Mvc;
using ITMCServiceCenter.Web.UI;
using System.Collections.Generic;
using System.Web;

namespace ITMCServiceCenter.Web.UI
{
    public class ServiceRequestsController : BaseController
    {
        #region HttpGet
        [HttpGet]
        public ActionResult ListAll()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetNewServiceRequestPartialAjax(int id)
        {
            var serviceRequestModel = ServiceRequestBusinessLogic.GetServiceRequest(id);
            return PartialView("_NewServiceRequestPartial", GetModel(serviceRequestModel));
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = GetModel(ServiceRequestBusinessLogic.GetServiceRequest(id));
            return View(model);
        }
        #endregion

        #region HttpPost
        [HttpPost]
        public bool SaveServiceRequest(ServiceRequestModel serviceRequestModel)
        {
            int serviceRequestId = new ServiceRequestBusinessLogic().SaveServiceRequest(serviceRequestModel.ServiceRequest);
            SaveAction(new tbl_ServiceRequestActionDTO()
            {
                Action = serviceRequestModel.ActionsModel.NewAction.Action,
                ServiceRequestId = serviceRequestId,
                CreatedBy = ITMCServiceCenterApplication.CurrentContextUser.UserFullName,
                CreatedOn = DateTime.Now
            });

            new TeamBusinessLogic().SaveTeamWithMembers(serviceRequestModel.TestingTeam.SelectedMembersId, TeamType.Testing, Types.ServiceRequest, serviceRequestId);
            return serviceRequestId > 0;
        }

        [HttpPost]
        public bool UpdateServiceRequest(ServiceRequestModel serviceRequestModel)
        {
            int serviceRequestId = new ServiceRequestBusinessLogic().UpdateServiceRequest(serviceRequestModel.ServiceRequest);
            SaveAction(new tbl_ServiceRequestActionDTO()
            {
                Action = serviceRequestModel.ActionsModel.NewAction.Action,
                ServiceRequestId = serviceRequestId,
                CreatedBy = ITMCServiceCenterApplication.CurrentContextUser.UserFullName,
                CreatedOn = DateTime.Now
            });

            new TeamBusinessLogic().SaveTeamWithMembers(serviceRequestModel.TestingTeam.SelectedMembersId, TeamType.Testing, Types.ServiceRequest, serviceRequestId);
            return serviceRequestId > 0;
        }
        #endregion

        #region Grid Actions
        [GridAction]
        public ActionResult GetAllServiceRequestsAjax()
        {
            var serviceRequests = ServiceRequestBusinessLogic.GetServiceRequests();
            var models = GetModels(serviceRequests);
            return View(new GridModel { Data = models });
        }
        #endregion

        #region Service Request Actions Methods
        [HttpPost]
        public HtmlString SaveAction(FormCollection formCollection)
        {
            var date = DateTime.Now;
            var htmlString = new HtmlString("");
            var actionId = SaveAction(new tbl_ServiceRequestActionDTO()
            {
                Action = formCollection["NewAction.Action"],
                ServiceRequestId = int.Parse(formCollection["RelateToId"]),
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
        private void InitializeServiceRequestModel()
        {
            ServiceRequestModel.Users = UserBusinessLogic.GetUsers();
            ServiceRequestModel.Projects = ProjectBusinessLogic.GetProjects();
            ServiceRequestModel.Priorities = new EntityUtility().GetEntitiesByType(Types.ServiceRequestPriority);
            ServiceRequestModel.Statuses = new EntityUtility().GetEntitiesByType(Types.ServiceRequestStatus);
        }

        private List<ServiceRequestModel> GetModels(List<tbl_ServiceRequest_DTO> serviceRequests)
        {
            //  Initialize Static members
            InitializeServiceRequestModel();

            ServiceRequestModel serviceRequestModel;
            TeamBusinessLogic teamBusinessLogic = new TeamBusinessLogic();
            List<ServiceRequestModel> models = new List<ServiceRequestModel>();
            List<IAction> actions;
            foreach (tbl_ServiceRequest_DTO serviceRequest in serviceRequests)
            {
                serviceRequestModel = new ServiceRequestModel();
                serviceRequestModel.ServiceRequest = serviceRequest;

                //  Fill Testing Team
                serviceRequestModel.TestingTeam.Team = TeamBusinessLogic.GetTeam(Types.ServiceRequest, serviceRequestModel.ServiceRequest.Id, TeamType.Testing);
                serviceRequestModel.TestingTeam.SelectedMembers = MarkupList<tbl_TeamMember_DTO>.Convert(TeamBusinessLogic.GetTeamMembersByTeam(serviceRequestModel.TestingTeam.Team));

                //  Fill Actions
                actions = ServiceRequestActionBusinessLogic.GetServiceRequestActionsByRequestId(serviceRequest.Id);
                serviceRequestModel.ActionsModel = actions.Count > 0 ? ActionsModel.Convert(actions, false) : new ActionsModel();
                models.Add(serviceRequestModel);
            }
            return models;
        }

        private ServiceRequestModel GetModel(tbl_ServiceRequest_DTO serviceRequest)
        {
            //  Initialize Static members
            InitializeServiceRequestModel();

            ServiceRequestModel serviceRequestModel = new ServiceRequestModel();
            TeamBusinessLogic teamBusinessLogic = new TeamBusinessLogic();
            serviceRequestModel.ServiceRequest = serviceRequest;

            //  Fill Testing Team
            serviceRequestModel.TestingTeam.Team = TeamBusinessLogic.GetTeam(Types.ChangeRequest, serviceRequestModel.ServiceRequest.Id, TeamType.Testing);
            serviceRequestModel.TestingTeam.SelectedMembers = MarkupList<tbl_TeamMember_DTO>.Convert(TeamBusinessLogic.GetTeamMembersByTeam(serviceRequestModel.TestingTeam.Team));

            //  Fill Actions
            var actions = ServiceRequestActionBusinessLogic.GetServiceRequestActionsByRequestId(serviceRequest.Id);
            serviceRequestModel.ActionsModel = actions.Count > 0 ? ActionsModel.Convert(actions) : new ActionsModel();
            return serviceRequestModel;
        }

        private int SaveAction(tbl_ServiceRequestActionDTO actionDto)
        {
            return new ServiceRequestActionBusinessLogic().SaveServiceRequestAction(actionDto);
        }
        #endregion
    }
}