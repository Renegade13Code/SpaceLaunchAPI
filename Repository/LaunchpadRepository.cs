using Microsoft.EntityFrameworkCore;
using SpaceLaunchAPI.Data;
using SpaceLaunchAPI.Models.Domain;

namespace SpaceLaunchAPI.Repository
{
    public class LaunchpadRepository : ILaunchpadRepository
    {
        private readonly SpaceLaunchDbContext dbContext;

        public LaunchpadRepository(SpaceLaunchDbContext DbContext)
        {
            dbContext = DbContext;
        }
        public async Task<IEnumerable<LaunchPad>> GetAllAsync()
        {
            return await dbContext.LaunchPads.ToListAsync();
        }

        public async Task<LaunchPad?> GetByIdAsync(string id)
        {
            var foundLaunchpad = await dbContext.LaunchPads.FindAsync(id);
            return foundLaunchpad;
        }

        public async Task<LaunchPad> AddAsync(LaunchPad launchPad)
        {
            launchPad.LaunchpadId = GenerateId();
            await dbContext.LaunchPads.AddAsync(launchPad);
            await dbContext.SaveChangesAsync();
            return launchPad;
        }

        public async Task<LaunchPad?> DeleteAsync(string id)
        {
            //Find rocket
            var foundLaunchpad = await dbContext.LaunchPads.FindAsync(id);
            if (foundLaunchpad == null)
            {
                return null;
            }

            //remove rocket from database
            dbContext.LaunchPads.Remove(foundLaunchpad);
            await dbContext.SaveChangesAsync();

            return foundLaunchpad;
        }

        public async Task<LaunchPad?> UpdateAsync(string id, LaunchPad launchPad)
        {
            //Find rocket
            var foundLaunchpad = await dbContext.LaunchPads.FindAsync(id);
            if (foundLaunchpad == null)
            {
                return null;
            }

            //Update database
            foundLaunchpad.Name = launchPad.Name;
            foundLaunchpad.FullName = launchPad.FullName;
            foundLaunchpad.Status = launchPad.Status;
            foundLaunchpad.Locality = launchPad.Locality;
            foundLaunchpad.Region = launchPad.Region;
            foundLaunchpad.TimeZone = launchPad.TimeZone;
            foundLaunchpad.Latitude = launchPad.Latitude;
            foundLaunchpad.Longitude = launchPad.Longitude;

            await dbContext.SaveChangesAsync();
            return foundLaunchpad;
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
