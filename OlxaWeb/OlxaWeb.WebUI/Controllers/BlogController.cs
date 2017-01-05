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
        public ActionResult List()  
        {
            return View(repository.Posts);
        }
    }
}