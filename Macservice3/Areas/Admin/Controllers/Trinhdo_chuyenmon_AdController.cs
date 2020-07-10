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
    public class Trinhdo_chuyenmon_AdController : Controller
    {
        private Macservice db = new Macservice();

        // GET: Admin/Trinhdo_chuyenmon_Ad
        public ActionResult Index(string tukhoa, int? page)
        {
            if (page == null) page = 1;
            var links = (from l in db.Trinhdo_chuyenmon
                         select l).OrderBy(x => x.Matrinhdochuyenmon);
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            //
            ViewBag.Tukhoa = tukhoa;
            if (tukhoa != null)
            {
                tukhoa = tukhoa.ToLower();

            }
            return View(db.Trinhdo_chuyenmon.Where(m => tukhoa == null || tukhoa.Trim() == "" || m.Matrinhdochuyenmon.Contains(tukhoa) || m.Tentrinhdochuyenmon.Contains(tukhoa)).ToList().ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Trinhdo_chuyenmon_Ad/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trinhdo_chuyenmon trinhdo_chuyenmon = db.Trinhdo_chuyenmon.Find(id);
            if (trinhdo_chuyenmon == null)
            {
                return HttpNotFound();
            }
            return View(trinhdo_chuyenmon);
        }

        // GET: Admin/Trinhdo_chuyenmon_Ad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Trinhdo_chuyenmon_Ad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Matrinhdochuyenmon,Tentrinhdochuyenmon")] Trinhdo_chuyenmon trinhdo_chuyenmon)
        {
            if (ModelState.IsValid)
            {
                db.Trinhdo_chuyenmon.Add(trinhdo_chuyenmon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trinhdo_chuyenmon);
        }

        // GET: Admin/Trinhdo_chuyenmon_Ad/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trinhdo_chuyenmon trinhdo_chuyenmon = db.Trinhdo_chuyenmon.Find(id);
            if (trinhdo_chuyenmon == null)
            {
                return HttpNotFound();
            }
            return View(trinhdo_chuyenmon);
        }

        // POST: Admin/Trinhdo_chuyenmon_Ad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Matrinhdochuyenmon,Tentrinhdochuyenmon")] Trinhdo_chuyenmon trinhdo_chuyenmon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trinhdo_chuyenmon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trinhdo_chuyenmon);
        }

        // GET: Admin/Trinhdo_chuyenmon_Ad/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trinhdo_chuyenmon trinhdo_chuyenmon = db.Trinhdo_chuyenmon.Find(id);
            if (trinhdo_chuyenmon == null)
            {
                return HttpNotFound();
            }
            return View(trinhdo_chuyenmon);
        }

        // POST: Admin/Trinhdo_chuyenmon_Ad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Trinhdo_chuyenmon trinhdo_chuyenmon = db.Trinhdo_chuyenmon.Find(id);
            db.Trinhdo_chuyenmon.Remove(trinhdo_chuyenmon);
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
