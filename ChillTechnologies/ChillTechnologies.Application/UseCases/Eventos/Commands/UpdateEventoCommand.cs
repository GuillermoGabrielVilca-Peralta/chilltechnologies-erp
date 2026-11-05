using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Eventos.Commands;

public record UpdateEventoCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public int? ViajeId { get; set; }
    public int TipoEventoId { get; set; }
    public int ImpactoPuntaje { get; set; }
    public decimal? Latitud { get; set; }
    public decimal? Longitud { get; set; }
    public string? FotoEvidencia { get; set; }
}

internal sealed class UpdateEventoCommandHandler : IRequestHandler<UpdateEventoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateEventoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateEventoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Evento>();

        var evento = await repo.GetByIdAsync(request.Id);

        evento!.ViajeId = request.ViajeId;
        evento.TipoEventoId = request.TipoEventoId;
        evento.ImpactoPuntaje = request.ImpactoPuntaje;
        evento.Latitud = request.Latitud;
        evento.Longitud = request.Longitud;
        evento.FotoEvidencia = request.FotoEvidencia;

        repo.Update(evento);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
