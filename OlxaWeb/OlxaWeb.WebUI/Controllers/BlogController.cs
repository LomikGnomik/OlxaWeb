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
        public int PageSize = 5; //количество постов на странице

        public BlogController(IBlogRepository repo)
        {
            repository = repo;
        }

        public ActionResult Index(string category, int page = 1)
        {
            BlogViewModels viewModel = new BlogViewModels {
                Posts = repository.Posts
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.Id)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                    repository.Posts.Count() :
                    repository.Posts.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(viewModel);
        }

        public ActionResult Post(int id)
        {
            Post post = repository.Posts.FirstOrDefault(m => m.Id == id);
            return View(post);
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = repository.Posts
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(categories);
        }

        public ViewResult EditPost(int Id)
        {
            Post post = repository.Posts
                .FirstOrDefault(p => p.Id == Id);
            return View(post);
        }
        [HttpPost]
        public ActionResult EditPost(HttpPostedFileBase picture, Post post)
        {
            if (picture != null)
            {
                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(picture.FileName);
                //пишем  имя картинки в бд
                post.UrlSlug = fileName;
                // сохраняем файл в папку img/BlogPicture/ в проекте
                picture.SaveAs(Server.MapPath("~/Content/img/BlogPicture/" + fileName));
            }

            if (ModelState.IsValid)
            {
                
                repository.SavePost(post);
                TempData["message"] = string.Format("{0} has been saved", post.Title);
                return RedirectToAction("Index");
            }
            else //Если что то пошло не так
                {
                 return View(post);
                }
        }
        public ViewResult CreatePost()
        {
            return View("EditPost", new Post());
        }
    }
}