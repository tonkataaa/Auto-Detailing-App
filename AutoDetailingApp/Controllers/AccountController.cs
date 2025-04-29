using AutoDetailingApp.Data;
using AutoDetailingApp.Models;
using AutoDetailingApp.Web.ViewModels.Account;
using Microsoft.AspNetCore.Mvc;

namespace AutoDetailingApp.Controllers
{

	public class AccountController : Controller
    {
	    private readonly AutoDetailingDbContext _context;

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = _context.Users
                .FirstOrDefault(p => p.Email == model.Email);

			if (user == null || user.PasswordHash != model.Password)
			{
				ModelState.AddModelError("", "Невалиден имейл или парола.");
				return View(model);
			}

			if (user.PasswordHash == model.Password)
            {
				return RedirectToAction("Index");
			}
                        
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

			if (_context.Users.Any(u => u.FullName == model.UserName))
			{
				ModelState.AddModelError("Username", "Това потребителско име вече е заето.");
				return View(model);
			}

            var user = new User
            {
                FullName = model.UserName,
                Email = model.Email,
                PasswordHash = model.Password,
                PhoneNumber = model.PhoneNumber
            };

            _context.Users.Add(user);
            _context.SaveChanges();

			return RedirectToAction("Login");
		}


        [HttpGet]
        public IActionResult Logout()
        {
            return RedirectToAction();
        }
    }
}
