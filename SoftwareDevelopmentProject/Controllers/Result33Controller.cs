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
    public class Result33Controller : Controller
    {
        private DBdcsaContext db = new DBdcsaContext();

        // GET: Result33
        public ActionResult Index()
        {
            var tbl_result33 = db.tbl_result33.Include(t => t.tbl_semester33_subject).Include(t => t.tbl_students);
            return View(tbl_result33.ToList());
        }

        // GET: Result33/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_result33 tbl_result33 = db.tbl_result33.Find(id);
            if (tbl_result33 == null)
            {
                return HttpNotFound();
            }
            return View(tbl_result33);
        }

        // GET: Result33/Create
        public ActionResult Create()
        {
            ViewBag.s33_course_code = new SelectList(db.tbl_semester33_subject, "s33_course_code", "s33_course_code");
            ViewBag.st_registration = new SelectList(db.tbl_students, "st_registration", "st_registration");
            return View();
        }

        // POST: Result33/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "result33_id,st_registration,s33_course_code,experment_mark1,book_mark2,viva_mark3,tma_mark1,tma_mark2,total_practical_mark,total_tma_mark,exam_term,st_study_center,submit_date")] tbl_result33 tbl_result33)
        {
            if (ModelState.IsValid)
            {
                db.tbl_result33.Add(tbl_result33);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.s33_course_code = new SelectList(db.tbl_semester33_subject, "s33_course_code", "s33_course_code", tbl_result33.s33_course_code);
            ViewBag.st_registration = new SelectList(db.tbl_students, "st_registration", "st_registration", tbl_result33.st_registration);
            return View(tbl_result33);
        }

        // GET: Result33/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_result33 tbl_result33 = db.tbl_result33.Find(id);
            if (tbl_result33 == null)
            {
                return HttpNotFound();
            }
            ViewBag.s33_course_code = new SelectList(db.tbl_semester33_subject, "s33_course_code", "s33_course_code", tbl_result33.s33_course_code);
            ViewBag.st_registration = new SelectList(db.tbl_students, "st_registration", "st_registration", tbl_result33.st_registration);
            return View(tbl_result33);
        }

        // POST: Result33/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "result33_id,st_registration,s33_course_code,experment_mark1,book_mark2,viva_mark3,tma_mark1,tma_mark2,total_practical_mark,total_tma_mark,exam_term,st_study_center,submit_date")] tbl_result33 tbl_result33)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_result33).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.s33_course_code = new SelectList(db.tbl_semester33_subject, "s33_course_code", "s33_course_code", tbl_result33.s33_course_code);
            ViewBag.st_registration = new SelectList(db.tbl_students, "st_registration", "st_registration", tbl_result33.st_registration);
            return View(tbl_result33);
        }

        // GET: Result33/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_result33 tbl_result33 = db.tbl_result33.Find(id);
            if (tbl_result33 == null)
            {
                return HttpNotFound();
            }
            return View(tbl_result33);
        }

        // POST: Result33/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_result33 tbl_result33 = db.tbl_result33.Find(id);
            db.tbl_result33.Remove(tbl_result33);
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
