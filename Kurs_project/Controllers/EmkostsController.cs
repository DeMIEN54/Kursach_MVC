using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kurs_project.Models;

namespace Kurs_project.Controllers
{
    public class EmkostsController : Controller
    {
        private azsEntities db = new azsEntities();

        // GET: Emkosts
        public ActionResult Index()
        {
            var emkost = db.Emkost.Include(e => e.Fuel);
            return View(emkost.ToList());
        }

        // GET: Emkosts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emkost emkost = db.Emkost.Find(id);
            if (emkost == null)
            {
                return HttpNotFound();
            }
            return View(emkost);
        }

        // GET: Emkosts/Create
        public ActionResult Create()
        {
            ViewBag.FuelID = new SelectList(db.Fuel, "FuelID", "FuelType");
            return View();
        }

        // POST: Emkosts/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmkostID,Nomer,Obyem,FuelID,About")] Emkost emkost)
        {
            if (ModelState.IsValid)
            {
                db.Emkost.Add(emkost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FuelID = new SelectList(db.Fuel, "FuelID", "FuelType", emkost.FuelID);
            return View(emkost);
        }

        // GET: Emkosts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emkost emkost = db.Emkost.Find(id);
            if (emkost == null)
            {
                return HttpNotFound();
            }
            ViewBag.FuelID = new SelectList(db.Fuel, "FuelID", "FuelType", emkost.FuelID);
            return View(emkost);
        }

        // POST: Emkosts/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmkostID,Nomer,Obyem,FuelID,About")] Emkost emkost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emkost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FuelID = new SelectList(db.Fuel, "FuelID", "FuelType", emkost.FuelID);
            return View(emkost);
        }

        // GET: Emkosts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emkost emkost = db.Emkost.Find(id);
            if (emkost == null)
            {
                return HttpNotFound();
            }
            return View(emkost);
        }

        // POST: Emkosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Emkost emkost = db.Emkost.Find(id);
            db.Emkost.Remove(emkost);
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
