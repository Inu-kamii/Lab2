using Application.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistance.Interfaces;

namespace API.Controllers;

public class LogicController : BaseController
{
    private IPigService _pigService;
    private ICowService _cowService;
    private IEggService _eggService;
    private ICheeseService _cheeseService;
    
    public LogicController(IPigService pigService, ICowService cowService, IEggService eggService, ICheeseService cheeseService)
    {
        _pigService = pigService;
        _cowService = cowService;
        _eggService = eggService;
        _cheeseService = cheeseService;
    }
    
    [HttpGet]
    [Route(nameof(GetGoodPigs))]
    public async Task<ActionResult> GetGoodPigs()
    {
        var pigs = await _pigService.GetGoodPigs();
        return Ok(pigs);
    }
    
    [HttpGet]
    [Route(nameof(GetBadPigs))]
    public async Task<ActionResult> GetBadPigs()
    {
        var pigs = await _pigService.GetBadPigs();
        return Ok(pigs);
    }

    [HttpGet]
    [Route(nameof(GetGoodCows))]
    public async Task<ActionResult> GetGoodCows()
    {
        var cows = await _cowService.GetGoodCows();
        return Ok(cows);
    }
    
    [HttpGet]
    [Route(nameof(GetBadCows))]
    public async Task<ActionResult> GetBadCows()
    {
        var cows = await _cowService.GetBadCows();
        return Ok(cows);
    }

    [HttpGet]
    [Route(nameof(GetGoodEggs))]
    public async Task<ActionResult> GetGoodEggs()
    {
        var eggs = (await _eggService.GetAllEggs()).Where(egg => 
            (egg.Mass >= Constants.eggXLMinSize && egg.Size == "XL") ||
             (egg.Mass >= Constants.eggLMinSize && egg.Mass <= Constants.eggLMaxSize && egg.Size == "L") || 
            (egg.Mass >= Constants.eggMMinSize && egg.Mass <= Constants.eggMMaxSize && egg.Size == "M") ||
            (egg.Mass >= Constants.eggSMinSize && egg.Mass <= Constants.eggSMaxSize && egg.Size == "S") || 
            (egg.Mass >= Constants.eggXSMinSize && egg.Mass <= Constants.eggXSMaxSize && egg.Size == "XL" )).ToList();
        return Ok(eggs);
    }

    [HttpGet]
    [Route(nameof(GetBadEggs))]
    public async Task<ActionResult> GetBadEggs()
    {
        var eggs = (await _eggService.GetAllEggs()).Where(egg => 
            !(egg.Mass >= Constants.eggXLMinSize && egg.Size == "XL") &&
            !(egg.Mass >= Constants.eggLMinSize && egg.Mass <= Constants.eggLMaxSize && egg.Size == "L") && 
            !(egg.Mass >= Constants.eggMMinSize && egg.Mass <= Constants.eggMMaxSize && egg.Size == "M") &&
            !(egg.Mass >= Constants.eggSMinSize && egg.Mass <= Constants.eggSMaxSize && egg.Size == "S") && 
            !(egg.Mass >= Constants.eggXSMinSize && egg.Mass <= Constants.eggXSMaxSize && egg.Size == "XL" )).ToList();
        return Ok(eggs);
    }

    [HttpGet]
    [Route(nameof(GetGoodCheeses))]
    public async Task<ActionResult> GetGoodCheeses()
    {
        var cheese = (await _cheeseService.GetAllCheeses()).Where(cheese => cheese.Fatness >= Constants.cheeseMinFatness
            && cheese.Moisture <= Constants.cheeseMaxMoisture 
            && cheese.Salt <= Constants.cheeseMaxSaltWR 
            && cheese.Hardness >= Constants.cheeseMinHardness 
            && cheese.Hardness <= Constants.cheeseMaxHardness);
        return Ok(cheese);
    }

    [HttpGet]
    [Route(nameof(GetBadCheeses))]
    public async Task<ActionResult> GetBadCheeses()
    {
        var cheese = (await _cheeseService.GetAllCheeses()).Where(cheese => cheese.Fatness < Constants.cheeseMinFatness
            || cheese.Moisture > Constants.cheeseMaxMoisture 
            || cheese.Salt > Constants.cheeseMaxSaltWR 
            || cheese.Hardness < Constants.cheeseMinHardness 
            || cheese.Hardness > Constants.cheeseMaxHardness);
        return Ok(cheese);
    }
}