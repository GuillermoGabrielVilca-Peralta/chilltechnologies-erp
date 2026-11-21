using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.SeguimientosTicket.Queries;

public record GetSeguimientosVisiblesByTicketQuery(int TicketId) : IRequest<IEnumerable<Domain.Entities.SeguimientosTicket>>;

internal sealed class GetSeguimientosVisiblesByTicketQueryHandler : IRequestHandler<GetSeguimientosVisiblesByTicketQuery, IEnumerable<Domain.Entities.SeguimientosTicket>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSeguimientosVisiblesByTicketQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.SeguimientosTicket>> Handle(GetSeguimientosVisiblesByTicketQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.SeguimientosTicket>()
            .FindAsync(s => s.TicketId == request.TicketId && s.VisibleCliente);
    }
}
