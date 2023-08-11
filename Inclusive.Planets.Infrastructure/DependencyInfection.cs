using Inclusive.Planets.Core.Interfaces;
using Inclusive.Planets.Infrastructure.Persistence;
using Inclusive.Planets.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Inclusive.Planets.Infrastructure
{
    public static class DependencyInfection
    {
        public static IServiceCollection AddInfrastructureDependencyInfection(this IServiceCollection services, IConfiguration configuration)
        {
            string path = Directory.GetCurrentDirectory();

            services.AddDbContext<PlanetsDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("DatabaseConnectionString").Replace("%CONTENTROOTPATH%", path)));
            services.AddTransient<IPlanetRepository, PlanetRepository>();

            return services;
        }
    }
}
