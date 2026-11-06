using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.MovimientosInventario.Queries;

public record GetAllMovimientosInventarioQuery : IRequest<IEnumerable<Domain.Entities.MovimientosInventario>>;

internal sealed class GetAllMovimientosInventarioQueryHandler : IRequestHandler<GetAllMovimientosInventarioQuery, IEnumerable<Domain.Entities.MovimientosInventario>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllMovimientosInventarioQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.MovimientosInventario>> Handle(GetAllMovimientosInventarioQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.MovimientosInventario>().GetAllAsync();
    }
}
