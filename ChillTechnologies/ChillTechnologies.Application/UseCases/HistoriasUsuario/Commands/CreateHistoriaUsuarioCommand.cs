using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.HistoriasUsuario.Commands;

public record CreateHistoriaUsuarioCommand : IRequest<int>
{
    public int ProyectoId { get; set; }
    public int? SprintId { get; set; }
    public string Codigo { get; set; } = null!;
    public string Titulo { get; set; } = null!;
    public string? Descripcion { get; set; }
    public string? CriteriosAceptacion { get; set; }
    public int PuntosHistoria { get; set; }
    // Baja, Media, Alta o Critica
    public string Prioridad { get; set; } = "Media";
}

internal sealed class CreateHistoriaUsuarioCommandHandler : IRequestHandler<CreateHistoriaUsuarioCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateHistoriaUsuarioCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateHistoriaUsuarioCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.HistoriasUsuario
        {
            ProyectoId = request.ProyectoId,
            SprintId = request.SprintId,
            Codigo = request.Codigo,
            Titulo = request.Titulo,
            Descripcion = request.Descripcion,
            CriteriosAceptacion = request.CriteriosAceptacion,
            PuntosHistoria = request.PuntosHistoria,
            Prioridad = request.Prioridad,
            Estado = request.SprintId == null ? "Backlog" : "Por hacer",
            FechaRegistro = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.HistoriasUsuario>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
