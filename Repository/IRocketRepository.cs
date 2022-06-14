using SpaceLaunchAPI.Models.Domain;

namespace SpaceLaunchAPI.Repository
{
    public interface IRocketRepository
    {
        public Task<IEnumerable<Rocket>> GetAllAsync();
        public Task<Rocket?> GetByIdAsync(string id);
        public Task<Rocket> AddAsync(Rocket rocket);
        public Task<IEnumerable<Rocket?>> GetRocketStatus(bool status);
        public Task<Rocket?> DeleteAsync(string id);
        public Task<Rocket?> UpdateAsync(string id, Rocket rocket);
    }
}
