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
            if (User.IsInRole("Manager"))
            {
                var tenant = db.Tenant.Include(t => t.Apartment);
                return View(tenant.ToList());
            }
            else if (User.IsInRole("Tenant"))
            {
                string currentUserId = User.Identity.GetUserId();
                Tenant currentTenant = db.Tenant.FirstOrDefault(x => x.ApplicationUserId == currentUserId);
                List<Tenant> tenantList = new List<Tenant>();
                tenantList.Add(currentTenant);
                return View("TenantIndex",tenantList);
            }
            else
            {
                return HttpNotFound();
            }
            
        }

        //GET: Tenants/ChargeRent
        [Authorize(Roles = "Manager")]
        public ActionResult ChargeRent()
        {
            foreach (Tenant tenant in db.Tenant)
            {
                try
                {
                    Apartment apartment = db.Apartment.FirstOrDefault(x => x.Id == tenant.ApartmentId);
                    if (tenant.OccupyingApartment)
                    {
                        tenant.Balance += apartment.RentPerMonth;
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
            }
            db.SaveChanges();
            var tenants = db.Tenant.Include(t => t.Apartment);
            return View("Index",tenants.ToList());
        }
        //GET: Tenants/ChargeRent
        [Authorize(Roles = "Manager")]
        public ActionResult MoveInOut()
        {
            foreach (Tenant tenant in db.Tenant)
            {
                try
                {
                    DateTime today = DateTime.Now;
                    Apartment apartment = db.Apartment.FirstOrDefault(x => x.Id == tenant.ApartmentId);
                    if (today >= tenant.MoveInDate && today <= tenant.MoveOutDate)
                    {
                        tenant.OccupyingApartment = true;
                    }
                    else
                    {
                        tenant.OccupyingApartment = false;
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
            }
            db.SaveChanges();
            var tenants = db.Tenant.Include(t => t.Apartment);
            return View("Index", tenants.ToList());
        }
        // GET: Tenants/Details/5
        [Authorize(Roles = "Manager")]
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
        [Authorize(Roles = "Manager")]
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
        public async Task<ActionResult> Create([Bind(Include = "Id,FirstName,LastName,Balance,ApartmentId,EmailAddress,InitialPassword,MoveInDate,MoveOutDate")] Tenant tenant)
        {
            if (ModelState.IsValid)
            {
                string email = tenant.EmailAddress.ToString();
                ApplicationUserManager UserManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                try
                {
                    var user = new ApplicationUser { UserName = email, Email = email };
                    var result = await UserManager.CreateAsync(user, tenant.InitialPassword);
                    await UserManager.AddToRoleAsync(user.Id, "Tenant");
                    ApplicationUser tenantUser = db.Users.FirstOrDefault(x => x.UserName == email);
                    tenant.ApplicationUserId = tenantUser.Id;
                    tenant.ApplicationUser = tenantUser;            
                    tenant.OccupyingApartment = false;
                    db.Tenant.Add(tenant);
                    db.SaveChanges();
                    await UserManager.AddToRoleAsync(user.Id, "Tenant");
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
                return RedirectToAction("Index");
            }

            ViewBag.ApartmentId = new SelectList(db.Apartment, "Id", "Features", tenant.ApartmentId);
            return View(tenant);
        }

        // GET: Tenants/Edit/5
        [Authorize(Roles = "Manager")]
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
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,ApartmentId,OccupyingApartment")] Tenant tenant)
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
        [Authorize(Roles = "Manager")]
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
