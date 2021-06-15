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
    public class MealsController : ApiController
    {
        private db_a72f14_fooddelivery02Entities db;

        public MealsController()
        {
            db = new db_a72f14_fooddelivery02Entities();
        }

        public IEnumerable<MealsDto> Getmeals()
        {
            return db.Meals.ToList().Select(Mapper.Map<Meal, MealsDto>);
        }



        public IEnumerable<MealsDto> GetMeals(int id)
        {
            var result =
            (
                from a in db.Meals
                from b in a.Resturants
                join c in db.Resturants on b.rest_id equals c.rest_id
                where b.rest_id == id
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

        [Route("api/meals/edit/{id:int}")]
        public IHttpActionResult Getmeal(int id)
        {
            var meal = db.Meals.SingleOrDefault(c => c.m_id == id);
            if (meal == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Meal, MealsDto>(meal));
        }


        [HttpPost]
        public IHttpActionResult CreateMeal(int id, MealsDto mealDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            var meal = Mapper.Map<MealsDto, Meal>(mealDto);
            db.Meals.Add(meal);
            db.SaveChanges();
            Resturant s = db.Resturants.FirstOrDefault(x => x.rest_id == id);
            db.Meals.FirstOrDefault(x => x.m_id == meal.m_id).Resturants.Add(s);
            db.SaveChanges();

            mealDto.m_id = meal.m_id;

            return Created(new Uri(Request.RequestUri + "/" + meal.m_id), mealDto);
        }

        [HttpPut]
        public void UpdateMeal(MealsDto MealDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            var MealInDb = db.Meals.Where(c => c.m_id == MealDto.m_id).FirstOrDefault<Meal>();

            if (MealInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(MealDto, MealInDb);

            db.SaveChanges();
        }

        [HttpDelete]
        [Route("api/Meals/{m_id:int}/{rest_id:int}")]
        public void DeleteMeal(int m_id, int rest_id)
        {

            var meal = new Meal() { m_id = m_id };
            var res = new Resturant() { rest_id = rest_id };
            meal.Resturants.Add(res);
            db.Meals.Attach(meal);
            meal.Resturants.Remove(res);
            db.SaveChanges();


            var MealInDb = db.Meals.SingleOrDefault(c => c.m_id == m_id);

            if (MealInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            db.Meals.Remove(MealInDb);
            db.SaveChanges();

        }

    }
}
