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
    public class UserProductService : IUserProductService
    {
        private readonly string connectionString;

        public UserProductService()
        {
            this.connectionString = Constants.connectionString;
        }

        public async Task<IEnumerable<Product>> GetProductsByUserId(int userId)
        {
            using (IDbConnection connection = new SqliteConnection(connectionString))
            {
                var query = @"SELECT p.* 
                              FROM Products p
                              JOIN UserProduct up ON p.ProductId = up.ProductId
                              WHERE up.UserId = @userId";
                return await connection.QueryAsync<Product>(query, new { userId });
            }
        }

        public async Task<IEnumerable<User>> GetUsersByProductId(int productId)
        {
            using (IDbConnection connection = new SqliteConnection(connectionString))
            {
                var query = @"SELECT u.* 
                              FROM Users u
                              JOIN UserProduct up ON u.UserId = up.UserId
                              WHERE up.ProductId = @productId";
                return await connection.QueryAsync<User>(query, new { productId });
            }
        }

        public async Task AddUserProduct(int userId, int productId)
        {
            using (IDbConnection connection = new SqliteConnection(connectionString))
            {
                var query = "INSERT INTO UserProduct (UserId, ProductId) VALUES (@userId, @productId)";
                await connection.ExecuteAsync(query, new { userId, productId });
            }
        }

        public async Task DeleteUserProduct(int userId, int productId)
        {
            using (IDbConnection connection = new SqliteConnection(connectionString))
            {
                var query = "DELETE FROM UserProduct WHERE UserId = @userId AND ProductId = @productId";
                await connection.ExecuteAsync(query, new { userId, productId });
            }
        }
    }
}
