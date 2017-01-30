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
            Temmplate site=new Temmplate();
            if (User.IsInRole("Admin"))
            {
                site = repository.Temmplates.FirstOrDefault(m => m.Id == id);
            }
            else
            {
                site = repository.Temmplates.FirstOrDefault(m => m.Id == id & m.Publish == true);
            }
            if (site == null)
            {
               return Redirect("~/Develop/Template");
            }
            else {
                return View(site);
            }
        }
        // Галлерея шаблонных сайтов
        public ActionResult Template()
        {
            if (User.IsInRole("Admin"))
            {
                // Для Админа (показывает неопубликованные сайты) 
                IEnumerable<string> categories = repository.Temmplates
               .Select(x => x.Category)
               .Distinct()
               .OrderBy(x => x);
            ViewBag.Filter = categories;

            return View(repository.Temmplates);
            }
            else
            {    // Для гостей (не показывает неопубликованные сайты) 
                IEnumerable<string> categories = repository.Temmplates
               .Where(p=>p.Publish==true)
               .Select(x => x.Category)
               .Distinct()
               .OrderBy(x => x);
                ViewBag.Filter = categories;

                IEnumerable<Temmplate> templat = repository.Temmplates
                    .Where(t => t.Publish == true)
                    .OrderBy(x=>x.Id);

                return View(templat);
            }
        }

        [Authorize(Roles = "Admin")]
        public ViewResult EditCard(int Id)
        {
            // Категории в выпадающем списке при добавлении в базу данных
            //IEnumerable<string> categories = new string[] {
            //    "Сайт-Визитка",
            //    "Корпоративный",
            //    "Интернет-магазин",
            //    "Информационный",
            //    "Landing page",
            //    };
            //ViewBag.Filter = categories;

            Temmplate temmplate = repository.Temmplates
                .FirstOrDefault(p => p.Id == Id);
            return View(temmplate);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult EditCard(HttpPostedFileBase picture, Temmplate temmplate)
        {
            if (picture != null)
            {    
                if (picture!=null)
                {
                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(picture.FileName);
                //пишем  имя картинки в бд
                temmplate.LinkPicture = fileName;
                // сохраняем файл в папку img/BlogPicture/ в проекте
                picture.SaveAs(Server.MapPath("~/Content/img/TemplateSitePicture/" + fileName));
                }
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
        public ViewResult CreateTemplate()
        {
            return View("EditCard", new Temmplate());
        }
        public ActionResult DeleteTemplate(int Id)
        {
            Temmplate deletedTemplate = repository.DeleteTemplate(Id);
            if (deletedTemplate != null)
            {
                TempData["message"] = string.Format("{0} был удалён", deletedTemplate.Title);
            }
            return RedirectToAction("Index");
        }
        public RedirectResult PublishTemplate(int Id)
        {
            Temmplate PublishTemplate = repository.PublishTemplate(Id);

            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
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