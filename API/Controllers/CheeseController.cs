using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Persistance.Interfaces;

namespace API.Controllers;

public class CheeseController : BaseController
{
    private readonly ICheeseService _service;

    public CheeseController(ICheeseService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route(nameof(GetAllCheeses))]
    public async Task<ActionResult<IEnumerable<Cheese>>> GetAllCheeses()
    {
        var cheeses = await _service.GetAllCheeses();
        return Ok(cheeses);
    }

    [HttpGet]
    [Route(nameof(GetCheeseById))]
    public async Task<ActionResult<Cheese>> GetCheeseById(int cheeseId)
    {
        var cheese = await _service.GetCheeseById(cheeseId);
        if (cheese == null)
        {
            return NotFound();
        }
        return Ok(cheese);
    }

    [HttpPost]
    [Route(nameof(AddCheese))]
    public async Task<ActionResult> AddCheese([FromForm] Cheese cheese)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _service.AddCheese(cheese);
        return Ok();
    }

    [HttpPut]
    [Route(nameof(UpdateCheese))]
    public async Task<ActionResult> UpdateCheese([FromForm] Cheese cheese)
    {
        await _service.UpdateCheese(cheese);
        return Ok();
    }

    [HttpDelete]
    [Route(nameof(DeleteCheese))]
    public async Task<ActionResult> DeleteCheese(int cheeseId)
    {
        await _service.DeleteCheese(cheeseId);
        return Ok();
    }
}