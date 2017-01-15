using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OlxaWeb.WebUI.Controllers
{
    public class MyWebSiteController : Controller
    {
        // GET: MyWebSite
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DevTemplate()
        {
            return View();
        }
        public ActionResult DevIndividual()
        {
            return View();
        }
        public ActionResult DevExclusive()
        {
            return View();
        }
    }
}