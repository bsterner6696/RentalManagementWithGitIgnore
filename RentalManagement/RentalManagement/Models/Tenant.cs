using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace RentalManagement.Models
{
    public class Tenant
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Balance { get; set; }

        [Display(Name = "Email Address")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        public string InitialPassword { get; set; }

        [ForeignKey("Apartment")]
        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}