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
    public class ApartmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Apartments
        public ActionResult Index()
        {
            var apartment = db.Apartment.Include(a => a.RentalProperty);
            return View(apartment.ToList());
        }

        // GET: Apartments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apartment apartment = db.Apartment.Find(id);
            if (apartment == null)
            {
                return HttpNotFound();
            }
            return View(apartment);
        }

        // GET: Apartments/Create
        public ActionResult Create()
        {
            ViewBag.RentalPropertyId = new SelectList(db.RentalProperty, "Id", "StreetAddress");
            return View();
        }

        // POST: Apartments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RentPerMonth,Unit,NumberBedrooms,NumberBathrooms,Features,RentalPropertyId")] Apartment apartment)
        {
            if (ModelState.IsValid)
            {
                db.Apartment.Add(apartment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RentalPropertyId = new SelectList(db.RentalProperty, "Id", "StreetAddress", apartment.RentalPropertyId);
            return View(apartment);
        }

        // GET: Apartments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apartment apartment = db.Apartment.Find(id);
            if (apartment == null)
            {
                return HttpNotFound();
            }
            ViewBag.RentalPropertyId = new SelectList(db.RentalProperty, "Id", "StreetAddress", apartment.RentalPropertyId);
            return View(apartment);
        }

        // POST: Apartments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RentPerMonth,Unit,NumberBedrooms,NumberBathrooms,Features,RentalPropertyId")] Apartment apartment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(apartment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RentalPropertyId = new SelectList(db.RentalProperty, "Id", "StreetAddress", apartment.RentalPropertyId);
            return View(apartment);
        }

        // GET: Apartments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apartment apartment = db.Apartment.Find(id);
            if (apartment == null)
            {
                return HttpNotFound();
            }
            return View(apartment);
        }

        // POST: Apartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Apartment apartment = db.Apartment.Find(id);
            db.Apartment.Remove(apartment);
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
