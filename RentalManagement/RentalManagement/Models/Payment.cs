using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentalManagement.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "AmountToCharge")]
        public decimal Amount { get; set; }

        [Display(Name = "Card Number")]
        public string CardNumber { get; set; }

        [Display(Name = "Expiration Date")]
        public string ExpirationDate { get; set; }

        [Display(Name = "Card Code")]
        public string CardCode { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

    }
}