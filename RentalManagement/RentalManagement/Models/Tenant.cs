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
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public decimal Balance { get; set; }

        [Display(Name = "Move In Date")]
        [DataType(DataType.Date)]
        public DateTime MoveInDate { get; set; }

        [Display(Name = "Move Out Date")]
        [DataType(DataType.Date)]
        public DateTime MoveOutDate { get; set; }

        [Display(Name = "Is Moved In")]
        public bool OccupyingApartment { get; set; }

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