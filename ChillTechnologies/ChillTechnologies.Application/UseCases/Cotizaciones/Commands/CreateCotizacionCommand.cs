using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Cotizaciones.Commands;

public record CreateCotizacionCommand : IRequest<int>
{
    public int ClienteId { get; set; }
    public string Numero { get; set; } = null!;
    public DateOnly FechaEmision { get; set; }
    public DateOnly? FechaValidez { get; set; }
    // Solo el subtotal
    public decimal Subtotal { get; set; }
    public int? EmpleadoId { get; set; }
    public string? Observaciones { get; set; }
}

internal sealed class CreateCotizacionCommandHandler : IRequestHandler<CreateCotizacionCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCotizacionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateCotizacionCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Cotizacione
        {
            ClienteId = request.ClienteId,
            Numero = request.Numero,
            FechaEmision = request.FechaEmision,
            FechaValidez = request.FechaValidez,
            Subtotal = request.Subtotal,
            Igv = Math.Round(request.Subtotal * 0.18m, 2),
            Total = request.Subtotal + Math.Round(request.Subtotal * 0.18m, 2),
            Estado = "Borrador",
            EmpleadoId = request.EmpleadoId,
            Observaciones = request.Observaciones,
            FechaRegistro = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.Cotizacione>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
