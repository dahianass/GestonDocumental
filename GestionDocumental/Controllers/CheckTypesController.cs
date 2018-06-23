using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestionDocumental.Data;
using GestionDocumental.Metadata;

namespace GestionDocumental.Controllers
{
    public class CheckTypesController : Controller
    {
        private GDEntities db = new GDEntities();

        // GET: CheckTypes
        public ActionResult Index()
        {
            var checkType = db.CheckType.Include(c => c.Check).Include(c => c.TypeProcess);
            return View(checkType.ToList());
        }

        // GET: CheckTypes
        public ActionResult List(int? id)
        {
            DocumentExpedientMD objDocumentExpedient = new DocumentExpedientMD();
            Expedient expedient = db.Expedient.Find(id);
            if (expedient != null)
            {
                objDocumentExpedient.IdExpendient = expedient.IdExpendient;
                objDocumentExpedient.FileExpendient = expedient.FileExpendient;
                objDocumentExpedient.Predial = expedient.Predial;
                objDocumentExpedient.NameDemandant = expedient.NameDemandant;
                objDocumentExpedient.IdTypeProcess = expedient.IdTypeProcess;
            }

            //objDocumentExpedient.ListDocument = ListCheck.ToList();
            return View(objDocumentExpedient);//Json(expedient, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult ListCheckProcess(int id)
        {
            //Pendiente de agregar tipo de proceso por consulta
            Expedient expedient = db.Expedient.Find(id);
            var idType = expedient.IdTypeProcess;



            var ListCheck = (from CT in db.CheckType
                             join C in db.Check on CT.IdChecck equals C.IdCheck
                             where CT.IdTypeProcess == idType
                             select new DocumentProcessMD()
                             {
                                 Name = C.Name,
                                 //Descripcion = C.Description,
                                 idTypeProces = CT.IdTypeProcess,
                                 idCheckType = CT.IdCheckType,
                                 idExpedient = id,
                                 Complet = (from CP in db.CheckProcess
                                            where CP.IdCheckType == CT.IdCheckType && CP.IdExpendient == id
                                            select CP.Complete).FirstOrDefault()
                             }).ToList();

            return Json(ListCheck, JsonRequestBehavior.AllowGet);
        }


        // GET: CheckTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckType checkType = db.CheckType.Find(id);
            if (checkType == null)
            {
                return HttpNotFound();
            }
            return View(checkType);
        }

        // GET: CheckTypes/Create
        public ActionResult Create()
        {
            ViewBag.IdChecck = new SelectList(db.Check, "IdCheck", "Name");
            ViewBag.IdTypeProcess = new SelectList(db.TypeProcess, "IdTypeProcess", "Name");
            return View();
        }

        // POST: CheckTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCheckType,IdTypeProcess,IdChecck,Active")] CheckType checkType)
        {
            if (ModelState.IsValid)
            {
                db.CheckType.Add(checkType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdChecck = new SelectList(db.Check, "IdCheck", "Name", checkType.IdChecck);
            ViewBag.IdTypeProcess = new SelectList(db.TypeProcess, "IdTypeProcess", "Name", checkType.IdTypeProcess);
            return View(checkType);
        }

        // GET: CheckTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckType checkType = db.CheckType.Find(id);
            if (checkType == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdChecck = new SelectList(db.Check, "IdCheck", "Name", checkType.IdChecck);
            ViewBag.IdTypeProcess = new SelectList(db.TypeProcess, "IdTypeProcess", "Name", checkType.IdTypeProcess);
            return View(checkType);
        }

        // POST: CheckTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCheckType,IdTypeProcess,IdChecck,Active")] CheckType checkType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(checkType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdChecck = new SelectList(db.Check, "IdCheck", "Name", checkType.IdChecck);
            ViewBag.IdTypeProcess = new SelectList(db.TypeProcess, "IdTypeProcess", "Name", checkType.IdTypeProcess);
            return View(checkType);
        }

        // GET: CheckTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckType checkType = db.CheckType.Find(id);
            if (checkType == null)
            {
                return HttpNotFound();
            }
            return View(checkType);
        }

        // POST: CheckTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CheckType checkType = db.CheckType.Find(id);
            db.CheckType.Remove(checkType);
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
