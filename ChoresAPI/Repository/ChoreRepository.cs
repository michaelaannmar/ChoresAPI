using ChoresAPI.Data;
using ChoresAPI.Models;
using Microsoft.AspNetCore.Connections;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Xml;

namespace ChoresAPI.Repository
{
    public class ChoreRepository : IChoreRepository
    {
       private readonly SqlConnectionFactory _connection;

        public ChoreRepository(SqlConnectionFactory connection) {
        
            _connection = connection;
        }
        public async Task AddChoreAsync(Chore chore)
        {
            using (var connection = _connection.CreateConnection())
            {
                await connection.OpenAsync();

                // Command to call the stored procedure 'AddCoffee'.
                var command = new SqlCommand("AddChore", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Id", chore.Id);
                command.Parameters.AddWithValue("@Title", chore.Title);
                command.Parameters.AddWithValue("@Description", chore.Description);
                command.Parameters.AddWithValue("@AssignedTo", chore.AssignedTo);
                command.Parameters.AddWithValue("@Point", chore.Point);
                command.Parameters.AddWithValue("@Status", chore.Status);
                command.Parameters.AddWithValue("Frequency", chore.Frequency);

                await command.ExecuteNonQueryAsync();

            }
            
        }

       

        public async Task DeleteChoreAsync(Guid id)
        {
            using (var connection = _connection.CreateConnection())
            {
                await connection.OpenAsync();

                // Command to call the stored procedure 'DeleteCoffee'.
                var command = new SqlCommand("DeleteChore", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Id", id);

                // Executing the stored procedure.
                await command.ExecuteNonQueryAsync();
            }
            
        }


        public async Task<IEnumerable<Chore>> GetAllChoresAsync()
        {
            var chores = new List<Chore>();

            using (var connection = _connection.CreateConnection())
            {
                await connection.OpenAsync();

                var command = new SqlCommand("SELECT * FROM Chores", connection);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        chores.Add(new Chore
                        {
                            Id = reader.GetGuid(0),
                            Title = reader.GetString(1),
                            Description = reader.GetString(2),
                            AssignedTo = reader.GetString(3),
                            Point = reader.GetInt32(4),
                            Status = reader.GetString(5),
                            Frequency = reader.GetString(6)
                        });
                    }
                }
            }
            return chores; 
        }

        public async Task<Chore> GetChoreByIdAsync(Guid id)
        {
            Chore chore = null;

            using (var connection = _connection.CreateConnection())
            {
                await connection.OpenAsync();

                var command = new SqlCommand("GetChoreByID", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        chore = new Chore()
                        {
                            Id = reader.GetGuid(0),
                            Title = reader.GetString(1),
                            Description = reader.GetString(2),
                            AssignedTo = reader.GetString(3),
                            Point = reader.GetInt32(4),
                            Status = reader.GetString(5),
                            Frequency = reader.GetString(6),

                        };
                    }
                }
            }
                return chore;

            
        }

        public async Task UpdateChoreAsync(Chore chore)
        {
            using (var connection = _connection.CreateConnection())
            {
                await connection.OpenAsync();

                // Command to call the stored procedure 'AddCoffee'.
                var command = new SqlCommand("UpdateChore", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Id", chore.Id);
                command.Parameters.AddWithValue("@Title", chore.Title);
                command.Parameters.AddWithValue("@Description", chore.Description);
                command.Parameters.AddWithValue("@AssignedTo", chore.AssignedTo);
                command.Parameters.AddWithValue("@Point", chore.Point);
                command.Parameters.AddWithValue("@Status", chore.Status);
                command.Parameters.AddWithValue("Frequency", chore.Frequency);

                await command.ExecuteNonQueryAsync();

            }
            
        }

      
    }

       
    }
