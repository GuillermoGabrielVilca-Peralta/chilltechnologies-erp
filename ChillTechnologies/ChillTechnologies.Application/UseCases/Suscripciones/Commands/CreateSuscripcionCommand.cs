using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Suscripciones.Commands;

public record CreateSuscripcionCommand : IRequest<int>
{
    // El titular es un usuario (B2C) o una empresa (B2B), nunca ambos
    public int? UsuarioId { get; set; }
    public int? EmpresaId { get; set; }
    public DateOnly FechaInicio { get; set; }
    public DateOnly FechaFin { get; set; }
    public decimal MontoSoles { get; set; }
    public int MetodoPagoId { get; set; }
    public string? ReferenciaPago { get; set; }
    public bool RenovacionAutomatica { get; set; }
    public int CantidadLicencias { get; set; } = 1;
}

internal sealed class CreateSuscripcionCommandHandler : IRequestHandler<CreateSuscripcionCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateSuscripcionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateSuscripcionCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Suscripcione
        {
            UsuarioId = request.UsuarioId,
            EmpresaId = request.EmpresaId,
            FechaInicio = request.FechaInicio,
            FechaFin = request.FechaFin,
            MontoSoles = request.MontoSoles,
            MetodoPagoId = request.MetodoPagoId,
            ReferenciaPago = request.ReferenciaPago,
            RenovacionAutomatica = request.RenovacionAutomatica,
            CantidadLicencias = request.CantidadLicencias,
            Estado = "Activa",
            FechaRegistro = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.Suscripcione>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
