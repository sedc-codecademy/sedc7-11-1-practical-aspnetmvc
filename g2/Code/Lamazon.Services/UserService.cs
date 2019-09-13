using Lamazon.DataAccess.Interfaces;
using Lamazon.Domain.Models;
using Lamazon.Services.Interfaces;
using Lamazon.WebModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lamazon.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository<User> _userRepo;

        public UserService(IUserRepository<User> userRepo)
        {
            _userRepo = userRepo;
        }

        public void Register(RegisterViewModel registerModel)
        {
            if (_userRepo.GetByUsername(registerModel.Username) == null)
                throw new Exception("Username already exists!");
            if (registerModel.Password != registerModel.ConfirmPassword)
                throw new Exception("Passwords does not match!");

            User user = new User
            {
                Username = registerModel.Username,
                Password = registerModel.Password,
                Firstname = registerModel.FirstName,
                Lastname = registerModel.LastName,
                Address = registerModel.Address,
                RoleId = 3
            };

            _userRepo.Insert(user);
        }

        public void Login(LoginViewModel loginModel)
        {
            throw new NotImplementedException();
        }

        public UserViewModel GetCurrentUser(string username)
        {
            User user = _userRepo.GetByUsername(username);
            if (user == null)
                throw new Exception("User does not exists!");
            
            UserViewModel userViewModel = new UserViewModel
            {
                Username = user.Username,
                FullName = $"{user.Firstname} {user.Lastname}",
                Address = user.Address
            };

            return userViewModel;
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }
    }
}
