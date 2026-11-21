using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Despliegues.Queries;

public record GetDesplieguesByVersionQuery(int VersionId) : IRequest<IEnumerable<Domain.Entities.Despliegue>>;

internal sealed class GetDesplieguesByVersionQueryHandler : IRequestHandler<GetDesplieguesByVersionQuery, IEnumerable<Domain.Entities.Despliegue>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetDesplieguesByVersionQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Despliegue>> Handle(GetDesplieguesByVersionQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Despliegue>()
            .FindAsync(d => d.VersionId == request.VersionId);
    }
}
