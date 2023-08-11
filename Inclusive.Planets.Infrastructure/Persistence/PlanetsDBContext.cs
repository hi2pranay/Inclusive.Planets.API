using Inclusive.Planets.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Inclusive.Planets.Infrastructure.Persistence
{
    public class PlanetsDBContext : DbContext
    {
        public PlanetsDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Planet> Planets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
