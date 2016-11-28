using MyWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebApplication.Controllers
{
    public class HomeController : Controller
    {
        BookContext db = new BookContext();
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
        public ActionResult Transform()
        {
            ViewBag.Message = "Transform";
            return View();
        }
       public ActionResult AjaxContent()
        {
             
            ViewBag.Message = "Ajax";
            return View(db.Books);
        }
        public ActionResult BookView(int id)
        { 
            return View(db.Books.Find(id));
        }
        public ActionResult EditBook(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Book book = db.Books.Find(id);
            if (book != null)
            {
                return View(book);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult EditBook(Book book)
        {
            db.Entry(book).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("AjaxContent");
        }
    }
}