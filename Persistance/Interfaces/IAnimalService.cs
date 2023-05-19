using Domain.Dto;

namespace Persistance.Interfaces;

public interface IAnimalService
{
    Task<List<Animal>> GetAllAnimals();
    Task<Animal> GetAnimalById(int animalId);
    Task AddAnimal (Animal animal);
    Task DeleteAnimal(int animalId);
    Task UpdateAnimal(Animal animal);
}