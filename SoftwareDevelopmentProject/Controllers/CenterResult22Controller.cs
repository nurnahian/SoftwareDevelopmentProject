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
    public class CenterResult22Controller : Controller
    {
        private DBdcsaContext db = new DBdcsaContext();

        // GET: CenterResult22
        public ActionResult Index()
        {
            var tbl_result22 = db.tbl_result22.Include(t => t.tbl_semester22_subject).Include(t => t.tbl_students);
            return View(tbl_result22.ToList());
        }

        // GET: CenterResult22/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_result22 tbl_result22 = db.tbl_result22.Find(id);
            if (tbl_result22 == null)
            {
                return HttpNotFound();
            }
            return View(tbl_result22);
        }

        // GET: CenterResult22/Create
        public ActionResult Create()
        {
            ViewBag.s22_course_code = new SelectList(db.tbl_semester22_subject, "s22_course_code", "s22_course_code");
            ViewBag.st_registration = new SelectList(db.tbl_students, "st_registration", "st_registration");
            return View();
        }

        // POST: CenterResult22/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "result22_id,st_registration,s22_course_code,experment_mark1,book_mark2,viva_mark3,tma_mark1,tma_mark2,total_practical_mark,total_tma_mark,exam_term,st_study_center,submit_date")] tbl_result22 tbl_result22)
        {
            tbl_result22.total_practical_mark = tbl_result22.experment_mark1 + tbl_result22.book_mark2 + tbl_result22.viva_mark3;
            tbl_result22.total_tma_mark = tbl_result22.tma_mark1 + tbl_result22.tma_mark2;
            tbl_result22.submit_date = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.tbl_result22.Add(tbl_result22);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.s22_course_code = new SelectList(db.tbl_semester22_subject, "s22_course_code", "s22_course_code", tbl_result22.s22_course_code);
            ViewBag.st_registration = new SelectList(db.tbl_students, "st_registration", "st_registration", tbl_result22.st_registration);
            return View(tbl_result22);
        }

        // GET: CenterResult22/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_result22 tbl_result22 = db.tbl_result22.Find(id);
            if (tbl_result22 == null)
            {
                return HttpNotFound();
            }
            ViewBag.s22_course_code = new SelectList(db.tbl_semester22_subject, "s22_course_code", "s22_course_code", tbl_result22.s22_course_code);
            ViewBag.st_registration = new SelectList(db.tbl_students, "st_registration", "st_registration", tbl_result22.st_registration);
            return View(tbl_result22);
        }

        // POST: CenterResult22/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "result22_id,st_registration,s22_course_code,experment_mark1,book_mark2,viva_mark3,tma_mark1,tma_mark2,total_practical_mark,total_tma_mark,exam_term,st_study_center,submit_date")] tbl_result22 tbl_result22)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_result22).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.s22_course_code = new SelectList(db.tbl_semester22_subject, "s22_course_code", "s22_course_code", tbl_result22.s22_course_code);
            ViewBag.st_registration = new SelectList(db.tbl_students, "st_registration", "st_name", tbl_result22.st_registration);
            return View(tbl_result22);
        }

        // GET: CenterResult22/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_result22 tbl_result22 = db.tbl_result22.Find(id);
            if (tbl_result22 == null)
            {
                return HttpNotFound();
            }
            return View(tbl_result22);
        }

        // POST: CenterResult22/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_result22 tbl_result22 = db.tbl_result22.Find(id);
            db.tbl_result22.Remove(tbl_result22);
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
