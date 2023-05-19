using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Persistance.Interfaces;

namespace API.Controllers;

public class UserAnimalController : BaseController
{
    private readonly IUserAnimalService _service;

    public UserAnimalController(IUserAnimalService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route(nameof(GetAnimalsByUserId))]
    public async Task<ActionResult<IEnumerable<Animal>>> GetAnimalsByUserId(int userId)
    {
        var animals = await _service.GetAnimalIdsByUserId(userId);
        return Ok(animals);
    }

    [HttpGet]
    [Route(nameof(GetUsersByAnimalId))]
    public async Task<ActionResult<IEnumerable<User>>> GetUsersByAnimalId(int animalId)
    {
        var users = await _service.GetUserIdsByAnimalId(animalId);
        return Ok(users);
    }

    [HttpPost]
    [Route(nameof(AddUserAnimal))]
    public async Task<ActionResult> AddUserAnimal(int userId, int animalId)
    {
        await _service.AddUserAnimal(userId, animalId);
        return Ok();
    }

    [HttpDelete]
    [Route(nameof(DeleteUserAnimal))]
    public async Task<ActionResult> DeleteUserAnimal(int userId, int animalId)
    {
        await _service.DeleteUserAnimal(userId, animalId);
        return Ok();
    }
}