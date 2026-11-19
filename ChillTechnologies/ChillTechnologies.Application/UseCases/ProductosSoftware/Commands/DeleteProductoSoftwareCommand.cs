using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.ProductosSoftware.Commands;

public record DeleteProductoSoftwareCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteProductoSoftwareCommandHandler : IRequestHandler<DeleteProductoSoftwareCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductoSoftwareCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteProductoSoftwareCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.ProductosSoftware>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
