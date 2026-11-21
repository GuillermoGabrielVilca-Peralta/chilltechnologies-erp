using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.EjecucionesPrueba.Queries;

public record GetAllEjecucionesPruebaQuery : IRequest<IEnumerable<Domain.Entities.EjecucionesPrueba>>;

internal sealed class GetAllEjecucionesPruebaQueryHandler : IRequestHandler<GetAllEjecucionesPruebaQuery, IEnumerable<Domain.Entities.EjecucionesPrueba>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllEjecucionesPruebaQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.EjecucionesPrueba>> Handle(GetAllEjecucionesPruebaQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.EjecucionesPrueba>().GetAllAsync();
    }
}
