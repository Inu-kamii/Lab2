using Domain.Dto;

namespace Persistance.Interfaces;

public interface IUserService
{
    Task<List<User>> GetAllUsers();
    Task<User> GetUserById(int userId);
    Task Register(User user);
    Task<User> Login(string login, string password);
    Task DeleteUser(int userId);
    Task UpdateUser(User user);
}