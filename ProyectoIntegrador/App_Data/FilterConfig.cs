using ProyectoIntegrador.App_Start.Filters;
using System.Web;
using System.Web.Mvc;

namespace ProyectoIntegrador
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new SessionFilter());
        }
    }
}
