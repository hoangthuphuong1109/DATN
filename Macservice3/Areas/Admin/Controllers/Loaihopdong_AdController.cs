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
    public class Loaihopdong_AdController : Controller
    {
        private Macservice db = new Macservice();

        // GET: Admin/Loaihopdong_Ad
        public ActionResult Index(string tukhoa, int? page)
        {   
            //Phân trang
            if (page == null) page = 1;
            var links = (from l in db.Kyluats
                         select l).OrderBy(x => x.Makyluat);
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            //Tìm kiếm
            ViewBag.Tukhoa = tukhoa;
            if (tukhoa != null)
            {
                tukhoa = tukhoa.ToLower();

            }
            return View(db.Loaihopdongs.Where(m => tukhoa == null || tukhoa.Trim() == "" || m.Maloaihopdong.Contains(tukhoa) || m.Tenloaihopdong.Contains(tukhoa) ).ToList().ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Loaihopdong_Ad/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loaihopdong loaihopdong = db.Loaihopdongs.Find(id);
            if (loaihopdong == null)
            {
                return HttpNotFound();
            }
            return View(loaihopdong);
        }

        // GET: Admin/Loaihopdong_Ad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Loaihopdong_Ad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Maloaihopdong,Tenloaihopdong")] Loaihopdong loaihopdong)
        {
            if (ModelState.IsValid)
            {
                db.Loaihopdongs.Add(loaihopdong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaihopdong);
        }

        // GET: Admin/Loaihopdong_Ad/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loaihopdong loaihopdong = db.Loaihopdongs.Find(id);
            if (loaihopdong == null)
            {
                return HttpNotFound();
            }
            return View(loaihopdong);
        }

        // POST: Admin/Loaihopdong_Ad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Maloaihopdong,Tenloaihopdong")] Loaihopdong loaihopdong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaihopdong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaihopdong);
        }

        // GET: Admin/Loaihopdong_Ad/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loaihopdong loaihopdong = db.Loaihopdongs.Find(id);
            if (loaihopdong == null)
            {
                return HttpNotFound();
            }
            return View(loaihopdong);
        }

        // POST: Admin/Loaihopdong_Ad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Loaihopdong loaihopdong = db.Loaihopdongs.Find(id);
            db.Loaihopdongs.Remove(loaihopdong);
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
