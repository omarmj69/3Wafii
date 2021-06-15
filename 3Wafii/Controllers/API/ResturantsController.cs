using _3Wafii.Dtos;
using _3Wafii.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace _3Wafii.Controllers.API

{
    public class ResturantsController : ApiController
    {
        private db_a72f14_fooddelivery02Entities db;

        public ResturantsController()
        {
            db = new db_a72f14_fooddelivery02Entities();
        }

        //GET /api/Resturants
        public IEnumerable<ResturantsDto> GetResturants()
        {
            return db.Resturants.ToList().Select(Mapper.Map<Resturant, ResturantsDto>);
        }

        //GET /api/Resturants/1
        public IHttpActionResult GetResturant(int id)
        {
            var resturant = db.Resturants.SingleOrDefault(c => c.rest_id == id);
            if (resturant == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Resturant, ResturantsDto>(resturant));
        }

        //POST /api/resturants
        [HttpPost]
        public IHttpActionResult CreateResturant(ResturantsDto resturantDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            
            var resturant = Mapper.Map<ResturantsDto, Resturant>(resturantDto);
            db.Resturants.Add(resturant);
            db.SaveChanges();

            resturantDto.rest_id = resturant.rest_id;

            return Created(new Uri(Request.RequestUri + "/" + resturant.rest_id) , resturantDto);
        }

        //PUT api/Resturants/2

        [HttpPut]
        public void UpdateResturant(ResturantsDto resturantDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            var ResturantInDb = db.Resturants.Where(c => c.rest_id == resturantDto.rest_id).FirstOrDefault<Resturant>();

            if(ResturantInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(resturantDto, ResturantInDb);

            db.SaveChanges();
        }

        //DELETE api/resturants/1

        [HttpDelete]
        public void DeleteResturant(int id)
        {
            var ResturantInDb = db.Resturants.SingleOrDefault(c => c.rest_id == id);

            if (ResturantInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            db.Resturants.Remove(ResturantInDb);
            db.SaveChanges();

        }


    }
}
