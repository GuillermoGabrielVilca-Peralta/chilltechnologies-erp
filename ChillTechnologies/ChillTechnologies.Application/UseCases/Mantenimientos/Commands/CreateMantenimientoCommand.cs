using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Mantenimientos.Commands;

public record CreateMantenimientoCommand : IRequest<int>
{
    public int VehiculoId { get; set; }
    public int TipoMantenimientoId { get; set; }
    public DateOnly? FechaProgramada { get; set; }
    public int? Kilometraje { get; set; }
    public string? Taller { get; set; }
    public string? Observaciones { get; set; }
}

internal sealed class CreateMantenimientoCommandHandler : IRequestHandler<CreateMantenimientoCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateMantenimientoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateMantenimientoCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Mantenimiento
        {
            VehiculoId = request.VehiculoId,
            TipoMantenimientoId = request.TipoMantenimientoId,
            FechaProgramada = request.FechaProgramada,
            Kilometraje = request.Kilometraje,
            Taller = request.Taller,
            Observaciones = request.Observaciones,
            Estado = "Programado",
            FechaRegistro = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.Mantenimiento>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
