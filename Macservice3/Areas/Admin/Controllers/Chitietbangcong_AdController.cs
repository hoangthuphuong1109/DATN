using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Macservice3.Models;
using PagedList;

namespace Macservice3.Areas.Admin.Controllers
{
    public class Chitietbangcong_AdController : Controller
    {
        private Macservice db = new Macservice();
        Xuly xl = new Xuly();

        // GET: Admin/Chitietbangcong_Ad
        public ActionResult Index(int? page, string tukhoa, string manv, int? thang)
        {

            // phân trang
            if (page == null) page = 1;
            var links = (from l in db.Chitietbangcongs
                         select l).OrderBy(x => x.Machitietbangcong);
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            // Tìm kiếm 

            ViewBag.Tukhoa = tukhoa;
            ViewBag.Manv = manv;
            ViewBag.Thangchamcong = thang;

            if (tukhoa != null)
            {
                tukhoa = tukhoa.ToLower();
                tukhoa = tukhoa.Replace("p", "").Replace("0", "");
            }
            var chitietbangcongs = db.Chitietbangcongs.Include(c => c.Bangchamcong).Include(c => c.Phongban).Include(c => c.Thongtinnhansu)
                .Where(m => manv == null || m.Thongtinnhansu.Manv == manv)
                .Where(m => thang == null || m.Bangchamcong.Thangchamcong == thang);
            return View(chitietbangcongs.Where(m => tukhoa == null || tukhoa.Trim() == "" || m.Machitietbangcong.Contains(tukhoa) || m.Manv.Contains(tukhoa) || m.Thongtinnhansu.Hoten.Contains(tukhoa)).ToList().ToPagedList(pageNumber, pageSize));
        }


        //Upload file xl
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                string _FileName = "DemoUploadFile.xlsx";
                string _path = Path.Combine(Server.MapPath("~/Uploads/Excels"), _FileName);
                file.SaveAs(_path);
                ViewBag.upload = _path;
                DataTable dt = new DataTable();
                dt = xl.ReadDataFromExcelFile(_path);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Bangchamcong bcc = new Bangchamcong();
                    bcc.Mabangcong = "BCC01";
                    bcc.Maphongban = dt.Rows[i][0].ToString();
                    db.Bangchamcongs.Add(bcc);
                    db.SaveChanges();
                }
            }
            else
            {
                ViewBag.upload = "Upload file không thành công";
            }


            return View();
        }
        // GET: Admin/Chitietbangcong_Ad/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietbangcong chitietbangcong = db.Chitietbangcongs.Find(id);
            if (chitietbangcong == null)
            {
                return HttpNotFound();
            }
            return View(chitietbangcong);
        }

        // GET: Admin/Chitietbangcong_Ad/Create
        public ActionResult Create()
        {
            ViewBag.Mabangcong = new SelectList(db.Bangchamcongs, "Mabangcong", "Maphongban");
            ViewBag.Maphongban = new SelectList(db.Phongbans, "Maphongban", "Tenphongban");
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten");
            return View();
        }

        // POST: Admin/Chitietbangcong_Ad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Machitietbangcong,Manv,Mabangcong,Sogiolam,Sogiolamthemngaythuong,Sogiolamthemngaynghi,Sogiolamthemngayle,Songaynghiphep,Maphongban")] Chitietbangcong chitietbangcong)
        {
            if (ModelState.IsValid)
            {
                db.Chitietbangcongs.Add(chitietbangcong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Mabangcong = new SelectList(db.Bangchamcongs, "Mabangcong", "Maphongban", chitietbangcong.Mabangcong);
            ViewBag.Maphongban = new SelectList(db.Phongbans, "Maphongban", "Tenphongban", chitietbangcong.Maphongban);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", chitietbangcong.Manv);
            return View(chitietbangcong);
        }

        // GET: Admin/Chitietbangcong_Ad/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietbangcong chitietbangcong = db.Chitietbangcongs.Find(id);
            if (chitietbangcong == null)
            {
                return HttpNotFound();
            }
            ViewBag.Mabangcong = new SelectList(db.Bangchamcongs, "Mabangcong", "Maphongban", chitietbangcong.Mabangcong);
            ViewBag.Maphongban = new SelectList(db.Phongbans, "Maphongban", "Tenphongban", chitietbangcong.Maphongban);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", chitietbangcong.Manv);
            return View(chitietbangcong);
        }

        // POST: Admin/Chitietbangcong_Ad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Machitietbangcong,Manv,Mabangcong,Sogiolam,Sogiolamthemngaythuong,Sogiolamthemngaynghi,Sogiolamthemngayle,Songaynghiphep,Maphongban")] Chitietbangcong chitietbangcong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chitietbangcong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Mabangcong = new SelectList(db.Bangchamcongs, "Mabangcong", "Maphongban", chitietbangcong.Mabangcong);
            ViewBag.Maphongban = new SelectList(db.Phongbans, "Maphongban", "Tenphongban", chitietbangcong.Maphongban);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", chitietbangcong.Manv);
            return View(chitietbangcong);
        }

        // GET: Admin/Chitietbangcong_Ad/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietbangcong chitietbangcong = db.Chitietbangcongs.Find(id);
            if (chitietbangcong == null)
            {
                return HttpNotFound();
            }
            return View(chitietbangcong);
        }

        // POST: Admin/Chitietbangcong_Ad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Chitietbangcong chitietbangcong = db.Chitietbangcongs.Find(id);
            db.Chitietbangcongs.Remove(chitietbangcong);
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
