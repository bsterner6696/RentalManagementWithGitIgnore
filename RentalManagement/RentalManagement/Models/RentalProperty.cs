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
        public string StreetAddress { get; set; }
        public int ZipCode { get; set; }
        [ForeignKey("PropertyManager")]
        public int PropertyManagerId { get; set; }
        public PropertyManager PropertyManager { get; set; }
    }
}