using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TaxiNavigator.Models;
using TaxiNavigator.Dto;

namespace MovieRent.App_Start
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            Mapper.CreateMap<OrderForm, OrderFormDto>();
            Mapper.CreateMap<OrderFormDto, OrderForm>();
            
        }
    }
}