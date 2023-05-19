using Application.Queries;
using Domain;
using Domain.Dto;
using MediatR;
using Persistance.Interfaces;

namespace Application.Handlers;

public record GetGoodCheesesQueryHandler(ICheeseService Service)
    : IRequestHandler<GetGoodCheesesQuery, List<Cheese>>
{
    public async Task<List<Cheese>> Handle(GetGoodCheesesQuery request, CancellationToken cancellationToken)
    {
        var cheese = (await Service.GetAllCheeses()).Where(cheese => cheese.Fatness >= Constants.cheeseMinFatness
            && cheese.Moisture <= Constants.cheeseMaxMoisture 
            && cheese.Salt <= Constants.cheeseMaxSaltWR 
            && cheese.Hardness >= Constants.cheeseMinHardness 
            && cheese.Hardness <= Constants.cheeseMaxHardness);
        return cheese.ToList();
    }
}