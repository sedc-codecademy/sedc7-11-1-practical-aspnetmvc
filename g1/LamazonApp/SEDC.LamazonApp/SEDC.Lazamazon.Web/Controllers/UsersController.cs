using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.WebModels_.ViewModels;
using Serilog;

namespace SEDC.Lazamazon.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IToastNotification _toastNotification;
        

        public UsersController(IUserService userService, IToastNotification toastNotification)
        {
            _userService = userService;
            _toastNotification = toastNotification;
        }


        public IActionResult LogIn()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public IActionResult LogIn(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                _userService.Login(model);
                if (User.IsInRole("admin"))
                {
                    _toastNotification.AddSuccessToastMessage("You have successfully loged in!");


                    Log.Information($"User with username {model.Username} logged in as admin!");

                    return RedirectToAction("listallorders", "order");
                }
                Thread.Sleep(1000);
                _toastNotification.AddSuccessToastMessage("You have successfully loged in!");

                Log.Error($"User with username {model.Username} logged in as regular user!");

                return RedirectToAction("products", "product");
            }
            _toastNotification.AddWarningToastMessage("Username or password are incorect!");
            return View(model);
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