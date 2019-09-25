using SEDC.Football.DataLayer.Interfaces;
using SEDC.Football.Domain.Models;

namespace SEDC.Football.DataLayer.Repositories
{
    public class TeamRepository : BaseRepository<Team>, ITeamRepository
    {
        public TeamRepository(FootballContext context)
            :base(context)
        {
        }
    }
}
