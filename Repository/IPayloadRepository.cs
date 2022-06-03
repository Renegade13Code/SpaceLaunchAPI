using SpaceLaunchAPI.Models.Domain;

namespace SpaceLaunchAPI.Repository
{
    public interface IPayloadRepository
    {
        public Task<IEnumerable<Payload>> GetAllAsync();
        public Task<Payload?> GetByIdAsync(string id);
        public Task<Payload> AddAsync(Payload payload);
        public Task<Payload?> DeleteAsync(string id);
        public Task<Payload?> UpdateAsync(string id, Payload payload);
    }
}
