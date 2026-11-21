using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Despliegues.Queries;

public record GetDesplieguesByAmbienteQuery(int AmbienteId) : IRequest<IEnumerable<Domain.Entities.Despliegue>>;

internal sealed class GetDesplieguesByAmbienteQueryHandler : IRequestHandler<GetDesplieguesByAmbienteQuery, IEnumerable<Domain.Entities.Despliegue>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetDesplieguesByAmbienteQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Despliegue>> Handle(GetDesplieguesByAmbienteQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Despliegue>()
            .FindAsync(d => d.AmbienteId == request.AmbienteId);
    }
}
