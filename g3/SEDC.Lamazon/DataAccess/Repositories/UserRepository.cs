using DataAccess.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(LamazonDbContext context) : base(context) {}

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(string id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public User GetByUsername(string username)
        {
            return _context.Users.FirstOrDefault(x => x.UserName == username);
        }

        public int Insert(User user)
        {
            _context.Users.Add(user);
            return _context.SaveChanges();
        }

        public int Update(User user)
        {
            _context.Users.Update(user);
            return _context.SaveChanges();

        }

        public int Delete(string id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return -1;
            }
            _context.Users.Remove(user);
            return _context.SaveChanges();
        }
    }
}
