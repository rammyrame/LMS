using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Graduation_Project.Models.Entity;

namespace Graduation_Project.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        DBLMSEntities2 db = new DBLMSEntities2();
        public ActionResult Index()
        {
            var values = db.TBLSTAFF.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult StaffAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult StaffAdd(TBLSTAFF p)
        {
            if(!ModelState.IsValid)
            {
                return View("StaffAdd");
            }
            db.TBLSTAFF.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult StaffDelete(int id)
        {
            var stf= db.TBLSTAFF.Find(id);
            db.TBLSTAFF.Remove(stf);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult StaffCall(int id)
        {
            var sft = db.TBLSTAFF.Find(id);
            return View("StaffCall", sft);
        }
        public ActionResult StaffUpdate(TBLSTAFF p)
        {
            var sft= db.TBLSTAFF.Find(p.ID);
            sft.STAFF = p.STAFF;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}