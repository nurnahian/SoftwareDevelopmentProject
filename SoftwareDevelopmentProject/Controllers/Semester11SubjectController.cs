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
    public class Semester11SubjectController : Controller
    {
        private DBdcsaContext db = new DBdcsaContext();

        // GET: Semester11Subject
        public ActionResult Index()
        {
            return View(db.tbl_semester11_subject.ToList());
        }

        // GET: Semester11Subject/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_semester11_subject tbl_semester11_subject = db.tbl_semester11_subject.Find(id);
            if (tbl_semester11_subject == null)
            {
                return HttpNotFound();
            }
            return View(tbl_semester11_subject);
        }

        // GET: Semester11Subject/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Semester11Subject/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "s11_id,s11_course_code,s11_course_name,s11_course_credit")] tbl_semester11_subject tbl_semester11_subject)
        {
            if (ModelState.IsValid)
            {
                db.tbl_semester11_subject.Add(tbl_semester11_subject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_semester11_subject);
        }

        // GET: Semester11Subject/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_semester11_subject tbl_semester11_subject = db.tbl_semester11_subject.Find(id);
            if (tbl_semester11_subject == null)
            {
                return HttpNotFound();
            }
            return View(tbl_semester11_subject);
        }

        // POST: Semester11Subject/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "s11_id,s11_course_code,s11_course_name,s11_course_credit")] tbl_semester11_subject tbl_semester11_subject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_semester11_subject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_semester11_subject);
        }

        // GET: Semester11Subject/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_semester11_subject tbl_semester11_subject = db.tbl_semester11_subject.Find(id);
            if (tbl_semester11_subject == null)
            {
                return HttpNotFound();
            }
            return View(tbl_semester11_subject);
        }

        // POST: Semester11Subject/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbl_semester11_subject tbl_semester11_subject = db.tbl_semester11_subject.Find(id);
            db.tbl_semester11_subject.Remove(tbl_semester11_subject);
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
