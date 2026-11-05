using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.ZonasRiesgo.Commands;

public record UpdateZonaRiesgoCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    public decimal Latitud { get; set; }
    public decimal Longitud { get; set; }
    public int RadioMetros { get; set; }
    public string Tipo { get; set; } = null!;
    public string NivelRiesgo { get; set; } = null!;
    public int IncidentesRegistrados { get; set; }
}

internal sealed class UpdateZonaRiesgoCommandHandler : IRequestHandler<UpdateZonaRiesgoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateZonaRiesgoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateZonaRiesgoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.ZonasRiesgo>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Nombre = request.Nombre;
        item.Descripcion = request.Descripcion;
        item.Latitud = request.Latitud;
        item.Longitud = request.Longitud;
        item.RadioMetros = request.RadioMetros;
        item.Tipo = request.Tipo;
        item.NivelRiesgo = request.NivelRiesgo;
        item.IncidentesRegistrados = request.IncidentesRegistrados;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
