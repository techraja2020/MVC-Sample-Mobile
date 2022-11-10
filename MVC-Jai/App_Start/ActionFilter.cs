using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Jai.App_Start
{
    public class ActionFilter: ActionFilterAttribute,IAuthorizationFilter
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //2
            //Log("OnActionExecuted", filterContext.RouteData);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //1
            //Log("OnActionExecuting", filterContext.RouteData);
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {//0
            //if(filterContext.HttpContext.Request["name"]!="Raja")
            //{
            //    filterContext.Result = new ViewResult
            //    {
            //        ViewName = "~/Views/Shared/Error.cshtml"
            //    };
            //}
            //ViewResult vr = new ViewResult();
            //filterContext.Result = vr;
            //throw new NotImplementedException();
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //4
            //Log("OnResultExecuted", filterContext.RouteData);
            filterContext.Controller.ViewBag.title = "Jai kumar";
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {//3
           
            //Log("OnResultExecuting ", filterContext.RouteData);
        }

    }
}