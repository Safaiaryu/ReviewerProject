using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ReviewerProject.Models;
using Microsoft.AspNet.Identity;

namespace ReviewerProject.Controllers
{
    public class ThreadCommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ThreadComments
        public ActionResult Index()
        {
            return View(db.Comments.ToList());
        }


        public ActionResult ListOfCommentsByUser(string ID, string sortOrder, string searchString)
        {
            ViewBag.ContentSortParam = String.IsNullOrEmpty(sortOrder) ? "username_asc" : "";

            //var comments = db.Comments
            //    .Where(a => a.User.Id == ID)
            //    .ToList();

            var comments = from u in db.Comments
                        select u;

            var user = db.Users.Find(ID);

            if (!String.IsNullOrEmpty(searchString))
            {
                comments = comments.Where(u => u.Content.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "username_asc":
                    comments = comments.OrderBy(u => u.Content);
                    break;
            }

            ViewBag.UserName = user.UserName;
            return View(comments.Where(a => a.User.Id == ID));
        }


        // GET: ThreadComments/Details/5
        public ActionResult Details(int? id)
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

        // GET: ThreadComments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ThreadComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Content,ThreadID,UserID")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.UserID = User.Identity.GetUserId();
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(comment);
        }

        // GET: ThreadComments/Edit/5
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
            return View(comment);
        }

        // POST: ThreadComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Content,ThreadID")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comment);
        }

        // GET: ThreadComments/Delete/5
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

        // POST: ThreadComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult ListOfCommentsByThread(int ID)
        {
            var comments = db.Comments
                .Where(a => a.ThreadID == ID)
                .ToList();

            var thread = db.Threads.Find(ID);
            ViewBag.ThreadTitle = thread.Title;
            ViewBag.ThreadID = thread.ID;

            return View(comments);
        }

        //public ActionResult ListOfCommentsByUser(int ID)
        //{
        //    var comments = db.Comments
        //        .Where(a => a.User.ID == ID)
        //}

        //User creates a review
        [HttpGet]
        public ActionResult UserCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserCreate(Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("ListOfCommentsByThread", new { id = comment.ThreadID });
            }

            return View(comment);
        }
    }
}
