using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BryanWright.Controllers
{
    [RequireHttps]
    public class JSController : Controller
    {
        // GET: JS
        public ActionResult Index()
        {
            return View();
        }
    }
}