using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using Kurs_project.Models;

namespace Kurs_project.Controllers
{
    public class OperaciyasController : Controller
    {
        private azsEntities db = new azsEntities();

        // GET: Operaciyas
       
        public ActionResult Index()
        {
            var operaciya = db.Operaciya.Include(o => o.Emkost).Include(o => o.Fuel).Include(o => o.Sotrudnik);
            return View(operaciya.ToList());
        }
       
      /*  public ActionResult Index(string SotrudnikFind="")
        {

            
            var tanks = from m in db.Operaciya 
                        where m.About.StartsWith(SotrudnikFind)//!
                        select m;
                          
            return View(tanks.ToList());           
        }
        */

        // GET: Operaciyas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operaciya operaciya = db.Operaciya.Find(id);
            if (operaciya == null)
            {
                return HttpNotFound();
            }
            return View(operaciya);
        }

        // GET: Operaciyas/Create
        public ActionResult Create()
        {
            ViewBag.EmkostID = new SelectList(db.Emkost, "EmkostID", "Nomer");
            ViewBag.FuelID = new SelectList(db.Fuel, "FuelID", "FuelType");
            ViewBag.SotrudnikID = new SelectList(db.Sotrudnik, "SotrudnikID", "Family");
            return View();
        }

        // POST: Operaciyas/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OperaciyaID,Prih_rash,Data_prih_rash,EmkostID,SotrudnikID,About,FuelID")] Operaciya operaciya)
        {
            if (ModelState.IsValid)
            {
                db.Operaciya.Add(operaciya);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmkostID = new SelectList(db.Emkost, "EmkostID", "Nomer", operaciya.EmkostID);
            ViewBag.FuelID = new SelectList(db.Fuel, "FuelID", "FuelType", operaciya.FuelID);
            ViewBag.SotrudnikID = new SelectList(db.Sotrudnik, "SotrudnikID", "Family", operaciya.SotrudnikID);
            return View(operaciya);
        }

        // GET: Operaciyas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operaciya operaciya = db.Operaciya.Find(id);
            if (operaciya == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmkostID = new SelectList(db.Emkost, "EmkostID", "Nomer", operaciya.EmkostID);
            ViewBag.FuelID = new SelectList(db.Fuel, "FuelID", "FuelType", operaciya.FuelID);
            ViewBag.SotrudnikID = new SelectList(db.Sotrudnik, "SotrudnikID", "Family", operaciya.SotrudnikID);
            return View(operaciya);
        }

        // POST: Operaciyas/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OperaciyaID,Prih_rash,Data_prih_rash,EmkostID,SotrudnikID,About,FuelID")] Operaciya operaciya)
        {
            if (ModelState.IsValid)
            {
                db.Entry(operaciya).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmkostID = new SelectList(db.Emkost, "EmkostID", "Nomer", operaciya.EmkostID);
            ViewBag.FuelID = new SelectList(db.Fuel, "FuelID", "FuelType", operaciya.FuelID);
            ViewBag.SotrudnikID = new SelectList(db.Sotrudnik, "SotrudnikID", "Family", operaciya.SotrudnikID);
            return View(operaciya);
        }

        // GET: Operaciyas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operaciya operaciya = db.Operaciya.Find(id);
            if (operaciya == null)
            {
                return HttpNotFound();
            }
            return View(operaciya);
        }

        // POST: Operaciyas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Operaciya operaciya = db.Operaciya.Find(id);
            db.Operaciya.Remove(operaciya);
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
