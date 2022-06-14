using Microsoft.EntityFrameworkCore;
using SpaceLaunchAPI.Models.Domain;

namespace SpaceLaunchAPI.Data
{
    public class SpaceLaunchDbContext : DbContext
    {
        public SpaceLaunchDbContext(DbContextOptions<SpaceLaunchDbContext> options) : base(options)
        {

        }

        public DbSet<Launch> Launches { get; set; }
        public DbSet<Rocket> Rockets { get; set; }
        public DbSet<Payload> PayLoads { get; set; }
        public DbSet<LaunchPad> LaunchPads { get; set; }
        public DbSet<Capsule> Capsules { get; set; }
        public DbSet<Astronaut> Astronauts { get; set; }

    }
}
