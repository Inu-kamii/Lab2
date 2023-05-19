using Domain.Dto;
using MediatR;

namespace Application.Queries;

public record GetGoodCheesesQuery()
    : IRequest<List<Cheese>>;