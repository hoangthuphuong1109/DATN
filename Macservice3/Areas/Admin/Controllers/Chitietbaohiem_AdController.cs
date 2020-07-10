using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Macservice3.Models;

namespace Macservice3.Areas.Admin.Controllers
{
    public class Chitietbaohiem_AdController : Controller
    {
        private Macservice db = new Macservice();

        // GET: Admin/Chitietbaohiem_Ad
        public ActionResult Index()
        {
            var chitietbaohiems = db.Chitietbaohiems.Include(c => c.Baohiem).Include(c => c.Thongtinnhansu);
            return View(chitietbaohiems.ToList());
        }

        // GET: Admin/Chitietbaohiem_Ad/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietbaohiem chitietbaohiem = db.Chitietbaohiems.Find(id);
            if (chitietbaohiem == null)
            {
                return HttpNotFound();
            }
            return View(chitietbaohiem);
        }

        // GET: Admin/Chitietbaohiem_Ad/Create
        public ActionResult Create()
        {
            ViewBag.Mabaohiem = new SelectList(db.Baohiems, "Mabaohiem", "Tenbaohiem");
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten");
            return View();
        }

        // POST: Admin/Chitietbaohiem_Ad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Machitietbaohiem,Mabaohiem,Manv,Tungay,Denngay")] Chitietbaohiem chitietbaohiem)
        {
            if (ModelState.IsValid)
            {
                db.Chitietbaohiems.Add(chitietbaohiem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Mabaohiem = new SelectList(db.Baohiems, "Mabaohiem", "Tenbaohiem", chitietbaohiem.Mabaohiem);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", chitietbaohiem.Manv);
            return View(chitietbaohiem);
        }

        // GET: Admin/Chitietbaohiem_Ad/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietbaohiem chitietbaohiem = db.Chitietbaohiems.Find(id);
            if (chitietbaohiem == null)
            {
                return HttpNotFound();
            }
            ViewBag.Mabaohiem = new SelectList(db.Baohiems, "Mabaohiem", "Tenbaohiem", chitietbaohiem.Mabaohiem);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", chitietbaohiem.Manv);
            return View(chitietbaohiem);
        }

        // POST: Admin/Chitietbaohiem_Ad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Machitietbaohiem,Mabaohiem,Manv,Tungay,Denngay")] Chitietbaohiem chitietbaohiem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chitietbaohiem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Mabaohiem = new SelectList(db.Baohiems, "Mabaohiem", "Tenbaohiem", chitietbaohiem.Mabaohiem);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", chitietbaohiem.Manv);
            return View(chitietbaohiem);
        }

        // GET: Admin/Chitietbaohiem_Ad/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietbaohiem chitietbaohiem = db.Chitietbaohiems.Find(id);
            if (chitietbaohiem == null)
            {
                return HttpNotFound();
            }
            return View(chitietbaohiem);
        }

        // POST: Admin/Chitietbaohiem_Ad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Chitietbaohiem chitietbaohiem = db.Chitietbaohiems.Find(id);
            db.Chitietbaohiems.Remove(chitietbaohiem);
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
