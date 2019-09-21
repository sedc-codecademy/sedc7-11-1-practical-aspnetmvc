using SEDC.Football.Domain;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.Football.DataLayer
{
    public interface IRepository<T> 
        where T : Entity
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        int Insert(T entity);
        int Update(T entity);
        int Remove(T entity);

        IQueryable<T> Table { get; }
    }
}
