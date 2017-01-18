using OlxaWeb.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OlxaWeb.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private IBlogRepository repository;
        public BlogController(IBlogRepository repo)
        {
            repository = repo;
        }

        // Возвращает все посты
        public ActionResult Index()  
        {
            return View(repository.Posts);
        }
        public ActionResult Post()
        {
            return View();
        }

        public PartialViewResult Menu()
        {
            IEnumerable<string> categories = repository.Posts
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(categories);
        }
    }
}