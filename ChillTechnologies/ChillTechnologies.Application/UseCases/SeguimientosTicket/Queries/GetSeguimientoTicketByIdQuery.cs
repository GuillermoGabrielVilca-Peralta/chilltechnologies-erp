using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.SeguimientosTicket.Queries;

public record GetSeguimientoTicketByIdQuery(int Id) : IRequest<Domain.Entities.SeguimientosTicket>;

internal sealed class GetSeguimientoTicketByIdQueryHandler : IRequestHandler<GetSeguimientoTicketByIdQuery, Domain.Entities.SeguimientosTicket>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSeguimientoTicketByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.SeguimientosTicket> Handle(GetSeguimientoTicketByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.SeguimientosTicket>().GetByIdAsync(request.Id))!;
    }
}
