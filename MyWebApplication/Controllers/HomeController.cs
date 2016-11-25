using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult ProgressBar()
        {
            ViewBag.Message = "My Progressbar.";
            return View();
        }
        public ActionResult NewBranch()
        {
            ViewBag.Message = "New Branch";
            return View();
        }
        public ActionResult Path()
        {
            ViewBag.Message = "Path";
            return View();
        }
    }
}