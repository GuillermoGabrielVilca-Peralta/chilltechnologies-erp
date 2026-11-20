using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.HistoriasUsuario.Commands;

public record UpdateHistoriaUsuarioCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Titulo { get; set; } = null!;
    public string? Descripcion { get; set; }
    public string? CriteriosAceptacion { get; set; }
    public int PuntosHistoria { get; set; }
    public string Prioridad { get; set; } = null!;
    public string Estado { get; set; } = null!;
}

internal sealed class UpdateHistoriaUsuarioCommandHandler : IRequestHandler<UpdateHistoriaUsuarioCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateHistoriaUsuarioCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateHistoriaUsuarioCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.HistoriasUsuario>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Titulo = request.Titulo;
        item.Descripcion = request.Descripcion;
        item.CriteriosAceptacion = request.CriteriosAceptacion;
        item.PuntosHistoria = request.PuntosHistoria;
        item.Prioridad = request.Prioridad;
        item.Estado = request.Estado;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
