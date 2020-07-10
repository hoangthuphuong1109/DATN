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
    public class Quatrinhluong_EmController : Controller
    {
        private Macservice db = new Macservice();

        // GET: Employee/Quatrinhluong_Em
        public ActionResult Index()
        {
            var quatrinhluongs = db.Quatrinhluongs.Include(q => q.Chucvu).Include(q => q.Phongban).Include(q => q.Thongtinnhansu);
            return View(quatrinhluongs.ToList());
        }

        // GET: Employee/Quatrinhluong_Em/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quatrinhluong quatrinhluong = db.Quatrinhluongs.Find(id);
            if (quatrinhluong == null)
            {
                return HttpNotFound();
            }
            return View(quatrinhluong);
        }

        // GET: Employee/Quatrinhluong_Em/Create
        public ActionResult Create()
        {
            ViewBag.Machucvu = new SelectList(db.Chucvus, "Machucvu", "Tenchucvu");
            ViewBag.Maphongban = new SelectList(db.Phongbans, "Maphongban", "Tenphongban");
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten");
            return View();
        }

        // POST: Employee/Quatrinhluong_Em/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Maquatrinhluong,Manv,Maphongban,Machucvu,Thoigian,Luongcoban,Trocapchucvu,Phucapkhac,Noidung,Luongdoanhso")] Quatrinhluong quatrinhluong)
        {
            if (ModelState.IsValid)
            {
                db.Quatrinhluongs.Add(quatrinhluong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Machucvu = new SelectList(db.Chucvus, "Machucvu", "Tenchucvu", quatrinhluong.Machucvu);
            ViewBag.Maphongban = new SelectList(db.Phongbans, "Maphongban", "Tenphongban", quatrinhluong.Maphongban);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", quatrinhluong.Manv);
            return View(quatrinhluong);
        }

        // GET: Employee/Quatrinhluong_Em/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quatrinhluong quatrinhluong = db.Quatrinhluongs.Find(id);
            if (quatrinhluong == null)
            {
                return HttpNotFound();
            }
            ViewBag.Machucvu = new SelectList(db.Chucvus, "Machucvu", "Tenchucvu", quatrinhluong.Machucvu);
            ViewBag.Maphongban = new SelectList(db.Phongbans, "Maphongban", "Tenphongban", quatrinhluong.Maphongban);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", quatrinhluong.Manv);
            return View(quatrinhluong);
        }

        // POST: Employee/Quatrinhluong_Em/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Maquatrinhluong,Manv,Maphongban,Machucvu,Thoigian,Luongcoban,Trocapchucvu,Phucapkhac,Noidung,Luongdoanhso")] Quatrinhluong quatrinhluong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quatrinhluong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Machucvu = new SelectList(db.Chucvus, "Machucvu", "Tenchucvu", quatrinhluong.Machucvu);
            ViewBag.Maphongban = new SelectList(db.Phongbans, "Maphongban", "Tenphongban", quatrinhluong.Maphongban);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", quatrinhluong.Manv);
            return View(quatrinhluong);
        }

        // GET: Employee/Quatrinhluong_Em/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quatrinhluong quatrinhluong = db.Quatrinhluongs.Find(id);
            if (quatrinhluong == null)
            {
                return HttpNotFound();
            }
            return View(quatrinhluong);
        }

        // POST: Employee/Quatrinhluong_Em/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Quatrinhluong quatrinhluong = db.Quatrinhluongs.Find(id);
            db.Quatrinhluongs.Remove(quatrinhluong);
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
