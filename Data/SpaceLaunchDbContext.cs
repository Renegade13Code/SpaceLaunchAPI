using Microsoft.EntityFrameworkCore;
using SpaceLaunchAPI.Models.Domain;

namespace SpaceLaunchAPI.Data
{
    public class SpaceLaunchDbContext : DbContext
    {
        public SpaceLaunchDbContext(DbContextOptions<SpaceLaunchDbContext> options) : base(options)
        {

        }

        //Still need to define domain models for data!
        public DbSet<Rocket> Rockets { get; set; }
        //public DbSet<Launch> Launches { get; set; }
        //public DbSet<PayLoad> PayLoads { get; set; }
    }
}
