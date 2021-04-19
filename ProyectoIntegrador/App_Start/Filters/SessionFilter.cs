using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoIntegrador.App_Start.Filters
{
    public class SessionFilter: ActionFilterAttribute
    {
        override
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            System.Console.WriteLine("prueba");
            HttpSessionStateBase session = filterContext.HttpContext.Session;
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower()+'/'+ filterContext.ActionDescriptor.ActionName.ToLower();
            var user = session["user"];
            if (user == null && !controllerName.Equals("account/login"))
            {
                var url = new UrlHelper(filterContext.RequestContext);
                var loginUrl = url.Content("~/Account/Login");
                filterContext.HttpContext.Response.Redirect(loginUrl, true);
            }
        }
    }
}