using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.OrdenesCompra.Commands;

public record UpdateOrdenCompraCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public DateOnly FechaEmision { get; set; }
    public DateOnly? FechaEntregaEstimada { get; set; }
    public decimal Subtotal { get; set; }
    // Borrador,enviada,arobada,recibida,anulada
    public string Estado { get; set; } = null!;
    public string? Observaciones { get; set; }
}

internal sealed class UpdateOrdenCompraCommandHandler : IRequestHandler<UpdateOrdenCompraCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateOrdenCompraCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateOrdenCompraCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.OrdenesCompra>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.FechaEmision = request.FechaEmision;
        item.FechaEntregaEstimada = request.FechaEntregaEstimada;
        item.Subtotal = request.Subtotal;
        item.Igv = Math.Round(request.Subtotal * 0.18m, 2);
        item.Total = request.Subtotal + item.Igv;
        item.Estado = request.Estado;
        item.Observaciones = request.Observaciones;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
