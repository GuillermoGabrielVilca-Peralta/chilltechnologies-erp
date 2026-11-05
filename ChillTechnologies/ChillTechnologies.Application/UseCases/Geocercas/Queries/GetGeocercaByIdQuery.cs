using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Geocercas.Queries;

public record GetGeocercaByIdQuery(int Id) : IRequest<Domain.Entities.Geocerca>;

internal sealed class GetGeocercaByIdQueryHandler : IRequestHandler<GetGeocercaByIdQuery, Domain.Entities.Geocerca>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetGeocercaByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Geocerca> Handle(GetGeocercaByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.Geocerca>().GetByIdAsync(request.Id))!;
    }
}
