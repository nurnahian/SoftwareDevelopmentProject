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
    public class UsersController : Controller
    {
        private DBdcsaContext db = new DBdcsaContext();

        // GET: Users
        public ActionResult Index()
        {
            var tbl_users = db.tbl_users.Include(t => t.tbl_studyCenter);
            var c = tbl_users.ToList();            
            return View(c);
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_users tbl_users = db.tbl_users.Find(id);
            if (tbl_users == null)
            {
                return HttpNotFound();
            }
            return View(tbl_users);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.study_center_code = new SelectList(db.tbl_studyCenter, "study_center_code", "study_center_code");
            var list = new List<SelectListItem>
                {
                        new SelectListItem{ Text="Admin", Value = "Admin" },
                        new SelectListItem{ Text="User", Value = "User" , Selected = true}
                };

            ViewData["user_role"] = list;
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "user_id,user_name,user_password,user_role,study_center_code")] tbl_users tbl_users)
        {
            if (ModelState.IsValid)
            {
                db.tbl_users.Add(tbl_users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.study_center_code = new SelectList(db.tbl_studyCenter, "study_center_code", "study_center_code", tbl_users.study_center_code);
            return View(tbl_users);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_users tbl_users = db.tbl_users.Find(id);
            if (tbl_users == null)
            {
                return HttpNotFound();
            }
            ViewBag.study_center_code = new SelectList(db.tbl_studyCenter, "study_center_code", "study_center_code", tbl_users.study_center_code);
            return View(tbl_users);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "user_id,user_name,user_password,user_role,study_center_code")] tbl_users tbl_users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.study_center_code = new SelectList(db.tbl_studyCenter, "study_center_code", "study_center_code", tbl_users.study_center_code);
            return View(tbl_users);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_users tbl_users = db.tbl_users.Find(id);
            if (tbl_users == null)
            {
                return HttpNotFound();
            }
            return View(tbl_users);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_users tbl_users = db.tbl_users.Find(id);
            db.tbl_users.Remove(tbl_users);
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
