using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.AsignacionesVehiculo.Commands;

public record UpdateAsignacionVehiculoCommand : IRequest<Unit>
{
    public int Id { get; set; }
    // Activa o Finalizada
    public string Estado { get; set; } = null!;
}

internal sealed class UpdateAsignacionVehiculoCommandHandler : IRequestHandler<UpdateAsignacionVehiculoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAsignacionVehiculoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateAsignacionVehiculoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.AsignacionesVehiculo>();

        var asignacion = await repo.GetByIdAsync(request.Id);

        asignacion!.Estado = request.Estado;
        asignacion.FechaFin = request.Estado == "Finalizada" ? DateTime.Now : null;

        repo.Update(asignacion);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
