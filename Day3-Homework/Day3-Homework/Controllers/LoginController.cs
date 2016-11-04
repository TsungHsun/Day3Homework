using Day3_Homework.Controllers.Models;
using Day3_Homework.Models;
using System.Web.Mvc;

namespace Day3_Homework.Controllers
{
    public class LoginController : Controller
    {
        private IAuth _auth;
        public IAuth AuthService
        {
            get
            {
                if (this._auth == null)
                {
                    this._auth = new AuthService();
                }

                return this._auth;
            }
            set
            {
                this._auth = value;
            }
        }

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