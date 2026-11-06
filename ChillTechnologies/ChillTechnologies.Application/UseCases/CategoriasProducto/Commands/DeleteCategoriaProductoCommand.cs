using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.CategoriasProducto.Commands;

public record DeleteCategoriaProductoCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteCategoriaProductoCommandHandler : IRequestHandler<DeleteCategoriaProductoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCategoriaProductoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteCategoriaProductoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.CategoriasProducto>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
