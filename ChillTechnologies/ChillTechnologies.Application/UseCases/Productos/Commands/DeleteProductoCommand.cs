using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Productos.Commands;

public record DeleteProductoCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteProductoCommandHandler : IRequestHandler<DeleteProductoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteProductoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Producto>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
