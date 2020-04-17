using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaxiNavigator.Models;

namespace TaxiNavigator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.IsInRole("Driver"))
            return View("DriverView");
            return View();
        }

        public List<Location> GetLocation(DbGeography current, ApplicationDbContext db_context)
        {
            var places = db_context.Set<Location>().OrderBy(n => n.Geolocation.Distance(current));
            var lst_places = places.ToList().Select(x => new Location
            {
                Id = x.Id,
                lng = x.Geolocation.Longitude,
                lat = x.Geolocation.Latitude,
                Distance = x.Geolocation.Distance(current),
                Driver = db_context.Drivers.FirstOrDefault(c => c.Id == x.Id)
            }).ToList();


            return lst_places;
        }
        public ActionResult GetNearByLocations(string Current)
        {
            using (ApplicationDbContext db_context = new ApplicationDbContext())
            {
                var currentLocation = DbGeography.FromText(Current);

                //var currentLocation = DbGeography.FromText("POINT( 78.3845534 17.4343666 )");

              


    
                //var places = (from u in db_context.Locations
                //              orderby u.Geolocation.Distance(currentLocation)
                //              select u).Take(1).Select(x => new TaxiNavigator.Models.Location() { Name = x.Name, lat = x.Geolocation.Latitude, lng = x.Geolocation.Longitude, Distance = x.Geolocation.Distance(currentLocation) });
                var nearschools = GetLocation(currentLocation,  db_context);

                return Json(nearschools, JsonRequestBehavior.AllowGet);
            }
        }


        public List<OrderForm> GetCustomerLocation(DbGeography current, ApplicationDbContext db_context)
        {
            var places = db_context.Set<OrderForm>().OrderBy(n => n.Geolocation.Distance(current));
            var lst_places = places.ToList().Select(x => new OrderForm
            {
                Id = x.Id,
                lng = x.Geolocation.Longitude,
                lat = x.Geolocation.Latitude,
                Distance = x.Geolocation.Distance(current),
                DriverId = x.DriverId,
                Name=x.Name,
                SecondName=x.SecondName,
                PhoneNumber=x.PhoneNumber,
                OrderNmb=x.OrderNmb,
                OrderDate=x.OrderDate
            }).ToList();


            return lst_places;
        }

        public ActionResult GetNearCustomers(string Current)
        {
            using (ApplicationDbContext db_context = new ApplicationDbContext())
            {
                var currentLocation = DbGeography.FromText(Current);

                //var currentLocation = DbGeography.FromText("POINT( 78.3845534 17.4343666 )");





                //var places = (from u in db_context.Locations
                //              orderby u.Geolocation.Distance(currentLocation)
                //              select u).Take(1).Select(x => new TaxiNavigator.Models.Location() { Name = x.Name, lat = x.Geolocation.Latitude, lng = x.Geolocation.Longitude, Distance = x.Geolocation.Distance(currentLocation) });
                var nearschools = GetCustomerLocation(currentLocation, db_context);

                return Json(nearschools, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}