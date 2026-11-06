using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.DetalleFactura.Commands;

public record CreateDetalleFacturaCommand : IRequest<int>
{
    public int FacturaId { get; set; }
    public int ProductoId { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
}

internal sealed class CreateDetalleFacturaCommandHandler : IRequestHandler<CreateDetalleFacturaCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateDetalleFacturaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateDetalleFacturaCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.DetalleFactura
        {
            FacturaId = request.FacturaId,
            ProductoId = request.ProductoId,
            Cantidad = request.Cantidad,
            PrecioUnitario = request.PrecioUnitario,
            Subtotal = request.Cantidad * request.PrecioUnitario
        };

        await _unitOfWork.Repository<Domain.Entities.DetalleFactura>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
