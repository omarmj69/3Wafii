using _3Wafii.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace _3Wafii.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
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

        public ActionResult orderdetails(int? id)
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
            IEnumerable<OrderDto> checkorder = null;
            using (var client1 = new HttpClient())
            {
                client1.BaseAddress = new Uri("http://localhost:7405/api/");
                var response1 = client1.GetAsync("orders/getorders/" + Session["res"]);
                response1.Wait();

                var rst = response1.Result;
                if (rst.IsSuccessStatusCode)
                {
                    var read = rst.Content.ReadAsAsync<List<OrderDto>>();
                    read.Wait();
                    checkorder = read.Result;
                }
            }

            int[] array = new int[checkorder.Count()];
            for (int i = 0; i < array.Length; i++)
            {
                var all = checkorder.ElementAtOrDefault(i);
                array[i] = all.or_id;

            }

            OrderDto order = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:7405/api/");
                var responseTask = client.GetAsync("orders/edit/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var read = result.Content.ReadAsAsync<OrderDto>();
                    read.Wait();
                    order = read.Result;
                }
                if (order == null)
                {
                    return RedirectToAction("Index/" + Session["res"], "Order");
                }

            }

            for (int j = 0; j < array.Length; j++)
            {
                if (array[j] == order.or_id)
                {
                    return View();

                }

            }

            Session["id"] = id;
            return RedirectToAction("Index/" + Session["res"], "Meals");
        }

    }
}