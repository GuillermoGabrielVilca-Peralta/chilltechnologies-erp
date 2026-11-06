using MediatR;
using ChillTechnologies.Application.Common;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.CuentasPorPagar.Commands;

public record CreateCuentaPorPagarCommand : IRequest<int>
{
    public int ProveedorId { get; set; }
    public int? OrdenCompraId { get; set; }
    public string NumeroDocumento { get; set; } = null!;
    public DateOnly FechaEmision { get; set; }
    public decimal Monto { get; set; }
}

internal sealed class CreateCuentaPorPagarCommandHandler : IRequestHandler<CreateCuentaPorPagarCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCuentaPorPagarCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateCuentaPorPagarCommand request, CancellationToken cancellationToken)
    {
        var proveedor = await _unitOfWork.Repository<Domain.Entities.Proveedore>()
            .GetByIdAsync(request.ProveedorId);

        var data = new Domain.Entities.CuentasPorPagar
        {
            ProveedorId = request.ProveedorId,
            OrdenCompraId = request.OrdenCompraId,
            NumeroDocumento = request.NumeroDocumento,
            FechaEmision = request.FechaEmision,
            // El vencimiento sale de la condicion de pago pactada con el proveedor
            FechaVencimiento = request.FechaEmision.AddDays(CondicionesPago.Dias(proveedor!.CondicionPago)),
            Monto = request.Monto,
            // Al nacer, el saldo es el monto completo
            Saldo = request.Monto,
            Estado = "Pendiente",
            FechaRegistro = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.CuentasPorPagar>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
