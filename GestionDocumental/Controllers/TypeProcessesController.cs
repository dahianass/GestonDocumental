using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestionDocumental.Data;

namespace GestionDocumental.Controllers
{
    public class TypeProcessesController : Controller
    {
        private GDEntities db = new GDEntities();

        // GET: TypeProcesses
        public ActionResult Index()
        {
            return View(db.TypeProcess.ToList());
        }

        // GET: TypeProcesses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeProcess typeProcess = db.TypeProcess.Find(id);
            if (typeProcess == null)
            {
                return HttpNotFound();
            }
            return View(typeProcess);
        }

        // GET: TypeProcesses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeProcesses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTypeProcess,Name,Descriptionq,Active,UseType")] TypeProcess typeProcess)
        {
            if (ModelState.IsValid)
            {
                db.TypeProcess.Add(typeProcess);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeProcess);
        }

        // GET: TypeProcesses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeProcess typeProcess = db.TypeProcess.Find(id);
            if (typeProcess == null)
            {
                return HttpNotFound();
            }
            return View(typeProcess);
        }

        // POST: TypeProcesses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTypeProcess,Name,Descriptionq,Active,UseType")] TypeProcess typeProcess)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeProcess).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeProcess);
        }

        // GET: TypeProcesses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeProcess typeProcess = db.TypeProcess.Find(id);
            if (typeProcess == null)
            {
                return HttpNotFound();
            }
            return View(typeProcess);
        }

        // POST: TypeProcesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypeProcess typeProcess = db.TypeProcess.Find(id);
            db.TypeProcess.Remove(typeProcess);
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
