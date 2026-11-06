using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Inventarios.Commands;

public record DeleteInventarioCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteInventarioCommandHandler : IRequestHandler<DeleteInventarioCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInventarioCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteInventarioCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Inventario>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
