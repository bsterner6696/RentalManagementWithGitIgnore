using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RentalManagement.Models;

namespace RentalManagement.Controllers
{
    public class PropertyManagersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PropertyManagers
        public ActionResult Index()
        {
            return View(db.PropertyManager.ToList());
        }

        // GET: PropertyManagers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyManager propertyManager = db.PropertyManager.Find(id);
            if (propertyManager == null)
            {
                return HttpNotFound();
            }
            return View(propertyManager);
        }

        // GET: PropertyManagers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PropertyManagers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmailAddress,PhoneNumber,Name")] PropertyManager propertyManager)
        {
            if (ModelState.IsValid)
            {
                db.PropertyManager.Add(propertyManager);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(propertyManager);
        }

        // GET: PropertyManagers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyManager propertyManager = db.PropertyManager.Find(id);
            if (propertyManager == null)
            {
                return HttpNotFound();
            }
            return View(propertyManager);
        }

        // POST: PropertyManagers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmailAddress,PhoneNumber,Name")] PropertyManager propertyManager)
        {
            if (ModelState.IsValid)
            {
                db.Entry(propertyManager).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(propertyManager);
        }

        // GET: PropertyManagers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyManager propertyManager = db.PropertyManager.Find(id);
            if (propertyManager == null)
            {
                return HttpNotFound();
            }
            return View(propertyManager);
        }

        // POST: PropertyManagers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PropertyManager propertyManager = db.PropertyManager.Find(id);
            db.PropertyManager.Remove(propertyManager);
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
