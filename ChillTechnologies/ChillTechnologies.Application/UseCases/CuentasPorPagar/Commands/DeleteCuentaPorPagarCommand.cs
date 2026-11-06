using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.CuentasPorPagar.Commands;

public record DeleteCuentaPorPagarCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteCuentaPorPagarCommandHandler : IRequestHandler<DeleteCuentaPorPagarCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCuentaPorPagarCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteCuentaPorPagarCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.CuentasPorPagar>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
