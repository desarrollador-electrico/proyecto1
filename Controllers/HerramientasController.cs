using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using AriasRomanJonathan_Proyecto1;

namespace AriasRomanJonathan_Proyecto1.Controllers
{
    public class HerramientasController : Controller
    {
        private TallerHerramientasEntities db = new TallerHerramientasEntities();

        // GET: Herramientas
        public ActionResult Index()
        {
            ViewBag.ActiveLink = "Herramientas";
            return View(db.Herramientas.ToList());
        }

        // GET: Herramientas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Herramientas herramientas = db.Herramientas.Find(id);
            if (herramientas == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActiveLink = "Herramientas";
            return View(herramientas);
        }

        // GET: Herramientas/Create
        public ActionResult Create()
        {
            ViewBag.ActiveLink = "Herramientas";
            return View();
        }

        // POST: Herramientas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodigoHerramienta,Nombre,Descripcion,CantidadDisponible")] Herramientas herramientas)
        {
            if (ModelState.IsValid)
            {
            // Logica de validacion dato repetido
            List<Herramientas> lista_herramientas = db.Herramientas.ToList(); // Carga lista de datos DB
            string message = "!! Código de herramienta ya existe !!";
            string title = "Dato Repetido";
            int contador = 1;
            bool repetido = false;

            foreach (Herramientas i in lista_herramientas)
            {
               contador++;
               if (i.CodigoHerramienta.Equals(herramientas.CodigoHerramienta)) // Dato repetido
               {
                  repetido = true;
                  MessageBox.Show(message, title);
                  break;
               }
            } // Final foreach

            if(contador > lista_herramientas.Count && repetido == false)
             {
               db.Herramientas.Add(herramientas);
               db.SaveChanges();
               return RedirectToAction("Index");
            } // Final if

         } // Final IsValid
            ViewBag.ActiveLink = "Herramientas";
            return View(herramientas);
        }

        // GET: Herramientas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Herramientas herramientas = db.Herramientas.Find(id);
            if (herramientas == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActiveLink = "Herramientas";
            return View(herramientas);
        }

        // POST: Herramientas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigoHerramienta,Nombre,Descripcion,CantidadDisponible")] Herramientas herramientas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(herramientas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActiveLink = "Herramientas";
            return View(herramientas);
        }

        // GET: Herramientas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Herramientas herramientas = db.Herramientas.Find(id);
            if (herramientas == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActiveLink = "Herramientas";
            return View(herramientas);
        }

        // POST: Herramientas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Herramientas herramientas = db.Herramientas.Find(id);
            db.Herramientas.Remove(herramientas);
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
