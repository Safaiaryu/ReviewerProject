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
    public class AbilitiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Abilities
        [AuthorizeOrRedirectAttribute(Roles = "Site Admin,Game Element Admin")]
        public ActionResult Index()
        {
            return View(db.Abilities.ToList());
        }

        public ActionResult ListAbilities()
        {
            return View(db.Abilities.ToList());
        }

        // GET: Abilities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ability ability = db.Abilities.Find(id);
            if (ability == null)
            {
                return HttpNotFound();
            }
            return View(ability);
        }

        // GET: Abilities/Create
        [AuthorizeOrRedirectAttribute(Roles = "Site Admin,Game Element Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Abilities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeOrRedirectAttribute(Roles = "Site Admin,Game Element Admin")]
        public ActionResult Create([Bind(Include = "ID,Name,Load,APCost,CoolDown,Power,Description")] Ability ability)
        {
            if (ModelState.IsValid)
            {
                db.Abilities.Add(ability);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ability);
        }

        // GET: Abilities/Edit/5
        [AuthorizeOrRedirectAttribute(Roles = "Site Admin,Game Element Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ability ability = db.Abilities.Find(id);
            if (ability == null)
            {
                return HttpNotFound();
            }
            return View(ability);
        }

        // POST: Abilities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeOrRedirectAttribute(Roles = "Site Admin,Game Element Admin")]
        public ActionResult Edit([Bind(Include = "ID,Name,Load,APCost,CoolDown,Power,Description")] Ability ability)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ability).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ability);
        }

        // GET: Abilities/Delete/5
        [AuthorizeOrRedirectAttribute(Roles = "Site Admin,Game Element Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ability ability = db.Abilities.Find(id);
            if (ability == null)
            {
                return HttpNotFound();
            }
            return View(ability);
        }

        // POST: Abilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AuthorizeOrRedirectAttribute(Roles = "Site Admin,Game Element Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Ability ability = db.Abilities.Find(id);
            db.Abilities.Remove(ability);
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
