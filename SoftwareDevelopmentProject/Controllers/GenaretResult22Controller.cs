using SoftwareDevelopmentProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace SoftwareDevelopmentProject.Controllers
{
    public class GenaretResult22Controller : Controller
    {
        private DBdcsaContext db = new DBdcsaContext();
        public ActionResult Index()
        {
            var tbl_result11 = db.tbl_result22.Include(t => t.tbl_semester22_subject).Include(t => t.tbl_students);

            var result22 = db.tbl_result22.ToList();
            return View(result22);
        }
    }
}