using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposTicket.Queries;

public record GetTipoTicketByIdQuery(int Id) : IRequest<Domain.Entities.TiposTicket>;

internal sealed class GetTipoTicketByIdQueryHandler : IRequestHandler<GetTipoTicketByIdQuery, Domain.Entities.TiposTicket>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTipoTicketByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.TiposTicket> Handle(GetTipoTicketByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.TiposTicket>().GetByIdAsync(request.Id))!;
    }
}
