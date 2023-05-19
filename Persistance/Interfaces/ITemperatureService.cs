using Domain.Dto;

namespace Persistance.Interfaces;

public interface ITemperatureService
{
    Task<List<Temperatures>> GetAllData();
    Task InsertTemperature(float temp, float hum);
}