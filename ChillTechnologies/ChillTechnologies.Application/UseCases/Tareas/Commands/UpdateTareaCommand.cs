using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Tareas.Commands;

public record UpdateTareaCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Titulo { get; set; } = null!;
    public string? Descripcion { get; set; }
    public int? EmpleadoId { get; set; }
    public decimal HorasEstimadas { get; set; }
    public string Estado { get; set; } = null!;
}

internal sealed class UpdateTareaCommandHandler : IRequestHandler<UpdateTareaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTareaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateTareaCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Tarea>();

        var tarea = await repo.GetByIdAsync(request.Id);

        tarea!.Titulo = request.Titulo;
        tarea.Descripcion = request.Descripcion;
        tarea.EmpleadoId = request.EmpleadoId;
        tarea.HorasEstimadas = request.HorasEstimadas;
        tarea.Estado = request.Estado;

        var horas = await _unitOfWork.Repository<Domain.Entities.RegistrosHora>()
            .FindAsync(h => h.TareaId == request.Id);

        tarea.HorasReales = horas.Sum(h => h.Horas);

        tarea.FechaCierre = request.Estado == "Hecha"
            ? tarea.FechaCierre ?? DateTime.Now
            : null;

        repo.Update(tarea);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
