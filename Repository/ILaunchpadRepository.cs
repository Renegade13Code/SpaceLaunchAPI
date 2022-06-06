using SpaceLaunchAPI.Models.Domain;

namespace SpaceLaunchAPI.Repository
{
    public interface ILaunchpadRepository
    {
        public Task<IEnumerable<LaunchPad>> GetAllAsync();
        public Task<LaunchPad?> GetByIdAsync(string id);
        public Task<LaunchPad> AddAsync(LaunchPad launchPad);
        public Task<LaunchPad?> DeleteAsync(string id);
        public Task<LaunchPad?> UpdateAsync(string id, LaunchPad launchPad);
    }
}
