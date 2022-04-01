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
    public class Result11Controller : Controller
    {
        private DBdcsaContext db = new DBdcsaContext();

        //int userid = Membership.GetUser(User.Identity.Name).ProviderUserKey;
        //int userid = db.tbl_users(.Identity.Name).ProviderUserKey;
        // GET: Result11

        
        [HttpGet]    
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

        // GET: Result11/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_result11 tbl_result11 = db.tbl_result11.Find(id);
            if (tbl_result11 == null)
            {
                return HttpNotFound();
            }
            return View(tbl_result11);
        }

        // GET: Result11/Create
        public ActionResult Create()
        {
            ViewBag.s11_course_code = new SelectList(db.tbl_semester11_subject, "s11_course_code", "s11_course_name");
            ViewBag.st_registration = new SelectList(db.tbl_students, "st_registration", "st_registration");
            
            return View();
        }

        // POST: Result11/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "result11_id,st_registration,s11_course_code,experment_mark1,book_mark2,viva_mark3,tma_mark1,tma_mark2,total_practical_mark,total_tma_mark,exam_term,st_study_center,submit_date")] tbl_result11 tbl_result11)
        {
            tbl_result11.total_practical_mark = tbl_result11.experment_mark1 + tbl_result11.book_mark2 + tbl_result11.viva_mark3;
            tbl_result11.total_tma_mark = tbl_result11.tma_mark1 + tbl_result11.tma_mark2;
            tbl_result11.submit_date = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.tbl_result11.Add(tbl_result11);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.s11_course_code = new SelectList(db.tbl_semester11_subject, "s11_course_code", "s11_course_name", tbl_result11.s11_course_code);
            ViewBag.st_registration = new SelectList(db.tbl_students, "st_registration", "st_name", tbl_result11.st_registration);
            return View(tbl_result11);
        }

        // GET: Result11/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_result11 tbl_result11 = db.tbl_result11.Find(id);
            if (tbl_result11 == null)
            {
                return HttpNotFound();
            }
            ViewBag.s11_course_code = new SelectList(db.tbl_semester11_subject, "s11_course_code", "s11_course_name", tbl_result11.s11_course_code);
            ViewBag.st_registration = new SelectList(db.tbl_students, "st_registration", "st_name", tbl_result11.st_registration);
            return View(tbl_result11);
        }

        // POST: Result11/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "result11_id,st_registration,s11_course_code,experment_mark1,book_mark2,viva_mark3,tma_mark1,tma_mark2,total_practical_mark,total_tma_mark,exam_term,st_study_center,submit_date")] tbl_result11 tbl_result11)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_result11).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.s11_course_code = new SelectList(db.tbl_semester11_subject, "s11_course_code", "s11_course_name", tbl_result11.s11_course_code);
            ViewBag.st_registration = new SelectList(db.tbl_students, "st_registration", "st_name", tbl_result11.st_registration);
            return View(tbl_result11);
        }

        // GET: Result11/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_result11 tbl_result11 = db.tbl_result11.Find(id);
            if (tbl_result11 == null)
            {
                return HttpNotFound();
            }
            return View(tbl_result11);
        }

        // POST: Result11/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_result11 tbl_result11 = db.tbl_result11.Find(id);
            db.tbl_result11.Remove(tbl_result11);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
