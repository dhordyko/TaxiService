using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Spatial;
using System.ComponentModel.DataAnnotations;

namespace TaxiNavigator.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
       

        public DbGeography Geolocation { get; set; }

        public double? lat
        {
            get; set;
        }
        public double? lng
        {
            get;
            set;
        }

        public double? Distance { get; set; }
        public Driver Driver { get; set; }
    }
}