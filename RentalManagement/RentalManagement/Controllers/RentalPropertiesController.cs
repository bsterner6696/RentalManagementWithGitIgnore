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
    public class RentalPropertiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RentalProperties
        public ActionResult Index()
        {
            var rentalProperty = db.RentalProperty.Include(r => r.PropertyManager);
            return View(rentalProperty.ToList());
        }

        // GET: RentalProperties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalProperty rentalProperty = db.RentalProperty.Find(id);
            if (rentalProperty == null)
            {
                return HttpNotFound();
            }
            return View(rentalProperty);
        }

        // GET: RentalProperties/Create
        public ActionResult Create()
        {
            ViewBag.PropertyManagerId = new SelectList(db.PropertyManager, "Id", "EmailAddress");
            return View();
        }

        // POST: RentalProperties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StreetAddress,ZipCode,PropertyManagerId")] RentalProperty rentalProperty)
        {
            if (ModelState.IsValid)
            {
                db.RentalProperty.Add(rentalProperty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PropertyManagerId = new SelectList(db.PropertyManager, "Id", "EmailAddress", rentalProperty.PropertyManagerId);
            return View(rentalProperty);
        }

        // GET: RentalProperties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalProperty rentalProperty = db.RentalProperty.Find(id);
            if (rentalProperty == null)
            {
                return HttpNotFound();
            }
            ViewBag.PropertyManagerId = new SelectList(db.PropertyManager, "Id", "EmailAddress", rentalProperty.PropertyManagerId);
            return View(rentalProperty);
        }

        // POST: RentalProperties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StreetAddress,ZipCode,PropertyManagerId")] RentalProperty rentalProperty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rentalProperty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PropertyManagerId = new SelectList(db.PropertyManager, "Id", "EmailAddress", rentalProperty.PropertyManagerId);
            return View(rentalProperty);
        }

        // GET: RentalProperties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalProperty rentalProperty = db.RentalProperty.Find(id);
            if (rentalProperty == null)
            {
                return HttpNotFound();
            }
            return View(rentalProperty);
        }

        // POST: RentalProperties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RentalProperty rentalProperty = db.RentalProperty.Find(id);
            db.RentalProperty.Remove(rentalProperty);
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
