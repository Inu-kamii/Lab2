using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Persistance.Interfaces;

namespace API.Controllers;

public class EggController : BaseController
{
    private readonly IEggService _service;

    public EggController(IEggService service)
    {
        this._service = service;
    }

    [HttpGet]
    [Route(nameof(GetAllEggs))]
    public async Task<ActionResult> GetAllEggs()
    {
        var eggs = await _service.GetAllEggs();
        return Ok(eggs);
    }

    [HttpGet]
    [Route(nameof(GetEggById))]
    public async Task<ActionResult> GetEggById(int eggID)
    {
        var egg = await _service.GetEggById(eggID);
        return Ok(egg);
    }

    [HttpPost]
    [Route(nameof(AddEgg))]
    public async Task<ActionResult> AddEgg([FromForm] Egg egg)
    {
        await _service.AddEgg(egg);
        return Ok(egg);
    }

    [HttpPut]
    [Route(nameof(UpdateEgg))]
    public async Task<ActionResult> UpdateEgg([FromForm] Egg egg)
    {
        await _service.UpdateEgg(egg);
        return Ok(egg);
    }

    [HttpDelete]
    [Route(nameof(DeleteEgg))]
    public async Task<ActionResult> DeleteEgg(int eggId)
    {
        await _service.DeleteEgg(eggId);
        return Ok();
    }
}