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
    public class Hopdong_EmController : Controller
    {
        private Macservice db = new Macservice();

        // GET: Employee/Hopdong_Em
        public ActionResult Index()
        {
            var hopdongs = db.Hopdongs.Include(h => h.Loaihopdong).Include(h => h.Thongtinnhansu);
            return View(hopdongs.ToList());
        }

        // GET: Employee/Hopdong_Em/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hopdong hopdong = db.Hopdongs.Find(id);
            if (hopdong == null)
            {
                return HttpNotFound();
            }
            return View(hopdong);
        }

        // GET: Employee/Hopdong_Em/Create
        public ActionResult Create()
        {
            ViewBag.Maloaihopdong = new SelectList(db.Loaihopdongs, "Maloaihopdong", "Tenloaihopdong");
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten");
            return View();
        }

        // POST: Employee/Hopdong_Em/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Mahopdong,Manv,Maloaihopdong,Ngaykyket,Ngayketthuc,Luongcoban")] Hopdong hopdong)
        {
            if (ModelState.IsValid)
            {
                db.Hopdongs.Add(hopdong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Maloaihopdong = new SelectList(db.Loaihopdongs, "Maloaihopdong", "Tenloaihopdong", hopdong.Maloaihopdong);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", hopdong.Manv);
            return View(hopdong);
        }

        // GET: Employee/Hopdong_Em/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hopdong hopdong = db.Hopdongs.Find(id);
            if (hopdong == null)
            {
                return HttpNotFound();
            }
            ViewBag.Maloaihopdong = new SelectList(db.Loaihopdongs, "Maloaihopdong", "Tenloaihopdong", hopdong.Maloaihopdong);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", hopdong.Manv);
            return View(hopdong);
        }

        // POST: Employee/Hopdong_Em/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Mahopdong,Manv,Maloaihopdong,Ngaykyket,Ngayketthuc,Luongcoban")] Hopdong hopdong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hopdong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Maloaihopdong = new SelectList(db.Loaihopdongs, "Maloaihopdong", "Tenloaihopdong", hopdong.Maloaihopdong);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", hopdong.Manv);
            return View(hopdong);
        }

        // GET: Employee/Hopdong_Em/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hopdong hopdong = db.Hopdongs.Find(id);
            if (hopdong == null)
            {
                return HttpNotFound();
            }
            return View(hopdong);
        }

        // POST: Employee/Hopdong_Em/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Hopdong hopdong = db.Hopdongs.Find(id);
            db.Hopdongs.Remove(hopdong);
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
