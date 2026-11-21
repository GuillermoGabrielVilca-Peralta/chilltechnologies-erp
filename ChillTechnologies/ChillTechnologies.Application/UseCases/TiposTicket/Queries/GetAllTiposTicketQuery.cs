using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposTicket.Queries;

public record GetAllTiposTicketQuery : IRequest<IEnumerable<Domain.Entities.TiposTicket>>;

internal sealed class GetAllTiposTicketQueryHandler : IRequestHandler<GetAllTiposTicketQuery, IEnumerable<Domain.Entities.TiposTicket>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTiposTicketQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.TiposTicket>> Handle(GetAllTiposTicketQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.TiposTicket>().GetAllAsync();
    }
}
