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
    public class Phongban_EmController : Controller
    {
        private Macservice db = new Macservice();

        // GET: Employee/Phongban_Em
        public ActionResult Index()
        {
            return View(db.Phongbans.ToList());
        }

        // GET: Employee/Phongban_Em/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phongban phongban = db.Phongbans.Find(id);
            if (phongban == null)
            {
                return HttpNotFound();
            }
            return View(phongban);
        }

        // GET: Employee/Phongban_Em/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Phongban_Em/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Maphongban,Tenphongban")] Phongban phongban)
        {
            if (ModelState.IsValid)
            {
                db.Phongbans.Add(phongban);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phongban);
        }

        // GET: Employee/Phongban_Em/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phongban phongban = db.Phongbans.Find(id);
            if (phongban == null)
            {
                return HttpNotFound();
            }
            return View(phongban);
        }

        // POST: Employee/Phongban_Em/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Maphongban,Tenphongban")] Phongban phongban)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phongban).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phongban);
        }

        // GET: Employee/Phongban_Em/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phongban phongban = db.Phongbans.Find(id);
            if (phongban == null)
            {
                return HttpNotFound();
            }
            return View(phongban);
        }

        // POST: Employee/Phongban_Em/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Phongban phongban = db.Phongbans.Find(id);
            db.Phongbans.Remove(phongban);
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
