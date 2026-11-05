using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.AlertasRiesgo.Commands;

public record CreateAlertaRiesgoCommand : IRequest<int>
{
    public int UsuarioId { get; set; }
    public int? VehiculoId { get; set; }
    public int? ViajeId { get; set; }
    public string Motivo { get; set; } = null!;
    // Baja, Media, Alta o Critica
    public string Severidad { get; set; } = "Media";
}

internal sealed class CreateAlertaRiesgoCommandHandler : IRequestHandler<CreateAlertaRiesgoCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAlertaRiesgoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateAlertaRiesgoCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.AlertasRiesgo
        {
            UsuarioId = request.UsuarioId,
            VehiculoId = request.VehiculoId,
            ViajeId = request.ViajeId,
            Motivo = request.Motivo,
            Severidad = request.Severidad,
            Estado = "Pendiente",
            FechaAlerta = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.AlertasRiesgo>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
