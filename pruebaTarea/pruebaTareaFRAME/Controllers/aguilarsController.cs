using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using pruebaTarea.Models;

namespace pruebaTareaFRAME.Controllers
{
    public class aguilarsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: aguilars
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        // GET: aguilars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aguilar aguilar = db.Students.Find(id);
            if (aguilar == null)
            {
                return HttpNotFound();
            }
            return View(aguilar);
        }

        // GET: aguilars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: aguilars/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "aguilar_ID,FriendofAguilar,Place_lista,email,Birthday")] aguilar aguilar)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(aguilar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aguilar);
        }

        // GET: aguilars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aguilar aguilar = db.Students.Find(id);
            if (aguilar == null)
            {
                return HttpNotFound();
            }
            return View(aguilar);
        }

        // POST: aguilars/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "aguilar_ID,FriendofAguilar,Place_lista,email,Birthday")] aguilar aguilar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aguilar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aguilar);
        }

        // GET: aguilars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aguilar aguilar = db.Students.Find(id);
            if (aguilar == null)
            {
                return HttpNotFound();
            }
            return View(aguilar);
        }

        // POST: aguilars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            aguilar aguilar = db.Students.Find(id);
            db.Students.Remove(aguilar);
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
