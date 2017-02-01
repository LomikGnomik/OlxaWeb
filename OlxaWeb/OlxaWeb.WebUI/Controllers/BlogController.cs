using OlxaWeb.Domain.Abstract;
using OlxaWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OlxaWeb.WebUI.Models;
using Microsoft.Security.Application;

namespace OlxaWeb.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private IBlogRepository repository;
        public int PageSize = 6; //количество постов на странице

        public BlogController(IBlogRepository repo)
        {
            repository = repo;
        }

        public ActionResult Index(string category, int page = 1)
        {
            if (User.IsInRole("Admin")) 
            {
                // Запрос для Админа (показывает опубликованные посты)
                BlogViewModels viewModel = new BlogViewModels
                {
                    Posts = repository.Posts
                              .Where(p =>category == null || p.Category == category)
                              .OrderBy(p => p.Id)
                              .Skip((page - 1) * PageSize)
                              .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
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
            else // Запрос для пользователей(не показывает опубликованные посты)
            { 
                BlogViewModels viewModel = new BlogViewModels
                {
                    Posts = repository.Posts
                 .Where(p => p.Published == true & (category == null || p.Category == category))
                 .OrderBy(p => p.Id)
                 .Skip((page - 1) * PageSize)
                 .Take(PageSize),

                    PagingInfo = new PagingInfo
                    {
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
        }

        public ActionResult Post(int id)
        {
            Post post = new Post();
            if (User.IsInRole("Admin")){
                post = repository.Posts.FirstOrDefault(m => m.Id == id);
            }
            else{
                post = repository.Posts.FirstOrDefault(m => m.Id == id & m.Published == true);
            }
            if (post == null){
                return Redirect("~/Blog/Index");
            }
            else{
                return View(post);
            }
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = repository.Posts
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            Dictionary<string,int> pcsInCategory = new Dictionary<string,int >() ;
            foreach (var cate in categories)
            {
                int pcs = repository.Posts.Count(x => x.Category == cate & x.Published==true);
                pcsInCategory.Add(cate,pcs);
            }
            ViewBag.pcsInCategory = pcsInCategory;
            
            return PartialView(categories);
        }

        public PartialViewResult MaxViewPost()
        {
            IEnumerable<Post> MaxViewPosts = repository.Posts
                              .Where(p => p.Published == true)
                              .OrderByDescending(p => p.Counter).
                              Take(3);

            return PartialView(MaxViewPosts);
        }

        public ViewResult EditPost(int Id)
        {
            ViewBag.Filter= repository.Posts
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            Post post = repository.Posts.FirstOrDefault(p => p.Id == Id);
            return View(post);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditPost(HttpPostedFileBase picture, Post post)
        {
            if (picture != null)
            {
                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(picture.FileName);
                //пишем  имя картинки в бд
                post.Picture = fileName;
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

        [HttpPost]
        public ActionResult DeleteBlog(int Id)
        {
            Post deletedPost = repository.DeletePost(Id);
            if (deletedPost != null)
            {
                TempData["message"] = string.Format("{0} был удалён", deletedPost.Title);
            }
            return RedirectToAction("Index");
        }

        public void Counter(int Id) //счётчик просмотров статей
        {
            //  UPDATE table SET count = (count + 1) WHERE post_id = ЧЕМУ ТО ТАМ РАВНО
            Post count = repository.Posts.FirstOrDefault(p => p.Id == Id);
            count.Counter = ++count.Counter;
            repository.SavePost(count);
        }

        public PartialViewResult Post_Site_Information(string category) //12 статей на сайте из блога по тематике "Разработка""SEO"
        {
            ViewBag.Category = category;
            IList<Post> postindevelop = repository.Posts
                .Where(p => p.Published == true & p.Category == category)
                .OrderBy(p => p.Id)
                .Take(12).ToList();

            return PartialView(postindevelop);
        }

        public ActionResult Search(string search, int page = 1)
        {
            BlogViewModels viewModel = new BlogViewModels
            {
                Posts = repository.Posts
                 .Where(p => p.Published == true & (p.Title.ToLower().Contains(Sanitizer.GetSafeHtmlFragment(search.ToLower())))) //p.Description.Contains(search) ||( p.Title.ToLower().Contains(search.ToLower())) 
                 .OrderBy(p => p.PostedOn)
                 .Skip((page - 1) * PageSize)
                 .Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Posts.Where(p => p.Published == true & (p.Title.ToLower().Contains(Sanitizer.GetSafeHtmlFragment(search.ToLower())))).Count()
                },
                SearchString = search
            };
            return View("Index", viewModel);

        }
        public RedirectResult PublishPost(int Id)
        {
           Post PublishTemplate = repository.PublishPost(Id);

            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }
    }
}