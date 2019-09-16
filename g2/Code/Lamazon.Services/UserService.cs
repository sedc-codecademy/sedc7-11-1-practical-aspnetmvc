using Lamazon.DataAccess.Interfaces;
using Lamazon.Domain.Models;
using Lamazon.Services.Helpers;
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
        private readonly ManualMapper _mapper;

        public UserService(IUserRepository<User> userRepo, ManualMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public void Register(RegisterViewModel registerModel)
        {
            if (_userRepo.GetByUsername(registerModel.Username) != null)
                throw new Exception("Username already exists!");
            if (registerModel.Password != registerModel.ConfirmPassword)
                throw new Exception("Passwords does not match!");

            _userRepo.Insert(
                _mapper.UserToDomainModel(registerModel)
            );
        }

        public void Login(LoginViewModel loginModel)
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
            throw new NotImplementedException();
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
