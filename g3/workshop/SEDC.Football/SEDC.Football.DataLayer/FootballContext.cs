using Microsoft.EntityFrameworkCore;

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

            base.OnModelCreating(modelBuilder);
        }
    }
}
