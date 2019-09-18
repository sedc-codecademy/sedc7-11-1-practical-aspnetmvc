﻿using Lamazon.DataAccess.Interfaces;
using Lamazon.Domain.Models;
using Lamazon.Services.Helpers;
using Lamazon.Services.Interfaces;
using Lamazon.WebModels.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lamazon.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository<User> _userRepo;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ManualMapper _mapper;

        public UserService(IUserRepository<User> userRepo, UserManager<User> userManager, SignInManager<User> signInManager, ManualMapper mapper)
        {
            _userRepo = userRepo;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public void Register(RegisterViewModel registerModel)
        {
            if (_userRepo.GetByUsername(registerModel.Username) != null)
                throw new Exception("Username already exists!");
            if (registerModel.Password != registerModel.ConfirmPassword)
                throw new Exception("Passwords does not match!");

            User user = _mapper.UserToDomainModel(registerModel);
            var result = _userManager.CreateAsync(user, registerModel.Password).Result;
            if (result.Succeeded)
            {
                var currentUser = _userManager.FindByNameAsync(user.UserName).Result;
                _userManager.AddToRoleAsync(currentUser, "customer");
            }

            Login(
                new LoginViewModel { Username = registerModel.Username, Password = registerModel.Password}
            );

            //_userRepo.Insert(
            //    _mapper.UserToDomainModel(registerModel)
            //);
        }

        public void Login(LoginViewModel loginModel)
        {
            var result = _signInManager.PasswordSignInAsync(
                loginModel.Username, 
                loginModel.Password, 
                false, 
                false).Result;

            if (result.IsNotAllowed)
            {
                throw new Exception("Username or password is wrong!");
            }
        }

        public void Logout()
        {
            _signInManager.SignOutAsync();
        }

        public UserViewModel GetCurrentUser(string username)
        {
            User user = _userRepo.GetByUsername(username);
            if (user == null)
                throw new Exception("User does not exists!");

            return _mapper.UserToViewModel(user);
        }
    }
}
