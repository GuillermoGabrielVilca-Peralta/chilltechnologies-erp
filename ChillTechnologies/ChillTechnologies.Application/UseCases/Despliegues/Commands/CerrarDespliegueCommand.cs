using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Despliegues.Commands;

public record CerrarDespliegueCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Estado { get; set; } = null!;
    public string? Observaciones { get; set; }
}

internal sealed class CerrarDespliegueCommandHandler : IRequestHandler<CerrarDespliegueCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public CerrarDespliegueCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CerrarDespliegueCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Despliegue>();

        var despliegue = await repo.GetByIdAsync(request.Id);

        despliegue!.Estado = request.Estado;
        despliegue.Observaciones = request.Observaciones;

        repo.Update(despliegue);

        var ambiente = await _unitOfWork.Repository<Domain.Entities.Ambiente>()
            .GetByIdAsync(despliegue.AmbienteId);

        if (request.Estado == "Exitoso" && ambiente!.EsProductivo)
        {
            var versiones = _unitOfWork.Repository<Domain.Entities.VersionesProducto>();
            var version = await versiones.GetByIdAsync(despliegue.VersionId);

            version!.Estado = "Liberada";
            version.FechaLiberacion ??= DateOnly.FromDateTime(DateTime.Now);
            versiones.Update(version);
        }

        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
