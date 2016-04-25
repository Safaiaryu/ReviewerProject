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
    public class ThreadsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUserManager _userManager;
        // GET: Threads
        public ActionResult Index()
        {
            return View(db.Threads.ToList());
        }

        public ActionResult AdminBugFixesList()
        {
            return View(db.Threads.ToList());
        }

        public ActionResult AdminReviewList()
        {
            return View(db.Threads.ToList());
        }

        public ActionResult ListThreads()
        {
            return View(db.Threads.ToList());
        }

        public ActionResult BugFixesList()
        {
            return View(db.Threads.ToList());
        }

        public ActionResult ReviewList()
        {
            return View(db.Threads.ToList());
        }


        public ActionResult ListOfThreadsByUser(string ID, string sortOrder, string searchString)
        {
            ViewBag.TitleSortParam = String.IsNullOrEmpty(sortOrder) ? "username_asc" : "";
            //var threads = db.Threads
            //    .Where(a => a.User.Id == ID)
            //    .ToList();

            var threads = from u in db.Threads
                           select u;

            var user = db.Users.Find(ID);

            if (!String.IsNullOrEmpty(searchString))
            {
                threads = threads.Where(u => u.Title.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "username_asc":
                    threads = threads.OrderBy(u => u.Title);
                    break;
            }

            ViewBag.UserName = user.UserName;
            return View(threads.Where(a => a.User.Id == ID));
        }

        // GET: Threads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thread thread = db.Threads.Find(id);
            if (thread == null)
            {
                return HttpNotFound();
            }
            return View(thread);
        }

        // GET: Threads/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Threads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,ThreadType,CategoryType,UserID")] Thread thread)
        {
            if (ModelState.IsValid)
            {
                thread.UserID = User.Identity.GetUserId();
                db.Threads.Add(thread);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thread);
        }

        // GET: Threads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thread thread = db.Threads.Find(id);
            if (thread == null)
            {
                return HttpNotFound();
            }
            return View(thread);
        }

        // POST: Threads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,ThreadType,CategoryType")] Thread thread)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thread).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thread);
        }

        // GET: Threads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thread thread = db.Threads.Find(id);
            if (thread == null)
            {
                return HttpNotFound();
            }
            return View(thread);
        }

        // POST: Threads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Thread thread = db.Threads.Find(id);
            db.Threads.Remove(thread);
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

        
    }
}
