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
    public class ExpedientsController : Controller
    {
        private GDEntities db = new GDEntities();

        // GET: Expedients
        public ActionResult Index()
        {
            var expedient = db.Expedient.Include(e => e.Project).Include(e => e.TypeProcess);
            return View(expedient.ToList());
        }

        // GET: Expedients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expedient expedient = db.Expedient.Find(id);
            if (expedient == null)
            {
                return HttpNotFound();
            }
            return View(expedient);
        }

        // GET: Expedients/Create
        public ActionResult Create()
        {
            ViewBag.IdProject = new SelectList(db.Project, "IdProject", "CodProject");
            ViewBag.IdTypeProcess = new SelectList(db.TypeProcess, "IdTypeProcess", "Name");
            return View();
        }

        // POST: Expedients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdExpendient,IdProject,FileExpendient,Predial,NameDemandant,IdTypeProcess,Settled,Court,Magistrate,Resposible,Amount,appraise,DateCreate,Advance,Active")] Expedient expedient)
        {
            if (ModelState.IsValid)
            {
                db.Expedient.Add(expedient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProject = new SelectList(db.Project, "IdProject", "CodProject", expedient.IdProject);
            ViewBag.IdTypeProcess = new SelectList(db.TypeProcess, "IdTypeProcess", "Name", expedient.IdTypeProcess);
            return View(expedient);
        }

        // GET: Expedients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expedient expedient = db.Expedient.Find(id);
            if (expedient == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProject = new SelectList(db.Project, "IdProject", "CodProject", expedient.IdProject);
            ViewBag.IdTypeProcess = new SelectList(db.TypeProcess, "IdTypeProcess", "Name", expedient.IdTypeProcess);
            return View(expedient);
        }

        // POST: Expedients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdExpendient,IdProject,FileExpendient,Predial,NameDemandant,IdTypeProcess,Settled,Court,Magistrate,Resposible,Amount,appraise,DateCreate,Advance,Active")] Expedient expedient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expedient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProject = new SelectList(db.Project, "IdProject", "CodProject", expedient.IdProject);
            ViewBag.IdTypeProcess = new SelectList(db.TypeProcess, "IdTypeProcess", "Name", expedient.IdTypeProcess);
            return View(expedient);
        }

        // GET: Expedients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expedient expedient = db.Expedient.Find(id);
            if (expedient == null)
            {
                return HttpNotFound();
            }
            return View(expedient);
        }

        // POST: Expedients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Expedient expedient = db.Expedient.Find(id);
            db.Expedient.Remove(expedient);
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


        //GET
        public ActionResult List(int id)
        {
            var expedient = db.Expedient.Where(e => e.IdProject == id);
            List<ExpedientsMD> ListExpedient = new List<ExpedientsMD>();

            foreach (Expedient item in expedient)
            {
                ExpedientsMD itemExpe =  ConvertExpedientSM(item);
                ListExpedient.Add(itemExpe);
            }
            return View(ListExpedient);
        }

        private ExpedientsMD ConvertExpedientSM(Expedient expedient)
        {
            ExpedientsMD objExpedient = new ExpedientsMD();

            objExpedient.IdExpendient = expedient.IdExpendient;
            objExpedient.IdProject = expedient.IdProject;
            objExpedient.FileExpendient = expedient.FileExpendient;
            objExpedient.Predial = expedient.Predial;
            objExpedient.NameDemandant = expedient.NameDemandant;
            objExpedient.IdTypeProcess = expedient.IdTypeProcess;
            objExpedient.Settled = expedient.Settled;
            objExpedient.Court = expedient.Court;
            objExpedient.Magistrate = expedient.Magistrate;
            objExpedient.Resposible = expedient.Resposible;
            objExpedient.Amount = expedient.Amount;
            objExpedient.appraise = expedient.appraise;
            objExpedient.DateCreate = expedient.DateCreate;
            objExpedient.Advance = expedient.Advance;
            objExpedient.Active = expedient.Active;

            return objExpedient;

        }
    }


}
