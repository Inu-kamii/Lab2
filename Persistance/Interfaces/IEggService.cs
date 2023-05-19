using Domain.Dto;

namespace Persistance.Interfaces;

public interface IEggService
{
    Task<List<Egg>> GetAllEggs();
    Task<Egg> GetEggById(int eggId);
    Task AddEgg(Egg egg);
    Task DeleteEgg(int eggId);
    Task UpdateEgg(Egg egg);

}