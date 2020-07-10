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
    public class Chitietbangcong_EmController : Controller
    {
        private Macservice db = new Macservice();

        // GET: Employee/Chitietbangcong_Em
        public ActionResult Index()
        {
            var chitietbangcongs = db.Chitietbangcongs.Include(c => c.Bangchamcong).Include(c => c.Phongban).Include(c => c.Thongtinnhansu);
            return View(chitietbangcongs.ToList());
        }

        // GET: Employee/Chitietbangcong_Em/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietbangcong chitietbangcong = db.Chitietbangcongs.Find(id);
            if (chitietbangcong == null)
            {
                return HttpNotFound();
            }
            return View(chitietbangcong);
        }

        // GET: Employee/Chitietbangcong_Em/Create
        public ActionResult Create()
        {
            ViewBag.Mabangcong = new SelectList(db.Bangchamcongs, "Mabangcong", "Maphongban");
            ViewBag.Maphongban = new SelectList(db.Phongbans, "Maphongban", "Tenphongban");
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten");
            return View();
        }

        // POST: Employee/Chitietbangcong_Em/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Machitietbangcong,Manv,Mabangcong,Sogiolam,Sogiolamthemngaythuong,Sogiolamthemngaynghi,Sogiolamthemngayle,Songaynghiphep,Maphongban")] Chitietbangcong chitietbangcong)
        {
            if (ModelState.IsValid)
            {
                db.Chitietbangcongs.Add(chitietbangcong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Mabangcong = new SelectList(db.Bangchamcongs, "Mabangcong", "Maphongban", chitietbangcong.Mabangcong);
            ViewBag.Maphongban = new SelectList(db.Phongbans, "Maphongban", "Tenphongban", chitietbangcong.Maphongban);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", chitietbangcong.Manv);
            return View(chitietbangcong);
        }

        // GET: Employee/Chitietbangcong_Em/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietbangcong chitietbangcong = db.Chitietbangcongs.Find(id);
            if (chitietbangcong == null)
            {
                return HttpNotFound();
            }
            ViewBag.Mabangcong = new SelectList(db.Bangchamcongs, "Mabangcong", "Maphongban", chitietbangcong.Mabangcong);
            ViewBag.Maphongban = new SelectList(db.Phongbans, "Maphongban", "Tenphongban", chitietbangcong.Maphongban);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", chitietbangcong.Manv);
            return View(chitietbangcong);
        }

        // POST: Employee/Chitietbangcong_Em/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Machitietbangcong,Manv,Mabangcong,Sogiolam,Sogiolamthemngaythuong,Sogiolamthemngaynghi,Sogiolamthemngayle,Songaynghiphep,Maphongban")] Chitietbangcong chitietbangcong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chitietbangcong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Mabangcong = new SelectList(db.Bangchamcongs, "Mabangcong", "Maphongban", chitietbangcong.Mabangcong);
            ViewBag.Maphongban = new SelectList(db.Phongbans, "Maphongban", "Tenphongban", chitietbangcong.Maphongban);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", chitietbangcong.Manv);
            return View(chitietbangcong);
        }

        // GET: Employee/Chitietbangcong_Em/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietbangcong chitietbangcong = db.Chitietbangcongs.Find(id);
            if (chitietbangcong == null)
            {
                return HttpNotFound();
            }
            return View(chitietbangcong);
        }

        // POST: Employee/Chitietbangcong_Em/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Chitietbangcong chitietbangcong = db.Chitietbangcongs.Find(id);
            db.Chitietbangcongs.Remove(chitietbangcong);
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
