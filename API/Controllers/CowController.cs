using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Persistance.Interfaces;

namespace API.Controllers;

public class CowController : BaseController
{
    private readonly ICowService _service;

    public CowController(ICowService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route(nameof(GetAllCows))]
    public async Task<ActionResult> GetAllCows()
    {
        var cows = await _service.GetAllCows();
        return Ok(cows);
    }

    [HttpGet]
    [Route(nameof(GetCowById))]
    public async Task<ActionResult> GetCowById(int cowId)
    {
        var cow = await _service.GetCowById(cowId);
        return Ok(cow);
    }

    [HttpPost]
    [Route(nameof(AddCow))]
    public async Task<ActionResult> AddCow(int cowId, string muscleType)
    {
        await _service.AddCow(new Cow() {CowId = cowId, MuscleType = muscleType});
        return Ok();
    }

    [HttpPut]
    [Route(nameof(UpdateCow))]
    public async Task<ActionResult> UpdateCow(int cowId, string muscleType)
    {
        await _service.UpdateCow(new Cow() { CowId = cowId, MuscleType = muscleType });
        return Ok();
    }

    [HttpDelete]
    [Route(nameof(DeleteCow))]
    public async Task<ActionResult> DeleteCow(int cowId)
    {
        await _service.DeleteCow(cowId);
        return Ok();
    }
}