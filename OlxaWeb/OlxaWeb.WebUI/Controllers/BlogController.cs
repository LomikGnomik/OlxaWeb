using OlxaWeb.Domain.Abstract;
using OlxaWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OlxaWeb.WebUI.Models;
using OlxaWeb.Domain.Entities;

namespace OlxaWeb.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private IBlogRepository repository;
        public int PageSize = 5 ; //количество постов на странице

        public BlogController(IBlogRepository repo)
        {
            repository = repo;
        }

        //[HttpGet]
        //public ActionResult Index()
        //{
        //    return View();
        //}
        // Возвращает все посты

      
        public ActionResult Index(string category, int page = 1)
        {
           BlogViewModels viewModel= new BlogViewModels {
               Posts=repository.Posts
                   .Where(p => category == null || p.Category == category)
                   .OrderBy(p => p.Id)
                   .Skip((page - 1) * PageSize)
                   .Take(PageSize),
                   PagingInfo = new PagingInfo {
                       CurrentPage = page,
                       ItemsPerPage = PageSize,
                       TotalItems = category == null ?
                   repository.Posts.Count() :
                   repository.Posts.Where(e=>e.Category == category).Count()
                   },
                CurrentCategory=category
                };
            return View(viewModel);
        }


        public ActionResult Post(int id)
        {
            Post post = repository.Posts.FirstOrDefault(m => m.Id == id);
            return View(post);
        }

        public PartialViewResult Menu(string category=null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = repository.Posts
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(categories);
        }
    }
}