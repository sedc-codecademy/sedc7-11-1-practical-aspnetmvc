using System;
using System.Collections.Generic;
using System.Text;

namespace Lamazon.DataAccess.Interfaces
{
    public interface IUserRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        TEntity GetByUsername(string username);
    }
}
