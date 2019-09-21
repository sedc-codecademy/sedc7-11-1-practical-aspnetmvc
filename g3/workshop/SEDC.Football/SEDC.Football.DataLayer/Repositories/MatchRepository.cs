using SEDC.Football.DataLayer.Interfaces;
using SEDC.Football.Domain.Models;

namespace SEDC.Football.DataLayer.Repositories
{
    public class MatchRepository : BaseRepository<Match>, IMatchRepository
    {
        public MatchRepository(FootballContext context)
            :base(context)
        {
        }
    }
}
