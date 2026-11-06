using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.MovimientosInventario.Queries;

public record GetMovimientoInventarioByIdQuery(int Id) : IRequest<Domain.Entities.MovimientosInventario>;

internal sealed class GetMovimientoInventarioByIdQueryHandler : IRequestHandler<GetMovimientoInventarioByIdQuery, Domain.Entities.MovimientosInventario>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetMovimientoInventarioByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.MovimientosInventario> Handle(GetMovimientoInventarioByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.MovimientosInventario>().GetByIdAsync(request.Id))!;
    }
}
