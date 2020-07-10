using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Macservice3.Models;

namespace Macservice3.Areas.Employee.Controllers
{
    public class Chitiettrinhdochuyenmon_EmController : Controller
    {
        private Macservice db = new Macservice();

        // GET: Employee/Chitiettrinhdochuyenmon_Em
        public ActionResult Index()
        {
            var chitiettrinhdochuyenmons = db.Chitiettrinhdochuyenmons.Include(c => c.Thongtinnhansu).Include(c => c.Trinhdo_chuyenmon);
            return View(chitiettrinhdochuyenmons.ToList());
        }

        // GET: Employee/Chitiettrinhdochuyenmon_Em/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitiettrinhdochuyenmon chitiettrinhdochuyenmon = db.Chitiettrinhdochuyenmons.Find(id);
            if (chitiettrinhdochuyenmon == null)
            {
                return HttpNotFound();
            }
            return View(chitiettrinhdochuyenmon);
        }

        // GET: Employee/Chitiettrinhdochuyenmon_Em/Create
        public ActionResult Create()
        {
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten");
            ViewBag.Matrinhdochuyenmon = new SelectList(db.Trinhdo_chuyenmon, "Matrinhdochuyenmon", "Tentrinhdochuyenmon");
            return View();
        }

        // POST: Employee/Chitiettrinhdochuyenmon_Em/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Machitiettrinhdochuyenmon,Manv,Matrinhdochuyenmon,Tungay,Denngay")] Chitiettrinhdochuyenmon chitiettrinhdochuyenmon)
        {
            if (ModelState.IsValid)
            {
                db.Chitiettrinhdochuyenmons.Add(chitiettrinhdochuyenmon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", chitiettrinhdochuyenmon.Manv);
            ViewBag.Matrinhdochuyenmon = new SelectList(db.Trinhdo_chuyenmon, "Matrinhdochuyenmon", "Tentrinhdochuyenmon", chitiettrinhdochuyenmon.Matrinhdochuyenmon);
            return View(chitiettrinhdochuyenmon);
        }

        // GET: Employee/Chitiettrinhdochuyenmon_Em/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitiettrinhdochuyenmon chitiettrinhdochuyenmon = db.Chitiettrinhdochuyenmons.Find(id);
            if (chitiettrinhdochuyenmon == null)
            {
                return HttpNotFound();
            }
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", chitiettrinhdochuyenmon.Manv);
            ViewBag.Matrinhdochuyenmon = new SelectList(db.Trinhdo_chuyenmon, "Matrinhdochuyenmon", "Tentrinhdochuyenmon", chitiettrinhdochuyenmon.Matrinhdochuyenmon);
            return View(chitiettrinhdochuyenmon);
        }

        // POST: Employee/Chitiettrinhdochuyenmon_Em/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Machitiettrinhdochuyenmon,Manv,Matrinhdochuyenmon,Tungay,Denngay")] Chitiettrinhdochuyenmon chitiettrinhdochuyenmon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chitiettrinhdochuyenmon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", chitiettrinhdochuyenmon.Manv);
            ViewBag.Matrinhdochuyenmon = new SelectList(db.Trinhdo_chuyenmon, "Matrinhdochuyenmon", "Tentrinhdochuyenmon", chitiettrinhdochuyenmon.Matrinhdochuyenmon);
            return View(chitiettrinhdochuyenmon);
        }

        // GET: Employee/Chitiettrinhdochuyenmon_Em/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitiettrinhdochuyenmon chitiettrinhdochuyenmon = db.Chitiettrinhdochuyenmons.Find(id);
            if (chitiettrinhdochuyenmon == null)
            {
                return HttpNotFound();
            }
            return View(chitiettrinhdochuyenmon);
        }

        // POST: Employee/Chitiettrinhdochuyenmon_Em/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Chitiettrinhdochuyenmon chitiettrinhdochuyenmon = db.Chitiettrinhdochuyenmons.Find(id);
            db.Chitiettrinhdochuyenmons.Remove(chitiettrinhdochuyenmon);
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
