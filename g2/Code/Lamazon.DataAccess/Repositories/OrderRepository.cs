using Lamazon.DataAccess.Interfaces;
using Lamazon.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lamazon.DataAccess.Repositories
{
    public class OrderRepository : BaseRepository<LamazonDbContext>, IRepository<Order>
    {
        public OrderRepository(LamazonDbContext context) : base(context) { }

        public IEnumerable<Order> GetAll()
        {
            return _db.Orders
                .Include(o => o.User)
                .Include(o => o.OrdersProducts)
                    .ThenInclude(op => op.Product);
                
        }

        public Order GetById(int id)
        {
            return _db.Orders
                .Include(o => o.User)
                .Include(o => o.OrdersProducts)
                    .ThenInclude(op => op.Product)
                .FirstOrDefault(o => o.Id == id);
        }

        public int Insert(Order entity)
        {
            _db.Orders.Add(entity);
            return _db.SaveChanges();
        }

        public int Update(Order entity)
        {
            _db.Orders.Update(entity);
            return _db.SaveChanges();
        }

        public int Delete(int id)
        {
            var entity = GetById(id);
            _db.Orders.Remove(entity);
            return _db.SaveChanges();
        }
    }
}
