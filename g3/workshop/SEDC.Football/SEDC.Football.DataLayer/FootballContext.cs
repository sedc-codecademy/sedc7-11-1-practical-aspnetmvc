using Microsoft.EntityFrameworkCore;
using SEDC.Football.DataLayer.Maps;

namespace SEDC.Football.DataLayer
{
    public class FootballContext : DbContext
    {
        public FootballContext(DbContextOptions options)
            :base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlayerMap());
            modelBuilder.ApplyConfiguration(new TeamMap());
            modelBuilder.ApplyConfiguration(new MatchMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
