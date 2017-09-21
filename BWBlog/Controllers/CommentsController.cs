using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BWBlog.Models;
using Microsoft.AspNet.Identity;

namespace BWBlog.Controllers
{
    [RequireHttps]
    public class CommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Comments
        //public ActionResult Index()
        //{
        //    var comments = db.Comments.Include(c => c.CommentAuthor).Include(c => c.Post);
        //    return View(comments.ToList());
        //}

        //// GET: Comments/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Comment comment = db.Comments.Find(id);
        //    if (comment == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(comment);
        //}

        //// GET: Comments/Create
        //public ActionResult Create()
        //{
        //    ViewBag.CommentAuthorID = new SelectList(db.Users, "Id", "FirstName");
        //    ViewBag.PostID = new SelectList(db.Posts, "Id", "Title");
        //    return View();
        //}

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CommentText")] Comment comment, int id)
        {
            if (ModelState.IsValid)
            {
                Post post = db.Posts.Find(id);
                var user = db.Users.Find(User.Identity.GetUserId());
                comment.CreationDate = DateTime.UtcNow;
                comment.PostID = id;
                comment.CommentAuthorID = user.Id;
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Details","Posts", new { slug = post.Slug });
            }

            return View(comment);
        }

        // GET: Comments/Edit/5
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.CommentAuthorID = new SelectList(db.Users, "Id", "FirstName", comment.CommentAuthorID);
            ViewBag.PostID = new SelectList(db.Posts, "Id", "Title", comment.PostID);
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin, Moderator")]
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ID,CommentText")] int commentId, int id, string commentText)
        {
            Post post = db.Posts.Find(id);
            Comment comment = db.Comments.Find(commentId);
            if (ModelState.IsValid)
            {
                comment.UpdateDate = DateTime.UtcNow;
                comment.CommentText = commentText;
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Posts", new { slug =  post.Slug });
            }
            return View(comment);
        }

        // GET: Comments/Delete/5
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Delete/5
        [Authorize(Roles = "Admin, Moderator")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int commentId, int id)
        {
            Comment comment = db.Comments.Find(commentId);
            Post post = db.Posts.Find(id);
            db.Comments.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Details", "Posts", new { slug = post.Slug });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
