using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RentalManagement.Models
{
    public class RentalProperty
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }
        [ForeignKey("PropertyManager")]
        public int PropertyManagerId { get; set; }
        public PropertyManager PropertyManager { get; set; }
    }
}