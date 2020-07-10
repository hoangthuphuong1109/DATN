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
    public class Baohiem_AdController : Controller
    {
        private Macservice db = new Macservice();

        // GET: Admin/Baohiem_Ad
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
            return View(db.Baohiems.Where(m => tukhoa == null || tukhoa.Trim() == "" || m.Mabaohiem.Contains(tukhoa) || m.Tenbaohiem.Contains(tukhoa) ).ToList().ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Baohiem_Ad/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Baohiem baohiem = db.Baohiems.Find(id);
            if (baohiem == null)
            {
                return HttpNotFound();
            }
            return View(baohiem);
        }

        // GET: Admin/Baohiem_Ad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Baohiem_Ad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Mabaohiem,Tenbaohiem")] Baohiem baohiem)
        {
            if (ModelState.IsValid)
            {
                db.Baohiems.Add(baohiem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(baohiem);
        }

        // GET: Admin/Baohiem_Ad/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Baohiem baohiem = db.Baohiems.Find(id);
            if (baohiem == null)
            {
                return HttpNotFound();
            }
            return View(baohiem);
        }

        // POST: Admin/Baohiem_Ad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Mabaohiem,Tenbaohiem")] Baohiem baohiem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baohiem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(baohiem);
        }

        // GET: Admin/Baohiem_Ad/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Baohiem baohiem = db.Baohiems.Find(id);
            if (baohiem == null)
            {
                return HttpNotFound();
            }
            return View(baohiem);
        }

        // POST: Admin/Baohiem_Ad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Baohiem baohiem = db.Baohiems.Find(id);
            db.Baohiems.Remove(baohiem);
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
