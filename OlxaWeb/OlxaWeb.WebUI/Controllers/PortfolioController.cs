using OlxaWeb.Domain.Abstract;
using OlxaWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OlxaWeb.WebUI.Controllers
{
    public class PortfolioController : Controller
    {
        private IPortfolioRepository repository;

        public PortfolioController(IPortfolioRepository repo)
        {
            repository = repo;
        }

        // GET: Portfolio
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                // //Запрос для Админа ( показывает неопубликованное портфолио)
                ViewBag.Filter = CategoryFilter();

                return View(repository.Portfolios);
            }
            else   //Запрос для гостей (не показывает неопубликованное портфолио)
            {
                ViewBag.Filter = CategoryFilter();
                IEnumerable<Portfolio> portfolio = repository.Portfolios
                  .Where(p => p.Publish == true)
                  .OrderBy(p => p.Id);
            
            return View(portfolio);
            }
        }

        public  ActionResult Site(int Id)
        {
            Portfolio site = new Portfolio();
            if (User.IsInRole("Admin"))
            {
                site = repository.Portfolios.FirstOrDefault(m => m.Id == Id);
            }
            else
            {
                site = repository.Portfolios.FirstOrDefault(m => m.Id == Id & m.Publish == true);
            }
            if (site == null)
            {
                return Redirect("~/Portfolio/Index");
            }
            else
            {
                return View(site);
            }
        }
        private IEnumerable<string> CategoryFilter()
        {
            IEnumerable<string> categories;
            if (User.IsInRole("Admin"))
            {
             categories = repository.Portfolios
            .Select(x => x.Category)
             .Distinct()
             .OrderBy(x => x);
            }
            else {
              categories = repository.Portfolios
             .Where(p => p.Publish == true)
             .Select(x => x.Category)
             .Distinct()
             .OrderBy(x => x);
            }
           
            return (categories);
        }

        public ViewResult EditSite(int Id)
        {
            IEnumerable<string> categories = new string[] {
                "Сайт-Визитка",
                "Корпоративный",
                "Интернет-магазин",
                "Информационный",
                "Landing page",};
                
            ViewBag.Filter = categories;

            Portfolio portfolio = repository.Portfolios
                .FirstOrDefault(p => p.Id == Id);

            return View(portfolio);
        }
        [HttpPost]
        public ActionResult EditSite(HttpPostedFileBase picture, Portfolio portfolio)
        {
            if (picture != null)
            {
                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(picture.FileName);
                //пишем  имя картинки в бд
            //    portfolio.UrlSlug = fileName;
                // сохраняем файл в папку img/BlogPicture/ в проекте
                picture.SaveAs(Server.MapPath("~/Content/img/PortfolioPicture/" + fileName));
            }

            if (ModelState.IsValid)
            {
                repository.SavePortfolio(portfolio);
                TempData["message"] = string.Format("{0} has been saved", portfolio.Name);
                return RedirectToAction("Index");
            }
            else //Если что то пошло не так
            {
                return View(portfolio);
            }
        }
        public ActionResult DeletePortfolio(int Id)
        {
            Portfolio deletedPortfolio = repository.DeletePortfolio(Id);
            if (deletedPortfolio != null)
            {
                TempData["message"] = string.Format("{0} был удалён", deletedPortfolio.Name);
            }
            return RedirectToAction("Index");
        }
        public ViewResult CreatePortfolio()
        {
            return View("EditSite", new Portfolio());
        }
    }
}