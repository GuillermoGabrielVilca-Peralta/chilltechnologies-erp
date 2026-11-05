using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.AsignacionesVehiculo.Commands;

public record DeleteAsignacionVehiculoCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteAsignacionVehiculoCommandHandler : IRequestHandler<DeleteAsignacionVehiculoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAsignacionVehiculoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteAsignacionVehiculoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.AsignacionesVehiculo>();

        var asignacion = await repo.GetByIdAsync(request.Id);

        repo.Delete(asignacion!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
