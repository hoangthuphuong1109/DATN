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
    public class Khenthuong_AdController : Controller
    {
        private Macservice db = new Macservice();

        // GET: Admin/Khenthuong_Ad
        public ActionResult Index(string tukhoa, int? page)
        {
            if (page == null) page = 1;
            var links = (from l in db.Khenthuongs
                         select l).OrderBy(x => x.Makhenthuong);
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            //
            ViewBag.Tukhoa = tukhoa;
            if (tukhoa != null)
            {
                tukhoa = tukhoa.ToLower();

            }
            return View(db.Khenthuongs.Where(m => tukhoa == null || tukhoa.Trim() == "" || m.Makhenthuong.Contains(tukhoa) || m.Tenkhenthuong.Contains(tukhoa) || m.Quyetdinh.Contains(tukhoa)).ToList().ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Khenthuong_Ad/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khenthuong khenthuong = db.Khenthuongs.Find(id);
            if (khenthuong == null)
            {
                return HttpNotFound();
            }
            return View(khenthuong);
        }

        // GET: Admin/Khenthuong_Ad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Khenthuong_Ad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Makhenthuong,Tenkhenthuong,Quyetdinh")] Khenthuong khenthuong)
        {
            if (ModelState.IsValid)
            {
                db.Khenthuongs.Add(khenthuong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(khenthuong);
        }

        // GET: Admin/Khenthuong_Ad/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khenthuong khenthuong = db.Khenthuongs.Find(id);
            if (khenthuong == null)
            {
                return HttpNotFound();
            }
            return View(khenthuong);
        }

        // POST: Admin/Khenthuong_Ad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Makhenthuong,Tenkhenthuong,Quyetdinh")] Khenthuong khenthuong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khenthuong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khenthuong);
        }

        // GET: Admin/Khenthuong_Ad/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khenthuong khenthuong = db.Khenthuongs.Find(id);
            if (khenthuong == null)
            {
                return HttpNotFound();
            }
            return View(khenthuong);
        }

        // POST: Admin/Khenthuong_Ad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Khenthuong khenthuong = db.Khenthuongs.Find(id);
            db.Khenthuongs.Remove(khenthuong);
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
