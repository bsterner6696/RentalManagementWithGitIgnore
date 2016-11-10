using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using RentalManagement.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace RentalManagement.Controllers
{
    public class TenantsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tenants
        public ActionResult Index()
        {
            var tenant = db.Tenant.Include(t => t.Apartment);
            return View(tenant.ToList());
        }

        // GET: Tenants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tenant tenant = db.Tenant.Find(id);
            if (tenant == null)
            {
                return HttpNotFound();
            }
            return View(tenant);
        }

        // GET: Tenants/Create
        public ActionResult Create()
        {
            ViewBag.ApartmentId = new SelectList(db.Apartment, "Id", "Features");
            return View();
        }

        // POST: Tenants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FirstName,LastName,Balance,ApartmentId,EmailAddress,InitialPassword")] Tenant tenant)
        {
            if (ModelState.IsValid)
            {
                string email = tenant.EmailAddress.ToString();
                ApplicationUserManager UserManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var user = new ApplicationUser { UserName = email, Email = email };
                var result = await UserManager.CreateAsync(user, tenant.InitialPassword);
                await UserManager.AddToRoleAsync(user.Id, "Tenant");
                ApplicationUser tenantUser = db.Users.FirstOrDefault(x => x.UserName == email);
                tenant.ApplicationUserId = tenantUser.Id;
                tenant.ApplicationUser = tenantUser;
               
                db.Tenant.Add(tenant);
                db.SaveChanges();
                await UserManager.AddToRoleAsync(user.Id, "Tenant");
                return RedirectToAction("Index");
            }

            ViewBag.ApartmentId = new SelectList(db.Apartment, "Id", "Features", tenant.ApartmentId);
            return View(tenant);
        }

        // GET: Tenants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tenant tenant = db.Tenant.Find(id);
            if (tenant == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApartmentId = new SelectList(db.Apartment, "Id", "Features", tenant.ApartmentId);
            return View(tenant);
        }

        // POST: Tenants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Balance,ApartmentId")] Tenant tenant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tenant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApartmentId = new SelectList(db.Apartment, "Id", "Features", tenant.ApartmentId);
            return View(tenant);
        }

        // GET: Tenants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tenant tenant = db.Tenant.Find(id);
            if (tenant == null)
            {
                return HttpNotFound();
            }
            return View(tenant);
        }

        // POST: Tenants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tenant tenant = db.Tenant.Find(id);
            db.Tenant.Remove(tenant);
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
