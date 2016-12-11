using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sample.MVC.Angular.UI.Controllers
{
    public class SearchProfileController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Search page.";
            return View();
        }

    }
}