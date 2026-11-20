using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Sprints.Commands;

public record CreateSprintCommand : IRequest<int>
{
    public int ProyectoId { get; set; }
    public int Numero { get; set; }
    public string? Objetivo { get; set; }
    public DateOnly FechaInicio { get; set; }
    public DateOnly FechaFin { get; set; }
}

internal sealed class CreateSprintCommandHandler : IRequestHandler<CreateSprintCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateSprintCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateSprintCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Sprint
        {
            ProyectoId = request.ProyectoId,
            Numero = request.Numero,
            Objetivo = request.Objetivo,
            FechaInicio = request.FechaInicio,
            FechaFin = request.FechaFin,
            PuntosComprometidos = 0,
            PuntosCompletados = 0,
            Estado = "Planificado"
        };

        await _unitOfWork.Repository<Domain.Entities.Sprint>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
