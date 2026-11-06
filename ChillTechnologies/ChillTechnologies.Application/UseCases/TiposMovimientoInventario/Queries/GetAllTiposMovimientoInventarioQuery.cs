using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposMovimientoInventario.Queries;

public record GetAllTiposMovimientoInventarioQuery : IRequest<IEnumerable<Domain.Entities.TiposMovimientoInventario>>;

internal sealed class GetAllTiposMovimientoInventarioQueryHandler : IRequestHandler<GetAllTiposMovimientoInventarioQuery, IEnumerable<Domain.Entities.TiposMovimientoInventario>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTiposMovimientoInventarioQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.TiposMovimientoInventario>> Handle(GetAllTiposMovimientoInventarioQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.TiposMovimientoInventario>().GetAllAsync();
    }
}
