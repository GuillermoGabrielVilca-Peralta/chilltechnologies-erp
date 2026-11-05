using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Geocercas.Commands;

public record CreateGeocercaCommand : IRequest<int>
{
    // Null = geocerca global del sistema
    public int? EmpresaId { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    public decimal Latitud { get; set; }
    public decimal Longitud { get; set; }
    public int RadioMetros { get; set; }
    // Permitida, Restringida o Interes
    public string Tipo { get; set; } = "Permitida";
}

internal sealed class CreateGeocercaCommandHandler : IRequestHandler<CreateGeocercaCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateGeocercaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateGeocercaCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Geocerca
        {
            EmpresaId = request.EmpresaId,
            Nombre = request.Nombre,
            Descripcion = request.Descripcion,
            Latitud = request.Latitud,
            Longitud = request.Longitud,
            RadioMetros = request.RadioMetros,
            Tipo = request.Tipo,
            Estado = "Activa",
            FechaRegistro = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.Geocerca>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
