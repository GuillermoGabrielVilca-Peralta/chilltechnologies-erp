using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.SeguimientosTicket.Queries;

public record GetSeguimientosByTicketQuery(int TicketId) : IRequest<IEnumerable<Domain.Entities.SeguimientosTicket>>;

internal sealed class GetSeguimientosByTicketQueryHandler : IRequestHandler<GetSeguimientosByTicketQuery, IEnumerable<Domain.Entities.SeguimientosTicket>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSeguimientosByTicketQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.SeguimientosTicket>> Handle(GetSeguimientosByTicketQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.SeguimientosTicket>()
            .FindAsync(s => s.TicketId == request.TicketId);
    }
}
