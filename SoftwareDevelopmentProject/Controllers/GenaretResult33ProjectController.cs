using SoftwareDevelopmentProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace SoftwareDevelopmentProject.Controllers
{
    public class GenaretResult33ProjectController : Controller
    {
        private DBdcsaContext db = new DBdcsaContext();
        public ActionResult Index()
        {
            var tbl_result11 = db.tbl_result33_project.Include(t => t.tbl_semester33_subject).Include(t => t.tbl_students);

            var result11 = db.tbl_result33_project.ToList();
            return View(result11);
        }
    }
}