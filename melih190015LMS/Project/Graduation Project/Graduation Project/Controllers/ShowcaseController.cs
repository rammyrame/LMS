using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Graduation_Project.Models.Entity;
using Graduation_Project.Models.Classes;

namespace Graduation_Project.Controllers
{
    public class ShowcaseController : Controller
    {
        // GET: Showcase
        DBLMSEntities2 db = new DBLMSEntities2();

        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Values1 = db.TBLBOOK.ToList();
            cs.Values2 = db.TBLABOUT.ToList();
            //var values = db.TBLBOOK.ToList();
            return View(cs);
        }
        [HttpPost]
        public ActionResult Index(TBLCONTACT t)
        {
            db.TBLCONTACT.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}