using Microsoft.EntityFrameworkCore;
using SpaceLaunchAPI.Data;
using SpaceLaunchAPI.Models.Domain;

namespace SpaceLaunchAPI.Repository
{
    public class AstronautRepository : IAstronautRepository
    {
        private readonly SpaceLaunchDbContext dbContext;
        public AstronautRepository(SpaceLaunchDbContext DbContext)
        {
            dbContext = DbContext;
        }

        public async Task<IEnumerable<Astronaut>> GetAllAsync()
        {
            return await dbContext.Astronauts
                //.Include(x => x.LaunchModel)
                .ToListAsync();
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
