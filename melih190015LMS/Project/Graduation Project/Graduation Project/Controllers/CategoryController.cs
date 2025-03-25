using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Graduation_Project.Models.Entity;

namespace Graduation_Project.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DBLMSEntities2 db = new DBLMSEntities2();
        public ActionResult Index()
        {
            try
            {
                var values = db.TBLCATEGORY.ToList();

                if (values == null || !values.Any())
                {
                    ViewBag.Message = "There is no category yet.";
                }

                return View(values);
            }
            catch (Exception ex)
            {

                ViewBag.Error = "An error occurred while loading data: " + ex.Message;
                return View(new List<TBLCATEGORY>());
            }
        }
        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoryAdd(TBLCATEGORY p)
        {
            db.TBLCATEGORY.Add(p);
            db.SaveChanges();
            return View();
        }

        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult CategoryDelete(int id)
        {
            var category = db.TBLCATEGORY.Find(id);
            db.TBLCATEGORY.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CategoryCall(int id)
        {
            var ctg = db.TBLCATEGORY.Find(id);
            return View("CategoryCall",ctg);
        }
        public ActionResult CategoryUpdate(TBLCATEGORY p)
        {
            var ctg = db.TBLCATEGORY.Find(p.ID);
            ctg.NAME = p.NAME;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
