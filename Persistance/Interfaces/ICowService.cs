using Domain.Dto;

namespace Persistance.Interfaces
{
    public interface ICowService
    {
        Task<List<Cow>> GetAllCows();
        Task<List<Cow>> GetGoodCows();
        Task<List<Cow>> GetBadCows();
        Task<Cow> GetCowById(int cowId);
        Task AddCow(Cow cow);
        Task DeleteCow(int cowId);
        Task UpdateCow(Cow cow);
    }
}