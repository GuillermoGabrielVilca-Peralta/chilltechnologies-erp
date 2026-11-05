using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Premios.Commands;

public record UpdatePremioCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    public int PuntosRequeridos { get; set; }
    public int Stock { get; set; }
    public DateOnly? FechaInicio { get; set; }
    public DateOnly? FechaFin { get; set; }
    public string? Imagen { get; set; }
    // Disponible, Agotado, Vencido o Pausado
    public string Estado { get; set; } = null!;
}

internal sealed class UpdatePremioCommandHandler : IRequestHandler<UpdatePremioCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePremioCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdatePremioCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Premio>();

        var premio = await repo.GetByIdAsync(request.Id);

        premio!.Nombre = request.Nombre;
        premio.Descripcion = request.Descripcion;
        premio.PuntosRequeridos = request.PuntosRequeridos;
        premio.Stock = request.Stock;
        premio.FechaInicio = request.FechaInicio;
        premio.FechaFin = request.FechaFin;
        premio.Imagen = request.Imagen;
        premio.Estado = request.Estado;

        repo.Update(premio);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
