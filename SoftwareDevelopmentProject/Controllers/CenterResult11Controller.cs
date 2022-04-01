using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SoftwareDevelopmentProject.Models;

namespace SoftwareDevelopmentProject.Controllers
{
    public class CenterResult11Controller : Controller
    {
        private DBdcsaContext db = new DBdcsaContext();

        // GET: CenterResult11
        public ActionResult Index()
        {
            var tbl_result11 = db.tbl_result11.Include(t => t.tbl_semester11_subject).Include(t => t.tbl_students);
            //var st = 810;//Session["810"];
            
            //tbl_result11.ToList().Where(m=>m.st_study_center.Equals(st));
           return View(tbl_result11.ToList());
            //.GroupBy(m => m.st_registration)
              // return View(tbl_result11.ToList().Where(m => m.st_study_center.Equals(st)));
        }

        // GET: CenterResult11/Details/5
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

        // GET: CenterResult11/Create
        public ActionResult Create()
        {
            ViewBag.s11_course_code = new SelectList(db.tbl_semester11_subject, "s11_course_code", "s11_course_code");
            ViewBag.st_registration = new SelectList(db.tbl_students, "st_registration", "st_name");
            return View();
        }

        // POST: CenterResult11/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "result11_id,st_registration,s11_course_code,experment_mark1,book_mark2,viva_mark3,tma_mark1,tma_mark2,total_practical_mark,total_tma_mark,exam_term,st_study_center,submit_date")] tbl_result11 tbl_result11)
        {
            tbl_result11.total_practical_mark = tbl_result11.experment_mark1 + tbl_result11.book_mark2+ tbl_result11.viva_mark3;
            tbl_result11.total_tma_mark = tbl_result11.tma_mark1 + tbl_result11.tma_mark2;
            tbl_result11.submit_date = DateTime.Now;
            
            if (ModelState.IsValid)
            {
                db.tbl_result11.Add(tbl_result11);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.s11_course_code = new SelectList(db.tbl_semester11_subject, "s11_course_code", "s11_course_code", tbl_result11.s11_course_code);
            ViewBag.st_registration = new SelectList(db.tbl_students, "st_registration", "st_name", tbl_result11.st_registration);
            return View(tbl_result11);
        }

        // GET: CenterResult11/Edit/5
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
            ViewBag.s11_course_code = new SelectList(db.tbl_semester11_subject, "s11_course_code", "s11_course_code", tbl_result11.s11_course_code);
            ViewBag.st_registration = new SelectList(db.tbl_students, "st_registration", "st_name", tbl_result11.st_registration);
            return View(tbl_result11);
        }

        // POST: CenterResult11/Edit/5
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
            ViewBag.s11_course_code = new SelectList(db.tbl_semester11_subject, "s11_course_code", "s11_course_code", tbl_result11.s11_course_code);
            ViewBag.st_registration = new SelectList(db.tbl_students, "st_registration", "st_name", tbl_result11.st_registration);
            return View(tbl_result11);
        }

        // GET: CenterResult11/Delete/5
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

        // POST: CenterResult11/Delete/5
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
