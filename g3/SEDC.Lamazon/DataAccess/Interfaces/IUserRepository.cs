using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetById(string id);
        User GetByUsername(string username);
        int Insert(User user);
        int Update(User user);
        int Delete(string id);
    }
}
