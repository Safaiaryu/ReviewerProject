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
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View(db.Jobs.ToList());
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

        [AuthorizeOrRedirectAttribute(Roles = "Site Admin")]
        public ActionResult Admin()
        {
            return View();
        }

        [AuthorizeOrRedirectAttribute(Roles = "Site Admin,Game Element Admin")]
        public ActionResult GameElementAdmin()
        {
            return View();
        }

    }
}