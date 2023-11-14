using System;
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
    public class PrestamosHerramientasController : Controller
    {
        private TallerHerramientasEntities db = new TallerHerramientasEntities();

        // GET: PrestamosHerramientas
        public ActionResult Index()
        {
            var prestamosHerramientas = db.PrestamosHerramientas.Include(p => p.Colaboradores).Include(p => p.Herramientas);
            ViewBag.ActiveLink = "PrestamosHerramientas";
            return View(prestamosHerramientas.ToList());
        }

        // GET: PrestamosHerramientas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrestamosHerramientas prestamosHerramientas = db.PrestamosHerramientas.Find(id);
            if (prestamosHerramientas == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActiveLink = "PrestamosHerramientas";
            return View(prestamosHerramientas);
        }

        // GET: PrestamosHerramientas/Create
        public ActionResult Create()
        {
            ViewBag.CedulaIdentidad = new SelectList(db.Colaboradores, "CedulaIdentidad", "Nombre");
            ViewBag.CodigoHerramienta = new SelectList(db.Herramientas, "CodigoHerramienta", "Nombre");
            ViewBag.ActiveLink = "PrestamosHerramientas";
            return View();
        }

        // POST: PrestamosHerramientas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPrestamo,CedulaIdentidad,CodigoHerramienta,FechaPrestamo,FechaCompromisoDevolucion,FechaRealDevolucion")] PrestamosHerramientas prestamosHerramientas)
        {
            if (ModelState.IsValid)
            {
               int reservaciones = 1;
            string message = "!! Se alcanzó el máximo de 5 herramientas !!";
            string title = "Máximo de Reservaciones Alcanzado";
            List<PrestamosHerramientas> lista_prestamo = db.PrestamosHerramientas.ToList(); // Carga lista de datos DB

            foreach (PrestamosHerramientas i in lista_prestamo)
            {
               if (prestamosHerramientas.CedulaIdentidad == i.CedulaIdentidad)
               {
                  reservaciones++;
               } // Final if
            }
            
            if(reservaciones > 5)
            {
               MessageBox.Show(message, title);
            }
            else
            {
               db.PrestamosHerramientas.Add(prestamosHerramientas);
               db.SaveChanges();
               return RedirectToAction("Index");
            } // Final if-else


                

            } // Final del If

            ViewBag.CedulaIdentidad = new SelectList(db.Colaboradores, "CedulaIdentidad", "Nombre", prestamosHerramientas.CedulaIdentidad);
            ViewBag.CodigoHerramienta = new SelectList(db.Herramientas, "CodigoHerramienta", "Nombre", prestamosHerramientas.CodigoHerramienta);
            ViewBag.ActiveLink = "PrestamosHerramientas";
            return View(prestamosHerramientas);
        }

        // GET: PrestamosHerramientas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrestamosHerramientas prestamosHerramientas = db.PrestamosHerramientas.Find(id);
            if (prestamosHerramientas == null)
            {
                return HttpNotFound();
            }
            ViewBag.CedulaIdentidad = new SelectList(db.Colaboradores, "CedulaIdentidad", "Nombre", prestamosHerramientas.CedulaIdentidad);
            ViewBag.CodigoHerramienta = new SelectList(db.Herramientas, "CodigoHerramienta", "Nombre", prestamosHerramientas.CodigoHerramienta);
            ViewBag.FechaPrestamo = new SelectList(db.Herramientas, "IDPrestamo", "FechaPrestamo", prestamosHerramientas.FechaPrestamo);
            ViewBag.FechaCompromisoDevolucion = new SelectList(db.Herramientas, "IDPrestamo", "FechaCompromisoDevolucion", prestamosHerramientas.FechaCompromisoDevolucion);
            ViewBag.FechaRealDevolucion = new SelectList(db.Herramientas, "IDPrestamo", "FechaRealDevolucion", prestamosHerramientas.FechaRealDevolucion);
            ViewBag.ActiveLink = "PrestamosHerramientas";
            return View(prestamosHerramientas);
        }

        // POST: PrestamosHerramientas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPrestamo,CedulaIdentidad,CodigoHerramienta,FechaPrestamo,FechaCompromisoDevolucion,FechaRealDevolucion")] PrestamosHerramientas prestamosHerramientas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prestamosHerramientas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CedulaIdentidad = new SelectList(db.Colaboradores, "CedulaIdentidad", "Nombre", prestamosHerramientas.CedulaIdentidad);
            ViewBag.CodigoHerramienta = new SelectList(db.Herramientas, "CodigoHerramienta", "Nombre", prestamosHerramientas.CodigoHerramienta);
            ViewBag.ActiveLink = "PrestamosHerramientas";
            return View(prestamosHerramientas);
        }

        // GET: PrestamosHerramientas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrestamosHerramientas prestamosHerramientas = db.PrestamosHerramientas.Find(id);
            if (prestamosHerramientas == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActiveLink = "PrestamosHerramientas";
            return View(prestamosHerramientas);
        }

        // POST: PrestamosHerramientas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PrestamosHerramientas prestamosHerramientas = db.PrestamosHerramientas.Find(id);
            db.PrestamosHerramientas.Remove(prestamosHerramientas);
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
