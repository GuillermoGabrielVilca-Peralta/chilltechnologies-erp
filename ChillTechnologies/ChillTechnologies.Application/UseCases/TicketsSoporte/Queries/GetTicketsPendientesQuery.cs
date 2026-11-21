using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TicketsSoporte.Queries;

public record GetTicketsPendientesQuery : IRequest<IEnumerable<Domain.Entities.TicketsSoporte>>;

internal sealed class GetTicketsPendientesQueryHandler : IRequestHandler<GetTicketsPendientesQuery, IEnumerable<Domain.Entities.TicketsSoporte>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTicketsPendientesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.TicketsSoporte>> Handle(GetTicketsPendientesQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.TicketsSoporte>()
            .FindAsync(t => t.Estado != "Resuelto" && t.Estado != "Cerrado");
    }
}
