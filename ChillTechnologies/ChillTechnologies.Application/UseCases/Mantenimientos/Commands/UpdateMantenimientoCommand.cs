using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Mantenimientos.Commands;

public record UpdateMantenimientoCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public int TipoMantenimientoId { get; set; }
    public DateOnly? FechaProgramada { get; set; }
    public int? Kilometraje { get; set; }
    public decimal? CostoSoles { get; set; }
    public string? Taller { get; set; }
    public string? Observaciones { get; set; }
    // Programado, Realizado, Vencido o Cancelado
    public string Estado { get; set; } = null!;
}

internal sealed class UpdateMantenimientoCommandHandler : IRequestHandler<UpdateMantenimientoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateMantenimientoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateMantenimientoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Mantenimiento>();

        var mantenimiento = await repo.GetByIdAsync(request.Id);

        mantenimiento!.TipoMantenimientoId = request.TipoMantenimientoId;
        mantenimiento.FechaProgramada = request.FechaProgramada;
        mantenimiento.Kilometraje = request.Kilometraje;
        mantenimiento.CostoSoles = request.CostoSoles;
        mantenimiento.Taller = request.Taller;
        mantenimiento.Observaciones = request.Observaciones;
        mantenimiento.Estado = request.Estado;
        mantenimiento.FechaRealizado = request.Estado == "Realizado"
            ? DateOnly.FromDateTime(DateTime.Now)
            : null;

        repo.Update(mantenimiento);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
