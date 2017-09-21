using BWBlog.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BWBlog.Controllers
{
    public class CommentsControllerCustom : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Posts/CreateComment
        public ActionResult CreateComment()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateComment([Bind(Include = "ID,CommentText,CommentAuthorID,CreationDate,UpdatedDate")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                //comment.CommentAuthor = db.Users.Find(User.Identity.GetUserId
                //add PostID to the Post Details view similar to the pass thru of Id in Post edit view
                comment.CreationDate = DateTime.Now;
                comment.CommentAuthor = db.Users.Find(User.Identity.GetUserId());
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index", "Posts");
            }

            return View(comment);
        }
    }
}