using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Geocercas.Queries;

public record GetAllGeocercasQuery : IRequest<IEnumerable<Domain.Entities.Geocerca>>;

internal sealed class GetAllGeocercasQueryHandler : IRequestHandler<GetAllGeocercasQuery, IEnumerable<Domain.Entities.Geocerca>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllGeocercasQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Geocerca>> Handle(GetAllGeocercasQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Geocerca>().GetAllAsync();
    }
}
