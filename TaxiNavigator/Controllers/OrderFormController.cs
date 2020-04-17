using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TaxiNavigator.Models;
using TaxiNavigator.Models.View_Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System.Data.Entity.Spatial;
using System.Globalization;

namespace TaxiNavigator.Controllers
{
    public class OrderFormController : Controller
    {
        private ApplicationDbContext _context;
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        public OrderFormController()
        {
            _context = new ApplicationDbContext();


        }
        public OrderFormController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        [Authorize]
        // GET: OrderForm
        public ActionResult Index()
        {    
          
        
        var viewDrivers= new OrderViewModel
            {
                order = new OrderForm(),
                drivers = _context.Drivers.ToList(),
                
            };

            return View(viewDrivers);
        }

        public ActionResult Delete(string ordernmb)
        {
            if (ordernmb != null) {
                var ordtodlt = _context.Orders.Single(m => m.OrderNmb == ordernmb);
                _context.Orders.Remove(ordtodlt);
                _context.SaveChanges(); }
            var x = _context.Orders.Include(m => m.Driver).ToList();
            return View("OrderList",x);

        }
        [Authorize]
        public async System.Threading.Tasks.Task<ActionResult> OrderList()
        {
            var userid = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            //var customerlgn = _context.Customers.SingleOrDefault(m => m.Email == userid.Email);
            var x = _context.Orders.Include(m => m.Driver).Where(m => m.UserMail == userid.Email).ToList();


            return View(x);
        }
        public ActionResult Edit(int id)
        {
            var order = _context.Orders.FirstOrDefault(m => m.Id == id);
            var OrderView = new OrderViewModel()
            {
                order = order,
                drivers = _context.Drivers.ToList(),
                
            };
            return View("Index", OrderView);
        }
        public string OrderId()
        {
            var random = new Random();
            var possibilities = Enumerable.Range(1, 100).ToList();
            var result = possibilities.OrderBy(number => random.Next()).Take(5).ToArray();
            return String.Join("", result);

        }
        [Authorize]
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> CreateOrder(OrderForm order)
        {
            if (!ModelState.IsValid)
            {
                var viewDrivers = new OrderViewModel
                {
                    order = new OrderForm(),
                    drivers = _context.Drivers.ToList(),

                };

                return View("Index", viewDrivers);
            }

            var userid = await UserManager.FindByIdAsync(User.Identity.GetUserId());

            order.OrderNmb = OrderId();
            order.UserMail = userid.Email;

            order.Geolocation=DbGeography.FromText(order.Geo); ;
  
            if (order.Id == 0) { _context.Orders.Add(order); }
            else
            {
                var orderinDB = _context.Orders.Single(m => m.Id == order.Id);
                orderinDB.Name = order.Name;
                orderinDB.SecondName = order.SecondName;
                orderinDB.PhoneNumber = order.PhoneNumber;
                orderinDB.OrderDate = order.OrderDate;
                orderinDB.Adress = order.Adress;
                orderinDB.DriverId = order.DriverId;
                orderinDB.Geolocation = order.Geolocation;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");


        }
    }
}