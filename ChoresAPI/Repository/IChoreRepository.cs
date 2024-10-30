using ChoresAPI.Models;

namespace ChoresAPI.Repository
{
    public interface IChoreRepository
    {
        Task<IEnumerable<Chore>> GetAllChoresAsync();

        Task<Chore> GetChoreByIdAsync(Guid id);

        Task AddChoreAsync(Chore chore);

        Task UpdateChoreAsync(Chore chore);

        Task DeleteChoreAsync(Guid id);
    }
}
