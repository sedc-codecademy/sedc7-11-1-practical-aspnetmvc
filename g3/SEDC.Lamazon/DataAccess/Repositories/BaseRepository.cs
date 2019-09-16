using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class BaseRepository
    {
        protected readonly LamazonDbContext _context;

        public BaseRepository(LamazonDbContext context)
        {
            _context = context;
        }
    }
}
