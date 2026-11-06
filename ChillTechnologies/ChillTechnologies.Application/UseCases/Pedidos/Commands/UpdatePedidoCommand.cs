using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Pedidos.Commands;

public record UpdatePedidoCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public DateOnly FechaPedido { get; set; }
    public DateOnly? FechaEntrega { get; set; }
    public decimal Subtotal { get; set; }
    //pendiente,confirmado,despachado,entregado,anulado
    public string Estado { get; set; } = null!;
}

internal sealed class UpdatePedidoCommandHandler : IRequestHandler<UpdatePedidoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePedidoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdatePedidoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Pedido>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.FechaPedido = request.FechaPedido;
        item.Subtotal = request.Subtotal;
        item.Igv = Math.Round(request.Subtotal * 0.18m, 2);
        item.Total = request.Subtotal + item.Igv;
        item.Estado = request.Estado;
        // Al marcarlo entregado se sella la fecha o la programada se respeta
        item.FechaEntrega = request.Estado == "Entregado"
            ? DateOnly.FromDateTime(DateTime.Now)
            : request.FechaEntrega;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
