using Lamazon.DataAccess.Interfaces;
using Lamazon.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lamazon.DataAccess.Repositories
{
    public class ProductRepository : BaseRepository<LamazonDbContext>, IRepository<Product>
    {
        public ProductRepository(LamazonDbContext context) : base(context) { }

        public IEnumerable<Product> GetAll()
        {
            return _db.Products
                .ToList();
        }

        public Product GetById(int id)
        {
            return _db.Products
                .FirstOrDefault(p => p.Id == id);
        }

        public int Insert(Product entity)
        {
            _db.Products.Add(entity);
            return _db.SaveChanges();
        }

        public int Update(Product entity)
        {
            _db.Products.Update(entity);
            return _db.SaveChanges();
        }

        public int Delete(int id)
        {
            var entity = _db.Products.FirstOrDefault(p => p.Id == id);
            if (entity == null)
                return -1;

            _db.Products.Remove(entity);
            return _db.SaveChanges();
        }
    }
}
