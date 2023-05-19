using Application.Queries;
using Domain;
using Domain.Dto;
using MediatR;
using Persistance.Interfaces;

namespace Application.Handlers;

public record GetBadCheesesQueryHandler(ICheeseService Service)
    : IRequestHandler<GetBadCheesesQuery, List<Cheese>>
{
    public async Task<List<Cheese>> Handle(GetBadCheesesQuery request, CancellationToken cancellationToken)
    {
        var cheese = (await Service.GetAllCheeses()).Where(cheese => cheese.Fatness < Constants.cheeseMinFatness
            || cheese.Moisture > Constants.cheeseMaxMoisture 
            || cheese.Salt > Constants.cheeseMaxSaltWR 
            || cheese.Hardness < Constants.cheeseMinHardness 
            || cheese.Hardness > Constants.cheeseMaxHardness);
        return cheese.ToList();
    }
}