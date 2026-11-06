using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.DetalleOrdenCompra.Commands;

public record UpdateDetalleOrdenCompraCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
}

internal sealed class UpdateDetalleOrdenCompraCommandHandler : IRequestHandler<UpdateDetalleOrdenCompraCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateDetalleOrdenCompraCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateDetalleOrdenCompraCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.DetalleOrdenCompra>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Cantidad = request.Cantidad;
        item.PrecioUnitario = request.PrecioUnitario;
        item.Subtotal = request.Cantidad * request.PrecioUnitario;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
