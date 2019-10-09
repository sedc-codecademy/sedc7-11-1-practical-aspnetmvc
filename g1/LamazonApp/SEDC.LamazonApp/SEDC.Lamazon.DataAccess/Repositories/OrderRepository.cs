using Microsoft.EntityFrameworkCore;
using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.Lamazon.DataAccess.Repositories
{
    public class OrderRepository : BaseRepository, IRepository<Order>
    {
        public OrderRepository(LamazonDbContext context) : base(context) { }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders
                .Include(o => o.Invoice)
                .Include(o => o.ProductOrders)
                .ThenInclude(po => po.Product)
                .Include(o => o.User);
        }

        public Order GetById(int id)
        {
            return _context.Orders
                .Include(o => o.ProductOrders)
                .ThenInclude(po => po.Product)
                .Include(o => o.User)
                .Include(o => o.Invoice)
                .FirstOrDefault(o => o.Id == id);
        }

        public int Insert(Order entity)
        {
            _context.Orders.Add(entity);
            return _context.SaveChanges();
        }

        public int Update(Order entity)
        {
            _context.Orders.Update(entity);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            Order order = _context.Orders.FirstOrDefault(o => o.Id == id);

            if (order == null)
                return -1;

            _context.Orders.Remove(order);
            return _context.SaveChanges();
        }
    }
}
