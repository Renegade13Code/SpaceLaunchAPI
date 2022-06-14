using SpaceLaunchAPI.Models.Domain;

namespace SpaceLaunchAPI.Repository
{
    public interface ICapsuleRepository
    {
        public Task<IEnumerable<Capsule>> GetAllCapsules();
        public Task<IEnumerable<Capsule?>> GetCapsuleStatus(string capsuleStatus);
        public Task<Capsule> AddAsync(Capsule capsule);
        public Task<Capsule?> DeleteAsync(string id);
        public Task<Capsule?> UpdateAsync(string id, Capsule capsule);
    }
}
