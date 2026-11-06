using MediatR;
using ChillTechnologies.Application.Common;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Facturas.Commands;

public record CreateFacturaCommand : IRequest<int>
{
    public int ClienteId { get; set; }
    public int? PedidoId { get; set; }
    public string Serie { get; set; } = "F001";
    public string Numero { get; set; } = null!;
    //factura,boleta,nota de credito,nota de debito
    public string TipoComprobante { get; set; } = "Factura";
    public DateOnly FechaEmision { get; set; }
    // Solo el subtotal
    public decimal Subtotal { get; set; }
}

internal sealed class CreateFacturaCommandHandler : IRequestHandler<CreateFacturaCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateFacturaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateFacturaCommand request, CancellationToken cancellationToken)
    {
        var cliente = await _unitOfWork.Repository<Domain.Entities.Cliente>()
            .GetByIdAsync(request.ClienteId);

        var igv = Math.Round(request.Subtotal * 0.18m, 2);

        var data = new Domain.Entities.Factura
        {
            ClienteId = request.ClienteId,
            PedidoId = request.PedidoId,
            Serie = request.Serie,
            Numero = request.Numero,
            TipoComprobante = request.TipoComprobante,
            FechaEmision = request.FechaEmision,
            // El vencimiento sale de la condicion de pago pactada con el cliente
            FechaVencimiento = request.FechaEmision.AddDays(CondicionesPago.Dias(cliente!.CondicionPago)),
            Subtotal = request.Subtotal,
            Igv = igv,
            Total = request.Subtotal + igv,
            Estado = "Emitida",
            FechaRegistro = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.Factura>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
