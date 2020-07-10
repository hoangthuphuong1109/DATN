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
    public class Chitietkhenthuong_AdController : Controller
    {
        private Macservice db = new Macservice();

        // GET: Admin/Chitietkhenthuong_Ad
        public ActionResult Index(int? page, string tukhoa, string makhenthuong)
        {
            // phân trang
            if (page == null) page = 1;
            var links = (from l in db.Chitietkhenthuongs
                         select l).OrderBy(x => x.Machitietkhenthuong);
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            // Tìm kiếm 

            ViewBag.Tukhoa = tukhoa;
            ViewBag.Makhenthuong = makhenthuong;

            if (tukhoa != null)
            {
                tukhoa = tukhoa.ToLower();
                tukhoa = tukhoa.Replace("p", "").Replace("0", "");
            }



            var chitietkhenthuongs = db.Chitietkhenthuongs.Include(c => c.Khenthuong).Include(c => c.Thongtinnhansu)
                .Where(m => makhenthuong == null || m.Khenthuong.Makhenthuong == makhenthuong);
            return View(chitietkhenthuongs.Where(m => tukhoa == null || tukhoa.Trim() == "" || m.Machitietkhenthuong.Contains(tukhoa) || m.Manv.Contains(tukhoa) || m.Thongtinnhansu.Hoten.Contains(tukhoa)).ToList().ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Chitietkhenthuong_Ad/Details/5
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

        // GET: Admin/Chitietkhenthuong_Ad/Create
        public ActionResult Create()
        {
            ViewBag.Makhenthuong = new SelectList(db.Khenthuongs, "Makhenthuong", "Tenkhenthuong");
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten");
            return View();
        }

        // POST: Admin/Chitietkhenthuong_Ad/Create
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

        // GET: Admin/Chitietkhenthuong_Ad/Edit/5
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

        // POST: Admin/Chitietkhenthuong_Ad/Edit/5
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

        // GET: Admin/Chitietkhenthuong_Ad/Delete/5
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

        // POST: Admin/Chitietkhenthuong_Ad/Delete/5
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
