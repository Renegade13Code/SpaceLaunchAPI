using Microsoft.EntityFrameworkCore;
using SpaceLaunchAPI.Data;
using SpaceLaunchAPI.Models.Domain;

namespace SpaceLaunchAPI.Repository
{
    public class LaunchRepository : ILaunchRepository
    {
        private readonly SpaceLaunchDbContext dbContext;

        public LaunchRepository(SpaceLaunchDbContext DbContext)
        {
            dbContext = DbContext;
        }

        public async Task<IEnumerable<Launch>> GetAllAsync()
        {
            return await dbContext.Launches
                .Include(x => x.RocketModel)
                .Include(x => x.LaunchPadModel)
                .Include(x => x.Payloads)
                .Include(x => x.Capsules)
                .ToListAsync();
        }

        public async Task<Launch?> GetByIdAsync(string id)
        {
            var foundLaunch = await  dbContext.Launches
                .Include(x => x.RocketModel)
                .Include(x => x.LaunchPadModel)
                .Include(x => x.Payloads)
                .Include(x => x.Capsules)
                .FirstOrDefaultAsync(x => x.LaunchId == id);

            return foundLaunch;
        }

        public async Task<Launch> AddAsync(Launch launch)
        {
            //Remove this and see if entity generates id
            launch.LaunchId = GenerateId();
            await dbContext.AddAsync(launch);
            await dbContext.SaveChangesAsync();

            return launch;
        }

        public async Task<Launch?> DeleteAsync(string id)
        {
            var foundLaunch = await dbContext.Launches
                .Include(x => x.RocketModel)
                .Include(x => x.LaunchPadModel)
                .Include(x => x.Payloads)
                .Include(x => x.Capsules)
                .FirstOrDefaultAsync(x => x.LaunchId == id);

            if(foundLaunch == null)
            {
                return null;
            }
            dbContext.Launches.Remove(foundLaunch);
            await dbContext.SaveChangesAsync();

            return foundLaunch;
        }

        public async Task<Launch?> UpdateAsync(string id, Launch launch)
        {
            var foundLaunch = await dbContext.Launches
                .Include(x => x.RocketModel)
                .Include(x => x.LaunchPadModel)
                .Include(x => x.Payloads)
                .Include(x => x.Capsules)
                .FirstOrDefaultAsync(x => x.LaunchId == id);

            if (foundLaunch == null)
            {
                return null;
            }

            foundLaunch.Name = launch.Name;
            foundLaunch.Date = launch.Date;
            foundLaunch.RocketId = launch.RocketId;
            foundLaunch.LaunchpadId = launch.LaunchpadId;
            foundLaunch.Success = launch.Success;
            foundLaunch.Failures = launch.Failures;

            await dbContext.SaveChangesAsync();
            return foundLaunch;
    }

        #region private methods
        private string GenerateId()
        {
            var chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[24];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new String(stringChars);
        }
        #endregion
    }
}
