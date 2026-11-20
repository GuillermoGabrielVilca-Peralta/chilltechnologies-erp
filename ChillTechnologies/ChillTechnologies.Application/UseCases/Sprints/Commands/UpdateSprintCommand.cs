using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Sprints.Commands;

public record UpdateSprintCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string? Objetivo { get; set; }
    public DateOnly FechaInicio { get; set; }
    public DateOnly FechaFin { get; set; }
    public string Estado { get; set; } = null!;
}

internal sealed class UpdateSprintCommandHandler : IRequestHandler<UpdateSprintCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSprintCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateSprintCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Sprint>();

        var sprint = await repo.GetByIdAsync(request.Id);

        sprint!.Objetivo = request.Objetivo;
        sprint.FechaInicio = request.FechaInicio;
        sprint.FechaFin = request.FechaFin;
        sprint.Estado = request.Estado;

        var historias = (await _unitOfWork.Repository<Domain.Entities.HistoriasUsuario>()
            .FindAsync(h => h.SprintId == request.Id)).ToList();

        sprint.PuntosComprometidos = historias.Sum(h => h.PuntosHistoria);
        sprint.PuntosCompletados = historias
            .Where(h => h.Estado == "Hecho")
            .Sum(h => h.PuntosHistoria);

        repo.Update(sprint);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
