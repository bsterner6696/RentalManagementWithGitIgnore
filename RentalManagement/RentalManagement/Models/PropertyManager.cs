using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace RentalManagement.Models
{
    public class PropertyManager
    {
        [Key]
        public int Id { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [Display(Name = "Property Manager Name")]
        public string Name { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}