using Day3_Homework.Controllers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day3_Homework.Controllers
{
    public class LoginController : Controller
    {
        public IAuth AuthService { get; set; }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string account, string password)
        {
            bool isValid = this.AuthService.Validate(account, password);

            if (isValid)
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