﻿using System;
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
    public class Fuels1Controller : Controller
    {
        private azsEntities db = new azsEntities();
        //Выборка по 2 пункту

        public ActionResult Sort(DateTime begining, DateTime ending)
        {

            List<Operaciya> operdata =
                db.Operaciya.Where(s => s.Data_prih_rash >= begining && s.Data_prih_rash <= ending).ToList();
            ViewBag.time = operdata;
            double[] mass=new double[operdata.Count];
            int ss = 0, cc = 0;
            foreach (var r  in operdata)
            {
                IQueryable<Fuel> inc = db.Fuel;
                foreach (var summ in inc.ToList())
                {
                    if (summ.FuelID==r.FuelID)
                    {
                        mass[ss] += r.Prih_rash;
                    }
                    cc++;
                }
                ss++;
            }
            ViewBag.summa = mass;
            return View();
        }

        // GET: Fuels1
        public ActionResult Index(string FuelTypeFind = "")
        {
            

            var tanks = from m in db.Fuel
                        where m.FuelType.StartsWith(FuelTypeFind)
                        select m;

            return View(tanks.ToList());
        }
        // GET: Fuels1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fuel fuel = db.Fuel.Find(id);
            if (fuel == null)
            {
                return HttpNotFound();
            }
            return View(fuel);
        }

        // GET: Fuels1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fuels1/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FuelID,FuelType,Oktan,Cena,Data,About")] Fuel fuel)
        {
            if (ModelState.IsValid)
            {
                db.Fuel.Add(fuel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fuel);
        }

        // GET: Fuels1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fuel fuel = db.Fuel.Find(id);
            if (fuel == null)
            {
                return HttpNotFound();
            }
            return View(fuel);
        }

        // POST: Fuels1/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FuelID,FuelType,Oktan,Cena,Data,About")] Fuel fuel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fuel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fuel);
        }

        // GET: Fuels1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fuel fuel = db.Fuel.Find(id);
            if (fuel == null)
            {
                return HttpNotFound();
            }
            return View(fuel);
        }

        // POST: Fuels1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fuel fuel = db.Fuel.Find(id);
            db.Fuel.Remove(fuel);
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
