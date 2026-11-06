using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.DetallePedido.Commands;

public record UpdateDetallePedidoCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
}

internal sealed class UpdateDetallePedidoCommandHandler : IRequestHandler<UpdateDetallePedidoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateDetallePedidoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateDetallePedidoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.DetallePedido>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Cantidad = request.Cantidad;
        item.PrecioUnitario = request.PrecioUnitario;
        item.Subtotal = request.Cantidad * request.PrecioUnitario;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
