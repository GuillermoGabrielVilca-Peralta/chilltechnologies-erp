using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.SeguimientosTicket.Queries;

public record GetHorasInvertidasByTicketQuery(int TicketId) : IRequest<decimal>;

internal sealed class GetHorasInvertidasByTicketQueryHandler : IRequestHandler<GetHorasInvertidasByTicketQuery, decimal>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetHorasInvertidasByTicketQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<decimal> Handle(GetHorasInvertidasByTicketQuery request, CancellationToken cancellationToken)
    {
        var seguimientos = await _unitOfWork.Repository<Domain.Entities.SeguimientosTicket>()
            .FindAsync(s => s.TicketId == request.TicketId);

        return seguimientos.Sum(s => s.HorasInvertidas);
    }
}
