using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Macservice3.Models;
using PagedList;

namespace Macservice3.Areas.Admin.Controllers
{
    public class Hopdong_AdController : Controller
    {
        private Macservice db = new Macservice();

        // GET: Admin/Hopdong_Ad
        public ActionResult Index(int? page, string tukhoa, string maloaihopdong)
        {
            // phân trang
            if (page == null) page = 1;
            var links = (from l in db.Hopdongs
                         select l).OrderBy(x => x.Mahopdong);
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            // Tìm kiếm 

            ViewBag.Tukhoa = tukhoa;
            ViewBag.Maloaihopdong = maloaihopdong;

            if (tukhoa != null)
            {
                tukhoa = tukhoa.ToLower();
                tukhoa = tukhoa.Replace("p", "").Replace("0", "");
            }


            var hopdongs = db.Hopdongs.Include(h => h.Loaihopdong).Include(h => h.Thongtinnhansu)
                .Where(m => maloaihopdong == null || m.Loaihopdong.Maloaihopdong == maloaihopdong);
            return View(hopdongs.Where(m => tukhoa == null || tukhoa.Trim() == "" || m.Maloaihopdong.Contains(tukhoa) || m.Manv.Contains(tukhoa) || m.Thongtinnhansu.Hoten.Contains(tukhoa)).ToList().ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Hopdong_Ad/Details/5
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

        // GET: Admin/Hopdong_Ad/Create
        public ActionResult Create()
        {
            ViewBag.Maloaihopdong = new SelectList(db.Loaihopdongs, "Maloaihopdong", "Tenloaihopdong");
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten");
            return View();
        }

        // POST: Admin/Hopdong_Ad/Create
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

        // GET: Admin/Hopdong_Ad/Edit/5
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

        // POST: Admin/Hopdong_Ad/Edit/5
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

        // GET: Admin/Hopdong_Ad/Delete/5
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

        // POST: Admin/Hopdong_Ad/Delete/5
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
