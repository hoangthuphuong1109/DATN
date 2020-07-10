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
    public class Chitietphongban_AdController : Controller
    {
        private Macservice db = new Macservice();

        // GET: Admin/Chitietphongban_Ad
        public ActionResult Index()
        {
            var chitietphongbans = db.Chitietphongbans.Include(c => c.Phongban).Include(c => c.Thongtinnhansu);
            return View(chitietphongbans.ToList());
        }

        // GET: Admin/Chitietphongban_Ad/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietphongban chitietphongban = db.Chitietphongbans.Find(id);
            if (chitietphongban == null)
            {
                return HttpNotFound();
            }
            return View(chitietphongban);
        }

        // GET: Admin/Chitietphongban_Ad/Create
        public ActionResult Create()
        {
            ViewBag.Maphongban = new SelectList(db.Phongbans, "Maphongban", "Tenphongban");
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten");
            return View();
        }

        // POST: Admin/Chitietphongban_Ad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Machitietphongban,Manv,Maphongban,Tungay,Denngay")] Chitietphongban chitietphongban)
        {
            if (ModelState.IsValid)
            {
                db.Chitietphongbans.Add(chitietphongban);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Maphongban = new SelectList(db.Phongbans, "Maphongban", "Tenphongban", chitietphongban.Maphongban);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", chitietphongban.Manv);
            return View(chitietphongban);
        }

        // GET: Admin/Chitietphongban_Ad/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietphongban chitietphongban = db.Chitietphongbans.Find(id);
            if (chitietphongban == null)
            {
                return HttpNotFound();
            }
            ViewBag.Maphongban = new SelectList(db.Phongbans, "Maphongban", "Tenphongban", chitietphongban.Maphongban);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", chitietphongban.Manv);
            return View(chitietphongban);
        }

        // POST: Admin/Chitietphongban_Ad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Machitietphongban,Manv,Maphongban,Tungay,Denngay")] Chitietphongban chitietphongban)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chitietphongban).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Maphongban = new SelectList(db.Phongbans, "Maphongban", "Tenphongban", chitietphongban.Maphongban);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", chitietphongban.Manv);
            return View(chitietphongban);
        }

        // GET: Admin/Chitietphongban_Ad/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietphongban chitietphongban = db.Chitietphongbans.Find(id);
            if (chitietphongban == null)
            {
                return HttpNotFound();
            }
            return View(chitietphongban);
        }

        // POST: Admin/Chitietphongban_Ad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Chitietphongban chitietphongban = db.Chitietphongbans.Find(id);
            db.Chitietphongbans.Remove(chitietphongban);
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
