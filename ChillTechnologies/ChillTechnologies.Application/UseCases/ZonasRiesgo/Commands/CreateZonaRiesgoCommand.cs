using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.ZonasRiesgo.Commands;

public record CreateZonaRiesgoCommand : IRequest<int>
{
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    public decimal Latitud { get; set; }
    public decimal Longitud { get; set; }
    public int RadioMetros { get; set; }
    // Curva peligrosa, alta siniestralidad,via deteriorada,zona escolar u otro
    public string Tipo { get; set; } = "Otro";
    // Bajo, medio, alto o critico
    public string NivelRiesgo { get; set; } = "Medio";
}

internal sealed class CreateZonaRiesgoCommandHandler : IRequestHandler<CreateZonaRiesgoCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateZonaRiesgoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateZonaRiesgoCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.ZonasRiesgo
        {
            Nombre = request.Nombre,
            Descripcion = request.Descripcion,
            Latitud = request.Latitud,
            Longitud = request.Longitud,
            RadioMetros = request.RadioMetros,
            Tipo = request.Tipo,
            NivelRiesgo = request.NivelRiesgo,
            IncidentesRegistrados = 0,
            FechaRegistro = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.ZonasRiesgo>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
