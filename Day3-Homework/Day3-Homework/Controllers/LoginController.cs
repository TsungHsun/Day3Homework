using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day3_Homework.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string account, string password)
        {
            if (account == "rickyho" && password == "1234")
            {
                return RedirectToAction("Index", "Welcome");
            }
            else
            {
                ViewBag.Message = "wrong account or password";
                return View();
            }
        }
    }
}