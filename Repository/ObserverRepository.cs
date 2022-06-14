using Microsoft.EntityFrameworkCore;
using SpaceLaunchAPI.Data;
using SpaceLaunchAPI.Models.Domain;

namespace SpaceLaunchAPI.Repository
{
    public class ObserverRepository : IObserverRepository
    {
        private readonly SpaceLaunchDbContext dbContext;

        public ObserverRepository(SpaceLaunchDbContext DbContext)
        {
            dbContext = DbContext;
        }

        public async Task<IEnumerable<EmailObserver>> GetAllAsync()
        {
            // need to create emails table for this to work
            return await dbContext.EmailRecipient
                .ToListAsync();
        }

        public async Task<EmailObserver?> GetByIdAsync(string id)
        {
            var foundObserver = await  dbContext.EmailRecipient
                .FirstOrDefaultAsync(x => x.EmailId == id);

            return foundObserver;
        }

        public async Task<EmailObserver> AddAsync(EmailObserver observer)
        {
            //Remove this and see if entity generates id
            observer.EmailId = GenerateId();
            await dbContext.EmailRecipient.AddAsync(observer);
            await dbContext.SaveChangesAsync();

            return observer;
        }

        public async Task<EmailObserver?> DeleteAsync(string id)
        {
            var foundObserver = await dbContext.EmailRecipient
                .FirstOrDefaultAsync(x => x.EmailId == id);

            if(foundObserver == null)
            {
                return null;
            }
            dbContext.EmailRecipient.Remove(foundObserver);
            await dbContext.SaveChangesAsync();

            return foundObserver;
        }

        public async Task<EmailObserver?> UpdateAsync(string id, EmailObserver observer)
        {
            var foundObserver = await dbContext.EmailRecipient
                .FirstOrDefaultAsync(x => x.EmailId == id);

            if (foundObserver == null)
            {
                return null;
            }

            foundObserver.Name = observer.Name;
            foundObserver.Email = observer.Email;
            foundObserver.LaunchId = observer.LaunchId;

            await dbContext.SaveChangesAsync();
            return foundObserver;
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
