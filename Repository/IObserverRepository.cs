using SpaceLaunchAPI.Models.Domain;

namespace SpaceLaunchAPI.Repository
{
    public interface IObserverRepository
    {
        public Task<IEnumerable<EmailObserver>> GetAllAsync(); //think about lists
        public Task<IEnumerable<EmailObserver?>> GetByIdAsync(string id);
        public Task<EmailObserver> AddAsync(EmailObserver observer);
        public Task<EmailObserver?> DeleteAsync(string id);
        public Task<EmailObserver?> UpdateAsync(string id, EmailObserver observer);
    }
}
