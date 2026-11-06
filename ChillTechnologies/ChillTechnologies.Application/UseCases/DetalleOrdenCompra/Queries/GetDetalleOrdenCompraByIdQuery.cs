using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.DetalleOrdenCompra.Queries;

public record GetDetalleOrdenCompraByIdQuery(int Id) : IRequest<Domain.Entities.DetalleOrdenCompra>;

internal sealed class GetDetalleOrdenCompraByIdQueryHandler : IRequestHandler<GetDetalleOrdenCompraByIdQuery, Domain.Entities.DetalleOrdenCompra>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetDetalleOrdenCompraByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.DetalleOrdenCompra> Handle(GetDetalleOrdenCompraByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.DetalleOrdenCompra>().GetByIdAsync(request.Id))!;
    }
}
