using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Vehiculos.Commands;

public record DeleteVehiculoCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteVehiculoCommandHandler : IRequestHandler<DeleteVehiculoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVehiculoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteVehiculoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Vehiculo>();

        var vehiculo = await repo.GetByIdAsync(request.Id);

        repo.Delete(vehiculo!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
