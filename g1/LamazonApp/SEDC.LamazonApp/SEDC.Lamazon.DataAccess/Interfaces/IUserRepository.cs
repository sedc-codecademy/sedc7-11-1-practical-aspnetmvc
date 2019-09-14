using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Lamazon.DataAccess.Interfaces
{
    public interface IUserRepository<T>: IRepository<T>
    {
        T GetByUsername(string username);
    }
}
