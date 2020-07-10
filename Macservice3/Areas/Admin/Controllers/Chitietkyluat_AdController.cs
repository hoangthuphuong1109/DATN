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
    public class Chitietkyluat_AdController : Controller
    {
        private Macservice db = new Macservice();

        // GET: Admin/Chitietkyluat_Ad
        public ActionResult Index(int? page, string tukhoa, string makyluat)
        {

            // phân trang
            if (page == null) page = 1;
            var links = (from l in db.Chitietkyluats
                         select l).OrderBy(x => x.Machitietkyluat);
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            // Tìm kiếm 

            ViewBag.Tukhoa = tukhoa;
            ViewBag.Makyluat = makyluat;

            if (tukhoa != null)
            {
                tukhoa = tukhoa.ToLower();
                tukhoa = tukhoa.Replace("p", "").Replace("0", "");
            }



            var chitietkyluats = db.Chitietkyluats.Include(c => c.Kyluat).Include(c => c.Thongtinnhansu)
                .Where(m => makyluat == null || m.Kyluat.Makyluat == makyluat);
            return View(chitietkyluats.Where(m => tukhoa == null || tukhoa.Trim() == "" || m.Machitietkyluat.Contains(tukhoa) || m.Manv.Contains(tukhoa) || m.Thongtinnhansu.Hoten.Contains(tukhoa)).ToList().ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Chitietkyluat_Ad/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietkyluat chitietkyluat = db.Chitietkyluats.Find(id);
            if (chitietkyluat == null)
            {
                return HttpNotFound();
            }
            return View(chitietkyluat);
        }

        // GET: Admin/Chitietkyluat_Ad/Create
        public ActionResult Create()
        {
            ViewBag.Makyluat = new SelectList(db.Kyluats, "Makyluat", "Tenkyluat");
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten");
            return View();
        }

        // POST: Admin/Chitietkyluat_Ad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Machitietkyluat,Manv,Makyluat,Lydokyluat,Tienphat")] Chitietkyluat chitietkyluat)
        {
            if (ModelState.IsValid)
            {
                db.Chitietkyluats.Add(chitietkyluat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Makyluat = new SelectList(db.Kyluats, "Makyluat", "Tenkyluat", chitietkyluat.Makyluat);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", chitietkyluat.Manv);
            return View(chitietkyluat);
        }

        // GET: Admin/Chitietkyluat_Ad/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietkyluat chitietkyluat = db.Chitietkyluats.Find(id);
            if (chitietkyluat == null)
            {
                return HttpNotFound();
            }
            ViewBag.Makyluat = new SelectList(db.Kyluats, "Makyluat", "Tenkyluat", chitietkyluat.Makyluat);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", chitietkyluat.Manv);
            return View(chitietkyluat);
        }

        // POST: Admin/Chitietkyluat_Ad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Machitietkyluat,Manv,Makyluat,Lydokyluat,Tienphat")] Chitietkyluat chitietkyluat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chitietkyluat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Makyluat = new SelectList(db.Kyluats, "Makyluat", "Tenkyluat", chitietkyluat.Makyluat);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", chitietkyluat.Manv);
            return View(chitietkyluat);
        }

        // GET: Admin/Chitietkyluat_Ad/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietkyluat chitietkyluat = db.Chitietkyluats.Find(id);
            if (chitietkyluat == null)
            {
                return HttpNotFound();
            }
            return View(chitietkyluat);
        }

        // POST: Admin/Chitietkyluat_Ad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Chitietkyluat chitietkyluat = db.Chitietkyluats.Find(id);
            db.Chitietkyluats.Remove(chitietkyluat);
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
