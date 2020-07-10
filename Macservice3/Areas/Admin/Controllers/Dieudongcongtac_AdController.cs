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
    public class Dieudongcongtac_AdController : Controller
    {
        private Macservice db = new Macservice();

        // GET: Admin/Dieudongcongtac_Ad
        public ActionResult Index()
        {
            var dieudongcongtacs = db.Dieudongcongtacs.Include(d => d.Chucvu).Include(d => d.Phongban).Include(d => d.Thongtinnhansu).Include(d => d.Trinhdo_chuyenmon);
            return View(dieudongcongtacs.ToList());
        }

        // GET: Admin/Dieudongcongtac_Ad/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dieudongcongtac dieudongcongtac = db.Dieudongcongtacs.Find(id);
            if (dieudongcongtac == null)
            {
                return HttpNotFound();
            }
            return View(dieudongcongtac);
        }

        // GET: Admin/Dieudongcongtac_Ad/Create
        public ActionResult Create()
        {
            ViewBag.Machucvu = new SelectList(db.Chucvus, "Machucvu", "Tenchucvu");
            ViewBag.Maphongban = new SelectList(db.Phongbans, "Maphongban", "Tenphongban");
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten");
            ViewBag.Matrinhdochuyenmon = new SelectList(db.Trinhdo_chuyenmon, "Matrinhdochuyenmon", "Tentrinhdochuyenmon");
            return View();
        }

        // POST: Admin/Dieudongcongtac_Ad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Malichtrinhcongtac,Manv,Maphongban,Machucvu,Matrinhdochuyenmon,Tungay,Denngay,Noicongtac,Noidungcongtac,Trocap")] Dieudongcongtac dieudongcongtac)
        {
            if (ModelState.IsValid)
            {
                db.Dieudongcongtacs.Add(dieudongcongtac);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Machucvu = new SelectList(db.Chucvus, "Machucvu", "Tenchucvu", dieudongcongtac.Machucvu);
            ViewBag.Maphongban = new SelectList(db.Phongbans, "Maphongban", "Tenphongban", dieudongcongtac.Maphongban);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", dieudongcongtac.Manv);
            ViewBag.Matrinhdochuyenmon = new SelectList(db.Trinhdo_chuyenmon, "Matrinhdochuyenmon", "Tentrinhdochuyenmon", dieudongcongtac.Matrinhdochuyenmon);
            return View(dieudongcongtac);
        }

        // GET: Admin/Dieudongcongtac_Ad/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dieudongcongtac dieudongcongtac = db.Dieudongcongtacs.Find(id);
            if (dieudongcongtac == null)
            {
                return HttpNotFound();
            }
            ViewBag.Machucvu = new SelectList(db.Chucvus, "Machucvu", "Tenchucvu", dieudongcongtac.Machucvu);
            ViewBag.Maphongban = new SelectList(db.Phongbans, "Maphongban", "Tenphongban", dieudongcongtac.Maphongban);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", dieudongcongtac.Manv);
            ViewBag.Matrinhdochuyenmon = new SelectList(db.Trinhdo_chuyenmon, "Matrinhdochuyenmon", "Tentrinhdochuyenmon", dieudongcongtac.Matrinhdochuyenmon);
            return View(dieudongcongtac);
        }

        // POST: Admin/Dieudongcongtac_Ad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Malichtrinhcongtac,Manv,Maphongban,Machucvu,Matrinhdochuyenmon,Tungay,Denngay,Noicongtac,Noidungcongtac,Trocap")] Dieudongcongtac dieudongcongtac)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dieudongcongtac).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Machucvu = new SelectList(db.Chucvus, "Machucvu", "Tenchucvu", dieudongcongtac.Machucvu);
            ViewBag.Maphongban = new SelectList(db.Phongbans, "Maphongban", "Tenphongban", dieudongcongtac.Maphongban);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", dieudongcongtac.Manv);
            ViewBag.Matrinhdochuyenmon = new SelectList(db.Trinhdo_chuyenmon, "Matrinhdochuyenmon", "Tentrinhdochuyenmon", dieudongcongtac.Matrinhdochuyenmon);
            return View(dieudongcongtac);
        }

        // GET: Admin/Dieudongcongtac_Ad/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dieudongcongtac dieudongcongtac = db.Dieudongcongtacs.Find(id);
            if (dieudongcongtac == null)
            {
                return HttpNotFound();
            }
            return View(dieudongcongtac);
        }

        // POST: Admin/Dieudongcongtac_Ad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Dieudongcongtac dieudongcongtac = db.Dieudongcongtacs.Find(id);
            db.Dieudongcongtacs.Remove(dieudongcongtac);
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
