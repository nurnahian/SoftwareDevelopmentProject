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
    public class Result33ProjectController : Controller
    {
        private DBdcsaContext db = new DBdcsaContext();

        // GET: Result33Project
        public ActionResult Index()
        {
            var tbl_result33_project = db.tbl_result33_project.Include(t => t.tbl_semester33_subject).Include(t => t.tbl_students);
            return View(tbl_result33_project.ToList());
        }

        // GET: Result33Project/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_result33_project tbl_result33_project = db.tbl_result33_project.Find(id);
            if (tbl_result33_project == null)
            {
                return HttpNotFound();
            }
            return View(tbl_result33_project);
        }

        // GET: Result33Project/Create
        public ActionResult Create()
        {
            ViewBag.s33_course_code = new SelectList(db.tbl_semester33_subject, "s33_course_code", "s33_course_name");
            ViewBag.st_registration = new SelectList(db.tbl_students, "st_registration", "st_name");
            return View();
        }

        // POST: Result33Project/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "result33_project_id,st_registration,s33_course_code,project_report,viva,exam_term,st_study_center,submit_date")] tbl_result33_project tbl_result33_project)
        {
            if (ModelState.IsValid)
            {
                db.tbl_result33_project.Add(tbl_result33_project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.s33_course_code = new SelectList(db.tbl_semester33_subject, "s33_course_code", "s33_course_name", tbl_result33_project.s33_course_code);
            ViewBag.st_registration = new SelectList(db.tbl_students, "st_registration", "st_name", tbl_result33_project.st_registration);
            return View(tbl_result33_project);
        }

        // GET: Result33Project/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_result33_project tbl_result33_project = db.tbl_result33_project.Find(id);
            if (tbl_result33_project == null)
            {
                return HttpNotFound();
            }
            ViewBag.s33_course_code = new SelectList(db.tbl_semester33_subject, "s33_course_code", "s33_course_name", tbl_result33_project.s33_course_code);
            ViewBag.st_registration = new SelectList(db.tbl_students, "st_registration", "st_name", tbl_result33_project.st_registration);
            return View(tbl_result33_project);
        }

        // POST: Result33Project/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "result33_project_id,st_registration,s33_course_code,project_report,viva,exam_term,st_study_center,submit_date")] tbl_result33_project tbl_result33_project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_result33_project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.s33_course_code = new SelectList(db.tbl_semester33_subject, "s33_course_code", "s33_course_name", tbl_result33_project.s33_course_code);
            ViewBag.st_registration = new SelectList(db.tbl_students, "st_registration", "st_name", tbl_result33_project.st_registration);
            return View(tbl_result33_project);
        }

        // GET: Result33Project/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_result33_project tbl_result33_project = db.tbl_result33_project.Find(id);
            if (tbl_result33_project == null)
            {
                return HttpNotFound();
            }
            return View(tbl_result33_project);
        }

        // POST: Result33Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_result33_project tbl_result33_project = db.tbl_result33_project.Find(id);
            db.tbl_result33_project.Remove(tbl_result33_project);
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
