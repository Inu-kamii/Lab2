using Microsoft.AspNetCore.Mvc;
using Persistance.Interfaces;

namespace API.Controllers;

public class TemperatureController : BaseController
{
    private ITemperatureService _service;

    public TemperatureController(ITemperatureService service)
    {
        this._service = service;
    }

    [HttpGet]
    [Route(nameof(GetAllTemperatures))]
    public async Task<ActionResult> GetAllTemperatures()
    {
        var result = await _service.GetAllData();
        return Ok(result);
    }

    [HttpPost]
    [Route(nameof(AddTemperature))]
    public async Task<ActionResult> AddTemperature(float temp, float hum)
    {
        await _service.InsertTemperature(temp, hum);
        return Ok();
    }
}