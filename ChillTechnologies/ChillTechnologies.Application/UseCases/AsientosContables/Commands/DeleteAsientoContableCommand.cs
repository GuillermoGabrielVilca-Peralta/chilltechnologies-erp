using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.AsientosContables.Commands;

public record DeleteAsientoContableCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteAsientoContableCommandHandler : IRequestHandler<DeleteAsientoContableCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAsientoContableCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteAsientoContableCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.AsientosContable>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
