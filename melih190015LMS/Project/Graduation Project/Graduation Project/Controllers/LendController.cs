using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
            var values = db.TBLMOVEMENT.Where(x => x.PROCESSTATUS == false).ToList();
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
            p.RETURNDATE = DateTime.Today.AddDays(7);
            p.PROCESSTATUS = false;
            db.TBLMOVEMENT.Add(p);
            var book = db.TBLBOOK.Find(p.BOOK);
            if(book !=null)
            {
                book.SITUATION = false;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ReturnTheLoan(int id)
        {
            var lon = db.TBLMOVEMENT.Find(id);
            return View("ReturnTheLoan", lon);

        }
        public ActionResult LoanUpdate(TBLMOVEMENT p)
        {
            var lan = db.TBLMOVEMENT.Find(p.ID);
            lan.RETURNEDDATE= p.RETURNEDDATE;
            lan.PROCESSTATUS = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}