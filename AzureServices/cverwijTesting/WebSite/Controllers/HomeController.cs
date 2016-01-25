using ChristiaanVerwijs.MvcSiteWithEntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChristiaanVerwijs.MvcSiteWithEntityFramework.WebSite.Models;

namespace ChristiaanVerwijs.MvcSiteWithEntityFramework.WebSite.Controllers
{
    public class HomeController : ControllerBase
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Application");
        }
    }
}
