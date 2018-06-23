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
    public class CheckProcessesController : Controller
    {
        private GDEntities db = new GDEntities();

        // GET: CheckProcesses
        public ActionResult Index()
        {
            var checkProcess = db.CheckProcess.Include(c => c.CheckType).Include(c => c.Expedient);
            return View(checkProcess.ToList());
        }

        // GET: CheckProcesses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckProcess checkProcess = db.CheckProcess.Find(id);
            if (checkProcess == null)
            {
                return HttpNotFound();
            }
            return View(checkProcess);
        }

        // GET: CheckProcesses/Create
        public ActionResult Create()
        {
            ViewBag.IdCheckType = new SelectList(db.CheckType, "IdCheckType", "IdCheckType");
            ViewBag.IdExpendient = new SelectList(db.Expedient, "IdExpendient", "FileExpendient");
            return View();
        }

        // POST: CheckProcesses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCheckProcess,IdExpendient,IdCheckType,Complete,Active")] CheckProcess checkProcess)
        {
            if (ModelState.IsValid)
            {
                db.CheckProcess.Add(checkProcess);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCheckType = new SelectList(db.CheckType, "IdCheckType", "IdCheckType", checkProcess.IdCheckType);
            ViewBag.IdExpendient = new SelectList(db.Expedient, "IdExpendient", "FileExpendient", checkProcess.IdExpendient);
            return View(checkProcess);
        }

        // GET: CheckProcesses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckProcess checkProcess = db.CheckProcess.Find(id);
            if (checkProcess == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCheckType = new SelectList(db.CheckType, "IdCheckType", "IdCheckType", checkProcess.IdCheckType);
            ViewBag.IdExpendient = new SelectList(db.Expedient, "IdExpendient", "FileExpendient", checkProcess.IdExpendient);
            return View(checkProcess);
        }

        // POST: CheckProcesses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCheckProcess,IdExpendient,IdCheckType,Complete,Active")] CheckProcess checkProcess)
        {
            if (ModelState.IsValid)
            {
                db.Entry(checkProcess).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCheckType = new SelectList(db.CheckType, "IdCheckType", "IdCheckType", checkProcess.IdCheckType);
            ViewBag.IdExpendient = new SelectList(db.Expedient, "IdExpendient", "FileExpendient", checkProcess.IdExpendient);
            return View(checkProcess);
        }

        // GET: CheckProcesses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckProcess checkProcess = db.CheckProcess.Find(id);
            if (checkProcess == null)
            {
                return HttpNotFound();
            }
            return View(checkProcess);
        }

        // POST: CheckProcesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CheckProcess checkProcess = db.CheckProcess.Find(id);
            db.CheckProcess.Remove(checkProcess);
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
