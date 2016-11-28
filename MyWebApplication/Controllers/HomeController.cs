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
        static ChatModel chatModel;
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
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();

            return RedirectToAction("AjaxContent");
        }
        public ActionResult Delete(int id)
        {
            Book b = db.Books.Find(id);
            if(b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Book b = db.Books.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            db.Books.Remove(b);
            db.SaveChanges();
            return RedirectToAction("AjaxContent");
        }
        
        public ActionResult ChatModel(string user, bool? logOn, bool? logOff, string chatMessage)
        {
            try
            {
                if (chatModel == null) chatModel = new ChatModel();
                if (chatModel.Messages.Count > 100)
                    chatModel.Messages.RemoveRange(0, 90);
                if (!Request.IsAjaxRequest())
                {
                    return View(chatModel);
                }
                else if (logOn !=  null && (bool)logOn)
                {
                    if(chatModel.Users.FirstOrDefault(u => u.Name == user) != null)
                    {
                        throw new Exception("Пользователь с таким ником уже есть");
                    }else if(chatModel.Users.Count > 10)
                    {
                        throw new Exception("Чат заполнен");
                    }
                    else
                    {
                        chatModel.Users.Add(new ChatUser() {
                            Name = user,
                            LoginTime = DateTime.Now,
                            LastPing = DateTime.Now
                        });
                        chatModel.Messages.Add(new ChatMessage()
                        {
                            Text = user + " вошел в чат",
                            Date = DateTime.Now
                        });

                    }
                    return PartialView("ChatRoom", chatModel);
                }
                else if (logOff != null && (bool)logOff)
                {
                    LogOff(chatModel.Users.FirstOrDefault(u => u.Name == user));
                    return PartialView("ChatRoom", chatModel);
                }else
                {
                    ChatUser currentUser = chatModel.Users.FirstOrDefault(u => u.Name == user);
                    currentUser.LastPing = DateTime.Now;

                    List<ChatUser> toRemove = new List<ChatUser>();
                    foreach (Models.ChatUser usr in chatModel.Users)
                    {
                        TimeSpan span = DateTime.Now - usr.LastPing;
                        if (span.TotalSeconds > 15)
                            toRemove.Add(usr);
                        
                    }
                    foreach (ChatUser u in toRemove)
                    {
                        LogOff(u);
                    }
                    if (!string.IsNullOrEmpty(chatMessage))
                    {
                        chatModel.Messages.Add(new ChatMessage()
                        {
                            User = currentUser,
                            Text = chatMessage,
                            Date = DateTime.Now
                        });
                    }
                    return PartialView("History", chatModel);
                }
            }
            catch(Exception ex)
            {
                Response.StatusCode = 500;
                return Content(ex.Message);
            }
        }
        public void LogOff(ChatUser user)
        {
            chatModel.Users.Remove(user);
            chatModel.Messages.Add(new ChatMessage()
            {
                Text = user.Name + " покинул чат.",
                Date = DateTime.Now
            });
        }
        
    }
}