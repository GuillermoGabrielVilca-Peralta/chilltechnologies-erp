using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.DetalleOrdenCompra.Commands;

public record CreateDetalleOrdenCompraCommand : IRequest<int>
{
    public int OrdenCompraId { get; set; }
    public int ProductoId { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
}

internal sealed class CreateDetalleOrdenCompraCommandHandler : IRequestHandler<CreateDetalleOrdenCompraCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateDetalleOrdenCompraCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateDetalleOrdenCompraCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.DetalleOrdenCompra
        {
            OrdenCompraId = request.OrdenCompraId,
            ProductoId = request.ProductoId,
            Cantidad = request.Cantidad,
            PrecioUnitario = request.PrecioUnitario,
            // El subtotal de linea no lo manda el cliente
            Subtotal = request.Cantidad * request.PrecioUnitario
        };

        await _unitOfWork.Repository<Domain.Entities.DetalleOrdenCompra>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
