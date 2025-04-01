using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Graduation_Project.Models.Entity;

namespace Graduation_Project.Controllers
{
    
    public class LendController : Controller
    {
        // GET: Lend
        DBLMSEntities2 db = new DBLMSEntities2();
        public ActionResult Index()
        {
            var values = db.TBLMOVEMENT.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult Lend()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Lend(TBLMOVEMENT p)
        {
            p.PURCHASEDATE = DateTime.Today;
            db.TBLMOVEMENT.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult ReturnTheLoan(int id)
        {
            var lon = db.TBLMOVEMENT.Find(id);
            return View("ReturnTheLoan", lon);

        }
    }
}