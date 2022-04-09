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
            
            var result11 = db.tbl_result11.ToList();
            return View(result11);
        }
        //public ActionResult GetList()
        //{
        //    var tbl_result11 = db.tbl_result11.Include(t => t.tbl_semester11_subject).Include(t => t.tbl_students);
            
        //    var c = db.tbl_result11.ToList();
        //    return View(c);
        //}
        
    }
}