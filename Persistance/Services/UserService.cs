using System.Data;
using Dapper;
using Domain;
using Domain.Dto;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Persistance.Interfaces;

namespace Persistance.Services;

public class UserService : IUserService
{
    private string connectionString;

    public UserService()
    {
        this.connectionString = Constants.connectionString;
    }
    
    public async Task DeleteUser(int userId)
    {
        using (IDbConnection connection = new SqliteConnection(connectionString))
        {
            var query = "DELETE FROM Users WHERE UserId = @userId";
            await connection.QueryAsync<User>(query, new { userId });
        }
    }

    public async Task<List<User>> GetAllUsers()
    {
        using (IDbConnection connection = new SqliteConnection(connectionString))
        {
            var query = "SELECT * FROM Users";
            return (await connection.QueryAsync<User>(query)).ToList();
        }
    }

    public async Task<User> GetUserById(int userId)
    {
        using (IDbConnection connection = new SqliteConnection(connectionString))
        {
            var query = "SELECT * FROM Users WHERE UserId = @userId";
            return (await connection.QueryAsync<User>(query, new { userId })).FirstOrDefault();
        }
    }

    public async Task<User> Login(string login, string password)
    {
        using (IDbConnection connection = new SqliteConnection(connectionString))
        {
            var query = "SELECT * FROM Users WHERE Login = @login AND Password = @password";
            return (await connection.QueryAsync<User>(query, new { login, password })).FirstOrDefault();
        }
    }

    public async Task Register(User user)
    {
        using (IDbConnection connection = new SqliteConnection(connectionString))
        {
            var query = "INSERT INTO Users (Login, Password, Email, Phone, Type) VALUES (@login, @password, @email, @phone, @type)";
            await connection.ExecuteAsync(query, new { login = user.Login, password = user.Password, email = user.Email, phone = user.Phone, type = user.Type });
        }
    }

    public async Task UpdateUser(User user)
    {
        using (IDbConnection connection = new SqliteConnection(connectionString))
        {
            var query = "UPDATE Users SET Login = @login, Password = @password, Email = @email, Phone = @phone, Type = @type WHERE UserId = @userId";
            await connection.ExecuteAsync(query, new { userId = user.UserId, login = user.Login, password = user.Password, email = user.Email, phone = user.Phone, type = user.Type });
        }
    }
}