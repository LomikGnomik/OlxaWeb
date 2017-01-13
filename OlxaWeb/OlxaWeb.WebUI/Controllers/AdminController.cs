﻿using OlxaWeb.Domain.Abstract;
using OlxaWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OlxaWeb.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private ITemplateRepository repository;

        public AdminController(ITemplateRepository repo)
        {
            repository = repo;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Templates()
        {
            return View(repository.Temmplates);
        }
        public ActionResult EditTemplates(int Id)
        {
            Temmplate site = repository.Temmplates
                .FirstOrDefault(p => p.Id == Id);
            return View(site);
        }
    }
}