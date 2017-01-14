using OlxaWeb.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OlxaWeb.WebUI.Controllers
{
    public class DevelopController : Controller
    {
        private ITemplateRepository repository;

        public DevelopController(ITemplateRepository repo)
        {
            repository = repo;
        }
        // Выбор из трёх видов сайта: шаблонные,индивидуальные,эксклюзивные
        public ActionResult Index()
        {
            return View();
        }
        // Продающая страница конкретного шаблонного сайта
        public ActionResult Card(int id)
        {
            return View();
        }
        // Галлерея шаблонных сайтов
        public ActionResult Template()
        {
            return View(repository.Temmplates);
        }
        // Страница про индивидуальные сайты 
        public ActionResult Individual()
        {
            return View();
        }
        //Страница про эксклюзивные сайты 
        public ActionResult Exclusive()
        {
            return View();
        }

    }
}