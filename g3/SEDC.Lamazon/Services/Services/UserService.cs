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
                User currentUser = _userManager
                    .FindByNameAsync(user.UserName)
                    .GetAwaiter()
                    .GetResult();

                _userManager.AddToRoleAsync(currentUser, "user")
                    .GetAwaiter()
                    .GetResult();

                var loginUser = new LoginViewModel()
                {
                    Username = model.Username,
                    Password = model.Password
                };

                Login(loginUser);
            }
            else
            {
                throw new Exception($"Register Failed. {result.Errors.First().Description}");
            }
        }

        public void Login(LoginViewModel model)
        {
            SignInResult result = _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false).Result;

            if (result.IsNotAllowed)
            {
                throw new Exception("Username and Password did not match!");
            }
        }

        public void Logout()
        {
            _signInManager.SignOutAsync();
        }

        public UserViewModel GetCurrentUser(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new Exception("Username is not valid!");
            }

            User user = _userRepository.GetByUsername(username);

            var userViewModel =  new UserViewModel()
            {
                Id = user.Id,
                FullName = user.FullName,
                Username = user.UserName
            };

            return userViewModel;
        }

    }
}
