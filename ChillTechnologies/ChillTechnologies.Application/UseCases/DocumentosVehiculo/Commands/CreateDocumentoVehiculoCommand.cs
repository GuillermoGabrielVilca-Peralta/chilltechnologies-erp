using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.DocumentosVehiculo.Commands;

public record CreateDocumentoVehiculoCommand : IRequest<int>
{
    public int VehiculoId { get; set; }
    public int TipoDocumentoId { get; set; }
    public string? Numero { get; set; }
    public DateOnly? FechaEmision { get; set; }
    public DateOnly FechaVencimiento { get; set; }
    public string? Archivo { get; set; }
}

internal sealed class CreateDocumentoVehiculoCommandHandler : IRequestHandler<CreateDocumentoVehiculoCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateDocumentoVehiculoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateDocumentoVehiculoCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.DocumentosVehiculo
        {
            VehiculoId = request.VehiculoId,
            TipoDocumentoId = request.TipoDocumentoId,
            Numero = request.Numero,
            FechaEmision = request.FechaEmision,
            FechaVencimiento = request.FechaVencimiento,
            Archivo = request.Archivo,
            Estado = request.FechaVencimiento < DateOnly.FromDateTime(DateTime.Now) ? "Vencido" : "Vigente",
            FechaRegistro = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.DocumentosVehiculo>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
