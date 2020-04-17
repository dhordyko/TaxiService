using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;

namespace TaxiNavigator.Models
{
    public class OrderForm
    {   [Key]
        public int Id { get; set; }
    
        public string OrderNmb { get; set; }
        [Required(ErrorMessage = "Wprowadz adres")]
        [Display(Name = "Adres")]
        public string Adress { get; set; }
        [Required(ErrorMessage = "Wprowadz swoje imie")]
        [Display(Name = "Imie")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Wprowadz swoje nazwisko")]
        [Display(Name = "Nazwisko")]
        public string SecondName { get; set; }
        [Required(ErrorMessage = "Wprowadz swój numer komurkowy")]
        [Display(Name = "Numer telefonu")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Wybierz datę i godzinę")]
        [Display(Name = "Data i czas")]
        public string OrderDate { get; set; }
       
        public Driver Driver { get; set; }
        [Required(ErrorMessage = "Wybierz numer kierowcy")]
        [Display(Name = "Kierowca")]
        public byte DriverId { get; set; }
        public string UserMail { get; set; }
        public DbGeography Geolocation { get; set; }
        public string Geo { get; set; }
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

    }
}