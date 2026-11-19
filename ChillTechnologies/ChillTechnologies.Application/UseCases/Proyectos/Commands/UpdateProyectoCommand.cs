using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Proyectos.Commands;

public record UpdateProyectoCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    public int? JefeProyectoId { get; set; }
    public DateOnly? FechaFinEstimada { get; set; }
    public decimal Presupuesto { get; set; }
    public decimal HorasEstimadas { get; set; }
    public string Estado { get; set; } = null!;
}

internal sealed class UpdateProyectoCommandHandler : IRequestHandler<UpdateProyectoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProyectoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateProyectoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Proyecto>();

        var proyecto = await repo.GetByIdAsync(request.Id);
        
        proyecto!.Nombre = request.Nombre;
        proyecto.Descripcion = request.Descripcion;
        proyecto.JefeProyectoId = request.JefeProyectoId;
        proyecto.FechaFinEstimada = request.FechaFinEstimada;
        proyecto.Presupuesto = request.Presupuesto;
        proyecto.HorasEstimadas = request.HorasEstimadas;
        proyecto.Estado = request.Estado;
        
        var hitos = (await _unitOfWork.Repository<Domain.Entities.HitosProyecto>()
            .FindAsync(h => h.ProyectoId == request.Id)).ToList();

        proyecto.AvancePorcentaje = hitos.Count == 0
            ? proyecto.AvancePorcentaje
            : Math.Round(hitos.Count(h => h.Estado == "Aprobado") * 100m / hitos.Count, 2);
        
        proyecto.FechaFinReal = request.Estado is "Finalizado" or "Cancelado"
            ? proyecto.FechaFinReal ?? DateOnly.FromDateTime(DateTime.Now)
            : null;

        repo.Update(proyecto);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
