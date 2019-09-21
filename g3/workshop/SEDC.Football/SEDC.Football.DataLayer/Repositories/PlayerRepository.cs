using SEDC.Football.DataLayer.Interfaces;
using SEDC.Football.Domain.Models;

namespace SEDC.Football.DataLayer.Repositories
{
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(FootballContext context)
            :base(context)
        {
        }
    }
}
