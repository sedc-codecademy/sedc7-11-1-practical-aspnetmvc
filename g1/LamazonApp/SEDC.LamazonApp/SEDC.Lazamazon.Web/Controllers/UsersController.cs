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
            return RedirectToAction("index", "product");
        }

        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            _userService.Register(model);
            return RedirectToAction("products", "product");
        }
    }
}