using System.Web.Mvc;

namespace ITMCServiceCenter.Web.UI
{
    public class BaseController : Controller
    {
        /// <summary>
        /// The below method will generate jave script file with json object same as resource file
        /// Object Name will be ``
        /// </summary>
        /// <returns></returns>
        public JavaScriptResult ITMCServiceCenterResource()
        {
            return ResourceJavaScripter.GetResourceScript(ITMCServiceCenter.Web.Domain.Resources.ITMCServiceCenterResource.ResourceManager);

        }
        /// <summary>
        /// This method will log all exceptions at UI level
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnException(ExceptionContext filterContext)
        {
            string controllerName = filterContext.RouteData.GetRequiredString("controller");
            string actionName = filterContext.RouteData.GetRequiredString("action");
            var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);

            //BLL.LogGenerator.Info(string.Format("ControllerName: {0}", controllerName));
            //BLL.LogGenerator.Info(string.Format("ActionName: {0}", actionName));
            //BLL.LogGenerator.Error("OnException: ", filterContext.Exception);

            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Error.cshtml"
            };
            filterContext.ExceptionHandled = true;

            base.OnException(filterContext);
        }
    }
}