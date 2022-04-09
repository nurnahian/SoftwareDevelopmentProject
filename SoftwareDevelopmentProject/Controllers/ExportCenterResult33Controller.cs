using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SoftwareDevelopmentProject.Models;

namespace SoftwareDevelopmentProject.Controllers
{
    public class ExportCenterResult33Controller : Controller
    {
        private DBdcsaContext db = new DBdcsaContext();
        public ActionResult Index()
        {
            var tbl_result11 = db.tbl_result33.Include(t => t.tbl_semester33_subject).Include(t => t.tbl_students);

            var CenterResult33 = db.tbl_result33.ToList();

            return View(CenterResult33);
        }
    }
}