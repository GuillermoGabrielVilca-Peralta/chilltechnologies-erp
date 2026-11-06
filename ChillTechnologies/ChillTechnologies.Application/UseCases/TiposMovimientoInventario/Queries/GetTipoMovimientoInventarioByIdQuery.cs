using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposMovimientoInventario.Queries;

public record GetTipoMovimientoInventarioByIdQuery(int Id) : IRequest<Domain.Entities.TiposMovimientoInventario>;

internal sealed class GetTipoMovimientoInventarioByIdQueryHandler : IRequestHandler<GetTipoMovimientoInventarioByIdQuery, Domain.Entities.TiposMovimientoInventario>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTipoMovimientoInventarioByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.TiposMovimientoInventario> Handle(GetTipoMovimientoInventarioByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.TiposMovimientoInventario>().GetByIdAsync(request.Id))!;
    }
}
