using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Graduation_Project.Models.Entity;

namespace Graduation_Project.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        DBLMSEntities2 db = new DBLMSEntities2();
        public ActionResult Index()
        {
            var books = db.TBLBOOK.ToList();
            return View(books);
        }
        [HttpGet]
        public ActionResult AddBook()
        {
            List<SelectListItem> value1 = (from i in db.TBLCATEGORY.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.NAME,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.vle1 = value1;
           

            List<SelectListItem> value2 = (from i in db.TBLAUTHOR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.NAME + ' ' + i.SURNAME,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.vle2 = value2;
            return View();
        }
        [HttpPost]
        public ActionResult AddBook(TBLBOOK p)
        {
            p.SITUATION = true;
            var ctg = db.TBLCATEGORY.Where(c => c.ID == p.TBLCATEGORY.ID).FirstOrDefault();
            var aut = db.TBLAUTHOR.Where(a => a.ID == p.TBLAUTHOR.ID).FirstOrDefault();
            p.TBLCATEGORY = ctg;
            p.TBLAUTHOR = aut;
            db.TBLBOOK.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteBook(int id)
        {
            var book = db.TBLBOOK.Find(id);
            db.TBLBOOK.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BookCall(int id)
        {
            var bk = db.TBLBOOK.Find(id);
            List<SelectListItem> value1 = (from i in db.TBLCATEGORY.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.NAME,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.vle1 = value1;
            List<SelectListItem> value2 = (from i in db.TBLAUTHOR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.NAME + ' ' + i.SURNAME,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.vle2 = value2;
            return View("BookCall", bk);
        }
        public ActionResult UpdateBook(TBLBOOK p)
        {
            p.SITUATION = true;
            var book = db.TBLBOOK.Find(p.ID);
            book.NAME = p.NAME;
            book.PRINTEDYEAR = p.PRINTEDYEAR;
            book.PAGE = p.PAGE;
            book.PUBLISHER = p.PUBLISHER;
            var ctg = db.TBLCATEGORY.Where(c => c.ID == p.TBLCATEGORY.ID).FirstOrDefault();
            var aut = db.TBLAUTHOR.Where(a => a.ID == p.TBLAUTHOR.ID).FirstOrDefault();
            book.CATEGORY = ctg.ID;
            book.AUTHOR = aut.ID;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Find(string p)
        {
            var books = db.TBLBOOK.Where(x => x.NAME.Contains(p)).ToList();

            ViewBag.p = p;
            return View("Index", books);
        }

    }
}