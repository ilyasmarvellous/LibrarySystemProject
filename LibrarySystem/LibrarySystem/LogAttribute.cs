using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LibrarySystem
{
    public class LogAttribute: ActionFilterAttribute
    {

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string  message=  Log("OnActionExecuted",filterContext.RouteData);
            filterContext.Controller.ViewBag.filterRes = message;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Log("OnActionExecuting", filterContext.RouteData);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Log("OnResultExecuted", filterContext.RouteData);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Log("OnResultExecuting", filterContext.RouteData);
        }

        private string Log(string methodName,RouteData routeData)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            string  message = String.Format("{0} response controller:{1} and action:{2}", methodName,controllerName,actionName);
            return message;
        }

    }
}