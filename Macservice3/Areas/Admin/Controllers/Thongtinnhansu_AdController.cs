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
    public class Thongtinnhansu_AdController : Controller
    {
        private Macservice db = new Macservice();

        // GET: Admin/Thongtinnhansu_Ad
        public ActionResult Index(int? page, string tukhoa, string machucvu, string maphongban, string matrinhdochuyenmon)
        {
            // phân trang
            if (page == null) page = 1;
            var links = (from l in db.Phongbans
                         select l).OrderBy(x => x.Maphongban);
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            // Tìm kiếm 

            ViewBag.Tukhoa = tukhoa;
            ViewBag.Machucvu = machucvu;
            ViewBag.Maphongban = maphongban;
            ViewBag.Matrinhdochuyenmon = matrinhdochuyenmon;

            if (tukhoa != null)
            {
                tukhoa = tukhoa.ToLower();
                tukhoa = tukhoa.Replace("p", "").Replace("0", "");
            }
            var thongtinnhansus = db.Thongtinnhansus.Include(t => t.Chucvu).Include(t => t.Phongban).Include(t => t.Trinhdo_chuyenmon)
                .Where(m => matrinhdochuyenmon == null || m.Trinhdo_chuyenmon.Matrinhdochuyenmon == matrinhdochuyenmon)
                .Where(m => machucvu == null || m.Chucvu.Machucvu == machucvu)
                .Where(m => maphongban == null || m.Phongban.Maphongban == maphongban);
            return View(thongtinnhansus.Where(m => tukhoa == null || tukhoa.Trim() == "" || m.Manv.Contains(tukhoa) || m.Hoten.Contains(tukhoa)).ToList().ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Thongtinnhansu_Ad/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thongtinnhansu thongtinnhansu = db.Thongtinnhansus.Find(id);
            if (thongtinnhansu == null)
            {
                return HttpNotFound();
            }
            return View(thongtinnhansu);
        }

        // GET: Admin/Thongtinnhansu_Ad/Create
        public ActionResult Create()
        {
            ViewBag.Machucvu = new SelectList(db.Chucvus, "Machucvu", "Tenchucvu");
            ViewBag.Maphongban = new SelectList(db.Phongbans, "Maphongban", "Tenphongban");
            ViewBag.Matrinhdochuyenmon = new SelectList(db.Trinhdo_chuyenmon, "Matrinhdochuyenmon", "Tentrinhdochuyenmon");
            return View();
        }

        // POST: Admin/Thongtinnhansu_Ad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Manv,Hoten,Ngaysinh,SDT,Gioitinh,Email,Dantoc,Noisinh,Hokhauthuongtru,Noiohientai,CMND,Ngaycap,Noicap,Maphongban,Machucvu,Matrinhdochuyenmon")] Thongtinnhansu thongtinnhansu)
        {
            if (ModelState.IsValid)
            {
                db.Thongtinnhansus.Add(thongtinnhansu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Machucvu = new SelectList(db.Chucvus, "Machucvu", "Tenchucvu", thongtinnhansu.Machucvu);
            ViewBag.Maphongban = new SelectList(db.Phongbans, "Maphongban", "Tenphongban", thongtinnhansu.Maphongban);
            ViewBag.Matrinhdochuyenmon = new SelectList(db.Trinhdo_chuyenmon, "Matrinhdochuyenmon", "Tentrinhdochuyenmon", thongtinnhansu.Matrinhdochuyenmon);
            return View(thongtinnhansu);
        }

        // GET: Admin/Thongtinnhansu_Ad/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thongtinnhansu thongtinnhansu = db.Thongtinnhansus.Find(id);
            if (thongtinnhansu == null)
            {
                return HttpNotFound();
            }
            ViewBag.Machucvu = new SelectList(db.Chucvus, "Machucvu", "Tenchucvu", thongtinnhansu.Machucvu);
            ViewBag.Maphongban = new SelectList(db.Phongbans, "Maphongban", "Tenphongban", thongtinnhansu.Maphongban);
            ViewBag.Matrinhdochuyenmon = new SelectList(db.Trinhdo_chuyenmon, "Matrinhdochuyenmon", "Tentrinhdochuyenmon", thongtinnhansu.Matrinhdochuyenmon);
            return View(thongtinnhansu);
        }

        // POST: Admin/Thongtinnhansu_Ad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Manv,Hoten,Ngaysinh,SDT,Gioitinh,Email,Dantoc,Noisinh,Hokhauthuongtru,Noiohientai,CMND,Ngaycap,Noicap,Maphongban,Machucvu,Matrinhdochuyenmon")] Thongtinnhansu thongtinnhansu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thongtinnhansu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Machucvu = new SelectList(db.Chucvus, "Machucvu", "Tenchucvu", thongtinnhansu.Machucvu);
            ViewBag.Maphongban = new SelectList(db.Phongbans, "Maphongban", "Tenphongban", thongtinnhansu.Maphongban);
            ViewBag.Matrinhdochuyenmon = new SelectList(db.Trinhdo_chuyenmon, "Matrinhdochuyenmon", "Tentrinhdochuyenmon", thongtinnhansu.Matrinhdochuyenmon);
            return View(thongtinnhansu);
        }

        // GET: Admin/Thongtinnhansu_Ad/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thongtinnhansu thongtinnhansu = db.Thongtinnhansus.Find(id);
            if (thongtinnhansu == null)
            {
                return HttpNotFound();
            }
            return View(thongtinnhansu);
        }

        // POST: Admin/Thongtinnhansu_Ad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Thongtinnhansu thongtinnhansu = db.Thongtinnhansus.Find(id);
            db.Thongtinnhansus.Remove(thongtinnhansu);
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
