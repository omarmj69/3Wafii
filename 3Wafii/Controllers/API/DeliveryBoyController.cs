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
    public class DeliveryBoyController : ApiController
    {
        private db_a72f14_fooddelivery02Entities db;

        public DeliveryBoyController()
        {
            db = new db_a72f14_fooddelivery02Entities();
        }

        public IEnumerable<DeliveryBoyDto> GetDeilveryBoy()
        {

            return db.DeliveryBoys.ToList().Select(Mapper.Map<DeliveryBoy, DeliveryBoyDto>);


        }

        public IHttpActionResult GetDeilveryBoy(int id)
        {
            var Deilvery = db.DeliveryBoys.SingleOrDefault(c => c.del_id == id);
            if (Deilvery == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<DeliveryBoy, DeliveryBoyDto>(Deilvery));
        }

        [HttpPost]
        public IHttpActionResult CreateDeilveryBoy(DeliveryBoyDto DeliveryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var deilvery = Mapper.Map<DeliveryBoyDto, DeliveryBoy>(DeliveryDto);
            db.DeliveryBoys.Add(deilvery);
            db.SaveChanges();

            DeliveryDto.del_id = deilvery.del_id;

            return Created(new Uri(Request.RequestUri + "/" + deilvery.del_id), DeliveryDto);
        }

        [HttpPut]
        public void UpdateDeilveryBoy(DeliveryBoyDto DeliveryDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            var DeilveryInDb = db.DeliveryBoys.Where(c => c.del_id == DeliveryDto.del_id).FirstOrDefault<DeliveryBoy>();

            if (DeilveryInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(DeliveryDto, DeilveryInDb);

            db.SaveChanges();
        }

        [HttpDelete]
        public void DeleteDeilveryBoy(int id)
        {
            var DeilveryInDb = db.DeliveryBoys.SingleOrDefault(c => c.del_id == id);

            if (DeilveryInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            db.DeliveryBoys.Remove(DeilveryInDb);
            db.SaveChanges();

        }


    }
}
