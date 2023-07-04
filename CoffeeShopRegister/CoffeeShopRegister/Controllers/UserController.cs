using CoffeeShopRegister.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopRegister.Controllers
{
    public class UserController : Controller
    {
        private List<User> userInfo = new List<User> { };

        public IActionResult Index()
        {
            return View(userInfo);
        }

        public IActionResult Summary(User user)
        {
            if (user == null)
            {
                return NotFound();
            }
            return View(user); 
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(User user)
        {
            userInfo.Add(user);
            return RedirectToAction("Summary", user);
        }
    }
}
