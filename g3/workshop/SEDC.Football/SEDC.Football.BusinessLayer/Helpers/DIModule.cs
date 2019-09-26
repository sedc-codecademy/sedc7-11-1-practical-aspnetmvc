using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SEDC.Football.DataLayer;
using SEDC.Football.DataLayer.Interfaces;
using SEDC.Football.DataLayer.Repositories;

namespace SEDC.Football.BusinessLayer.Helpers
{
    public class DIModule
    {
        public static IServiceCollection RegisterDependencies(IServiceCollection services, string connectionString)
        {
            // registering DbContext in our case Football context
            services.AddDbContext<FootballContext>(opt => opt.UseSqlServer(connectionString));

            // Data Layer Dependencies
            services.AddTransient<IPlayerRepository, PlayerRepository>();
            services.AddTransient<ITeamRepository, TeamRepository>();
            services.AddTransient<IMatchRepository, MatchRepository>();

            // Business Layer Dependencies
            // register dependencies here

            return services;
        }
    }
}
