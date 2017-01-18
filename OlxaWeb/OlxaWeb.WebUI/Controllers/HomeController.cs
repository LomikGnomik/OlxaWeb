using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OlxaWeb.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MySite()
        {        
         //будет проверка на авторизированность.
            return View("~/Views/MyWebSite/Index.cshtml");
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Blog()
        {
            return View();
        }
        public ActionResult Brigade()
        {
            return View();
        }
    }
}