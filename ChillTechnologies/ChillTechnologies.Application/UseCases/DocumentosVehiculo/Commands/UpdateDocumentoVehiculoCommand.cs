using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.DocumentosVehiculo.Commands;

public record UpdateDocumentoVehiculoCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public int TipoDocumentoId { get; set; }
    public string? Numero { get; set; }
    public DateOnly? FechaEmision { get; set; }
    public DateOnly FechaVencimiento { get; set; }
    public string? Archivo { get; set; }
    // Vigente, Por Vencer o Vencido
    public string Estado { get; set; } = null!;
}

internal sealed class UpdateDocumentoVehiculoCommandHandler : IRequestHandler<UpdateDocumentoVehiculoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateDocumentoVehiculoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateDocumentoVehiculoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.DocumentosVehiculo>();

        var documento = await repo.GetByIdAsync(request.Id);

        documento!.TipoDocumentoId = request.TipoDocumentoId;
        documento.Numero = request.Numero;
        documento.FechaEmision = request.FechaEmision;
        documento.FechaVencimiento = request.FechaVencimiento;
        documento.Archivo = request.Archivo;
        documento.Estado = request.Estado;

        repo.Update(documento);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
