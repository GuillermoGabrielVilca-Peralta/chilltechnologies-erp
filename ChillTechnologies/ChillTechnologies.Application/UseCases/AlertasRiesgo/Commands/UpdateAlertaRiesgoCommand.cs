using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.AlertasRiesgo.Commands;

public record UpdateAlertaRiesgoCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Motivo { get; set; } = null!;
    // Baja, Media, Alta o Critica
    public string Severidad { get; set; } = null!;
    // Pendiente, Revisada o Descartada
    public string Estado { get; set; } = null!;
}

internal sealed class UpdateAlertaRiesgoCommandHandler : IRequestHandler<UpdateAlertaRiesgoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAlertaRiesgoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateAlertaRiesgoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.AlertasRiesgo>();

        var alerta = await repo.GetByIdAsync(request.Id);

        alerta!.Motivo = request.Motivo;
        alerta.Severidad = request.Severidad;
        alerta.Estado = request.Estado;

        repo.Update(alerta);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
