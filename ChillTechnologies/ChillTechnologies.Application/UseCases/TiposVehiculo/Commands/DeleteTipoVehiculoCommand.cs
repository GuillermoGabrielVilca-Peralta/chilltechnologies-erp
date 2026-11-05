using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposVehiculo.Commands;

public record DeleteTipoVehiculoCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteTipoVehiculoCommandHandler : IRequestHandler<DeleteTipoVehiculoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTipoVehiculoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteTipoVehiculoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.TiposVehiculo>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
