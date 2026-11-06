using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.DetalleFactura.Commands;

public record UpdateDetalleFacturaCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
}

internal sealed class UpdateDetalleFacturaCommandHandler : IRequestHandler<UpdateDetalleFacturaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateDetalleFacturaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateDetalleFacturaCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.DetalleFactura>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Cantidad = request.Cantidad;
        item.PrecioUnitario = request.PrecioUnitario;
        item.Subtotal = request.Cantidad * request.PrecioUnitario;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
