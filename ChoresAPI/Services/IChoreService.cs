using ChoresAPI.Models;

namespace ChoresAPI.Services
{
    public interface IChoreService
    {
        Task<IEnumerable<Chore>> GetAllChoresAsync();

        Task AddChoreAsync(Chore chore);

        Task<Chore> GetChoreByIdAsync(Guid id);

        Task UpdateChoreAsync(Chore chore);

        Task DeleteChoreAsync(Guid id);

        
    }
}