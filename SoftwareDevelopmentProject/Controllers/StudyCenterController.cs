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
    public class StudyCenterController : Controller
    {
        private DBdcsaContext db = new DBdcsaContext();

        // GET: StudyCenter
        public ActionResult Index()
        {
            return View(db.tbl_studyCenter.ToList());
        }

        // GET: StudyCenter/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_studyCenter tbl_studyCenter = db.tbl_studyCenter.Find(id);
            if (tbl_studyCenter == null)
            {
                return HttpNotFound();
            }
            return View(tbl_studyCenter);
        }

        // GET: StudyCenter/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudyCenter/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "study_center_id,study_center_code,study_center_name")] tbl_studyCenter tbl_studyCenter)
        {
            if (ModelState.IsValid)
            {
                db.tbl_studyCenter.Add(tbl_studyCenter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_studyCenter);
        }

        // GET: StudyCenter/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_studyCenter tbl_studyCenter = db.tbl_studyCenter.Find(id);
            if (tbl_studyCenter == null)
            {
                return HttpNotFound();
            }
            return View(tbl_studyCenter);
        }

        // POST: StudyCenter/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "study_center_id,study_center_code,study_center_name")] tbl_studyCenter tbl_studyCenter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_studyCenter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_studyCenter);
        }

        // GET: StudyCenter/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_studyCenter tbl_studyCenter = db.tbl_studyCenter.Find(id);
            if (tbl_studyCenter == null)
            {
                return HttpNotFound();
            }
            return View(tbl_studyCenter);
        }

        // POST: StudyCenter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_studyCenter tbl_studyCenter = db.tbl_studyCenter.Find(id);
            db.tbl_studyCenter.Remove(tbl_studyCenter);
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
