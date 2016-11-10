using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RentalManagement.Models
{
    public class MaintainenceRequest
    {
        [Key]
        public int Id { get; set; }
        public DateTime TimeAndDateOfRequest { get; set; }
        public string Request { get; set; }
        [ForeignKey("Apartment")]
        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }
    }
}