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
    public class DocumentProcessesController : Controller
    {
        private GDEntities db = new GDEntities();

        // GET: DocumentProcesses
        public ActionResult Index()
        {
            var documentProcess = db.DocumentProcess.Include(d => d.DocumentCheck).Include(d => d.Expedient);
            return View(documentProcess.ToList());
        }

        // GET: DocumentProcesses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentProcess documentProcess = db.DocumentProcess.Find(id);
            if (documentProcess == null)
            {
                return HttpNotFound();
            }
            return View(documentProcess);
        }

        // GET: DocumentProcesses/Create
        public ActionResult Create()
        {
            ViewBag.IdDocumentCheck = new SelectList(db.DocumentCheck, "IdDocumentCheck", "IdDocumentCheck");
            ViewBag.IdExpedient = new SelectList(db.Expedient, "IdExpendient", "FileExpendient");
            return View();
        }

        // POST: DocumentProcesses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDocumentProcess,IdDocumentCheck,IdExpedient,IdState,IdType,Requiered,Active")] DocumentProcess documentProcess)
        {
            if (ModelState.IsValid)
            {
                db.DocumentProcess.Add(documentProcess);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdDocumentCheck = new SelectList(db.DocumentCheck, "IdDocumentCheck", "IdDocumentCheck", documentProcess.IdDocumentCheck);
            ViewBag.IdExpedient = new SelectList(db.Expedient, "IdExpendient", "FileExpendient", documentProcess.IdExpedient);
            return View(documentProcess);
        }

        // GET: DocumentProcesses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentProcess documentProcess = db.DocumentProcess.Find(id);
            if (documentProcess == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDocumentCheck = new SelectList(db.DocumentCheck, "IdDocumentCheck", "IdDocumentCheck", documentProcess.IdDocumentCheck);
            ViewBag.IdExpedient = new SelectList(db.Expedient, "IdExpendient", "FileExpendient", documentProcess.IdExpedient);
            return View(documentProcess);
        }

        // POST: DocumentProcesses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDocumentProcess,IdDocumentCheck,IdExpedient,IdState,IdType,Requiered,Active")] DocumentProcess documentProcess)
        {
            if (ModelState.IsValid)
            {
                db.Entry(documentProcess).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdDocumentCheck = new SelectList(db.DocumentCheck, "IdDocumentCheck", "IdDocumentCheck", documentProcess.IdDocumentCheck);
            ViewBag.IdExpedient = new SelectList(db.Expedient, "IdExpendient", "FileExpendient", documentProcess.IdExpedient);
            return View(documentProcess);
        }

        // GET: DocumentProcesses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentProcess documentProcess = db.DocumentProcess.Find(id);
            if (documentProcess == null)
            {
                return HttpNotFound();
            }
            return View(documentProcess);
        }

        // POST: DocumentProcesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DocumentProcess documentProcess = db.DocumentProcess.Find(id);
            db.DocumentProcess.Remove(documentProcess);
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
