using ProyectoIntegrador.App_Start.Filters.Objects;
using ProyectoIntegrador.Models;
using ProyectoIntegrador.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoIntegrador.App_Start.Filters
{
    public class SessionFilter: ActionFilterAttribute
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private static string[] publicPages = { "public/homeinfo", "public/consultesucita" };

        override
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpSessionStateBase session = filterContext.HttpContext.Session;
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower()+'/'+ filterContext.ActionDescriptor.ActionName.ToLower();
            var user = session["user"];
            if (user == null && !controllerName.Equals("account/login"))
            {
                Boolean isPublic = false;
                foreach (string name in publicPages)
                {
                    if (controllerName.Equals(name))
                    {
                        isPublic = true;
                        break;
                    }
                }
                if (!isPublic) { 
                    var url = new UrlHelper(filterContext.RequestContext);
                    var loginUrl = url.Content("~/Account/Login");
                    filterContext.HttpContext.Response.Redirect(loginUrl, true);
                }
            }
        }

        override
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            AddMenus(filterContext);
        }

        private void AddMenus(ActionExecutedContext filterContext)
        {
            HttpSessionStateBase session = filterContext.HttpContext.Session;
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower() + '/' + filterContext.ActionDescriptor.ActionName.ToLower();
            ApplicationUser user = (ApplicationUser) session["user"];
            if (user != null)
            {
                if (session["menus"] != null) {
                    filterContext.Controller.ViewBag.Menus = session["menus"];
                } else
                {
                    IQueryable<Menu> menusIQ = from menu in db.Menu
                                               join rolmenu in db.RolMenu on menu.Id equals rolmenu.Menu
                                               join rol in db.Roles on rolmenu.Rol equals rol.Id
                                               join rolusr in db.UserRoles on rol.Id equals rolusr.RoleId
                                               join usr in db.Users on rolusr.UserId equals usr.Id
                                               where usr.Id == user.Id
                                               select menu;
                    Dictionary<long?, MenuDTO> menuMap = new Dictionary<long?, MenuDTO>();
                    foreach (var menu in menusIQ)
                    {
                        MenuDTO _menu = new MenuDTO(menu);
                        if (_menu.EsPadre)
                        {
                            menuMap.Add(menu.Id, _menu);
                        }
                        else
                        {
                            menuMap[menu.Padre].Hijos.Add(_menu);
                            menuMap[menu.Padre].Hijos.Sort(delegate (MenuDTO a, MenuDTO b) {
                                return a.Datos.Orden.CompareTo(b.Datos.Orden);
                            });
                        }
                    }
                    session["menus"] = menuMap.Select(o => o.Value).ToList();
                    filterContext.Controller.ViewBag.Menus = session["menus"];
                }
            }
        }
    }
}