using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SEDC.Football.Domain;

namespace SEDC.Football.DataLayer
{
    public abstract class BaseRepository<T> : IRepository<T>
        where T : Entity
    {
        protected readonly DbSet<T> _entity;
        private readonly FootballContext _context;

        public BaseRepository(FootballContext context)
        {
            _entity = context.Set<T>();
            _context = context;
        }

        public IQueryable<T> Table => _entity.AsQueryable();

        public T Get(int id)
        {
            return _entity.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _entity;
        }

        public int Insert(T entity)
        {
            _entity.Add(entity);
            return _context.SaveChanges();
        }

        public int Remove(T entity)
        {
            var item = _entity.Find(entity.Id);
            if(item == null)
            {
                return -1;
            }
            _entity.Remove(item);
            return _context.SaveChanges();
        }

        public int Update(T entity)
        {
            _entity.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChanges();
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }
    }
}
