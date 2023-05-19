using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Domain;
using Domain.Dto;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Persistance.Interfaces;
    
namespace Persistance.Services;

public class UserAnimalService : IUserAnimalService
{
    private string _connectionString;

    public UserAnimalService()
    {
        _connectionString = Constants.connectionString;
    }

    public async Task<List<Animal>> GetAnimalIdsByUserId(int userId)
    {
        using (IDbConnection connection = new SqliteConnection(_connectionString))
        {
            var query = @"SELECT a.* 
                          FROM Animals a
                          JOIN UserAnimal ua ON a.AnimalId = ua.AnimalId
                          WHERE ua.UserId = @userId";
            return (await connection.QueryAsync<Animal>(query, new { userId })).ToList();
        }
    }
    public async Task<List<User>> GetUserIdsByAnimalId(int animalId)
    {
        using (IDbConnection connection = new SqliteConnection(_connectionString))
        {
            var query = @"SELECT u.* 
                          FROM Users u
                          JOIN UserAnimal ua ON u.UserId = ua.UserId
                          WHERE ua.AnimalId = @animalId";
            return (await connection.QueryAsync<User>(query, new { animalId })).ToList();
        }
    }

    public async Task AddUserAnimal(int userId, int animalId)
    {
        using (IDbConnection connection = new SqliteConnection(_connectionString))
        {
            var query = "INSERT INTO UserAnimal (UserId, AnimalId) VALUES (@userId, @animalId)";
            await connection.ExecuteAsync(query, new { userId, animalId });
        }
    }

    public async Task DeleteUserAnimal(int userId, int animalId)
    {
        using (IDbConnection connection = new SqliteConnection(_connectionString))
        {
            var query = "DELETE FROM UserAnimal WHERE UserId = @userId AND AnimalId = @animalId";
            await connection.ExecuteAsync(query, new { userId, animalId });
        }
    }

}