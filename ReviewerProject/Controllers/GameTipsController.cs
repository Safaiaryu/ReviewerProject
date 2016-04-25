using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ReviewerProject.Models;
using ReviewerProject.CustomAttribute;

namespace ReviewerProject.Controllers
{
    public class GameTipsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GameTips
        [AuthorizeOrRedirectAttribute(Roles = "Site Admin")]
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.TitleSortParam = String.IsNullOrEmpty(sortOrder) ? "title_asc" : "";
            ViewBag.ContentSortParam = sortOrder == "content_asc" ? "content_desc" : "content_asc";

            var db = new ApplicationDbContext();
            var gameTips = from u in db.GameTips
                        select u;

            if (!String.IsNullOrEmpty(searchString))
            {
                gameTips = gameTips.Where(u => u.Title.Contains(searchString)
                                       || u.Content.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "title_asc":
                    gameTips = gameTips.OrderBy(u => u.Title);
                    break;
                case "content_desc":
                    gameTips = gameTips.OrderByDescending(u => u.Content);
                    break;
                case "content_asc":
                    gameTips = gameTips.OrderBy(u => u.Content);
                    break;
            }

            return View(gameTips.ToList());
        }

        public ActionResult ListOfTipsByEidolon(int ID)
        {
            var tips = db.GameTips
                .Where(a => a.EidolonID == ID )
                .ToList();

            var eidolon = db.Eidolons.Find(ID);
            ViewBag.EidolonTitle = eidolon.EidolonName;
            ViewBag.EidolonID = eidolon.ID;

            return View(tips);
        }

        public ActionResult ListOfTipsByEidolonUser(int ID)
        {
            var tips = db.GameTips
                .Where(a => a.EidolonID == ID)
                .ToList();

            var eidolon = db.Eidolons.Find(ID);
            ViewBag.EidolonTitle = eidolon.EidolonName;
            ViewBag.EidolonID = eidolon.ID;

            return View(tips);
        }

        public ActionResult ListOfTipsByJob(int ID)
        {
            var tips = db.GameTips
                .Where(a => a.JobID == ID)
                .ToList();

            var job = db.Jobs.Find(ID);
            ViewBag.JobTitle = job.JobName;
            ViewBag.JobID = job.ID;

            return View(tips);
        }

        public ActionResult ListOfTipsByJobUser(int ID)
        {
            var tips = db.GameTips
                .Where(a => a.JobID == ID)
                .ToList();

            var job = db.Jobs.Find(ID);
            ViewBag.JobTitle = job.JobName;
            ViewBag.JobID = job.ID;

            return View(tips);
        }

        public ActionResult ListOfTipsByQuest(int ID)
        {
            var tips = db.GameTips
                .Where(a => a.QuestID == ID)
                .ToList();

            var quest = db.Quests.Find(ID);
            ViewBag.QuestTitle = quest.Title;
            ViewBag.QuestID = quest.ID;

            return View(tips);
        }

        public ActionResult ListOfTipsByQuestUser(int ID)
        {
            var tips = db.GameTips
                .Where(a => a.QuestID == ID)
                .ToList();

            var quest = db.Quests.Find(ID);
            ViewBag.QuestTitle = quest.Title;
            ViewBag.QuestID = quest.ID;

            return View(tips);
        }

        // GET: GameTips/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameTips gameTips = db.GameTips.Find(id);
            if (gameTips == null)
            {
                return HttpNotFound();
            }
            return View(gameTips);
        }

        // GET: GameTips/Create
        [AuthorizeOrRedirectAttribute(Roles = "Site Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: GameTips/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeOrRedirectAttribute(Roles = "Site Admin")]
        public ActionResult Create([Bind(Include = "ID,Title,Content,ImageURL,EidolonID,JobID,QuestID")] GameTips gameTips)
        {
            if (ModelState.IsValid)
            {
                db.GameTips.Add(gameTips);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gameTips);
        }

        // GET: GameTips/Edit/5
        [AuthorizeOrRedirectAttribute(Roles = "Site Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameTips gameTips = db.GameTips.Find(id);
            if (gameTips == null)
            {
                return HttpNotFound();
            }
            return View(gameTips);
        }

        // POST: GameTips/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeOrRedirectAttribute(Roles = "Site Admin")]
        public ActionResult Edit([Bind(Include = "ID,Title,Content,ImageURL")] GameTips gameTips)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gameTips).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gameTips);
        }

        // GET: GameTips/Delete/5
        [AuthorizeOrRedirectAttribute(Roles = "Site Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameTips gameTips = db.GameTips.Find(id);
            if (gameTips == null)
            {
                return HttpNotFound();
            }
            return View(gameTips);
        }

        // POST: GameTips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AuthorizeOrRedirectAttribute(Roles = "Site Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            GameTips gameTips = db.GameTips.Find(id);
            db.GameTips.Remove(gameTips);
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
