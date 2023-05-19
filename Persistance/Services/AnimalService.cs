using System.Data;
using Dapper;
using Domain;
using Domain.Dto;
using Microsoft.Data.Sqlite;
using Persistance.Interfaces;

namespace Persistance.Services;

public class AnimalService : IAnimalService
{
    private string connectionString;

    public AnimalService()
    {
        this.connectionString = Constants.connectionString;
    }

    public async Task<List<Animal>> GetAllAnimals()
    {
        using (IDbConnection connection = new SqliteConnection(connectionString))
        {
            var query = "SELECT * FROM Animals";
            return (await connection.QueryAsync<Animal>(query)).ToList();
        }
    }

    public async Task<Animal> GetAnimalById(int animalId)
    {
        using (IDbConnection connection = new SqliteConnection(connectionString))
        {
            var query = "SELECT * FROM Animals WHERE AnimalId = @animalId";
            return (await connection.QueryAsync<Animal>(query, new { animalId })).FirstOrDefault();
        }
    }

    public async Task AddAnimal(Animal animal)
    {
        using (IDbConnection connection = new SqliteConnection(connectionString))
        {
            var query = "INSERT INTO Animals (Name, Weight, Age, Type) VALUES (@name, @weight, @age, @type)";
            await connection.ExecuteAsync(query, new {name = animal.Name, weight = animal.Weight, age = animal.Age, type = animal.Type});
        }
    }

    public async Task DeleteAnimal(int animalId)
    {
        using (IDbConnection connection = new SqliteConnection(connectionString))
        {
            var query = "DELETE FROM Animals WHERE AnimalId = @animalId";
            await connection.QueryAsync<User>(query, new { animalId });
        }
    }

    public async Task UpdateAnimal(Animal animal)
    {
        using (IDbConnection connection = new SqliteConnection(connectionString))
        {
            var query = "UPDATE Animals SET Name = @name, Weight = @weight, Age = @age, Type = @type WHERE AnimalId = @animalId";
            await connection.ExecuteAsync(query, new {animalId = animal.AnimalId, name = animal.Name, weight = animal.Weight, age = animal.Age, type = animal.Type});
        }
    }
}