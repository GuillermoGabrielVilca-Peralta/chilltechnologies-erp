using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.OrdenesCompra.Commands;

public record DeleteOrdenCompraCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteOrdenCompraCommandHandler : IRequestHandler<DeleteOrdenCompraCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteOrdenCompraCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteOrdenCompraCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.OrdenesCompra>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
