using Domain.Dto;
using MediatR;

namespace Application.Queries;

public record GetGoodEggsQuery()
    : IRequest<List<Egg>>;