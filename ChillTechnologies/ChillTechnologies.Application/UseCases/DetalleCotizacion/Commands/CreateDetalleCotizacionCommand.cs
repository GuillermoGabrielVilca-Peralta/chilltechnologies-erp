using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.DetalleCotizacion.Commands;

public record CreateDetalleCotizacionCommand : IRequest<int>
{
    public int CotizacionId { get; set; }
    public int ProductoId { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
}

internal sealed class CreateDetalleCotizacionCommandHandler : IRequestHandler<CreateDetalleCotizacionCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateDetalleCotizacionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateDetalleCotizacionCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.DetalleCotizacion
        {
            CotizacionId = request.CotizacionId,
            ProductoId = request.ProductoId,
            Cantidad = request.Cantidad,
            PrecioUnitario = request.PrecioUnitario,
            // El subtotal de linea no lo manda el cliente
            Subtotal = request.Cantidad * request.PrecioUnitario
        };

        await _unitOfWork.Repository<Domain.Entities.DetalleCotizacion>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
