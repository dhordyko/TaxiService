using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxiNavigator.Models.View_Models
{
    public class OrderViewModel
    {
        public OrderForm order { get; set; }
        public IEnumerable<Driver> drivers { get; set; }
    }
}