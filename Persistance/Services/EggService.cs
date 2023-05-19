using System.Data;
using Dapper;
using Domain;
using Domain.Dto;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Persistance.Interfaces;

public class EggService : IEggService
{
    private string connectionString;

    public EggService()
    {
        this.connectionString = Constants.connectionString;
    }

    public async Task<List<Egg>> GetAllEggs()
    {
        using (IDbConnection connection = new SqliteConnection(connectionString))
        {
            var query = "SELECT * FROM Eggs";
            return (await connection.QueryAsync<Egg>(query)).ToList();
        }
    }

    public async Task<Egg> GetEggById(int eggId)
    {
        using (IDbConnection connection = new SqliteConnection(connectionString))
        {
            var query = "SELECT * FROM Eggs WHERE EggId = @eggId";
            return (await connection.QueryAsync<Egg>(query, new { eggId })).FirstOrDefault();
        }
    }

    public async Task AddEgg(Egg egg)
    {
        using (IDbConnection connection = new SqliteConnection(connectionString))
        {
            var query = "INSERT INTO Eggs (EggId, Mass, Size) VALUES (@eggId, @mass, @size)";
            await connection.ExecuteAsync(query, new { eggId = egg.EggId, mass = egg.Mass, size = egg.Size });
        }
    }

    public async Task DeleteEgg(int eggId)
    {
        using (IDbConnection connection = new SqliteConnection(connectionString))
        {
            var query = "DELETE FROM Eggs WHERE EggId = @eggId";
            await connection.ExecuteAsync(query, new { eggId });
        }
    }

    public async Task UpdateEgg(Egg egg)
    {
        using (IDbConnection connection = new SqliteConnection(connectionString))
        {
            var query = "UPDATE Eggs SET Mass = @mass, Size = @size WHERE EggId = @eggId";
            await connection.ExecuteAsync(query, new { eggId = egg.EggId, mass = egg.Mass, size = egg.Size });
        }
    }
}