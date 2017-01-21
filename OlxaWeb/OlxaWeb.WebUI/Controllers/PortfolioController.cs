using OlxaWeb.Domain.Abstract;
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

    }
}