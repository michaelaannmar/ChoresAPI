using ChoresAPI.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ChoresAPI.Repository
{
    public class JsonChoreRepository : IChoreRepository
    {
        public async Task AddChoreAsync(Chore chore)
        {
            try
            {
                var chores = (await GetAllChoresAsync()).ToList();
                chores.Add(chore);
                await SaveChoreAsync(chores);
            }
            catch
            {
                throw new Exception("Error adding chore");
            }
            
        }

        public async Task DeleteChoreAsync(Guid id)
        {
            try
            {
                var chores = (await GetAllChoresAsync()).ToList();
                var choreToRemove = chores.FirstOrDefault(c => c.Id == id);
                if (choreToRemove != null)
                {
                    chores.Remove(choreToRemove);
                    await SaveChoreAsync(chores);
                }
                else
                {
                    throw new KeyNotFoundException($"Chore with Id {id} not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting chore");
            }
            
        }

        public async Task<IEnumerable<Chore>> GetAllChoresAsync()
        {
            // create a list of chores
            var chores = new List<Chore>();
            // get json file 
            var jsonChores = await File.ReadAllTextAsync("Data/chores.json");
            // deserialize into a list of chores
            chores = JsonConvert.DeserializeObject<List<Chore>>(jsonChores);
            // return list of chores

            return chores;
        }

        public async Task SaveChoreAsync(List<Chore> chores)
        {
            var json = JsonConvert.SerializeObject(chores);
            await File.WriteAllTextAsync("Data/chores.json", json);
        }

        public async Task<Chore> GetChoreByIdAsync(Guid id)
        {
            try
            {
                var chores = await GetAllChoresAsync();
                var chore = chores.FirstOrDefault(x => x.Id == id);

               

                return chore;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving chore by ID.", ex);
            }
            
        }

        public async Task UpdateChoreAsync(Chore chore)
        {
            try
            {
                var chores = (await GetAllChoresAsync()).ToList();
                var oldchore = chores.FirstOrDefault(c => c.Id == chore.Id);
                if (oldchore != null) {
                    chores.Remove(oldchore);
                    chores.Add(chore);
                    await SaveChoreAsync(chores);
                }
                else
                {
                    throw new KeyNotFoundException($"Chore with ID {chore.Id} not found");
                }
            }
            catch
            {
                throw new Exception("Error updating chore");
            }
        }
    }
}
