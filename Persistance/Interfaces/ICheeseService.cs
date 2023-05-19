using Domain.Dto;

namespace Persistance.Interfaces;

public interface ICheeseService
{
    Task<IEnumerable<Cheese>> GetAllCheeses();
    Task<Cheese> GetCheeseById(int cheeseId);
    Task AddCheese(Cheese cheese);
    Task DeleteCheese(int cheeseId);
    Task UpdateCheese(Cheese cheese);
}