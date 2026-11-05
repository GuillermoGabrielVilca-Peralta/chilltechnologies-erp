using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Suscripciones.Commands;

public record UpdateSuscripcionCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public DateOnly FechaInicio { get; set; }
    public DateOnly FechaFin { get; set; }
    public decimal MontoSoles { get; set; }
    public int MetodoPagoId { get; set; }
    public string? ReferenciaPago { get; set; }
    public bool RenovacionAutomatica { get; set; }
    public int CantidadLicencias { get; set; }
    // Activa, Vencida o Cancelada
    public string Estado { get; set; } = null!;
}

internal sealed class UpdateSuscripcionCommandHandler : IRequestHandler<UpdateSuscripcionCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSuscripcionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateSuscripcionCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Suscripcione>();

        var suscripcion = await repo.GetByIdAsync(request.Id);

        suscripcion!.FechaInicio = request.FechaInicio;
        suscripcion.FechaFin = request.FechaFin;
        suscripcion.MontoSoles = request.MontoSoles;
        suscripcion.MetodoPagoId = request.MetodoPagoId;
        suscripcion.ReferenciaPago = request.ReferenciaPago;
        suscripcion.RenovacionAutomatica = request.RenovacionAutomatica;
        suscripcion.CantidadLicencias = request.CantidadLicencias;
        suscripcion.Estado = request.Estado;

        repo.Update(suscripcion);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
