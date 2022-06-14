using Microsoft.EntityFrameworkCore;
using SpaceLaunchAPI.Data;
using SpaceLaunchAPI.Models.Domain;

namespace SpaceLaunchAPI.Repository
{
    public class RocketRepository : IRocketRepository
    {
        private readonly SpaceLaunchDbContext dbContext;

        public RocketRepository(SpaceLaunchDbContext DbContext)
        {
            dbContext = DbContext;
        }
        public async Task<IEnumerable<Rocket>> GetAllAsync()
        {
            return await dbContext.Rockets.ToListAsync();
        }

        public async Task<Rocket?> GetByIdAsync(string id)
        {
            var foundRocket = await dbContext.Rockets.FindAsync(id);
            return foundRocket;
        }

        public async Task<IEnumerable<Rocket?>> GetRocketStatus(bool status)
        {
            var rocketsFiltered = await dbContext.Rockets.Where(x => x.IsActive == status).ToListAsync();
            return rocketsFiltered;
        }

        public async Task<Rocket> AddAsync(Rocket rocket)
        {
            //generate id 
            rocket.RocketId = GenerateId();
            await dbContext.Rockets.AddAsync(rocket);
            await dbContext.SaveChangesAsync();
            return rocket;
        }

        public async Task<Rocket?> DeleteAsync(string id)
        {
            //Find rocket
            var foundRocket = await dbContext.Rockets.FindAsync(id);
            if(foundRocket == null)
            {
                return null;
            }

            //remove rocket from database
            dbContext.Rockets.Remove(foundRocket);
            await dbContext.SaveChangesAsync();

            return foundRocket;
        }

        public async Task<Rocket?> UpdateAsync(string id, Rocket rocket)
        {
            //Find rocket
            var foundRocket = await dbContext.Rockets.FindAsync(id);
            if (foundRocket == null)
            {
                return null;
            }

            //Update database
            foundRocket.Name = rocket.Name;
            foundRocket.Type = rocket.Type;
            foundRocket.IsActive = rocket.IsActive;
            foundRocket.Country = rocket.Country;
            foundRocket.Company = rocket.Company;
            foundRocket.HeightMt = rocket.HeightMt;
            foundRocket.HeightFt = rocket.HeightFt;
            foundRocket.DiameterMt = rocket.DiameterMt;
            foundRocket.DiameterFt = rocket.DiameterFt;
            foundRocket.MassKg = rocket.MassKg;
            foundRocket.MassLb = rocket.MassLb;
            foundRocket.Stages = rocket.Stages;
            foundRocket.Boosters = rocket.Boosters;
            foundRocket.CostPerLaunch = rocket.CostPerLaunch;
            foundRocket.Engines = rocket.Engines;

            await dbContext.SaveChangesAsync();
            return foundRocket;
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
