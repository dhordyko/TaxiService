using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaxiNavigator.Models;
using TaxiNavigator.Dto;
using System.Data.Entity;
using AutoMapper;

namespace TaxiNavigator.Controllers.Api
{
    public class OrderController : ApiController
    {
        private ApplicationDbContext _context;

        public OrderController()
        {
            _context = new ApplicationDbContext();


        }
        public IEnumerable<OrderFormDto> GetCustomers()
        {
            var x = _context.Orders.Include(m=>m.Driver).ToList().Select(Mapper.Map<OrderForm, OrderFormDto>);

           
            return x;


        }
        //[HttpPost]
        //public void CreateOrder(OrderForm form)
        //{
        //    if (!ModelState.IsValid)
        //        throw new HttpRequestException(HttpStatusCode.BadRequest.ToString());

        //    _context.Orders.Add(form);
        //    _context.SaveChanges();



        //}
    }
}
