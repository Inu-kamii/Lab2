using Domain.Dto;
using MediatR;

namespace Application.Queries;

public record GetBadCheesesQuery()
    : IRequest<List<Cheese>>;