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
    public class DocumentChecksController : Controller
    {
        private GDEntities db = new GDEntities();

        // GET: DocumentChecks
        public ActionResult Index()
        {
            var documentCheck = db.DocumentCheck.Include(d => d.CheckType).Include(d => d.Document).Include(d => d.State).Include(d => d.Type);
            return View(documentCheck.ToList());
        }

        public ActionResult List()
        {
            var documentCheck = db.DocumentCheck.Include(d => d.CheckType).Include(d => d.Document).Include(d => d.State).Include(d => d.Type);
            return View(documentCheck.ToList());
        }

        // GET: DocumentChecks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentCheck documentCheck = db.DocumentCheck.Find(id);
            if (documentCheck == null)
            {
                return HttpNotFound();
            }
            return View(documentCheck);
        }

        // GET: DocumentChecks/Create
        public ActionResult Create()
        {
            ViewBag.IdCheckType = new SelectList(db.CheckType, "IdCheckType", "IdCheckType");
            ViewBag.IdDocument = new SelectList(db.Document, "IdDocument", "Name");
            ViewBag.IdState = new SelectList(db.State, "IdState", "Name");
            ViewBag.IdType = new SelectList(db.Type, "IdType", "Name");
            return View();
        }

        // POST: DocumentChecks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDocumentCheck,IdDocument,IdCheckType,IdState,IdType,Requiered,Active")] DocumentCheck documentCheck)
        {
            if (ModelState.IsValid)
            {
                db.DocumentCheck.Add(documentCheck);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCheckType = new SelectList(db.CheckType, "IdCheckType", "IdCheckType", documentCheck.IdCheckType);
            ViewBag.IdDocument = new SelectList(db.Document, "IdDocument", "Name", documentCheck.IdDocument);
            ViewBag.IdState = new SelectList(db.State, "IdState", "Name", documentCheck.IdState);
            ViewBag.IdType = new SelectList(db.Type, "IdType", "Name", documentCheck.IdType);
            return View(documentCheck);
        }

        // GET: DocumentChecks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentCheck documentCheck = db.DocumentCheck.Find(id);
            if (documentCheck == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCheckType = new SelectList(db.CheckType, "IdCheckType", "IdCheckType", documentCheck.IdCheckType);
            ViewBag.IdDocument = new SelectList(db.Document, "IdDocument", "Name", documentCheck.IdDocument);
            ViewBag.IdState = new SelectList(db.State, "IdState", "Name", documentCheck.IdState);
            ViewBag.IdType = new SelectList(db.Type, "IdType", "Name", documentCheck.IdType);
            return View(documentCheck);
        }

        // POST: DocumentChecks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDocumentCheck,IdDocument,IdCheckType,IdState,IdType,Requiered,Active")] DocumentCheck documentCheck)
        {
            if (ModelState.IsValid)
            {
                db.Entry(documentCheck).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCheckType = new SelectList(db.CheckType, "IdCheckType", "IdCheckType", documentCheck.IdCheckType);
            ViewBag.IdDocument = new SelectList(db.Document, "IdDocument", "Name", documentCheck.IdDocument);
            ViewBag.IdState = new SelectList(db.State, "IdState", "Name", documentCheck.IdState);
            ViewBag.IdType = new SelectList(db.Type, "IdType", "Name", documentCheck.IdType);
            return View(documentCheck);
        }

        // GET: DocumentChecks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentCheck documentCheck = db.DocumentCheck.Find(id);
            if (documentCheck == null)
            {
                return HttpNotFound();
            }
            return View(documentCheck);
        }

        // POST: DocumentChecks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DocumentCheck documentCheck = db.DocumentCheck.Find(id);
            db.DocumentCheck.Remove(documentCheck);
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

        [HttpGet]
        public JsonResult ListDocumentProcess(int id, int IdExpedient)
        {
            //Pendiente de agregar tipo de proceso por consulta
            CheckType CT = db.CheckType.Find(id);
            int idCheck = CT.IdCheckType;

            var ListCheck = (from DC in db.DocumentCheck
                             join D in db.Document on DC.IdDocument equals D.IdDocument
                             join T in db.Type on DC.IdType equals T.IdType
                             join S in db.State on DC.IdState equals S.IdState
                             where DC.IdCheckType == idCheck
                             select new DocumentAdjMD()
                             {
                                 idDocument = DC.IdDocument,
                                 idDocumentType = DC.IdDocumentCheck,
                                 IdDocumentCheck = DC.IdDocumentCheck,
                                 idCheckType = DC.IdCheckType,
                                 name = D.Name,
                                 description = D.Description,
                                 idType = DC.IdType,
                                 type = T.Name,
                                 idState = DC.IdState,
                                 state = S.Name,
                                 requeried = DC.Requiered,
                                 nameRequeried = DC.Requiered == true ? "SI" : "NO"

                             }).ToList();

            for (int i = 0; i < ListCheck.Count; i++)
            {
                ListCheck[i].adjImg = adjImagen(ListCheck[i].IdDocumentCheck, IdExpedient, ListCheck[i].requeried);
            }


            return Json(ListCheck, JsonRequestBehavior.AllowGet);
        }


        protected bool adjImagen(int IdDocumentCheck, int IdExpedient, bool Requiered)
        {
            int count = (from DP in db.DocumentProcess
                         where DP.IdDocumentCheck == IdDocumentCheck && DP.IdExpedient == IdExpedient
                         select new
                         {
                             id = DP.IdDocumentProcess,
                         }).ToList().Count();
            if (count > 0 && Requiered == true)
            {
                return false;
            }
            return true;

        }
    }

}
