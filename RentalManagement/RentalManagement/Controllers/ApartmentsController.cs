using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RentalManagement.Models;
using Twilio;
using System.Configuration;

namespace RentalManagement.Controllers
{
    public class ApartmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Apartments
        public ActionResult Index()
        {
            if (User.IsInRole("Manager"))
            {
                var apartment = db.Apartment.Include(a => a.RentalProperty);
                return View("ManagerIndex",apartment.ToList());
            }
            else
            {
                var apartment = db.Apartment.Include(a => a.RentalProperty);
                return View(apartment.ToList());
            }
        }

        public ActionResult GetWalkScore(int? id)
        {
            var rentalProperty = db.Apartment.Include(a => a.RentalProperty).SingleOrDefault(r => r.Id == id);
            return View(rentalProperty);
        }
      
        public ActionResult ScheduleShowing(int? id)
        {
            Schedule schedule = new Schedule();
            schedule.ShowingTime = default(DateTime).Add(schedule.ShowingTime.TimeOfDay);

            return View(schedule);
        }

        [HttpPost]
        public ActionResult ScheduleShowing(Schedule schedule)
        {

            var message = $"Appointment from {schedule.FirstName} {schedule.LastName} \n ";
            message += $" Email: {schedule.Email} Phone: {schedule.Phone} Date: {schedule.ShowingDate.ToShortDateString()} Time: {schedule.ShowingTime.ToShortTimeString()}";


            //db.Schedule.Add(schedule);
            //db.SaveChanges();

            var client = new TwilioRestClient(ConfigurationManager.AppSettings["TwilioAccountSid"], ConfigurationManager.AppSettings["TwilioAuthToken"]);
            client.SendMessage(ConfigurationManager.AppSettings["TwilioPhoneNumber"], "14143368732", message);

            return RedirectToAction("Index");

        }

        // GET: Apartments/Details/5
        [Authorize(Roles = "Manager, Tenant, Admin")]
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
        [Authorize(Roles = "Manager, Admin")]
        public ActionResult Create()
        {
            ViewBag.RentalPropertyId = new SelectList(db.RentalProperty, "Id", "StreetAddress");
            return View("Create");
        }

        // POST: Apartments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RentPerMonth,Unit,NumberBedrooms,NumberBathrooms,Features,RentalPropertyId,IsAvailable,DateAvailable")] Apartment apartment)
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
        [Authorize(Roles = "Manager, Admin")]
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
        public ActionResult Edit([Bind(Include = "Id,RentPerMonth,Unit,NumberBedrooms,NumberBathrooms,Features,RentalPropertyId,IsAvailable,DateAvailable")] Apartment apartment)
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
        [Authorize(Roles = "Manager, Admin")]
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
