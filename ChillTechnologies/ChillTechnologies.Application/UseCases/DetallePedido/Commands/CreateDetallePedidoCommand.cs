using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.DetallePedido.Commands;

public record CreateDetallePedidoCommand : IRequest<int>
{
    public int PedidoId { get; set; }
    public int ProductoId { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
}

internal sealed class CreateDetallePedidoCommandHandler : IRequestHandler<CreateDetallePedidoCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateDetallePedidoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateDetallePedidoCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.DetallePedido
        {
            PedidoId = request.PedidoId,
            ProductoId = request.ProductoId,
            Cantidad = request.Cantidad,
            PrecioUnitario = request.PrecioUnitario,
            Subtotal = request.Cantidad * request.PrecioUnitario
        };

        await _unitOfWork.Repository<Domain.Entities.DetallePedido>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
