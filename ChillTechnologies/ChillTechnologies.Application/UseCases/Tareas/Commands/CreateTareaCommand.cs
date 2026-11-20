using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Tareas.Commands;

public record CreateTareaCommand : IRequest<int>
{
    public int HistoriaId { get; set; }
    public string Titulo { get; set; } = null!;
    public string? Descripcion { get; set; }
    public int? EmpleadoId { get; set; }
    public decimal HorasEstimadas { get; set; }
}

internal sealed class CreateTareaCommandHandler : IRequestHandler<CreateTareaCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateTareaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateTareaCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Tarea
        {
            HistoriaId = request.HistoriaId,
            Titulo = request.Titulo,
            Descripcion = request.Descripcion,
            EmpleadoId = request.EmpleadoId,
            HorasEstimadas = request.HorasEstimadas,
            HorasReales = 0,
            Estado = "Por hacer",
            FechaRegistro = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.Tarea>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
