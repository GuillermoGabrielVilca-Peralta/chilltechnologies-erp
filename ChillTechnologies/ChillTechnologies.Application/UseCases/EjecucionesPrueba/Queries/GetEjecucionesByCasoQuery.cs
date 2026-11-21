using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.EjecucionesPrueba.Queries;

public record GetEjecucionesByCasoQuery(int CasoPruebaId) : IRequest<IEnumerable<Domain.Entities.EjecucionesPrueba>>;

internal sealed class GetEjecucionesByCasoQueryHandler : IRequestHandler<GetEjecucionesByCasoQuery, IEnumerable<Domain.Entities.EjecucionesPrueba>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetEjecucionesByCasoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.EjecucionesPrueba>> Handle(GetEjecucionesByCasoQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.EjecucionesPrueba>()
            .FindAsync(e => e.CasoPruebaId == request.CasoPruebaId);
    }
}
