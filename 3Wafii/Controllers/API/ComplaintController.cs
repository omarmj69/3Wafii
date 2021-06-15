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
    public class ComplaintController : ApiController
    {
        private db_a72f14_fooddelivery02Entities db;

        public ComplaintController()
        {
            db = new db_a72f14_fooddelivery02Entities();
        }

        public IEnumerable<ComplaintDto> GetComplaint()
        {
            return db.Complaints.ToList().Select(Mapper.Map<Complaint, ComplaintDto>);
        }
        public IHttpActionResult GetComplaint(int id)
        {
            var com = db.Complaints.SingleOrDefault(c => c.com_id == id);
            if (com == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Complaint, ComplaintDto>(com));
        }

        [HttpDelete]
        public void DeleteComplaint(int id)
        {
            var ComInDb = db.Complaints.SingleOrDefault(c => c.com_id == id);

            if (ComInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            db.Complaints.Remove(ComInDb);
            db.SaveChanges();

        }

    }
}
