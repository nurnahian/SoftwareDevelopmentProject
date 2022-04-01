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
    public class Semester22SubjectController : Controller
    {
        private DBdcsaContext db = new DBdcsaContext();

        // GET: Semester22Subject
        public ActionResult Index()
        {
            return View(db.tbl_semester22_subject.ToList());
        }

        // GET: Semester22Subject/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_semester22_subject tbl_semester22_subject = db.tbl_semester22_subject.Find(id);
            if (tbl_semester22_subject == null)
            {
                return HttpNotFound();
            }
            return View(tbl_semester22_subject);
        }

        // GET: Semester22Subject/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Semester22Subject/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "s22_id,s22_course_code,s22_course_name,s22_course_credit")] tbl_semester22_subject tbl_semester22_subject)
        {
            if (ModelState.IsValid)
            {
                db.tbl_semester22_subject.Add(tbl_semester22_subject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_semester22_subject);
        }

        // GET: Semester22Subject/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_semester22_subject tbl_semester22_subject = db.tbl_semester22_subject.Find(id);
            if (tbl_semester22_subject == null)
            {
                return HttpNotFound();
            }
            return View(tbl_semester22_subject);
        }

        // POST: Semester22Subject/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "s22_id,s22_course_code,s22_course_name,s22_course_credit")] tbl_semester22_subject tbl_semester22_subject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_semester22_subject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_semester22_subject);
        }

        // GET: Semester22Subject/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_semester22_subject tbl_semester22_subject = db.tbl_semester22_subject.Find(id);
            if (tbl_semester22_subject == null)
            {
                return HttpNotFound();
            }
            return View(tbl_semester22_subject);
        }

        // POST: Semester22Subject/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbl_semester22_subject tbl_semester22_subject = db.tbl_semester22_subject.Find(id);
            db.tbl_semester22_subject.Remove(tbl_semester22_subject);
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
