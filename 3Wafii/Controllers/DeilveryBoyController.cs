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
    public class DeilveryBoyController : Controller
    {
        // GET: DeilveryBoy
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("login", "Account");
            }

            return View();
        }

        public ActionResult Create()

        {
            if (Session["user"] == null)
            {
                return RedirectToAction("login", "Account");
            }

            return View();
        }

        public ActionResult Edit(int? id)

        {
            if (Session["user"] == null)
            {
                return RedirectToAction("login", "Account");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DeliveryBoyDto delivery = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:7405/api/");
                var responseTask = client.GetAsync("DeliveryBoy/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var read = result.Content.ReadAsAsync<DeliveryBoyDto>();
                    read.Wait();
                    delivery = read.Result;

                }

            }
            return View(delivery);
        }
    }
}