using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Dto;

namespace Persistance.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(int productId);
        Task AddProduct(Product product);
        Task DeleteProduct(int productId);
        Task UpdateProduct(Product product);
    }
}