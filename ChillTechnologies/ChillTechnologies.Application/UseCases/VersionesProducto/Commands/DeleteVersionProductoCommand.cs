using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.VersionesProducto.Commands;

public record DeleteVersionProductoCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteVersionProductoCommandHandler : IRequestHandler<DeleteVersionProductoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVersionProductoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteVersionProductoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.VersionesProducto>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
