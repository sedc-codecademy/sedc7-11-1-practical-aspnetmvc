using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SEDC.Football.Domain;

namespace SEDC.Football.DataLayer
{
    public abstract class BaseRepository<T> : IRepository<T>
        where T : Entity
    {
        private readonly DbSet<T> _entity;
        private readonly FootballContext _context;

        public BaseRepository(FootballContext context)
        {
            _entity = context.Set<T>();
            _context = context;
        }

        public IQueryable<T> Table => _entity.AsQueryable();

        public virtual T Get(int id)
        {
            return _entity.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _entity;
        }

        public virtual int Insert(T entity)
        {
            _entity.Add(entity);
            return _context.SaveChanges();
        }

        public virtual int Remove(T entity)
        {
            var item = _entity.Find(entity.Id);
            if(item == null)
            {
                return -1;
            }
            _entity.Remove(item);
            return _context.SaveChanges();
        }

        public virtual int Update(T entity)
        {
            _entity.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChanges();
        }
    }
}
