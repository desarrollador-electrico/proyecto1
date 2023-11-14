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
    public class ColaboradoresController : Controller
    {
        private TallerHerramientasEntities db = new TallerHerramientasEntities();

        // GET: Colaboradores
        public ActionResult Index()
        {
         ViewBag.ActiveLink = "Colaboradores";
         return View(db.Colaboradores.ToList());
        }

        // GET: Colaboradores/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colaboradores colaboradores = db.Colaboradores.Find(id);
            if (colaboradores == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActiveLink = "Colaboradores";
            return View(colaboradores);
        }

        // GET: Colaboradores/Create
        public ActionResult Create()
        {
            ViewBag.ActiveLink = "Colaboradores";
            return View();
        }

        // POST: Colaboradores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CedulaIdentidad,Nombre,Apellidos,FechaRegistro,Estado")] Colaboradores colaboradores)
        {
            if (ModelState.IsValid)
            {                
            // Logica de validacion dato repetido
            List<Colaboradores> lista_colaboradores = db.Colaboradores.ToList(); // Carga lista de datos DB
            string message = "!! ID del colaborador ya existe !!";
            string title = "Dato Repetido";
            int contador = 1;
            bool repetido = false;

            foreach (Colaboradores i in lista_colaboradores)
            {
               contador++;
               if (i.CedulaIdentidad.Equals(colaboradores.CedulaIdentidad)) // Dato repetido
               {
                  repetido = true;
                  MessageBox.Show(message, title);
                  break;
               }
            } // Final foreach

            if (contador > lista_colaboradores.Count && repetido == false)
            {
               db.Colaboradores.Add(colaboradores);
               db.SaveChanges();
               return RedirectToAction("Index");
            } // Final if

         } // Final IsValid
            ViewBag.ActiveLink = "Colaboradores";
            return View(colaboradores);
        }

        // GET: Colaboradores/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colaboradores colaboradores = db.Colaboradores.Find(id);
            if (colaboradores == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActiveLink = "Colaboradores";
            return View(colaboradores);
        }

        // POST: Colaboradores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CedulaIdentidad,Nombre,Apellidos,FechaRegistro,Estado")] Colaboradores colaboradores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(colaboradores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActiveLink = "Colaboradores";
            return View(colaboradores);
        }

        // GET: Colaboradores/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colaboradores colaboradores = db.Colaboradores.Find(id);
            if (colaboradores == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActiveLink = "Colaboradores";
            return View(colaboradores);
        }

        // POST: Colaboradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Colaboradores colaboradores = db.Colaboradores.Find(id);
            db.Colaboradores.Remove(colaboradores);
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
