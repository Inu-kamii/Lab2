using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Persistance.Interfaces;

namespace API.Controllers;

public class AnimalController : BaseController
{
    private IAnimalService _service;

    public AnimalController(IAnimalService service)
    {
        this._service = service;
    }
    
    [HttpGet]
    [Route(nameof(GetAllAnimals))]
    public async Task<ActionResult> GetAllAnimals()
    {
        var animals = await _service.GetAllAnimals();
        return Ok(animals);
    }
    
    [HttpGet]
    [Route(nameof(GetAnimalById))]
    public async Task<ActionResult> GetAnimalById(int animalId)
    {
        var animal = await _service.GetAnimalById(animalId);
        return Ok(animal);
    }
    
    [HttpPost]
    [Route(nameof(AddAnimal))]
    public async Task<ActionResult> AddAnimal(string name, int weight, int age, string type)
    {
        await _service.AddAnimal(new Animal() {Age = age, Name = name, Type = type, Weight = weight});
        return Ok();
    }

    [HttpPut]
    [Route(nameof(UpdateAnimal))]
    public async Task<ActionResult> UpdateAnimal(int animalId, string name, int weight, int age, string type)
    {
        await _service.UpdateAnimal(new Animal() {Age = age, AnimalId = animalId, Name = name, Type = type, Weight = weight} );
        return Ok();
    }

    [HttpDelete]
    [Route(nameof(DeleteAnimal))]
    public async Task<ActionResult> DeleteAnimal(int animalId)
    {
        await _service.DeleteAnimal(animalId);
        return Ok();
    }
}