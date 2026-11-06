using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.OrdenesCompra.Commands;

public record CreateOrdenCompraCommand : IRequest<int>
{
    public int ProveedorId { get; set; }
    public string Numero { get; set; } = null!;
    public DateOnly FechaEmision { get; set; }
    public DateOnly? FechaEntregaEstimada { get; set; }
    // Solo el subtotal ya q el IGV y el total los calcula el handler
    public decimal Subtotal { get; set; }
    public int? EmpleadoId { get; set; }
    public string? Observaciones { get; set; }
}

internal sealed class CreateOrdenCompraCommandHandler : IRequestHandler<CreateOrdenCompraCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateOrdenCompraCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateOrdenCompraCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.OrdenesCompra
        {
            ProveedorId = request.ProveedorId,
            Numero = request.Numero,
            FechaEmision = request.FechaEmision,
            FechaEntregaEstimada = request.FechaEntregaEstimada,
            Subtotal = request.Subtotal,
            Igv = Math.Round(request.Subtotal * 0.18m, 2),
            Total = request.Subtotal + Math.Round(request.Subtotal * 0.18m, 2),
            Estado = "Borrador",
            EmpleadoId = request.EmpleadoId,
            Observaciones = request.Observaciones,
            FechaRegistro = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.OrdenesCompra>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
