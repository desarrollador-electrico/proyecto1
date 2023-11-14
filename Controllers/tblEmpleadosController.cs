using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AriasRomanJonathan_Proyecto1;

namespace AriasRomanJonathan_Proyecto1.Controllers
{
    public class tblEmpleadosController : Controller
    {
        private EmpresaEntities db = new EmpresaEntities();

        // GET: tblEmpleados
        public ActionResult Index()
        {
            ViewBag.ActiveLink = "CRUD";
            return View(db.tblEmpleados.ToList());
        }

        // GET: tblEmpleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmpleados tblEmpleados = db.tblEmpleados.Find(id);
            if (tblEmpleados == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActiveLink = "CRUD";
            return View(tblEmpleados);
        }

        // GET: tblEmpleados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblEmpleados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Apellidos")] tblEmpleados tblEmpleados)
        {
            if (ModelState.IsValid)
            {
                db.tblEmpleados.Add(tblEmpleados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActiveLink = "CRUD";
            return View(tblEmpleados);
        }

        // GET: tblEmpleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmpleados tblEmpleados = db.tblEmpleados.Find(id);
            if (tblEmpleados == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActiveLink = "CRUD";
            return View(tblEmpleados);
        }

        // POST: tblEmpleados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,Apellidos")] tblEmpleados tblEmpleados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblEmpleados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActiveLink = "CRUD";
            return View(tblEmpleados);
        }

        // GET: tblEmpleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmpleados tblEmpleados = db.tblEmpleados.Find(id);
            if (tblEmpleados == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActiveLink = "CRUD";
            return View(tblEmpleados);
        }

        // POST: tblEmpleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblEmpleados tblEmpleados = db.tblEmpleados.Find(id);
            db.tblEmpleados.Remove(tblEmpleados);
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
