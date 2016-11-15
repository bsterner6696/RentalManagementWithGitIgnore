using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RentalManagement.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        [Display (Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }
        public DateTime ShowingDate { get; set; }
        [Display (Name = "Time")]
        public DateTime ShowingTime { get; set; }
        public string Apartment { get; set; }
  
    }
}