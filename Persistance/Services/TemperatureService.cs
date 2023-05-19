using System.Data;
using Dapper;
using Domain;
using Domain.Dto;
using Microsoft.Data.Sqlite;
using Persistance.Interfaces;

namespace Persistance.Services;

public class TemperatureService : ITemperatureService
{
    private string connectionString;

    public TemperatureService()
    {
        this.connectionString = Constants.connectionString;
    }
    
    public async Task<List<Temperatures>> GetAllData()
    {
        using (IDbConnection connection = new SqliteConnection(connectionString))
        {
            var query = "SELECT * FROM Temperatures";
            return (await connection.QueryAsync<Temperatures>(query)).ToList();
        }
    }

    public async Task InsertTemperature(float temp, float hum)
    {
        var date = DateTime.Now;
        using (IDbConnection connection = new SqliteConnection(connectionString))
        {
            var query = "INSERT INTO Temperatures (Date, Temperature, Humidity) VALUES (@date, @temp, @hum)";
            await connection.ExecuteAsync(query, new {date = date, temp = temp, hum = hum});
        }
    }
}