using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Persistance.Interfaces;
using Domain;
using Domain.Dto;
using Microsoft.Data.Sqlite;

namespace Persistance.Services
{
    public class ProductService : IProductService
    {
        private readonly string _connectionString;

        public ProductService()
        {
            this._connectionString = Constants.connectionString;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            using (IDbConnection connection = new SqliteConnection(_connectionString))
            {
                var query = "SELECT * FROM Products";
                return (await connection.QueryAsync<Product>(query)).ToList();
            }
        }

        public async Task<Product> GetProductById(int productId)
        {
            using (IDbConnection connection = new SqliteConnection(_connectionString))
            {
                var query = "SELECT * FROM Products WHERE ProductId = @productId";
                return (await connection.QueryAsync<Product>(query, new { productId })).FirstOrDefault();
            }
        }

        public async Task AddProduct(Product product)
        {
            using (IDbConnection connection = new SqliteConnection(_connectionString))
            {
                var query = "INSERT INTO Products (ExpirationDate) VALUES (@expirationDate)";
                await connection.ExecuteAsync(query, new { expirationDate = product.ExpirationDate });
            }
        }

        public async Task DeleteProduct(int productId)
        {
            using (IDbConnection connection = new SqliteConnection(_connectionString))
            {
                var query = "DELETE FROM Products WHERE ProductId = @productId";
                await connection.ExecuteAsync(query, new { productId });
            }
        }

        public async Task UpdateProduct(Product product)
        {
            using (IDbConnection connection = new SqliteConnection(_connectionString))
            {
                var query = "UPDATE Products SET ExpirationDate = @expirationDate WHERE ProductId = @productId";
                await connection.ExecuteAsync(query, new { productId = product.ProductId, expirationDate = product.ExpirationDate });
            }
        }
    }
}
