using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.EjecucionesPrueba.Queries;

public record GetEjecucionesByVersionQuery(int VersionId) : IRequest<IEnumerable<Domain.Entities.EjecucionesPrueba>>;

internal sealed class GetEjecucionesByVersionQueryHandler : IRequestHandler<GetEjecucionesByVersionQuery, IEnumerable<Domain.Entities.EjecucionesPrueba>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetEjecucionesByVersionQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.EjecucionesPrueba>> Handle(GetEjecucionesByVersionQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.EjecucionesPrueba>()
            .FindAsync(e => e.VersionId == request.VersionId);
    }
}
