using Microsoft.EntityFrameworkCore;
using SpaceLaunchAPI.Data;
using SpaceLaunchAPI.Models.Domain;

namespace SpaceLaunchAPI.Repository
{
    public class PayloadRepository : IPayloadRepository
    {
        private readonly SpaceLaunchDbContext dbContext;
        public PayloadRepository(SpaceLaunchDbContext DbContext)
        {
            dbContext = DbContext;
        }

        public async Task<IEnumerable<Payload>> GetAllAsync()
        {
            return await dbContext.PayLoads
                //.Include(x => x.LaunchModel)
                .ToListAsync();
        }

        public async Task<Payload?> GetByIdAsync(string id)
        {
            var foundPayload = await dbContext.PayLoads
                //.Include(x => x.LaunchModel)
                .FirstOrDefaultAsync(x => id == x.PayloadId);

            return foundPayload;
        }
        public async Task<Payload> AddAsync(Payload payload)
        {
            payload.PayloadId = GenerateId();
            await dbContext.PayLoads.AddAsync(payload);
            await dbContext.SaveChangesAsync();
            return payload;
        }

        public async Task<Payload?> DeleteAsync(string id)
        {
            //Find paylaod
            var foundPayload = await dbContext.PayLoads
                //.Include(x => x.LaunchModel)
                .FirstOrDefaultAsync(x => id == x.PayloadId);

            if (foundPayload == null)
            {
                return foundPayload;
            }

            //Remove payload
            dbContext.PayLoads.Remove(foundPayload);
            await dbContext.SaveChangesAsync();

            return foundPayload;
        }

        public async Task<Payload?> UpdateAsync(string id, Payload payload)
        {
            //Find paylaod
            var foundPayload = await dbContext.PayLoads
                //.Include(x => x.LaunchModel)
                .FirstOrDefaultAsync(x => id == x.PayloadId);

            if (foundPayload == null)
            {
                return foundPayload;
            }

            //Update payload
            foundPayload.Name = payload.Name;
            foundPayload.Type = payload.Type;
            foundPayload.Reused = payload.Reused;
            foundPayload.Manufacturers = payload.Manufacturers;
            foundPayload.MassKg = payload.MassKg;
            foundPayload.MassLb = payload.MassLb;
            foundPayload.Orbit = payload.Orbit;
            foundPayload.ReferenceSystem = payload.ReferenceSystem;
            foundPayload.Regime = payload.Regime;
            foundPayload.LaunchId = payload.LaunchId;

            await dbContext.SaveChangesAsync();
            return foundPayload;

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
