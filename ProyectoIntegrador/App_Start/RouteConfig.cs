using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProyectoIntegrador
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Administrativo",
                url: "administrativos/{controller}/{action}/{id}",
                defaults: new { controller = "Personas", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "ProyectoIntegrador.Controllers.Administrativos" }
            );
            routes.MapRoute(
                name: "Citas",
                url: "Citas/{controller}/{action}/{id}",
                defaults: new { controller = "Personas", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "ProyectoIntegrador.Controllers.Administrativos" }
            );
            routes.MapRoute(
                name: "Informacion publica",
                url: "informacion",
                defaults: new { controller = "Public", action = "HomeInfo", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
