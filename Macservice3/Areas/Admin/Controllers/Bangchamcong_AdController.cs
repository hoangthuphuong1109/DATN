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
using System.Data.OleDb;


namespace Macservice3.Areas.Admin.Controllers
{
    public class Bangchamcong_AdController : Controller
    {
        private Macservice db = new Macservice();

        // GET: Admin/Bangchamcong_Ad
        public ActionResult Index(int? page, string tukhoa, string maphongban)
        {
            // phân trang
            if (page == null) page = 1;
            var links = (from l in db.Bangchamcongs
                         select l).OrderBy(x => x.Mabangcong);
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            // Tìm kiếm 

            ViewBag.Tukhoa = tukhoa;
            ViewBag.Maphongban = maphongban;

            if (tukhoa != null)
            {
                tukhoa = tukhoa.ToLower();
                tukhoa = tukhoa.Replace("p", "").Replace("0", "");
            }


            var bangchamcongs = db.Bangchamcongs.Include(b => b.Phongban)
                .Where(m => maphongban == null || m.Phongban.Maphongban == maphongban);
            return View(bangchamcongs.Where(m => tukhoa == null || tukhoa.Trim() == "" || m.Mabangcong.Contains(tukhoa)).ToList().ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Bangchamcong_Ad/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bangchamcong bangchamcong = db.Bangchamcongs.Find(id);
            if (bangchamcong == null)
            {
                return HttpNotFound();
            }
            return View(bangchamcong);
        }

        // GET: Admin/Bangchamcong_Ad/Create
        public ActionResult Create()
        {
            ViewBag.Maphongban = new SelectList(db.Phongbans, "Maphongban", "Tenphongban");
            return View();
        }

        // POST: Admin/Bangchamcong_Ad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Mabangcong,Maphongban,Thangchamcong,Nam")] Bangchamcong bangchamcong)
        {
            if (ModelState.IsValid)
            {
                db.Bangchamcongs.Add(bangchamcong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Maphongban = new SelectList(db.Phongbans, "Maphongban", "Tenphongban", bangchamcong.Maphongban);
            return View(bangchamcong);
        }

        // GET: Admin/Bangchamcong_Ad/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bangchamcong bangchamcong = db.Bangchamcongs.Find(id);
            if (bangchamcong == null)
            {
                return HttpNotFound();
            }
            ViewBag.Maphongban = new SelectList(db.Phongbans, "Maphongban", "Tenphongban", bangchamcong.Maphongban);
            return View(bangchamcong);
        }

        // POST: Admin/Bangchamcong_Ad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Mabangcong,Maphongban,Thangchamcong,Nam")] Bangchamcong bangchamcong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bangchamcong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Maphongban = new SelectList(db.Phongbans, "Maphongban", "Tenphongban", bangchamcong.Maphongban);
            return View(bangchamcong);
        }

        // GET: Admin/Bangchamcong_Ad/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bangchamcong bangchamcong = db.Bangchamcongs.Find(id);
            if (bangchamcong == null)
            {
                return HttpNotFound();
            }
            return View(bangchamcong);
        }

        // POST: Admin/Bangchamcong_Ad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Bangchamcong bangchamcong = db.Bangchamcongs.Find(id);
            db.Bangchamcongs.Remove(bangchamcong);
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
