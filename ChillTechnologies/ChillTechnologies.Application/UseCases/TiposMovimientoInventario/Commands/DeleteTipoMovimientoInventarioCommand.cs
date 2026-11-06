using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposMovimientoInventario.Commands;

public record DeleteTipoMovimientoInventarioCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteTipoMovimientoInventarioCommandHandler : IRequestHandler<DeleteTipoMovimientoInventarioCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTipoMovimientoInventarioCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteTipoMovimientoInventarioCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.TiposMovimientoInventario>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
