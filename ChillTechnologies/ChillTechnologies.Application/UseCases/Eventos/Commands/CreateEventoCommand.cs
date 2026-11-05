using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Eventos.Commands;

public record CreateEventoCommand : IRequest<int>
{
    // Null si la deteccion ocurre fuera de un viaje activo
    public int? ViajeId { get; set; }
    public int CamaraId { get; set; }
    public int TipoEventoId { get; set; }
    public int ImpactoPuntaje { get; set; }
    public decimal? Latitud { get; set; }
    public decimal? Longitud { get; set; }
    public string? FotoEvidencia { get; set; }
    // Identificador propio del cliente, para evitar eventos duplicados
    public string? ClienteEventoId { get; set; }
}

internal sealed class CreateEventoCommandHandler : IRequestHandler<CreateEventoCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateEventoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateEventoCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Evento
        {
            ViajeId = request.ViajeId,
            CamaraId = request.CamaraId,
            TipoEventoId = request.TipoEventoId,
            ImpactoPuntaje = request.ImpactoPuntaje,
            Latitud = request.Latitud,
            Longitud = request.Longitud,
            FotoEvidencia = request.FotoEvidencia,
            ClienteEventoId = request.ClienteEventoId,
            FechaEvento = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.Evento>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
