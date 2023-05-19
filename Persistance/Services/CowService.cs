using System.Data;
using Dapper;
using Domain;
using Domain.Dto;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Persistance.Interfaces;

namespace Persistance.Services;

public class CowService : ICowService
{
    private string connectionString;

    public CowService()
    {
        this.connectionString = Constants.connectionString;
    }

    public async Task<List<Cow>> GetAllCows()
    {
        using (IDbConnection connection = new SqliteConnection(connectionString))
        {
            var query = "SELECT * FROM Cows";
            return (await connection.QueryAsync<Cow>(query)).ToList();
        }
    }
    
    public async Task<List<Cow>> GetGoodCows()
    {
        using (IDbConnection connection = new SqliteConnection(connectionString))
        {
            var query = "SELECT * FROM Cows INNER JOIN Animals A on A.AnimalId = Cows.CowID WHERE A.Weight > 330 AND A.Weight < 430 AND Cows.MuscleType = 'good'";
            return (await connection.QueryAsync<Cow>(query)).ToList();
        }
    }
    
    public async Task<List<Cow>> GetBadCows()
    {
        using (IDbConnection connection = new SqliteConnection(connectionString))
        {
            var query = "SELECT * FROM Cows INNER JOIN Animals A on A.AnimalId = Cows.CowID WHERE A.Weight < 330 OR A.Weight > 430 AND Cows.MuscleType != 'good'";
            return (await connection.QueryAsync<Cow>(query)).ToList();
        }
    }

    public async Task<Cow> GetCowById(int cowId)
    {
        using (IDbConnection connection = new SqliteConnection(connectionString))
        {
            var query = "SELECT * FROM Cows WHERE CowID = @cowId";
            return (await connection.QueryAsync<Cow>(query, new { cowId })).FirstOrDefault();
        }
    }

    public async Task AddCow(Cow cow)
    {
        using (IDbConnection connection = new SqliteConnection(connectionString))
        {
            var query = "INSERT INTO Cows (CowID, MuscleType) VALUES (@cowId, @muscleType)";
            await connection.ExecuteAsync(query, new {cowId = cow.CowId, muscleType = cow.MuscleType});
        }
    }

    public async Task DeleteCow(int cowId)
    {
        using (IDbConnection connection = new SqliteConnection(connectionString))
        {
            var query = "DELETE FROM Cows WHERE CowID = @cowId";
            await connection.QueryAsync<Cow>(query, new { cowId });
        }
    }

    public async Task UpdateCow(Cow cow)
    {
        using (IDbConnection connection = new SqliteConnection(connectionString))
        {
            var query = "UPDATE Cows SET MuscleType = @muscleType WHERE CowID = @cowId";
            await connection.ExecuteAsync(query, new {cowId = cow.CowId, muscleType = cow.MuscleType});
        }
    }
}