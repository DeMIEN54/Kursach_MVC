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
    public class SotrudniksController : Controller
    { 
        private azsEntities db = new azsEntities();
        

        // GET: Sotrudniks  
        [HttpPost]      
        public ActionResult Sort(DateTime begining,DateTime ending)
        {

            List<Operaciya> operdata =
                db.Operaciya.Where(s => s.Data_prih_rash >= begining && s.Data_prih_rash <= ending).ToList();
            ViewBag.time = operdata;
            return View();
        }
        public ActionResult Index(string SotrudnikFind = "")
        {


            var tanks = from m in db.Sotrudnik
                where m.Family.StartsWith(SotrudnikFind)
                select m;

            return View(tanks.ToList());
        }

        // GET: Sotrudniks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sotrudnik sotrudnik = db.Sotrudnik.Find(id);
            if (sotrudnik == null)
            {
                return HttpNotFound();
            }
            return View(sotrudnik);
        }

        // GET: Sotrudniks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sotrudniks/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SotrudnikID,Name,Family,Otchestvo,Dolgnost,Data_nach_rab,Data_okon_rab,About")] Sotrudnik sotrudnik)
        {
            if (ModelState.IsValid)
            {
                db.Sotrudnik.Add(sotrudnik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sotrudnik);
        }

        // GET: Sotrudniks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sotrudnik sotrudnik = db.Sotrudnik.Find(id);
            if (sotrudnik == null)
            {
                return HttpNotFound();
            }
            return View(sotrudnik);
        }

        // POST: Sotrudniks/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SotrudnikID,Name,Family,Otchestvo,Dolgnost,Data_nach_rab,Data_okon_rab,About")] Sotrudnik sotrudnik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sotrudnik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sotrudnik);
        }

        // GET: Sotrudniks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sotrudnik sotrudnik = db.Sotrudnik.Find(id);
            if (sotrudnik == null)
            {
                return HttpNotFound();
            }
            return View(sotrudnik);
        }

        // POST: Sotrudniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sotrudnik sotrudnik = db.Sotrudnik.Find(id);
            db.Sotrudnik.Remove(sotrudnik);
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
