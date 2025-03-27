using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Graduation_Project.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace Graduation_Project.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        DBLMSEntities2 db = new DBLMSEntities2();
        public ActionResult Index(int page = 1)
        {
            // var values = db.TBLUSERS.ToList();
            var values = db.TBLUSERS.ToList().ToPagedList(page, 10);
            return View(values);
        }
        [HttpGet]
        public ActionResult UsersAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UsersAdd(TBLUSERS p)
        {
            if (!ModelState.IsValid)
            {
                return View("UsersAdd");
            }
            db.TBLUSERS.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UsersDelete(int id)
        {
            var use = db.TBLUSERS.Find(id);
            db.TBLUSERS.Remove(use);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UsersCall(int id)
        {
            var use = db.TBLUSERS.Find(id);
            return View("UsersCall", use);
        }
        public ActionResult UsersUpdate(TBLUSERS p)
        {
            var use = db.TBLUSERS.Find(p.ID);
            use.NAME = p.NAME;
            use.SURNAME = p.SURNAME;
            use.MAIL = p.MAIL;
            use.USERNAME = p.USERNAME;
            use.PASSWORD = p.PASSWORD;
            use.PHONE = p.PHONE;
            use.SCHOOL= p.SCHOOL;
            use.PHOTO = p.PHOTO;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}