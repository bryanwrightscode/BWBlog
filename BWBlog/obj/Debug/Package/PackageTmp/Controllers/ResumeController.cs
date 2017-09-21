using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BryanWright.Controllers
{
    [RequireHttps]
    public class ResumeController : Controller
    {
        // GET: Resume
        public ActionResult Index()
        {
            ViewBag.activeResume = "active";
            return View();
        }
    }
}