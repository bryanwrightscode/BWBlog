using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BryanWright.Controllers
{
    [RequireHttps]
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            ViewBag.activeAbout = "active";
            return View();
        }
    }
}