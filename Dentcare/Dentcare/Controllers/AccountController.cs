using Microsoft.AspNetCore.Mvc;
using Dentcare.Models;

namespace Dentcare.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(Patient p)
        {
            // later we save to database
            ViewBag.Message = "Signup Successful";

            return View();
        }
    }
}