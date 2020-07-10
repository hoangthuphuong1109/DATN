using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Macservice3.Models;

namespace Macservice3.Areas.Admin.Controllers
{
    public class Taikhoan_AdController : Controller
    {
        private Macservice db = new Macservice();

        // GET: Admin/Taikhoan_Ad
        public ActionResult Index()
        {
            var taikhoans = db.Taikhoans.Include(t => t.Role);
            return View(taikhoans.ToList());
        }

        // GET: Admin/Taikhoan_Ad/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Taikhoan taikhoan = db.Taikhoans.Find(id);
            if (taikhoan == null)
            {
                return HttpNotFound();
            }
            return View(taikhoan);
        }

        // GET: Admin/Taikhoan_Ad/Create
        public ActionResult Create()
        {
            ViewBag.Role_id = new SelectList(db.Roles, "Role_id", "Role_name");
            return View();
        }

        // POST: Admin/Taikhoan_Ad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Mataikhoan,Tendangnhap,Matkhau,Role_id")] Taikhoan taikhoan)
        {
            if (ModelState.IsValid)
            {
                db.Taikhoans.Add(taikhoan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Role_id = new SelectList(db.Roles, "Role_id", "Role_name", taikhoan.Role_id);
            return View(taikhoan);
        }

        // GET: Admin/Taikhoan_Ad/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Taikhoan taikhoan = db.Taikhoans.Find(id);
            if (taikhoan == null)
            {
                return HttpNotFound();
            }
            ViewBag.Role_id = new SelectList(db.Roles, "Role_id", "Role_name", taikhoan.Role_id);
            return View(taikhoan);
        }

        // POST: Admin/Taikhoan_Ad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Mataikhoan,Tendangnhap,Matkhau,Role_id")] Taikhoan taikhoan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taikhoan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Role_id = new SelectList(db.Roles, "Role_id", "Role_name", taikhoan.Role_id);
            return View(taikhoan);
        }

        // GET: Admin/Taikhoan_Ad/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Taikhoan taikhoan = db.Taikhoans.Find(id);
            if (taikhoan == null)
            {
                return HttpNotFound();
            }
            return View(taikhoan);
        }

        // POST: Admin/Taikhoan_Ad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Taikhoan taikhoan = db.Taikhoans.Find(id);
            db.Taikhoans.Remove(taikhoan);
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
