using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Graduation_Project.Models.Entity;

namespace Graduation_Project.Controllers
{
    public class OperationsController : Controller
    {
        // GET: Operations
        DBLMSEntities2 db = new DBLMSEntities2();
        public ActionResult Index()
        {
            var values = db.TBLMOVEMENT.Where(x => x.PROCESSTATUS == true).ToList();
            return View(values);
        }
    }
}