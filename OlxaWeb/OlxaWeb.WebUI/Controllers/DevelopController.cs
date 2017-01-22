using OlxaWeb.Domain.Abstract;
using OlxaWeb.Domain.Entities;
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
            Temmplate site = repository.Temmplates.FirstOrDefault(m => m.Id == id);
            return View(site);
        }
        // Галлерея шаблонных сайтов
        public ActionResult Template()
        {
            return View(repository.Temmplates);
        }
       public enum Category
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }
        public ViewResult EditCard(int Id)
        {
            Temmplate temmplate = repository.Temmplates
                .FirstOrDefault(p => p.Id == Id);
            return View(temmplate);
        }
        [HttpPost]
        public ActionResult EditCard(HttpPostedFileBase picture, Temmplate temmplate)
        {
            if (picture != null)
            {
                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(picture.FileName);
                //пишем  имя картинки в бд
              //  post.UrlSlug = fileName;
                // сохраняем файл в папку img/BlogPicture/ в проекте
                picture.SaveAs(Server.MapPath("~/Content/img/TemplatePicture/" + fileName));
            }

            if (ModelState.IsValid)
            {

                repository.SaveTemplate(temmplate);
                TempData["message"] = string.Format("{0} has been saved", temmplate.Title);
                return RedirectToAction("Template");
            }
            else //Если что то пошло не так
            {
                return View(temmplate);
            }
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