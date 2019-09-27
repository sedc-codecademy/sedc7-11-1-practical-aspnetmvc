using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.WebModels_.ViewModels;

namespace SEDC.Lazamazon.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        public IActionResult LogIn()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public IActionResult LogIn(LoginViewModel model)
        {
            _userService.Login(model);
            if (User.IsInRole("admin"))
            {
                return RedirectToAction("listallorders", "order");
            }
            return RedirectToAction("products", "product");
        }

        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                _userService.Register(model);
                return RedirectToAction("products", "product");
            }
            return View(model);
        }

        public IActionResult LogOut()
        {
            _userService.Logout();
            return RedirectToAction("index", "home");
        }
    }
}