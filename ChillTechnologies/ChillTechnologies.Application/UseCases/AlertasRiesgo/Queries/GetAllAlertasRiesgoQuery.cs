using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.AlertasRiesgo.Queries;

public record GetAllAlertasRiesgoQuery : IRequest<IEnumerable<Domain.Entities.AlertasRiesgo>>;

internal sealed class GetAllAlertasRiesgoQueryHandler : IRequestHandler<GetAllAlertasRiesgoQuery, IEnumerable<Domain.Entities.AlertasRiesgo>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAlertasRiesgoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.AlertasRiesgo>> Handle(GetAllAlertasRiesgoQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.AlertasRiesgo>().GetAllAsync();
    }
}
