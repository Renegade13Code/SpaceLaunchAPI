using SpaceLaunchAPI.Models.Domain;

namespace SpaceLaunchAPI.Repository
{
    public interface ILaunchRepository
    {
        public Task<IEnumerable<Launch>> GetAllAsync();
        public Task<Launch?> GetByIdAsync(string id);
        public Task<Launch> AddAsync(Launch launch);
        public Task<Launch?> DeleteAsync(string id);
        public Task<Launch?> UpdateAsync(string id, Launch launch);
    }
}
