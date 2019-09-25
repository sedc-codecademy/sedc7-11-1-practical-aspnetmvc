using DataAccess.Interfaces;
using Domain.Enumerations;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using WebModels.ViewModels;

namespace Services.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUserRepository _userRepository;

        public UserService(UserManager<User> userManager,
            SignInManager<User> signInManager,
            IUserRepository userRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userRepository = userRepository;
        }

        public void Register(RegisterViewModel model)
        {
            User user = new User()
            {
                UserName = model.Username,
                FullName = model.FirstName + " " + model.LastName,
                Email = model.Email,
                Orders = new List<Order>()
                {
                    new Order() { Status = OrderStatusType.Init }
                }
            };

            IdentityResult result = _userManager
                .CreateAsync(user, model.Password)
                .GetAwaiter().GetResult();

            if (result.Succeeded)
            {
                var currentUser = _userManager
                    .FindByNameAsync(user.UserName)
                    .GetAwaiter()
                    .GetResult();

                _userManager.AddToRoleAsync(currentUser, "user");
                Login();
            }
            else
            {
                throw new Exception($"Register Failed. {result.Errors.First().Description}");
            }
        }

        public void Login()
        {

        }
    }
}
