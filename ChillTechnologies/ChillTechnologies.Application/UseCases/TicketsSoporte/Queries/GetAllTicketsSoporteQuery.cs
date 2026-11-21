using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TicketsSoporte.Queries;

public record GetAllTicketsSoporteQuery : IRequest<IEnumerable<Domain.Entities.TicketsSoporte>>;

internal sealed class GetAllTicketsSoporteQueryHandler : IRequestHandler<GetAllTicketsSoporteQuery, IEnumerable<Domain.Entities.TicketsSoporte>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTicketsSoporteQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.TicketsSoporte>> Handle(GetAllTicketsSoporteQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.TicketsSoporte>().GetAllAsync();
    }
}
