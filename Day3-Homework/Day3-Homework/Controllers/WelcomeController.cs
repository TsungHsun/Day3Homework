using System.Web.Mvc;

namespace Day3_Homework.Controllers
{
    public class WelcomeController : Controller
    {
        // GET: Welcome
        public ActionResult Index()
        {
            ViewBag.LoginUser = "rickyho";
            return View();
        }
    }
}