using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TicketsSoporte.Queries;

public record GetTicketSoporteByIdQuery(int Id) : IRequest<Domain.Entities.TicketsSoporte>;

internal sealed class GetTicketSoporteByIdQueryHandler : IRequestHandler<GetTicketSoporteByIdQuery, Domain.Entities.TicketsSoporte>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTicketSoporteByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.TicketsSoporte> Handle(GetTicketSoporteByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.TicketsSoporte>().GetByIdAsync(request.Id))!;
    }
}
