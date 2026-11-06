using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.DetalleOrdenCompra.Queries;

public record GetAllDetalleOrdenCompraQuery : IRequest<IEnumerable<Domain.Entities.DetalleOrdenCompra>>;

internal sealed class GetAllDetalleOrdenCompraQueryHandler : IRequestHandler<GetAllDetalleOrdenCompraQuery, IEnumerable<Domain.Entities.DetalleOrdenCompra>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllDetalleOrdenCompraQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.DetalleOrdenCompra>> Handle(GetAllDetalleOrdenCompraQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.DetalleOrdenCompra>().GetAllAsync();
    }
}
