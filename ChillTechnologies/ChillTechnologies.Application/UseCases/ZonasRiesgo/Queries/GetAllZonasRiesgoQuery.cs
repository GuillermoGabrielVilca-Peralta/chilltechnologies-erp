using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.ZonasRiesgo.Queries;

public record GetAllZonasRiesgoQuery : IRequest<IEnumerable<Domain.Entities.ZonasRiesgo>>;

internal sealed class GetAllZonasRiesgoQueryHandler : IRequestHandler<GetAllZonasRiesgoQuery, IEnumerable<Domain.Entities.ZonasRiesgo>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllZonasRiesgoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.ZonasRiesgo>> Handle(GetAllZonasRiesgoQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.ZonasRiesgo>().GetAllAsync();
    }
}
