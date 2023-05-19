using Domain.Dto;

namespace Persistance.Interfaces;

public interface IUserAnimalService
{
    Task<List<Animal>> GetAnimalIdsByUserId(int userId);
    Task<List<User>> GetUserIdsByAnimalId(int animalId);
    Task AddUserAnimal(int userId, int animalId);
    Task DeleteUserAnimal(int userId, int animalId);
}