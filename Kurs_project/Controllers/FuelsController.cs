using System.Net;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kurs_project.Models;
using System.Data.Entity;

namespace Kurs_project.Controllers
{
    public class FuelsController : Controller
    {
        private  azsEntities db=new azsEntities();
        // GET: Fuels
        public ActionResult Index(string FuelFind="")
        {
            var fuel = from m in db.Fuel
                where m.FuelType.StartsWith(FuelFind)
                select m;
            
            
            
            return View(fuel.ToList());
        }

        // GET: Fuels/Details/5
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

        // GET: Fuels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fuels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FuelID,FuelType,Oktan,Cena,Data,About")] Fuel fuel)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    db.Fuel.Add(fuel);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(fuel);
            }
            catch
            {
                return View();
            }
        }

        // GET: Fuels/Edit/5
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

        // POST: Fuels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FuelID,FuelType,Oktan,Cena,Data,About")] Fuel fuel)
        {
            ViewBag.Title = "Гсм";

            if (ModelState.IsValid)
            {
                db.Entry(fuel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fuel);
      
        }

        // GET: Fuels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return  new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fuel fuel = db.Fuel.Find(id);
            if (fuel == null)
            {
                return HttpNotFound();
            }
            return View(fuel);
        }

        // POST: Fuels/Delete/5
        [HttpPost,ActionName("Delete")]
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

