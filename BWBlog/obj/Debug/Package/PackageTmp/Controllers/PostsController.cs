//Using directives, using statements likely in unmanaged code in views
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BWBlog.Models;
using BWBlog.Helpers;
using Microsoft.AspNet.Identity;
using System.IO;

namespace BWBlog.Controllers
{
    [RequireHttps]
    //This class inherits from Controller class
    public class PostsController : Controller
    {
        

        //Instantiate new DbContext to shorter variable name
        //DbSets in var allow add,remove,edit,delete,find,tolist etc
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: unpublished Posts
        //Generates a List of Post entities
        public ActionResult Index()
        {
            ViewBag.activeBlog = "active";
            //ToList a method in DbSet
            //Returns a list of blogs in database to Index View
            var publishedPosts = db.Posts.Where(a => a.Published == true);
            var sortedPublishedPosts = publishedPosts.OrderByDescending(s => s.CreationDate);
            return View(sortedPublishedPosts.ToList());
        }

        public ActionResult Drafts()
        {
            ViewBag.activeBlog = "active";
            //ToList a method in DbSet
            //Returns a list of blogs in database to Index View
            var unpublishedPosts = db.Posts.Where(a => a.Published == false);
            return View(unpublishedPosts.ToList());
        }

        // GET: Posts/Details/5
        //Parameters allow null id
        //the id parameter is related to the route.confic file
        public ActionResult Details(string Slug)
        {
            ViewBag.HideBanner = true;
            //Condition if id is null
            if (String.IsNullOrWhiteSpace(Slug))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Explicit variable declaration, not implicit, var is of the Post type
            Post post = db.Posts.FirstOrDefault(p => p.Slug == Slug);
            if (post == null)
            {
                return HttpNotFound();
            }


            //var comments = db.Comments.ToList();
            //SEE TUTORIAL
            return View(post);
        }

        [Authorize(Roles = "Admin")]
        // GET: Posts/Create
        public ActionResult Create()
        {
            ViewBag.activeBlog = "active";
            ViewBag.HideBanner = true;
            return View();
        }

        // POST: Posts/Create
        //Occurs when you hit submit button on create view
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //Restricts user data to only be valid when form is sent
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        //Bind attribute aids in confirming valid model state
        public ActionResult Create([Bind(Include = "Id,PostAuthorId,CreationDate,UpdatedDate,Title,BodyText,MediaUrl,Published,Slug")] Post post, HttpPostedFileBase image)
        {
            if (image != null && image.ContentLength > 0)
            {
                var ext = Path.GetExtension(image.FileName).ToLower();
                if (ext != ".png" && ext != ".jpg" && ext != ".jpeg" && ext != ".gif" && ext != ".bmp")
                    ModelState.AddModelError("image", "Invalid Format");
            }

            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    var filePath = "/Uploads/";
                    var absPath = Server.MapPath("~" + filePath);
                    post.MediaUrl = filePath + image.FileName;
                    image.SaveAs(Path.Combine(absPath, image.FileName));
                }

                var Slug = StringUtilities.URLFriendly(post.Title);
                if (String.IsNullOrWhiteSpace(Slug))
                {
                    ModelState.AddModelError("Title", "Invalid title");
                    return View(post);
                }
                if (db.Posts.Any(p => p.Slug == Slug))
                {
                    ModelState.AddModelError("Title", "The title must be unique");
                    return View(post);
                }

                post.Slug = Slug;
                post.PostAuthor = db.Users.Find(User.Identity.GetUserId());

                post.CreationDate = DateTime.Now;

                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(post);
        }

        [Authorize(Roles = "Admin")]
        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.activeBlog = "active";
            ViewBag.HideBanner = true;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        [Authorize(Roles = "Admin")]
        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PostAuthorId,CreationDate,UpdatedDate,Title,BodyText,MediaUrl,Published,Slug")] Post post, HttpPostedFileBase image)
        {
            if (image != null && image.ContentLength > 0)
            {
                var ext = Path.GetExtension(image.FileName).ToLower();
                if (ext != ".png" && ext != ".jpg" && ext != ".jpeg" && ext != ".gif" && ext != ".bmp")
                    ModelState.AddModelError("image", "Invalid Format");
            }

            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    var filePath = "/Uploads/";
                    var absPath = Server.MapPath("~" + filePath);
                    post.MediaUrl = filePath + image.FileName;
                    image.SaveAs(Path.Combine(absPath, image.FileName));
                }
                post.UpdatedDate = DateTime.Now;
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        [Authorize(Roles = "Admin")]
        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.activeBlog = "active";
            ViewBag.HideBanner = true;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        [Authorize(Roles = "Admin")]
        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, HttpPostedFileBase image)
        {
            Post post = db.Posts.Find(id);
            if (image != null)
            {
                var absPath = Server.MapPath("~" + post.MediaUrl);  //DELETES IMAGE FROM FOLDER
                System.IO.File.Delete(absPath);
            }
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Disposes object in current controller
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
