using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RentalManagement.Models;
using Microsoft.AspNet.Identity;

namespace RentalManagement.Controllers
{
    public class MaintainenceRequestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MaintainenceRequests
        public ActionResult Index()
        {
            var maintainenceRequest = db.MaintainenceRequest.Include(m => m.Apartment);
            return View(maintainenceRequest.ToList());
        }

        // GET: MaintainenceRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaintainenceRequest maintainenceRequest = db.MaintainenceRequest.Find(id);
            if (maintainenceRequest == null)
            {
                return HttpNotFound();
            }
            return View(maintainenceRequest);
        }

        // GET: MaintainenceRequests/Create
        public ActionResult Create()
        {
            ViewBag.ApartmentId = new SelectList(db.Apartment, "Id", "Features");
            return View();
        }

        // POST: MaintainenceRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MaintainenceRequest maintainenceRequest)
        {
            var userId = User.Identity.GetUserId();
            var tenant = db.Tenant.Include(a => a.Apartment).SingleOrDefault(t => t.ApplicationUserId == userId);
            maintainenceRequest.TimeAndDateOfRequest = DateTime.Now;
            maintainenceRequest.ApartmentId = tenant.ApartmentId;
            maintainenceRequest.Apartment = tenant.Apartment;

            if (ModelState.IsValid)
            {
                db.MaintainenceRequest.Add(maintainenceRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApartmentId = new SelectList(db.Apartment, "Id", "Features", maintainenceRequest.ApartmentId);
            return View(maintainenceRequest);
        }

        // GET: MaintainenceRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaintainenceRequest maintainenceRequest = db.MaintainenceRequest.Find(id);
            if (maintainenceRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApartmentId = new SelectList(db.Apartment, "Id", "Features", maintainenceRequest.ApartmentId);
            return View(maintainenceRequest);
        }

        // POST: MaintainenceRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TimeAndDateOfRequest,ApartmentId")] MaintainenceRequest maintainenceRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maintainenceRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApartmentId = new SelectList(db.Apartment, "Id", "Features", maintainenceRequest.ApartmentId);
            return View(maintainenceRequest);
        }

        // GET: MaintainenceRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaintainenceRequest maintainenceRequest = db.MaintainenceRequest.Find(id);
            if (maintainenceRequest == null)
            {
                return HttpNotFound();
            }
            return View(maintainenceRequest);
        }

        // POST: MaintainenceRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MaintainenceRequest maintainenceRequest = db.MaintainenceRequest.Find(id);
            db.MaintainenceRequest.Remove(maintainenceRequest);
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
