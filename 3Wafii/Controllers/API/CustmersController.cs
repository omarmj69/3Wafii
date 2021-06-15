using _3Wafii.Dtos;
using _3Wafii.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _3Wafii.Controllers.API
{
    public class CustmersController : ApiController
    {
        private db_a72f14_fooddelivery02Entities db;

        public CustmersController()
        {
            db = new db_a72f14_fooddelivery02Entities();
        }
        public IEnumerable<CustmerDto> GetCustmers()
        {
            return db.Customers.ToList().Select(Mapper.Map<Customer, CustmerDto>);
        }

        public IHttpActionResult GetCustmers(int id)
        {
            var customer = db.Customers.SingleOrDefault(c => c.cus_id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Customer, CustmerDto>(customer));
        }

        [HttpPut]
        public void UpdateCustomer(CustmerDto CustomerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            var CustomerInDb = db.Customers.Where(c => c.cus_id == CustomerDto.cus_id).FirstOrDefault<Customer>();

            if (CustomerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(CustomerDto, CustomerInDb);

            db.SaveChanges();
        }

    }
}
