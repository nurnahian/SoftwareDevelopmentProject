using SoftwareDevelopmentProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace SoftwareDevelopmentProject.Controllers
{
    public class ExportCenterResult11Controller : Controller
    {
        // GET: ExportCenterResult11
       private DBdcsaContext db = new DBdcsaContext();
        public ActionResult Index()
        {
            var st = Convert.ToInt32(Session["Ucenter"]);
            var tbl_result11 = db.tbl_result11.Include(t => t.tbl_semester11_subject).Include(t => t.tbl_students);
            var CenterResult11 = db.tbl_result11.Where(r => r.st_study_center == st).ToList();
            return View(CenterResult11);
        }
    }
}