using Application.Queries;
using Domain;
using Domain.Dto;
using MediatR;
using Persistance.Interfaces;

namespace Application.Handlers;

public record GetGoodEggsQueryHandler(IEggService Service) 
    : IRequestHandler<GetGoodEggsQuery, List<Egg>>
{
    public async Task<List<Egg>> Handle(GetGoodEggsQuery request, CancellationToken cancellationToken)
    {
        var eggs = (await Service.GetAllEggs()).Where(egg => 
            (egg.Mass >= Constants.eggXLMinSize && egg.Size == "XL") ||
             (egg.Mass >= Constants.eggLMinSize && egg.Mass <= Constants.eggLMaxSize && egg.Size == "L") || 
            (egg.Mass >= Constants.eggMMinSize && egg.Mass <= Constants.eggMMaxSize && egg.Size == "M") ||
            (egg.Mass >= Constants.eggSMinSize && egg.Mass <= Constants.eggSMaxSize && egg.Size == "S") || 
            (egg.Mass >= Constants.eggXSMinSize && egg.Mass <= Constants.eggXSMaxSize && egg.Size == "XL" )).ToList();
        return eggs;
    }
}