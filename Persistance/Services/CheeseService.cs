using Dapper;
using Domain.Dto;
using Microsoft.Data.SqlClient;
using Persistance.Interfaces;
using System.Data;
using Domain;
using Microsoft.Data.Sqlite;


namespace Persistance.Services;

public class CheeseService : ICheeseService
{
    private readonly string _connectionString;

        public CheeseService()
        {
            this._connectionString = Constants.connectionString;
        }

        public async Task<IEnumerable<Cheese>> GetAllCheeses()
        {
            using (IDbConnection connection = new SqliteConnection(_connectionString))
            {
                var query = "SELECT * FROM Cheeses";
                return (await connection.QueryAsync<Cheese>(query)).ToList();
            }
        }

        public async Task<Cheese> GetCheeseById(int cheeseId)
        {
            using (IDbConnection connection = new SqliteConnection(_connectionString))
            {
                var query = "SELECT * FROM Cheeses WHERE CheeseId = @cheeseId";
                return (await connection.QueryAsync<Cheese>(query, new { cheeseId })).FirstOrDefault();
            }
        }

        public async Task AddCheese(Cheese cheese)
        {
            using (IDbConnection connection = new SqliteConnection(_connectionString))
            {
                var query = "INSERT INTO Cheeses (CheeseId, Fatness, Moisture, Salt, Hardness) VALUES (@cheeseId, @fatness, @moisture, @salt, @hardness)";
                await connection.ExecuteAsync(query, new { cheeseId = cheese.CheeseId, fatness = cheese.Fatness, moisture = cheese.Moisture, salt = cheese.Salt, hardness = cheese.Hardness });
            }
        }

        public async Task DeleteCheese(int cheeseId)
        {
            using (IDbConnection connection = new SqliteConnection(_connectionString))
            {
                var query = "DELETE FROM Cheeses WHERE CheeseId = @cheeseId";
                await connection.ExecuteAsync(query, new { cheeseId });
            }
        }

        public async Task UpdateCheese(Cheese cheese)
        {
            using (IDbConnection connection = new SqliteConnection(_connectionString))
            {
                var query = "UPDATE Cheeses SET Fatness = @fatness, Moisture = @moisture, Salt = @salt, Hardness = @hardness WHERE CheeseId = @cheeseId";
                await connection.ExecuteAsync(query, new { cheeseId = cheese.CheeseId, fatness = cheese.Fatness, moisture = cheese.Moisture, salt = cheese.Salt, hardness = cheese.Hardness });
            }
        }
}