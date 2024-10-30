using ChoresAPI.Models;
using ChoresAPI.Repository;

namespace ChoresAPI.Services
{
    public class ChoreService : IChoreService
    {
        private readonly IChoreRepository _choreRepository;


        public ChoreService(IChoreRepository choreRepository)
        {
            _choreRepository = choreRepository;
        }

        public async Task<IEnumerable<Chore>> GetAllChoresAsync()
        {
            return await _choreRepository.GetAllChoresAsync();
        }

        public async Task AddChoreAsync(Chore chore)
        {
            await _choreRepository.AddChoreAsync(chore);
        }

        public async Task<Chore> GetChoreByIdAsync(Guid id)
        {
            try
            {
               return await _choreRepository.GetChoreByIdAsync(id);
            }
            catch (KeyNotFoundException ex)
            {
                throw new Exception(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the chore by ID.", ex);
            }
        }

        public async Task UpdateChoreAsync(Chore chore)
        {
            await _choreRepository.UpdateChoreAsync(chore);
        }

        public async Task DeleteChoreAsync(Guid id)
        {
            await _choreRepository.DeleteChoreAsync(id);
        }
    }
}
