using _3Wafii.Dtos;
using _3Wafii.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace _3Wafii.Controllers
{
    public class MealsController : Controller
    {
        // GET: Meals
        public ActionResult Index(int id)
        {
            int resid = Convert.ToInt32(Session["res"]);
            if (Session["res"] == null || id != resid)
            {
                return RedirectToAction("login", "Account");
            }
            Session["id"] = id;
            return View();
        }

        public ActionResult Create(int id)

        {
            int resid = Convert.ToInt32(Session["res"]);
            if (Session["res"] == null || id != resid)
            {
                return RedirectToAction("login", "Account");
            }
            Session["id"] = id;

            IEnumerable<MealsDto> checkmeal = null;
            using (var client1 = new HttpClient())
            {
                client1.BaseAddress = new Uri("http://localhost:7405/api/");
                var response1 = client1.GetAsync("Meals");
                response1.Wait();

                var rst = response1.Result;
                if (rst.IsSuccessStatusCode)
                {
                    var read = rst.Content.ReadAsAsync<List<MealsDto>>();
                    read.Wait();
                    checkmeal = read.Result;
                }
            }
            Session["lastid"] = checkmeal.Select(m => m.m_id).LastOrDefault() + 1;


            return View();
        }

        public ActionResult ResturantProfile(int id)

        {
            int resid = Convert.ToInt32(Session["res"]);
            if (Session["res"] == null || id != resid)
            {
                return RedirectToAction("login", "Account");
            }
            Session["id"] = id;
            ResturantsDto resturants = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:7405/api/");
                var responseTask = client.GetAsync("Resturants/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var read = result.Content.ReadAsAsync<ResturantsDto>();
                    read.Wait();
                    resturants = read.Result;

                }
                return View(resturants);
            }
        }

        public ActionResult Edit(int? id)

        {
            int resid = Convert.ToInt32(Session["res"]);
            if (Session["res"] == null)
            {
                return RedirectToAction("login", "Account");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IEnumerable<MealsDto> checkmeal = null;
            using (var client1 = new HttpClient())
            {
                client1.BaseAddress = new Uri("http://localhost:7405/api/");
                var response1 = client1.GetAsync("Meals/" + Session["res"]);
                response1.Wait();

                var rst = response1.Result;
                if (rst.IsSuccessStatusCode)
                {
                    var read = rst.Content.ReadAsAsync<List<MealsDto>>();
                    read.Wait();
                    checkmeal = read.Result; 
                }
            }

            int[] array = new int[checkmeal.Count()];
            for (int i = 0; i < array.Length; i++)
            {
                var all = checkmeal.ElementAtOrDefault(i);
                array[i] = all.m_id;

            }

            MealsDto meal = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:7405/api/");
                var responseTask = client.GetAsync("Meals/edit/" + id.ToString());
                responseTask.Wait();
                
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var read = result.Content.ReadAsAsync<MealsDto>();
                    read.Wait();
                    meal = read.Result;
                }
                if (meal == null)
                {
                    return RedirectToAction("Index/" + Session["res"], "Meals");
                }

            }

            for (int j = 0; j < array.Length; j++)
            {
                if (array[j]==meal.m_id)
                {
                    return View(meal);

                }

            }

            return RedirectToAction("Index/" + Session["res"], "Meals");


        }
    }
}