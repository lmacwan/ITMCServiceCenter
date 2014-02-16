using ITMCServiceCenter.Web.BLL;
using ITMCServiceCenter.Web.Domain;
using System.Web.Mvc;

namespace ITMCServiceCenter.Web.UI
{
    public class AccountController : BaseController
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginToAuthenticate)
        {
            if (ModelState.IsValid)
            {
                var userToAuthenticate = new tbl_UserMaster_DTO();
                userToAuthenticate.UserName = loginToAuthenticate.UserName;
                userToAuthenticate.Password = loginToAuthenticate.Password;
                var loginResponse = new LoginBusinessLogic().AuthenticateUser(userToAuthenticate);
                if (loginResponse != null)
                {
                    if (loginResponse.ModelMessage.Count == 0)
                    {
                        ITMCServiceCenterApplication.CurrentContextUser = loginResponse;
                    }
                    else
                    {
                        loginToAuthenticate.ModelMessage = loginResponse.ModelMessage;
                        return View(loginToAuthenticate);
                    }
                }
                else
                {
                    loginToAuthenticate.ModelMessage.Add(new ModelMessage { Code = ErrorCode.Invalid, Message = ITMCServiceCenter.Web.Domain.Resources.ITMCServiceCenterResource.msgIncorrectUserNameAndPassword, Type = MessageType.Error });
                }
            }
            return RedirectToAction("ListAll", "Projects");
        }

        //public ActionResult Home()
        //{
        //    var check = new ProjectBusinessLogic().GetProjectDTOList();
        //    return View();
        //}
    }
}