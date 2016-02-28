using System;
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
    public class EidolonsController : Controller
    {
        private FFE_Db db = new FFE_Db();

        // GET: Eidolons
        public ActionResult Index()
        {
            return View(db.Eidolons.ToList());
        }

        // GET: Eidolons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eidolon eidolon = db.Eidolons.Find(id);
            if (eidolon == null)
            {
                return HttpNotFound();
            }
            return View(eidolon);
        }

        // GET: Eidolons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Eidolons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EidolonName,Description,MagiciteAbilty")] Eidolon eidolon)
        {
            if (ModelState.IsValid)
            {
                db.Eidolons.Add(eidolon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eidolon);
        }

        // GET: Eidolons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eidolon eidolon = db.Eidolons.Find(id);
            if (eidolon == null)
            {
                return HttpNotFound();
            }
            return View(eidolon);
        }

        // POST: Eidolons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EidolonName,Description,MagiciteAbilty")] Eidolon eidolon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eidolon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eidolon);
        }

        // GET: Eidolons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eidolon eidolon = db.Eidolons.Find(id);
            if (eidolon == null)
            {
                return HttpNotFound();
            }
            return View(eidolon);
        }

        // POST: Eidolons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Eidolon eidolon = db.Eidolons.Find(id);
            db.Eidolons.Remove(eidolon);
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
