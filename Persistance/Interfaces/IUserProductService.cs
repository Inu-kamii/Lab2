using Domain.Dto;

namespace Persistance.Interfaces;

public interface IUserProductService
{
    Task<IEnumerable<Product>> GetProductsByUserId(int userId);
    Task<IEnumerable<User>> GetUsersByProductId(int productId);
    Task AddUserProduct(int userId, int productId);
    Task DeleteUserProduct(int userId, int productId);
}