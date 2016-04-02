﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ReviewerProject.Models;

namespace ReviewerProject.Controllers
{
    public class QuestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Quests
        public ActionResult Index()
        {
            return View(db.Quests.ToList());
        }

        public ActionResult ListQuests()
        {
            return View(db.Quests.ToList());
        }

        // GET: Quests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quest quest = db.Quests.Find(id);
            if (quest == null)
            {
                return HttpNotFound();
            }
            return View(quest);
        }

        // GET: Quests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Quests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,StarLevel,Time")] Quest quest)
        {
            if (ModelState.IsValid)
            {
                db.Quests.Add(quest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quest);
        }

        // GET: Quests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quest quest = db.Quests.Find(id);
            if (quest == null)
            {
                return HttpNotFound();
            }
            return View(quest);
        }

        // POST: Quests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,StarLevel,Time")] Quest quest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quest);
        }

        // GET: Quests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quest quest = db.Quests.Find(id);
            if (quest == null)
            {
                return HttpNotFound();
            }
            return View(quest);
        }

        // POST: Quests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Quest quest = db.Quests.Find(id);
            db.Quests.Remove(quest);
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
