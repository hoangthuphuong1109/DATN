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
    public class Chucvu_EmController : Controller
    {
        private Macservice db = new Macservice();

        // GET: Employee/Chucvu_Em
        public ActionResult Index()
        {
            return View(db.Chucvus.ToList());
        }

        // GET: Employee/Chucvu_Em/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chucvu chucvu = db.Chucvus.Find(id);
            if (chucvu == null)
            {
                return HttpNotFound();
            }
            return View(chucvu);
        }

        // GET: Employee/Chucvu_Em/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Chucvu_Em/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Machucvu,Tenchucvu")] Chucvu chucvu)
        {
            if (ModelState.IsValid)
            {
                db.Chucvus.Add(chucvu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chucvu);
        }

        // GET: Employee/Chucvu_Em/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chucvu chucvu = db.Chucvus.Find(id);
            if (chucvu == null)
            {
                return HttpNotFound();
            }
            return View(chucvu);
        }

        // POST: Employee/Chucvu_Em/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Machucvu,Tenchucvu")] Chucvu chucvu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chucvu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chucvu);
        }

        // GET: Employee/Chucvu_Em/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chucvu chucvu = db.Chucvus.Find(id);
            if (chucvu == null)
            {
                return HttpNotFound();
            }
            return View(chucvu);
        }

        // POST: Employee/Chucvu_Em/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Chucvu chucvu = db.Chucvus.Find(id);
            db.Chucvus.Remove(chucvu);
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
