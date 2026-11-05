using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.ZonasRiesgo.Queries;

public record GetZonaRiesgoByIdQuery(int Id) : IRequest<Domain.Entities.ZonasRiesgo>;

internal sealed class GetZonaRiesgoByIdQueryHandler : IRequestHandler<GetZonaRiesgoByIdQuery, Domain.Entities.ZonasRiesgo>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetZonaRiesgoByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.ZonasRiesgo> Handle(GetZonaRiesgoByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.ZonasRiesgo>().GetByIdAsync(request.Id))!;
    }
}
