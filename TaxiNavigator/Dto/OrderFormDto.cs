using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaxiNavigator.Models;

namespace TaxiNavigator.Dto
{
    public class OrderFormDto
    {
        public string OrderNmb { get; set; }
    
        public string Adress { get; set; }
    
        public string Name { get; set; }
      
        public string SecondName { get; set; }
     
        public string PhoneNumber { get; set; }

        public string OrderDate { get; set; }

        public Driver Driver { get; set; }
      
        public byte DriverNmb { get; set; }
    }
}