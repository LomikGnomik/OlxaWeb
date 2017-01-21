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
            return View(repository.Portfolios);
        }

        public ActionResult Site(int Id)
        {
            Portfolio site = repository.Portfolios.FirstOrDefault(m => m.Id == Id);
            return View(site);
        }
        public ViewResult EditSite(int Id)
        {
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
    }
}