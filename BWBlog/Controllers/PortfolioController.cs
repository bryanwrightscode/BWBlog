using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BryanWright.Controllers
{
    [RequireHttps]
    public class PortfolioController : Controller
    {
        // GET: Portfolio
        [RequireHttps]
        public ActionResult Index()
        {
            ViewBag.activePortfolio = "active";
            return View();
        }
        public ActionResult JS()
        {
            ViewBag.activePortfolio = "active";
            return View();
        }
    }
}