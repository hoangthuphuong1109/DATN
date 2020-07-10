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
    public class Chitietchucvu_AdController : Controller
    {
        private Macservice db = new Macservice();

        // GET: Admin/Chitietchucvu_Ad
        public ActionResult Index()
        {
            var chitietchucvus = db.Chitietchucvus.Include(c => c.Chucvu).Include(c => c.Thongtinnhansu);
            return View(chitietchucvus.ToList());
        }

        // GET: Admin/Chitietchucvu_Ad/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietchucvu chitietchucvu = db.Chitietchucvus.Find(id);
            if (chitietchucvu == null)
            {
                return HttpNotFound();
            }
            return View(chitietchucvu);
        }

        // GET: Admin/Chitietchucvu_Ad/Create
        public ActionResult Create()
        {
            ViewBag.Machucvu = new SelectList(db.Chucvus, "Machucvu", "Tenchucvu");
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten");
            return View();
        }

        // POST: Admin/Chitietchucvu_Ad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Machitietchucvu,Manv,Machucvu,Tungay,Denngay")] Chitietchucvu chitietchucvu)
        {
            if (ModelState.IsValid)
            {
                db.Chitietchucvus.Add(chitietchucvu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Machucvu = new SelectList(db.Chucvus, "Machucvu", "Tenchucvu", chitietchucvu.Machucvu);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", chitietchucvu.Manv);
            return View(chitietchucvu);
        }

        // GET: Admin/Chitietchucvu_Ad/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietchucvu chitietchucvu = db.Chitietchucvus.Find(id);
            if (chitietchucvu == null)
            {
                return HttpNotFound();
            }
            ViewBag.Machucvu = new SelectList(db.Chucvus, "Machucvu", "Tenchucvu", chitietchucvu.Machucvu);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", chitietchucvu.Manv);
            return View(chitietchucvu);
        }

        // POST: Admin/Chitietchucvu_Ad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Machitietchucvu,Manv,Machucvu,Tungay,Denngay")] Chitietchucvu chitietchucvu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chitietchucvu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Machucvu = new SelectList(db.Chucvus, "Machucvu", "Tenchucvu", chitietchucvu.Machucvu);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", chitietchucvu.Manv);
            return View(chitietchucvu);
        }

        // GET: Admin/Chitietchucvu_Ad/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietchucvu chitietchucvu = db.Chitietchucvus.Find(id);
            if (chitietchucvu == null)
            {
                return HttpNotFound();
            }
            return View(chitietchucvu);
        }

        // POST: Admin/Chitietchucvu_Ad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Chitietchucvu chitietchucvu = db.Chitietchucvus.Find(id);
            db.Chitietchucvus.Remove(chitietchucvu);
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
