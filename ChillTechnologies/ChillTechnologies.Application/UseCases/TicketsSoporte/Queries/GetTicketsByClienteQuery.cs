using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TicketsSoporte.Queries;

public record GetTicketsByClienteQuery(int ClienteId) : IRequest<IEnumerable<Domain.Entities.TicketsSoporte>>;

internal sealed class GetTicketsByClienteQueryHandler : IRequestHandler<GetTicketsByClienteQuery, IEnumerable<Domain.Entities.TicketsSoporte>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTicketsByClienteQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.TicketsSoporte>> Handle(GetTicketsByClienteQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.TicketsSoporte>()
            .FindAsync(t => t.ClienteId == request.ClienteId);
    }
}
