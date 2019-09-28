using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.Domain.Models;
using SEDC.Lamazon.Domain.Models.Enums;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.WebModels_.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.Lamazon.Services.Services
{
    public class UserService : IUserService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(SignInManager<User> signInManager,
                           UserManager<User> userManager,
                           IUserRepository userRepository,
                           IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public UserViewModel GetCurrentUser(string username)
        {
            try
            {
                User user = _userRepository.GetByUsername(username);

                return new UserViewModel()
                {
                    UserName = user.UserName,
                    Id = user.Id,
                    FullName = user.FullName
                };
            }
            catch (Exception ex)
            {
                string message = $"User with username {username} does not exist!";
                throw new Exception(message, ex);
            }
        }

        public void Login(LoginViewModel loginModel)
        {
            var result = _signInManager
                         .PasswordSignInAsync(loginModel.Username, loginModel.Password, false, false).Result;

            if (result.IsNotAllowed)
            {
                throw new Exception("Username or Password is not correct!");
            }
        }

        public void Logout()
        {
            _signInManager.SignOutAsync();
        }

        public void Register(RegisterViewModel registerModel)
        {
            User user = new User()
            {
                UserName = registerModel.Username,
                FullName = registerModel.FirstName + " " + registerModel.LastName,
                Email = registerModel.Email,
                Orders = new List<Order>()
                {
                    new Order()
                    {
                        Status = StatusType.Init
                    }
                }
            };
            var password = registerModel.Password;

            var result = _userManager.CreateAsync(user, password).Result;

            if (result.Succeeded)
            {
                var currentUser = _userManager.FindByNameAsync(user.UserName).Result;
                _userManager.AddToRoleAsync(user, "user");

                Login(new LoginViewModel()
                {
                    Username = registerModel.Username,
                    Password = registerModel.Password
                });
            }
            else
            {
                throw new Exception($"Register failed! , {result.Errors.First().Description}");
            }

        }
    }
}
