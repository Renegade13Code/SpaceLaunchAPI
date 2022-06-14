using SpaceLaunchAPI.Models.Domain;

namespace SpaceLaunchAPI.Repository
{
    public interface IAstronautRepository
    {
        public Task<IEnumerable<Astronaut>> GetAllAsync();
    }
}