using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Viajes.Commands;

public record UpdateViajeCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public decimal? DistanciaKm { get; set; }
    public int? DuracionMinutos { get; set; }
    public decimal? PuntajeConduccion { get; set; }
    public int PuntosGanados { get; set; }
    // En Curso, Finalizado o Cancelado
    public string Estado { get; set; } = null!;
}

internal sealed class UpdateViajeCommandHandler : IRequestHandler<UpdateViajeCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateViajeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateViajeCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Viaje>();

        var viaje = await repo.GetByIdAsync(request.Id);

        viaje!.DistanciaKm = request.DistanciaKm;
        viaje.DuracionMinutos = request.DuracionMinutos;
        viaje.PuntajeConduccion = request.PuntajeConduccion;
        viaje.PuntosGanados = request.PuntosGanados;
        viaje.Estado = request.Estado;
        viaje.FechaFin = request.Estado == "Finalizado" ? DateTime.Now : null;

        repo.Update(viaje);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
