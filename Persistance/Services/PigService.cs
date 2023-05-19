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

namespace Persistance.Services
{
    public class PigService : IPigService
    {
        private string connectionString;

        public PigService()
        {
            this.connectionString = Constants.connectionString;
        }

        public async Task<List<Pig>> GetAllPigs()
        {
            using (IDbConnection connection = new SqliteConnection(connectionString))
            {
                var query = "SELECT * FROM Pigs";
                return (await connection.QueryAsync<Pig>(query)).ToList();
            }
        }

        public async Task<List<Pig>> GetGoodPigs()
        {
            using (IDbConnection connection = new SqliteConnection(connectionString))
            {
                var query = "SELECT * FROM Pigs INNER JOIN Animals A on A.AnimalId = Pigs.PigId WHERE A.Weight < 150 AND A.Weight > 70 AND Pigs.FatLength > 1";
                return (await connection.QueryAsync<Pig>(query)).ToList();
            }
        }
        
        public async Task<List<Pig>> GetBadPigs()
        {
            using (IDbConnection connection = new SqliteConnection(connectionString))
            {
                var query = "SELECT * FROM Pigs INNER JOIN Animals A on A.AnimalId = Pigs.PigId WHERE A.Weight > 150 OR A.Weight < 70 OR Pigs.FatLength < 1";
                return (await connection.QueryAsync<Pig>(query)).ToList();
            }
        }

        public async Task<Pig> GetPigById(int pigId)
        {
            using (IDbConnection connection = new SqliteConnection(connectionString))
            {
                var query = "SELECT * FROM Pigs WHERE PigId = @pigId";
                return (await connection.QueryAsync<Pig>(query, new { pigId })).FirstOrDefault();
            }
        }

        public async Task AddPig(Pig pig)
        {
            using (IDbConnection connection = new SqliteConnection(connectionString))
            {
                var query = "INSERT INTO Pigs (PigId, FatLength) VALUES (@pigId, @fatLength)";
                await connection.ExecuteAsync(query, new { pigId = pig.PigId, fatLength = pig.FatLength });
            }
        }

        public async Task DeletePig(int pigId)
        {
            using (IDbConnection connection = new SqliteConnection(connectionString))
            {
                var query = "DELETE FROM Pigs WHERE PigId = @pigId";
                await connection.QueryAsync<Pig>(query, new { pigId });
            }
        }

        public async Task UpdatePig(Pig pig)
        {
            using (IDbConnection connection = new SqliteConnection(connectionString))
            {
                var query = "UPDATE Pigs SET FatLength = @fatLength WHERE PigId = @pigId";
                await connection.ExecuteAsync(query, new { pigId = pig.PigId, fatLength = pig.FatLength });
            }
        }
    }
}
