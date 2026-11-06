using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.CuentasPorCobrar.Commands;

public record DeleteCuentaPorCobrarCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteCuentaPorCobrarCommandHandler : IRequestHandler<DeleteCuentaPorCobrarCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCuentaPorCobrarCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteCuentaPorCobrarCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.CuentasPorCobrar>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
