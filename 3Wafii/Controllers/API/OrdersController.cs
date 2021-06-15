using _3Wafii.Dtos;
using _3Wafii.Models;
using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _3Wafii.Controllers.API
{
    public class OrdersController : ApiController
    {
        private db_a72f14_fooddelivery02Entities db;

        public OrdersController()
        {
            db = new db_a72f14_fooddelivery02Entities();
        }

        public IEnumerable<MealsDto> GetMeals(int id)
        {
            var result =
            (
                from a in db.Meals
                from b in a.Orders
                join c in db.Orders on b.or_id equals c.or_id
                where b.or_id == id
                select new MealsDto
                {
                    m_id = a.m_id,
                    m_name = a.m_name,
                    Description = a.Description,
                    image = a.image,
                    m_count = a.m_count,
                    price = a.price

                }).ToList();

            return result;
        }

        [Route("api/orders/getorders/{id:int}")]
        public IEnumerable<OrderDto> GetOrder(int id)
        {
            var result =
            (

                from o in db.Orders
                from a in o.Meals
                join c in db.Meals on a.m_id equals c.m_id
                from r in db.Resturants
                from q in r.Meals
                join n in db.Meals on q.m_id equals n.m_id
                where c.m_id == n.m_id && r.rest_id == id

                select new OrderDto
                {
                    or_id = o.or_id,
                    cus_id = o.Customer.cus_id,
                    or_count = o.or_count,
                    total_price = o.total_price


                }).ToList();

            return result;
        }

        [Route("api/orders/edit/{id:int}")]
        public IHttpActionResult Getorder(int id)
        {
            var order = db.Orders.SingleOrDefault(c => c.or_id == id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Order, OrderDto>(order));
        }


    }
}
