using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Macservice3.Models;

namespace Macservice3.Areas.Employee.Controllers
{
    public class Chitietkhenthuong_EmController : Controller
    {
        private Macservice db = new Macservice();

        // GET: Employee/Chitietkhenthuong_Em
        public ActionResult Index()
        {
            var chitietkhenthuongs = db.Chitietkhenthuongs.Include(c => c.Khenthuong).Include(c => c.Thongtinnhansu);
            return View(chitietkhenthuongs.ToList());
        }

        // GET: Employee/Chitietkhenthuong_Em/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietkhenthuong chitietkhenthuong = db.Chitietkhenthuongs.Find(id);
            if (chitietkhenthuong == null)
            {
                return HttpNotFound();
            }
            return View(chitietkhenthuong);
        }

        // GET: Employee/Chitietkhenthuong_Em/Create
        public ActionResult Create()
        {
            ViewBag.Makhenthuong = new SelectList(db.Khenthuongs, "Makhenthuong", "Tenkhenthuong");
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten");
            return View();
        }

        // POST: Employee/Chitietkhenthuong_Em/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Machitietkhenthuong,Manv,Makhenthuong,Lydokhenthuong,Tienthuong")] Chitietkhenthuong chitietkhenthuong)
        {
            if (ModelState.IsValid)
            {
                db.Chitietkhenthuongs.Add(chitietkhenthuong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Makhenthuong = new SelectList(db.Khenthuongs, "Makhenthuong", "Tenkhenthuong", chitietkhenthuong.Makhenthuong);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", chitietkhenthuong.Manv);
            return View(chitietkhenthuong);
        }

        // GET: Employee/Chitietkhenthuong_Em/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietkhenthuong chitietkhenthuong = db.Chitietkhenthuongs.Find(id);
            if (chitietkhenthuong == null)
            {
                return HttpNotFound();
            }
            ViewBag.Makhenthuong = new SelectList(db.Khenthuongs, "Makhenthuong", "Tenkhenthuong", chitietkhenthuong.Makhenthuong);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", chitietkhenthuong.Manv);
            return View(chitietkhenthuong);
        }

        // POST: Employee/Chitietkhenthuong_Em/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Machitietkhenthuong,Manv,Makhenthuong,Lydokhenthuong,Tienthuong")] Chitietkhenthuong chitietkhenthuong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chitietkhenthuong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Makhenthuong = new SelectList(db.Khenthuongs, "Makhenthuong", "Tenkhenthuong", chitietkhenthuong.Makhenthuong);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", chitietkhenthuong.Manv);
            return View(chitietkhenthuong);
        }

        // GET: Employee/Chitietkhenthuong_Em/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietkhenthuong chitietkhenthuong = db.Chitietkhenthuongs.Find(id);
            if (chitietkhenthuong == null)
            {
                return HttpNotFound();
            }
            return View(chitietkhenthuong);
        }

        // POST: Employee/Chitietkhenthuong_Em/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Chitietkhenthuong chitietkhenthuong = db.Chitietkhenthuongs.Find(id);
            db.Chitietkhenthuongs.Remove(chitietkhenthuong);
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
