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
    public class Kyluat_AdController : Controller
    {
        private Macservice db = new Macservice();

        // GET: Admin/Kyluat_Ad
        public ActionResult Index(string tukhoa, int? page)
        {
            if (page == null) page = 1;
            var links = (from l in db.Kyluats
                         select l).OrderBy(x => x.Makyluat);
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            //
            ViewBag.Tukhoa = tukhoa;
            if (tukhoa != null)
            {
                tukhoa = tukhoa.ToLower();

            }
            return View(db.Kyluats.Where(m => tukhoa == null || tukhoa.Trim() == "" || m.Makyluat.Contains(tukhoa) || m.Tenkyluat.Contains(tukhoa) || m.Quyetdinh.Contains(tukhoa)).ToList().ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Kyluat_Ad/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kyluat kyluat = db.Kyluats.Find(id);
            if (kyluat == null)
            {
                return HttpNotFound();
            }
            return View(kyluat);
        }

        // GET: Admin/Kyluat_Ad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Kyluat_Ad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Makyluat,Tenkyluat,Quyetdinh")] Kyluat kyluat)
        {
            if (ModelState.IsValid)
            {
                db.Kyluats.Add(kyluat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kyluat);
        }

        // GET: Admin/Kyluat_Ad/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kyluat kyluat = db.Kyluats.Find(id);
            if (kyluat == null)
            {
                return HttpNotFound();
            }
            return View(kyluat);
        }

        // POST: Admin/Kyluat_Ad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Makyluat,Tenkyluat,Quyetdinh")] Kyluat kyluat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kyluat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kyluat);
        }

        // GET: Admin/Kyluat_Ad/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kyluat kyluat = db.Kyluats.Find(id);
            if (kyluat == null)
            {
                return HttpNotFound();
            }
            return View(kyluat);
        }

        // POST: Admin/Kyluat_Ad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Kyluat kyluat = db.Kyluats.Find(id);
            db.Kyluats.Remove(kyluat);
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
