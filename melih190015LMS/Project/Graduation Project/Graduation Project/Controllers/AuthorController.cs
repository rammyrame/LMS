using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Graduation_Project.Models.Entity;

namespace Graduation_Project.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        DBLMSEntities2 db = new DBLMSEntities2();
        public ActionResult Index()
        {
            var values = db.TBLAUTHOR.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }
        public ActionResult AddAuthor(TBLAUTHOR p)
        {
            db.TBLAUTHOR.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult DeleteAuthor(int id)
        {
            var author = db.TBLAUTHOR.Find(id);
            db.TBLAUTHOR.Remove(author);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AuthorCall(int id)
        {
            var ath = db.TBLAUTHOR.Find(id);
            return View("AuthorCall", ath);
        }
        public ActionResult UpdateAuthor(TBLAUTHOR p)
        {
            var aut = db.TBLAUTHOR.Find(p.ID);
            aut.NAME = p.NAME;
            aut.SURNAME = p.SURNAME;
            aut.DETAILS = p.DETAILS;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}