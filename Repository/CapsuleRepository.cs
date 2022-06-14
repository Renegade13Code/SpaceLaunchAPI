using Microsoft.EntityFrameworkCore;
using SpaceLaunchAPI.Data;
using SpaceLaunchAPI.Models.Domain;

namespace SpaceLaunchAPI.Repository
{
    public class CapsuleRepository : ICapsuleRepository
    {
        private readonly SpaceLaunchDbContext dbContext;
        private readonly LaunchPad launchPad;
        public CapsuleRepository(SpaceLaunchDbContext DbContext)
        {
            dbContext = DbContext;
        }

        public async Task<Capsule> AddAsync(Capsule capsule)
        {
            capsule.CapsuleId = GenerateId();
            await dbContext.Capsules.AddAsync(capsule);
            await dbContext.SaveChangesAsync();
            return capsule;
        }

        public async Task<Capsule?> DeleteAsync(string id)
        {
            //Find capsule
            var foundCapsule = await dbContext.Capsules.FindAsync(id);
            if (foundCapsule == null)
            {
                return null;
            }

            //remove capsule from database
            dbContext.Capsules.Remove(foundCapsule);
            await dbContext.SaveChangesAsync();

            return foundCapsule;
        }

        public async Task<IEnumerable<Capsule>> GetAllCapsules()
        {
            return await dbContext.Capsules.ToListAsync();
        }

        public async Task<IEnumerable<Capsule?>> GetCapsuleStatus(string capsuleStatus)
        {
            var capsulePayload = await dbContext.Capsules.Where(x => x.Status == capsuleStatus).ToListAsync();
            return capsulePayload;
        }

        public async Task<Capsule?> UpdateAsync(string id, Capsule capsule)
        {
            //Find capsule
            var foundCapsule = await dbContext.Capsules.FindAsync(id);
            if (foundCapsule == null)
            {
                return null;
            }

            //Update database
            foundCapsule.Serial = capsule.Serial;
            foundCapsule.Status = capsule.Status;
            foundCapsule.ReuseCount = capsule.ReuseCount;
            foundCapsule.WaterLandings = capsule.WaterLandings;
            foundCapsule.LandLandings = capsule.LandLandings;
            foundCapsule.LaunchId = capsule.LaunchId;
       
            await dbContext.SaveChangesAsync();
            return foundCapsule;
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
