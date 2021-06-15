using _3Wafii.Dtos;
using _3Wafii.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;

namespace _3Wafii.Controllers.API
{
    public class UsersController : ApiController
    {

        private db_a72f14_fooddelivery02Entities db;

        public UsersController()
        {
            db = new db_a72f14_fooddelivery02Entities();
        }

        public IEnumerable<UsersDto> GetUsers()
        {
            return db.Users.ToList().Select(Mapper.Map<User, UsersDto>);
        }

        public IHttpActionResult GetUsers(int id)
        {
            var user = db.Users.SingleOrDefault(c => c.u_id == id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<User, UsersDto>(user));
        }

        //POST /api/resturants
        [HttpPost]
        public IHttpActionResult CreateUser(UsersDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            string salt = Crypto.GenerateSalt();
            string password = userDto.password + salt;
            string hashedpass = Crypto.HashPassword(password);

            userDto.password = hashedpass;
            userDto.salt = salt;
            
            var user = Mapper.Map<UsersDto, User>(userDto);
            db.Users.Add(user);
            db.SaveChanges();

            userDto.u_id = user.u_id;

            return Created(new Uri(Request.RequestUri + "/" + user.u_id), userDto);
        }

        [HttpPut]
        public void UpdateUser(UsersDto UserDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            var UserInDb = db.Users.Where(c => c.u_id == UserDto.u_id).FirstOrDefault<User>();

            if (UserInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(UserDto, UserInDb);

            db.SaveChanges();
        }

        [HttpDelete]
        public void DeleteUser(int id)
        {
            var UserInDb = db.Users.SingleOrDefault(c => c.u_id == id);

            if (UserInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            db.Users.Remove(UserInDb);
            db.SaveChanges();

        }

    }
}
