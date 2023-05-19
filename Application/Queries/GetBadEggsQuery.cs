using Domain.Dto;
using MediatR;

namespace Application.Queries;

public record GetBadEggsQuery()
    : IRequest<List<Egg>>;