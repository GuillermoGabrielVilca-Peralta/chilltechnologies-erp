using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.SolicitudesAusencia.Commands;

public record UpdateSolicitudAusenciaCommand : IRequest<Unit>
{
    public int Id { get; set; }
    // pendiente, aprobada, rechazada cancelada
    public string Estado { get; set; } = null!;
    // empleado que resuelve la solicitud
    public int? AprobadoPor { get; set; }
}

internal sealed class UpdateSolicitudAusenciaCommandHandler : IRequestHandler<UpdateSolicitudAusenciaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSolicitudAusenciaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateSolicitudAusenciaCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.SolicitudesAusencium>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Estado = request.Estado;
        item.AprobadoPor = request.AprobadoPor;
        // La fecha de respuesta se completa al salir de Pendiente
        item.FechaRespuesta = request.Estado != "Pendiente" ? DateTime.Now : null;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
