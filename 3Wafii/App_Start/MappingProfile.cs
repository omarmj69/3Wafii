using _3Wafii.Dtos;
using _3Wafii.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3Wafii.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Resturant, ResturantsDto>();
            Mapper.CreateMap<ResturantsDto, Resturant>();

            Mapper.CreateMap<User, UsersDto>();
            Mapper.CreateMap<UsersDto, User>();

            Mapper.CreateMap<DeliveryBoy, DeliveryBoyDto>();
            Mapper.CreateMap<DeliveryBoyDto, DeliveryBoy>();

            Mapper.CreateMap<Complaint, ComplaintDto>();
            Mapper.CreateMap<ComplaintDto, Complaint>();

            Mapper.CreateMap<Customer, CustmerDto>();
            Mapper.CreateMap<CustmerDto, Customer>();

            Mapper.CreateMap<Meal, MealsDto>();
            Mapper.CreateMap<MealsDto, Meal>();

            Mapper.CreateMap<Order, OrderDto>();
            Mapper.CreateMap<OrderDto, Order>();


        }

    }
}