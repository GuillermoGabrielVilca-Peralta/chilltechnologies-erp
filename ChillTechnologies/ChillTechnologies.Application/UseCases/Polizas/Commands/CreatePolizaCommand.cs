using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Polizas.Commands;

public record CreatePolizaCommand : IRequest<int>
{
    public int AseguradoraId { get; set; }
    public int VehiculoId { get; set; }
    public string Numero { get; set; } = null!;
    public DateOnly FechaInicio { get; set; }
    public DateOnly FechaFin { get; set; }
    public decimal PrimaSoles { get; set; }
    public string? Cobertura { get; set; }
}

internal sealed class CreatePolizaCommandHandler : IRequestHandler<CreatePolizaCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePolizaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreatePolizaCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Poliza
        {
            AseguradoraId = request.AseguradoraId,
            VehiculoId = request.VehiculoId,
            Numero = request.Numero,
            FechaInicio = request.FechaInicio,
            FechaFin = request.FechaFin,
            PrimaSoles = request.PrimaSoles,
            Cobertura = request.Cobertura,
            Estado = "Vigente",
            FechaRegistro = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.Poliza>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
