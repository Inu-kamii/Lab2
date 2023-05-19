using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Dto;

namespace Persistance.Interfaces
{
    public interface IPigService
    {
        Task<List<Pig>> GetAllPigs();
        Task<List<Pig>> GetGoodPigs();
        Task<List<Pig>> GetBadPigs();
        Task<Pig> GetPigById(int pigId);
        Task AddPig(Pig pig);
        Task DeletePig(int pigId);
        Task UpdatePig(Pig pig);
    }
}