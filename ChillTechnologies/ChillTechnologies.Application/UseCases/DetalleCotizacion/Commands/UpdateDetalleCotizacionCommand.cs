using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.DetalleCotizacion.Commands;

public record UpdateDetalleCotizacionCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
}

internal sealed class UpdateDetalleCotizacionCommandHandler : IRequestHandler<UpdateDetalleCotizacionCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateDetalleCotizacionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateDetalleCotizacionCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.DetalleCotizacion>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Cantidad = request.Cantidad;
        item.PrecioUnitario = request.PrecioUnitario;
        item.Subtotal = request.Cantidad * request.PrecioUnitario;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
