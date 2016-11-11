﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RentalManagement.Models
{
    public class Apartment
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Is Available")]
        public bool IsAvailable { get; set; }

        [Display(Name = "Date Available")]
        [DataType(DataType.Date)]
        public DateTime DateAvailable { get; set; }

        public decimal RentPerMonth { get; set; }
        public int Unit { get; set; }
        [Display(Name = "Number of Bedrooms")]
        public double NumberBedrooms { get; set; }
        [Display(Name = "Number of Bathrooms")]
        public double NumberBathrooms { get; set; }
        public string Features { get; set; }

        [ForeignKey("RentalProperty")]
        public int RentalPropertyId { get; set; }
        public RentalProperty RentalProperty { get; set; }
    }
}