using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoIntegrador.Controllers
{
    public class PublicController : Controller
    {
        // GET: Public
        public ActionResult homeInfo()
        {

            return View("/Views/Public/HomeInfo.cshtml");
        }
    }
}