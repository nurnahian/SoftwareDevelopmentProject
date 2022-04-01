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
    public class StudentsController : Controller
    {
        private DBdcsaContext db = new DBdcsaContext();

        // GET: Students
        public ActionResult Index()
        {
            var tbl_students = db.tbl_students.Include(t => t.tbl_studyCenter);
            return View(tbl_students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_students tbl_students = db.tbl_students.Find(id);
            if (tbl_students == null)
            {
                return HttpNotFound();
            }
            return View(tbl_students);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.st_study_center_code = new SelectList(db.tbl_studyCenter, "study_center_code", "study_center_code");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "st_id,st_registration,st_name,st_admission_year,st_semester11,st_semester22,st_semester33,st_study_center_code")] tbl_students tbl_students)
        {
            if (ModelState.IsValid)
            {
                db.tbl_students.Add(tbl_students);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.st_study_center_code = new SelectList(db.tbl_studyCenter, "study_center_code", "study_center_code", tbl_students.st_study_center_code);
            return View(tbl_students);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_students tbl_students = db.tbl_students.Find(id);
            if (tbl_students == null)
            {
                return HttpNotFound();
            }
            ViewBag.st_study_center_code = new SelectList(db.tbl_studyCenter, "study_center_code", "study_center_code", tbl_students.st_study_center_code);
            return View(tbl_students);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "st_id,st_registration,st_name,st_admission_year,st_semester11,st_semester22,st_semester33,st_study_center_code")] tbl_students tbl_students)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_students).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.st_study_center_code = new SelectList(db.tbl_studyCenter, "study_center_code", "study_center_code", tbl_students.st_study_center_code);
            return View(tbl_students);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_students tbl_students = db.tbl_students.Find(id);
            if (tbl_students == null)
            {
                return HttpNotFound();
            }
            return View(tbl_students);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbl_students tbl_students = db.tbl_students.Find(id);
            db.tbl_students.Remove(tbl_students);
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
