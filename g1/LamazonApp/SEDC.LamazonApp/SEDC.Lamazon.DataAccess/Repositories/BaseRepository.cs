using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Lamazon.DataAccess.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly LamazonDbContext _context;
        public BaseRepository(LamazonDbContext context)
        {
            _context = context;
        }
    }
}
