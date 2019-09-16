using Lamazon.DataAccess.Interfaces;
using Lamazon.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lamazon.DataAccess.Repositories
{
    public class UserRespository : BaseRepository<LamazonDbContext>, IUserRepository<User>
    {
        public UserRespository(LamazonDbContext context) : base(context) { }

        public IEnumerable<User> GetAll()
        {
            return _db.Users
                .ToList();
        }

        public User GetById(int id)
        {
            return _db.Users
                .FirstOrDefault(u => u.Id == id);
        }

        public User GetByUsername(string username)
        {
            return _db.Users
                .FirstOrDefault(u => u.Username == username);
        }

        public int Insert(User entity)
        {
            _db.Users.Add(entity);
            return _db.SaveChanges();
        }

        public int Update(User entity)
        {
            _db.Users.Update(entity);
            return _db.SaveChanges();
        }

        public int Delete(int id)
        {
            var entity = _db.Users.FirstOrDefault(u => u.Id == id);
            if (entity == null)
                return -1;

            _db.Users.Remove(entity);
            return _db.SaveChanges();
        }
    }
}
