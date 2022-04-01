using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SoftwareDevelopmentProject.Models;

namespace SoftwareDevelopmentProject.Controllers
{
    public class GenaretResult11Controller : Controller
    {
        // GET: GenaretResult11
        private DBdcsaContext db = new DBdcsaContext();
        public ActionResult Index()
        {
            var tbl_result11 = db.tbl_result11.Include(t => t.tbl_semester11_subject).Include(t => t.tbl_students);
            //var se=TempData["cen"];
            //List<tbl_result11> tbl_Result11 = db.tbl_result11.Where(r => r.st_study_center.Value(n=>n.)).ToList();
            //db.tbl_result11.SqlQuery("Select * from tbl_result11 where st_study_center'" + cen + "'").ToList();
            //db.tbl_result11.ToList();
            var c = db.tbl_result11.ToList();
            return View(c);
        }
        public ActionResult GetList()
        {
            var tbl_result11 = db.tbl_result11.Include(t => t.tbl_semester11_subject).Include(t => t.tbl_students);
            //var se=TempData["cen"];
            //List<tbl_result11> tbl_Result11 = db.tbl_result11.Where(r => r.st_study_center.Value(n=>n.)).ToList();
            //db.tbl_result11.SqlQuery("Select * from tbl_result11 where st_study_center'" + cen + "'").ToList();
            //db.tbl_result11.ToList();
            var c = db.tbl_result11.ToList();
            return View(c);
        }
        
    }
}