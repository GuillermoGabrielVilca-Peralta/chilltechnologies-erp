using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Cotizaciones.Commands;

public record UpdateCotizacionCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public DateOnly FechaEmision { get; set; }
    public DateOnly? FechaValidez { get; set; }
    public decimal Subtotal { get; set; }
    //borrador,enviada,aceptada,rechazada,vencida
    public string Estado { get; set; } = null!;
    public string? Observaciones { get; set; }
}

internal sealed class UpdateCotizacionCommandHandler : IRequestHandler<UpdateCotizacionCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCotizacionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateCotizacionCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Cotizacione>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.FechaEmision = request.FechaEmision;
        item.FechaValidez = request.FechaValidez;
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
