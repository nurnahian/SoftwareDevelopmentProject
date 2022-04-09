using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SoftwareDevelopmentProject.Models;

namespace SoftwareDevelopmentProject.Controllers
{
    public class ExportCenterResult33ProjectController : Controller
    {
        private DBdcsaContext db = new DBdcsaContext();
        public ActionResult Index()
        {
            var tbl_result11 = db.tbl_result33_project.Include(t => t.tbl_semester33_subject).Include(t => t.tbl_students);
            var CenterResult33Project = db.tbl_result33_project.ToList();
            return View(CenterResult33Project);
        }
    }
}