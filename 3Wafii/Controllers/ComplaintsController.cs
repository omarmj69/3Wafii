using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _3Wafii.Controllers
{
    public class ComplaintsController : Controller
    {
        // GET: Complaints
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("login", "Account");
            }

            return View();
        }
    }
}