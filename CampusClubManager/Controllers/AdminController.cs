using Microsoft.AspNetCore.Mvc;

namespace CampusClubManager.Controllers
{
    public class AdminController : Controller
    {
        private const string AdminPassword = "1234";

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string password)
        {
            if (password == AdminPassword)
            {
                HttpContext.Session.SetString("admin", "true");
                return RedirectToAction("Create", "Event");
            }

            ViewBag.Error = "Hatalı şifre";
            return View();
        }

       
    }
}
