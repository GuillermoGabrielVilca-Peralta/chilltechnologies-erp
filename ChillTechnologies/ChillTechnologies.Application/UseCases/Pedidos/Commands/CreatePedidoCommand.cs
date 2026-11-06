using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Pedidos.Commands;

public record CreatePedidoCommand : IRequest<int>
{
    public int ClienteId { get; set; }
    // Si nace de una cotizacion aceptada se deja la trazabilidad
    public int? CotizacionId { get; set; }
    public string Numero { get; set; } = null!;
    public DateOnly FechaPedido { get; set; }
    public DateOnly? FechaEntrega { get; set; }
    public decimal Subtotal { get; set; }
    public int? EmpleadoId { get; set; }
}

internal sealed class CreatePedidoCommandHandler : IRequestHandler<CreatePedidoCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePedidoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreatePedidoCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Pedido
        {
            ClienteId = request.ClienteId,
            CotizacionId = request.CotizacionId,
            Numero = request.Numero,
            FechaPedido = request.FechaPedido,
            FechaEntrega = request.FechaEntrega,
            Subtotal = request.Subtotal,
            Igv = Math.Round(request.Subtotal * 0.18m, 2),
            Total = request.Subtotal + Math.Round(request.Subtotal * 0.18m, 2),
            Estado = "Pendiente",
            EmpleadoId = request.EmpleadoId,
            FechaRegistro = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.Pedido>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
